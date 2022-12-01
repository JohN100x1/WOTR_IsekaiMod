﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Items;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class InterdimensionalBag
    {
        private static readonly Sprite Icon_LargeBagOfHolding = Resources.GetBlueprint<BlueprintItem>("6deaab0e39c6f16468c38ff8a32f57a1").m_Icon;
        public static void Add()
        {
            var InterdimensionalBagFeature = Helpers.CreateFeature("InterdimensionalBagFeature", bp => {
                bp.SetName("Overpowered Ability — Interdimensional Bag");
                bp.SetDescription("You have an infinite carry capacity.");
                bp.m_Icon = Icon_LargeBagOfHolding;
                bp.AddComponent<AddPartyEncumbrance>(c => {
                    c.Value = 1000000;
                });
            });

            OverpoweredAbilitySelection.AddToSelection(InterdimensionalBagFeature);
        }
    }
}
