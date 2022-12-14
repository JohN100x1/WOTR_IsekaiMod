using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    class IsekaiProtagonistProgression
    {
        public static void Add()
        {
            // Isekai Protagonist Features
            var IsekaiProtagonistProficiencies = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies");
            var EdgeLordProficiencies = Resources.GetModBlueprint<BlueprintFeature>("EdgeLordProficiencies");
            var GodEmperorProficiencies = Resources.GetModBlueprint<BlueprintFeature>("GodEmperorProficiencies");
            var VillainProficiencies = Resources.GetModBlueprint<BlueprintFeature>("VillainProficiencies");
            var HeroProficiencies = Resources.GetModBlueprint<BlueprintFeature>("HeroProficiencies");

            var IsekaiProtagonistCantripsFeature = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistCantripsFeature");
            var IsekaiProtagonistBonusFeatSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistBonusFeatSelection");
            var SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            var PlotArmor = Resources.GetModBlueprint<BlueprintFeature>("PlotArmor");
            var StartingWeaponSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("StartingWeaponSelection");
            var SummonHaremFeature = Resources.GetModBlueprint<BlueprintFeature>("SummonHaremFeature");
            var UncannyDodge = Resources.GetBlueprint<BlueprintFeature>("3c08d842e802c3e4eb19d15496145709");
            var ImprovedUncannyDodge = Resources.GetBlueprint<BlueprintFeature>("485a18c05792521459c7d06c63128c79");
            var Evasion = Resources.GetBlueprint<BlueprintFeature>("576933720c440aa4d8d42b0c54b77e80");
            var ImprovedEvasion = Resources.GetBlueprint<BlueprintFeature>("ce96af454a6137d47b9c6a1e02e66803");
            var OtherworldlyStamina = Resources.GetModBlueprint<BlueprintFeature>("OtherworldlyStamina");
            var SignatureMoveSelection = Resources.GetModBlueprint<BlueprintFeature>("SignatureMoveSelection");
            var IsekaiFighterTraining = Resources.GetModBlueprint<BlueprintFeature>("IsekaiFighterTraining");
            var IsekaiFastMovement = Resources.GetModBlueprint<BlueprintFeature>("IsekaiFastMovement");
            var IsekaiQuickFooted = Resources.GetModBlueprint<BlueprintFeature>("IsekaiQuickFooted");
            var VillainQuickFooted = Resources.GetModBlueprint<BlueprintFeature>("VillainQuickFooted");
            var FriendlyAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("FriendlyAuraFeature");
            var DarkAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("DarkAuraFeature");
            var SecondReincarnation = Resources.GetModBlueprint<BlueprintFeature>("SecondReincarnation");
            var CelestialRealmFeature = Resources.GetModBlueprint<BlueprintFeature>("CelestialRealmFeature");
            var Godhood = Resources.GetModBlueprint<BlueprintFeature>("Godhood");
            var GodlyVessel = Resources.GetModBlueprint<BlueprintFeature>("GodlyVessel");
            var NascentApotheosis = Resources.GetModBlueprint<BlueprintFeature>("NascentApotheosis");
            var DivineArray = Resources.GetModBlueprint<BlueprintFeature>("DivineArray");
            var GodEmperorEnergySelection = Resources.GetModBlueprint<BlueprintFeature>("GodEmperorEnergySelection");
            var AuraOfGoldenProtectionFeature = Resources.GetModBlueprint<BlueprintFeature>("AuraOfGoldenProtectionFeature");
            var AuraOfMajestyFeature = Resources.GetModBlueprint<BlueprintFeature>("AuraOfMajestyFeature");
            var SiphoningAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("SiphoningAuraFeature");
            var ArmorSaint = Resources.GetModBlueprint<BlueprintFeature>("ArmorSaint");
            var AuraOfDivineFuryFeature = Resources.GetModBlueprint<BlueprintFeature>("AuraOfDivineFuryFeature");
            var SupersonicCombat = Resources.GetModBlueprint<BlueprintFeature>("SupersonicCombat");
            var EdgeLordFastMovement = Resources.GetModBlueprint<BlueprintFeature>("EdgeLordFastMovement");
            var SlayerStudyTargetFeature = Resources.GetBlueprint<BlueprintFeature>("09bdd9445ac38044389476689ae8d5a1");
            var SlayerSwiftStudyTargetFeature = Resources.GetBlueprint<BlueprintFeature>("40d4f55a5ac0e4f469d67d36c0dfc40b");
            var ExtraStrike = Resources.GetModBlueprint<BlueprintFeature>("ExtraStrike");
            var CripplingStrike = Resources.GetBlueprint<BlueprintFeature>("b696bd7cb38da194fa3404032483d1db");
            var DispellingAttack = Resources.GetBlueprint<BlueprintFeature>("1b92146b8a9830d4bb97ab694335fa7c");
            var CorruptAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("CorruptAuraFeature");
            var SecondFormFeature = Resources.GetModBlueprint<BlueprintFeature>("SecondFormFeature");
            var GracefulCombat = Resources.GetModBlueprint<BlueprintFeature>("GracefulCombat");
            var TrueSmiteFeature = Resources.GetModBlueprint<BlueprintFeature>("TrueSmiteFeature");
            var TrueSmiteAdditionalUse = Resources.GetModBlueprint<BlueprintFeature>("TrueSmiteAdditionalUse");
            var TrueMarkFeature = Resources.GetModBlueprint<BlueprintFeature>("TrueMarkFeature");
            var HerosPresenceFeature = Resources.GetModBlueprint<BlueprintFeature>("HerosPresenceFeature");
            var IsekaiChannelPositiveEnergyFeature = Resources.GetModBlueprint<BlueprintFeature>("IsekaiChannelPositiveEnergyFeature");
            var IsekaiChannelNegativeEnergyFeature = Resources.GetModBlueprint<BlueprintFeature>("IsekaiChannelNegativeEnergyFeature");

            var IsekaiPetSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiPetSelection");
            var OverpoweredAbilitySelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection");
            var OverpoweredAbilitySelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2");
            var OverpoweredAbilitySelectionVillain = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelectionVillain");
            var BeachEpisodeSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection");
            var SpecialPowerSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("SpecialPowerSelection");

            var IsekaiProtagonistProgression = Helpers.CreateBlueprint<BlueprintProgression>("IsekaiProtagonistProgression", bp => {
                bp.SetName("");
                bp.SetDescription("Isekai protagonists are otherworldly entities who have been reincarnated into the world of Golarion with extraordinary abilities. "
                    + "As their story progresses, they gain more unexplained and overpowered abilities to overcome every challenge they face.");
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
                bp.m_FeaturesRankIncrease = null;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
            });
            IsekaiProtagonistProgression.LevelEntries = new LevelEntry[20] {
                Helpers.LevelEntry(1, IsekaiProtagonistProficiencies, IsekaiProtagonistCantripsFeature, IsekaiProtagonistBonusFeatSelection, SneakAttack, OverpoweredAbilitySelection, PlotArmor, StartingWeaponSelection, IsekaiPetSelection),
                Helpers.LevelEntry(2, IsekaiProtagonistBonusFeatSelection, UncannyDodge),
                Helpers.LevelEntry(3, SneakAttack, IsekaiFighterTraining, Evasion, SpecialPowerSelection),
                Helpers.LevelEntry(4, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(5, SneakAttack, OverpoweredAbilitySelection2, ImprovedUncannyDodge),
                Helpers.LevelEntry(6, IsekaiProtagonistBonusFeatSelection, SignatureMoveSelection),
                Helpers.LevelEntry(7, SneakAttack, SpecialPowerSelection),
                Helpers.LevelEntry(8, IsekaiProtagonistBonusFeatSelection, IsekaiFastMovement),
                Helpers.LevelEntry(9, SneakAttack, SpecialPowerSelection, FriendlyAuraFeature),
                Helpers.LevelEntry(10, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection2, ImprovedEvasion),
                Helpers.LevelEntry(11, SneakAttack, SpecialPowerSelection),
                Helpers.LevelEntry(12, IsekaiProtagonistBonusFeatSelection, BeachEpisodeSelection),
                Helpers.LevelEntry(13, SneakAttack, SpecialPowerSelection),
                Helpers.LevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(15, SneakAttack, OverpoweredAbilitySelection2, OtherworldlyStamina, IsekaiQuickFooted),
                Helpers.LevelEntry(16, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(17, SneakAttack, SpecialPowerSelection, SummonHaremFeature),
                Helpers.LevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(19, SneakAttack, SpecialPowerSelection),
                Helpers.LevelEntry(20, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection2, SecondReincarnation)
            };
            IsekaiProtagonistProgression.UIGroups = new UIGroup[] {
                Helpers.CreateUIGroup(SneakAttack, OverpoweredAbilitySelectionVillain),
                Helpers.CreateUIGroup(SupersonicCombat, ExtraStrike),
                Helpers.CreateUIGroup(SlayerStudyTargetFeature, SlayerSwiftStudyTargetFeature),
                Helpers.CreateUIGroup(GracefulCombat, TrueSmiteFeature, TrueSmiteAdditionalUse, TrueMarkFeature),
                Helpers.CreateUIGroup(NascentApotheosis, DivineArray, GodEmperorEnergySelection, AuraOfGoldenProtectionFeature, AuraOfMajestyFeature, SiphoningAuraFeature, GodlyVessel, CelestialRealmFeature, Godhood),
                Helpers.CreateUIGroup(OverpoweredAbilitySelection, OverpoweredAbilitySelection2, CorruptAuraFeature, SpecialPowerSelection, IsekaiChannelPositiveEnergyFeature, IsekaiChannelNegativeEnergyFeature, ArmorSaint, AuraOfDivineFuryFeature),
                Helpers.CreateUIGroup(PlotArmor, CripplingStrike, DispellingAttack, IsekaiFighterTraining, SignatureMoveSelection, SummonHaremFeature, FriendlyAuraFeature, DarkAuraFeature, BeachEpisodeSelection, OtherworldlyStamina, SecondReincarnation, SecondFormFeature, HerosPresenceFeature),
                Helpers.CreateUIGroup(IsekaiPetSelection, UncannyDodge, ImprovedUncannyDodge, Evasion, ImprovedEvasion, IsekaiFastMovement, EdgeLordFastMovement, IsekaiQuickFooted, VillainQuickFooted),
            };
            IsekaiProtagonistProgression.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] {
                HeroProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                EdgeLordProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                GodEmperorProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                VillainProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProtagonistProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProtagonistCantripsFeature.ToReference<BlueprintFeatureBaseReference>(),
                StartingWeaponSelection.ToReference<BlueprintFeatureBaseReference>(),
            };
            IsekaiProtagonistClass.SetProgression(IsekaiProtagonistProgression);
        }
    }
}
