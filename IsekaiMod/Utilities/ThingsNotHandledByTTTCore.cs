﻿using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Root;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Utility;
using System;
using System.IO;
using TabletopTweaks.Core.ModLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;
using static UnityModManagerNet.UnityModManager;

namespace IsekaiMod.Utilities {
    //Classname is a partial lie, some are just not handled well *coughs*
    internal class ThingsNotHandledByTTTCore {
        public static void RegisterClass(BlueprintCharacterClass classToRegister) {
            var existingClasses = ClassTools.Classes.AllClasses;
            if (containsClass(existingClasses, classToRegister)) {
                IsekaiContext.Logger.LogWarning("class already registered= " + classToRegister.name + " gui id=" + classToRegister.AssetGuid.m_Guid.ToString("N"));
                return; 
            }
            BlueprintRoot.Instance.Progression.m_CharacterClasses = ClassTools.ClassReferences.AllClasses.AddToArray(classToRegister.ToReference<BlueprintCharacterClassReference>());


        }
        public static void RegisterSpell(BlueprintSpellList list, BlueprintAbility spell, int level) {
            // Core method check if spell already exists uses a simple contains check that fails if multiple instances of the spell were created (for example if it exists in multiple spellbooks)
            // the Core method does a few other nice things though, like correctly adding the spell to specialist lists so should be called after ones own security check
            if (listContainsSpell(list, spell)) {
                IsekaiContext.Logger.LogWarning("spell already registered= " + spell.name + " gui id=" + spell.AssetGuid.m_Guid.ToString("N"));
                return;
            }
            spell.AddToSpellList(list, level);

        }

        public static void RegisterForPrestigeSpellbook(BlueprintFeatureSelectMythicSpellbook mythicSpellbook, BlueprintSpellbook spellBook) {
            if (containsSpellbook(mythicSpellbook.AllowedSpellbooks,spellBook)) {
                IsekaiContext.Logger.LogWarning("spellbook already registered= " + spellBook.name + " gui id=" + spellBook.AssetGuid.m_Guid.ToString("N")+" for mythic= "+mythicSpellbook.Name);
                return;
            }
            mythicSpellbook.m_AllowedSpellbooks = mythicSpellbook.m_AllowedSpellbooks.AddToArray(spellBook.ToReference<BlueprintSpellbookReference>());
        }

        public static T[] AddToFirst<T>(T[] array, T itemToBeAdded) {
            // TODO: probably should check if item is already added here too but blueprints and blueprintreferences would require separate methods with different checks so leave it for a step 2
            var len = array.Length;
            var result = new T[len + 1];
            Array.Copy(array, 0, result, 1, len);
            result[0] = itemToBeAdded;
            return result;
        }


        private static Boolean listContainsSpell(BlueprintSpellList list, BlueprintAbility spell) {
            foreach (var level in list.SpellsByLevel) {
                foreach (var comparespell in level.Spells) {
                    if (spell.AssetGuid.m_Guid.ToString("N").Equals(comparespell.AssetGuid.m_Guid.ToString("N"))) {
                        return true;
                    }
                }
            }
            return false;
        }
        private static Boolean containsClass(BlueprintCharacterClass[] array, BlueprintCharacterClass classToCheck) {
            foreach (var arrayClass in array) {
                if (arrayClass.AssetGuid.m_Guid.ToString("N").Equals(classToCheck.AssetGuid.m_Guid.ToString("N"))) { return true; }
            }
            return false;
        }
        private static Boolean containsSpellbook(BlueprintSpellbookReference[] array, BlueprintSpellbook classToCheck) {
            foreach (var arrayClass in array) {
                if (arrayClass != null && arrayClass.Guid != null) {
                    if (arrayClass.Guid.Equals(classToCheck.AssetGuid.m_Guid.ToString("N"))) { return true; }
                } else {
                    IsekaiContext.Logger.LogWarning("prestige class spellbook array contained null value");
                }
            }
            return false;
        }
    }

    class AssetLoaderExtension : AssetLoader {
        public static Sprite LoadInternal(ModContextBase modContext, string folder, string file, Vector2Int size) {
            return Image2SpriteExtension.Create($"{modContext.ModEntry.Path}Assets{Path.DirectorySeparatorChar}{folder}{Path.DirectorySeparatorChar}{file}", size);
        }
        public static class Image2SpriteExtension {
            public static string icons_folder = "";
            public static Sprite Create(string filePath, Vector2Int size) {
                var bytes = File.ReadAllBytes(icons_folder + filePath);
                var texture = new Texture2D(size.x, size.y, TextureFormat.RGBA32, false) { mipMapBias = 15.0f };
                _ = texture.LoadImage(bytes);
                return Sprite.Create(texture, new Rect(0, 0, size.x, size.y), new Vector2(0, 0));
            }
        }
    }


}
