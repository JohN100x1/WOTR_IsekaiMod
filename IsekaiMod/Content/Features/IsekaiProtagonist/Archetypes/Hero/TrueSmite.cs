﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Collections.Generic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero
{
    class TrueSmite
    {
        public static void Add()
        {
            var Icon_True_Smite = AssetLoader.LoadInternal("Features", "ICON_TRUE_SMITE.png");
            var TrueSmiteResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("TrueSmiteResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount
                {
                    BaseValue = 1,
                    IncreasedByLevel = false,
                    LevelIncrease = 1,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 0,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    OtherClassesModifier = 0,
                    IncreasedByStat = false,
                    ResourceBonusStat = StatType.Unknown,
                };
            });
            var TrueSmiteBuff = Helpers.CreateBuff("TrueSmiteBuff", bp => {
                bp.SetName("True Smite");
                bp.SetDescription("The hero adds her {g|Encyclopedia:Charisma}Cha{/g} {g|Encyclopedia:Bonus}bonus{/g} (if any) to her {g|Encyclopedia:Attack}attack rolls{/g} against this "
                    + "creature and adds her character level to all {g|Encyclopedia:Damage}damage rolls{/g} against this creature."
                    + "Attacks against this creature automatically bypass any {g|Encyclopedia:Damage_Reduction}DR{/g} the creature might possess and "
                    + "automatically confirms all critical threats against them. In addition, while true smite is in effect, the hero gains a deflection bonus equal to her Charisma modifier "
                    + "(if any) to her {g|Encyclopedia:Armor_Class}AC{/g} against attacks made by this creature.\nTrue smite lasts until this creature dies or the hero selects "
                    + "a new target.");
                bp.m_Icon = Icon_True_Smite;
                bp.AddComponent<AttackBonusAgainstTarget>(c => {
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Shared,
                        ValueShared = AbilitySharedValue.StatBonus
                    };
                    c.CheckCaster = true;
                });
                bp.AddComponent<DamageBonusAgainstTarget>(c => {
                    c.CheckCaster = true;
                    c.ApplyToSpellDamage = true;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Shared,
                        ValueShared = AbilitySharedValue.DamageBonus
                    };
                });
                bp.AddComponent<ACBonusAgainstTarget>(c => {
                    c.CheckCaster = true;
                    c.Descriptor = ModifierDescriptor.Deflection;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Shared,
                        ValueShared = AbilitySharedValue.StatBonus
                    };
                });
                bp.AddComponent<RemoveBuffIfCasterIsMissing>(c => {
                    c.RemoveOnCasterDeath = true;
                });
                bp.AddComponent<IgnoreTargetDR>(c => {
                    c.CheckCaster = true;
                });
                bp.AddComponent<TargetCritAutoconfirm>();
                bp.AddComponent<UniqueBuff>();
                bp.Stacking = StackingType.Replace;
                bp.FxOnStart = new PrefabLink() { AssetId = "5b4cdc22715305949a1bd80fab08302b" };
            });
            var TrueSmiteAbility = Helpers.CreateBlueprint<BlueprintAbility>("TrueSmiteAbility", bp => {
                bp.SetName("True Smite");
                bp.SetDescription("Once per day, the hero can call out her inner powers to aid her against her enemies. "
                    + "As a {g|Encyclopedia:Swift_Action}swift action{/g}, the hero chooses one target within sight to smite. The hero adds her {g|Encyclopedia:Charisma}Cha{/g} "
                    + "{g|Encyclopedia:Bonus}bonus{/g} (if any) to her {g|Encyclopedia:Attack}attack rolls{/g} and adds her character level to all {g|Encyclopedia:Damage}damage rolls{/g} "
                    + "made against the target of her smite, true smite attacks automatically bypass any {g|Encyclopedia:Damage_Reduction}DR{/g} the creature might possess and "
                    + "automatically confirms all critical threats against them. In addition, while true smite is in effect, the hero gains a deflection bonus equal to her Charisma modifier "
                    + "(if any) to her {g|Encyclopedia:Armor_Class}AC{/g} against attacks made by the target of the smite.\nTrue smite lasts until the target dies or the hero selects "
                    + "a new target. At 4th level, and at every three levels thereafter, the hero may use true smite one additional time per day.");
                bp.m_Icon = Icon_True_Smite;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.Permanent = true;
                        c.m_Buff = TrueSmiteBuff.ToReference<BlueprintBuffReference>();
                        c.DurationValue = new ContextDurationValue()
                        {
                            Rate = DurationRate.Rounds,
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 0,
                            m_IsExtendable = true
                        };
                        c.IsNotDispelable = true;
                        c.UseDurationSeconds = false;
                        c.DurationSeconds = 0;
                        c.IsFromSpell = false;
                        c.ToCaster = false;
                        c.AsChild = false;
                    });
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.StatBonus;
                    c.Value = new ContextDiceValue()
                    {
                        DiceType = DiceType.Zero,
                        DiceCountValue = 0,
                        BonusValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Rank,
                            ValueRank = AbilityRankType.StatBonus,
                            ValueShared = AbilitySharedValue.StatBonus
                        },
                    };
                    c.Modifier = 1;
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.DamageBonus;
                    c.Value = new ContextDiceValue()
                    {
                        DiceCountValue = new ContextValue(),
                        BonusValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Rank,
                            ValueRank = AbilityRankType.DamageBonus,
                            ValueShared = AbilitySharedValue.DamageBonus
                        },
                    };
                    c.Modifier = 1;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.StatBonus;
                    c.m_Stat = StatType.Charisma;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "6e799a804a9ce4044a70eba38890cf5a" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                    c.WeaponTarget = AbilitySpawnFxWeaponTarget.None;
                    c.DestroyOnCast = false;
                    c.Delay = 0;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationMode = AbilitySpawnFxOrientation.Copy;
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = TrueSmiteResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                    c.Amount = 1;
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Medium;
                bp.m_AllowNonContextActions = false;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = false;
                bp.SpellResistance = false;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Swift;
                bp.AvailableMetamagic = Metamagic.Heighten | Metamagic.Reach;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "Until the target of the smite is dead");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "");
            });
            var TrueSmiteFeature = Helpers.CreateBlueprint<BlueprintFeature>("TrueSmiteFeature", bp => {
                bp.SetName("True Smite");
                bp.SetDescription("Once per day, the hero can call out her inner powers to aid her against her enemies. "
                    + "As a {g|Encyclopedia:Swift_Action}swift action{/g}, the hero chooses one target within sight to smite. The hero adds her {g|Encyclopedia:Charisma}Cha{/g} "
                    + "{g|Encyclopedia:Bonus}bonus{/g} (if any) to her {g|Encyclopedia:Attack}attack rolls{/g} and adds her character level to all {g|Encyclopedia:Damage}damage rolls{/g} "
                    + "made against the target of her smite, true smite attacks automatically bypass any {g|Encyclopedia:Damage_Reduction}DR{/g} the creature might possess and "
                    + "automatically confirms all critical threats against them. In addition, while true smite is in effect, the hero gains a deflection bonus equal to her Charisma modifier "
                    + "(if any) to her {g|Encyclopedia:Armor_Class}AC{/g} against attacks made by the target of the smite.\nTrue smite lasts until the target dies or the hero selects "
                    + "a new target. At 4th level, and at every three levels thereafter, the hero may use true smite one additional time per day.");
                bp.m_Icon = Icon_True_Smite;
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = TrueSmiteResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { TrueSmiteAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var TrueSmiteAdditionalUse = Helpers.CreateBlueprint<BlueprintFeature>("TrueSmiteAdditionalUse", bp => {
                bp.SetName("True Smite — Additional Use");
                bp.SetDescription("Once per day, the hero can call out her inner powers to aid her against her enemies. "
                    + "As a {g|Encyclopedia:Swift_Action}swift action{/g}, the hero chooses one target within sight to smite. The hero adds her {g|Encyclopedia:Charisma}Cha{/g} "
                    + "{g|Encyclopedia:Bonus}bonus{/g} (if any) to her {g|Encyclopedia:Attack}attack rolls{/g} and adds her character level to all {g|Encyclopedia:Damage}damage rolls{/g} "
                    + "made against the target of her smite, true smite attacks automatically bypass any {g|Encyclopedia:Damage_Reduction}DR{/g} the creature might possess and "
                    + "automatically confirms all critical threats against them. In addition, while true smite is in effect, the hero gains a deflection bonus equal to her Charisma modifier "
                    + "(if any) to her {g|Encyclopedia:Armor_Class}AC{/g} against attacks made by the target of the smite.\nTrue smite lasts until the target dies or the hero selects "
                    + "a new target. At 4th level, and at every three levels thereafter, the hero may use true smite one additional time per day.");
                bp.m_Icon = Icon_True_Smite;
                bp.AddComponent<IncreaseResourceAmount>(c => {
                    c.m_Resource = TrueSmiteResource.ToReference<BlueprintAbilityResourceReference>();
                    c.Value = 1;
                });
                bp.Ranks = 10;
                bp.IsClassFeature = true;
            });
        }
    }
}