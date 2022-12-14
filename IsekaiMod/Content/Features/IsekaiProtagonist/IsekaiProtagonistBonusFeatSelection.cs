using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class IsekaiProtagonistBonusFeatSelection
    {
        private static readonly BlueprintFeatureSelection BasicFeatSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");
        public static void Add()
        {
            var IsekaiProtagonistBonusFeatSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistBonusFeatSelection", bp => {
                bp.SetName("Bonus Feat");
                bp.SetDescription("At 1st level, and at every even level thereafter, you gain a bonus {g|Encyclopedia:Feat}feat{/g} in addition to those gained from normal advancement.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.Group = FeatureGroup.Feat;
                bp.Group2 = FeatureGroup.TricksterFeat;
                bp.m_AllFeatures = BasicFeatSelection.m_AllFeatures;
            });
            PatchExceptionalFeatSelection(IsekaiProtagonistBonusFeatSelection);
        }
        private static void PatchExceptionalFeatSelection(BlueprintFeatureSelection blueprintFeatureSelection)
        {
            var ExceptionalFeatSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("ExceptionalFeatSelection");
            var ExceptionalFeatBonusSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("ExceptionalFeatBonusSelection");
            if (ExceptionalFeatSelection != null && ExceptionalFeatBonusSelection != null)
            {
                blueprintFeatureSelection.m_AllFeatures = blueprintFeatureSelection.m_AllFeatures
                    .RemoveFromArray(ExceptionalFeatSelection.ToReference<BlueprintFeatureReference>())
                    .AddToFirst(ExceptionalFeatBonusSelection.ToReference<BlueprintFeatureReference>());
            }
        }
    }
}
