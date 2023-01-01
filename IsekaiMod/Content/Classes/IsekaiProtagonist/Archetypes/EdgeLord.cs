﻿using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes
{
    class EdgeLord
    {
        public static void Add()
        {
            // Archetype features
            var EdgeLordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "EdgeLordProficiencies");
            var SupersonicCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SupersonicCombat");
            var EdgeLordFastMovement = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "EdgeLordFastMovement");
            var ExtraStrike = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ExtraStrike");
            var CripplingStrike = BlueprintTools.GetBlueprint<BlueprintFeature>("b696bd7cb38da194fa3404032483d1db");
            var DispellingAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("1b92146b8a9830d4bb97ab694335fa7c");

            // Removed features
            var IsekaiProtagonistProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies");
            var IsekaiFastMovement = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFastMovement");
            var FriendlyAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "FriendlyAuraFeature");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");
            var OverpoweredAbilitySelection2 = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection2");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");

            // Archetype
            var EdgeLordArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "EdgeLordArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString(IsekaiContext, $"EdgeLordArchetype.Name", "Edge Lord");
                bp.LocalizedDescription = Helpers.CreateString(IsekaiContext, $"EdgeLordArchetype.Description", "After reincarnating into Golarion, some protagonists use their newfound abilities "
                    + "to look cool and stylish. Their attacks become flashy and myriad, moving so fast that side characters would be lucky to even see the afterimage.");
                bp.LocalizedDescriptionShort = Helpers.CreateString(IsekaiContext, $"EdgeLordArchetype.DescriptionShort", "After reincarnating into Golarion, some protagonists use their newfound abilities "
                    + "to look cool and stylish. Their attacks become flashy and myriad, moving so fast that side characters would be lucky to even see the afterimage.");
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiProtagonistProficiencies),
                    Helpers.CreateLevelEntry(5, OverpoweredAbilitySelection2),
                    Helpers.CreateLevelEntry(8, IsekaiFastMovement),
                    Helpers.CreateLevelEntry(9, FriendlyAuraFeature),
                    Helpers.CreateLevelEntry(10, OverpoweredAbilitySelection2),
                    Helpers.CreateLevelEntry(15, OverpoweredAbilitySelection2),
                    Helpers.CreateLevelEntry(20, SecondReincarnation),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, EdgeLordProficiencies, SupersonicCombat),
                    Helpers.CreateLevelEntry(5, SpecialPowerSelection, ExtraStrike),
                    Helpers.CreateLevelEntry(7, EdgeLordFastMovement),
                    Helpers.CreateLevelEntry(8, CripplingStrike),
                    Helpers.CreateLevelEntry(10, ExtraStrike, DispellingAttack),
                    Helpers.CreateLevelEntry(15, SpecialPowerSelection, ExtraStrike),
                    Helpers.CreateLevelEntry(20, ExtraStrike),
                };
                bp.OverrideAttributeRecommendations = true;
                bp.RecommendedAttributes = new StatType[] { StatType.Dexterity, StatType.Charisma };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(EdgeLordArchetype);
        }
        public static BlueprintArchetype Get()
        {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "EdgeLordArchetype");
        }
        public static BlueprintArchetypeReference GetReference()
        {
            return Get().ToReference<BlueprintArchetypeReference>();
        }
    }
}
