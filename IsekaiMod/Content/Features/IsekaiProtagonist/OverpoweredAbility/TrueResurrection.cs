using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class TrueResurrection
    {
        private static readonly Sprite Icon_Resurrection = Resources.GetBlueprint<BlueprintAbility>("80a1a388ee938aa4e90d427ce9a7a3e9").m_Icon;
        public static void Add()
        {
            var TrueResurrectionAbility = Helpers.CreateBlueprint<BlueprintAbility>("TrueResurrectionAbility", bp => {
                bp.SetName("Overpowered Ability — True Resurrection");
                bp.SetDescription("Restore life and complete {g|Encyclopedia:Strength}strength{/g} to any deceased creature. Upon completion of this ability, the creature is "
                    + "immediately restored to full {g|Encyclopedia:HP}hit points{/g}, vigor, and {g|Encyclopedia:Healing}health{/g}, with no loss of prepared spells.\n"
                    + "This ability does not require diamonds.");
                bp.m_Icon = Icon_Resurrection;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionResurrect>(c => {
                        c.FullRestore = true;
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Conjuration;
                });
                bp.AddComponent<AbilityTargetIsDeadCompanion>();
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "ee0c5b9397ffec54d86acf56c94f4b06" };
                    c.Time = AbilitySpawnFxTime.OnPrecastFinished;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                });
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Unlimited;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.m_IsFullRoundAction = true;
                bp.AvailableMetamagic = Metamagic.Quicken | Metamagic.Heighten | Metamagic.CompletelyNormal;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var TrueResurrectionFeature = Helpers.CreateFeature("TrueResurrectionFeature", bp => {
                bp.SetName("Overpowered Ability — True Resurrection");
                bp.SetDescription("As a full action, you can restore life and complete {g|Encyclopedia:Strength}strength{/g} to any deceased creature. Upon completion of this ability, "
                    + "the creature is immediately restored to full {g|Encyclopedia:HP}hit points{/g}, vigor, and {g|Encyclopedia:Healing}health{/g}, with no loss of prepared spells.\n"
                    + "This ability does not require diamonds.");
                bp.m_Icon = Icon_Resurrection;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { TrueResurrectionAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(TrueResurrectionFeature);
        }
    }
}
