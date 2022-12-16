﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor
{
    class NascentApotheosis
    {
        public static void Add()
        {
            var Icon_Serenity = Resources.GetBlueprint<BlueprintAbility>("d316d3d94d20c674db2c24d7de96f6a7").m_Icon;
            var NascentApotheosis = Helpers.CreateFeature("NascentApotheosis", bp => {
                bp.SetName("Nascent Apotheosis");
                bp.SetDescription("The God Emperor gains an inherent bonus to all attributes and spell penetration equal to 1/2 their character level and "
                    + "{g|Encyclopedia:Damage_Reduction}DR{/g}/— equal to their character level.");
                bp.m_Icon = Icon_Serenity;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Strength;
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Dexterity;
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Constitution;
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Intelligence;
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Wisdom;
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Charisma;
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<SpellPenetrationBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.ReapplyOnLevelUp = true;
            });
        }
    }
}
