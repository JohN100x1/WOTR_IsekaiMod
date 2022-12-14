using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class AlphaStrike
    {
        private static readonly Sprite Icon_SneakStab = Resources.GetBlueprint<BlueprintFeature>("df4f34f7cac73ab40986bc33f87b1a3c").m_Icon;
        public static void Add()
        {
            var AlphaStrike = Helpers.CreateFeature("AlphaStrike", bp => {
                bp.SetName("Alpha Strike");
                bp.SetDescription("You have become an alpha. Your critical threats are automatically confirmed.");
                bp.m_Icon = Icon_SneakStab;
                bp.AddComponent<InitiatorCritAutoconfirm>();
            });
            SpecialPowerSelection.AddToSelection(AlphaStrike);
        }
    }
}
