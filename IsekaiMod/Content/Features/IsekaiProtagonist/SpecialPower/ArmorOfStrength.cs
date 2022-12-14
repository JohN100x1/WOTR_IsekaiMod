using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class ArmorOfStrength
    {
        private static readonly Sprite Icon_ArmoredHulkIndomitableStance = Resources.GetBlueprint<BlueprintFeature>("74c59090138e28f4687c8a3400030763").m_Icon;
        public static void Add()
        {
            var ArmorOfStrength = Helpers.CreateFeature("ArmorOfStrength", bp => {
                bp.SetName("Armor of Strength");
                bp.SetDescription("You gain a natural armor bonus to AC equal to your strength modifier.");
                bp.m_Icon = Icon_ArmoredHulkIndomitableStance;
                bp.AddComponent<DerivativeStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.NaturalArmor;
                    c.BaseStat = StatType.Strength;
                    c.DerivativeStat = StatType.AC;
                });
                bp.AddComponent<RecalculateOnStatChange>(c => {
                    c.Stat = StatType.Strength;
                });
            });

            SpecialPowerSelection.AddToSelection(ArmorOfStrength);
        }
    }
}
