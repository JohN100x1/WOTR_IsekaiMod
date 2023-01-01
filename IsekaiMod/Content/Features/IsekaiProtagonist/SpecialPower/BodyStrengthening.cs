﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;
using Kingmaker.Blueprints.Classes;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class BodyStrengthening
    {
        private static readonly Sprite Icon_IronBody = BlueprintTools.GetBlueprint<BlueprintAbility>("198fcc43490993f49899ed086fe723c1").m_Icon;
        public static void Add()
        {
            var BodyStrengthening = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext,"BodyStrengthening", bp => {
                bp.SetName(IsekaiContext, "Body Strengthening");
                bp.SetDescription(IsekaiContext, "You gain {g|Encyclopedia:Damage_Reduction}DR{/g}/— equal to your character level.");
                bp.m_Icon = Icon_IronBody;
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.ReapplyOnLevelUp = true;
            });

            SpecialPowerSelection.AddToSelection(BodyStrengthening);
        }
    }
}
