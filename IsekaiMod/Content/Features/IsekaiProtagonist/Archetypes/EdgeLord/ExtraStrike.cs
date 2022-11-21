﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord
{
    class ExtraStrike
    {
        private static readonly Sprite Icon_Extra_Strike = Resources.GetBlueprint<BlueprintAbility>("3e1a13fdca87e9c49b2fac4556e5a948").m_Icon;
        public static void Add()
        {
            var ExtraStrike = Helpers.CreateBlueprint<BlueprintFeature>("ExtraStrike", bp => {
                bp.SetName("Extra Strike");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 5th level and every 5 levels thereafter (10th, 15th, and 20th level), you gain 1 additional {g|Encyclopedia:Attack}attack{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 1;
                    c.Haste = false;
                });
                bp.Ranks = 4;
                bp.IsClassFeature = true;
            });
        }
    }
}