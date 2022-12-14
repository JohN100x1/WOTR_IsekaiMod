using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class AuraOfRighteousWrath
    {
        public static void Add()
        {
            var Icon_AuraOfRighteousWrath = AssetLoader.LoadInternal("Features", "ICON_AURA_RIGHTEOUS_WRATH.png");
            var AuraOfRighteousWrathEnchantment = Helpers.CreateWeaponEnchantment("AuraOfRighteousWrathEnchantment", bp => {
                bp.m_EnchantName = Helpers.CreateString("AuraOfRighteousWrathEnchantment.Name", "Overpowered Ability — Aura of Righteous Wrath");
                bp.m_Description = Helpers.CreateString("AuraOfRighteousWrathEnchantment.Description", "This creature has two extra attacks and deal an additional 5d6 physical damage. "
                    + "It also has additional sneak attack damage.");
                bp.AddComponent<WeaponConditionalDamageDice>(c => {
                    c.Damage = new DamageDescription()
                    {
                        Dice = new DiceFormula()
                        {
                            m_Dice = DiceType.D6,
                            m_Rolls = 5
                        },
                        TypeDescription = new DamageTypeDescription()
                        {
                            Type = DamageType.Physical,
                            Common = new DamageTypeDescription.CommomData(),
                            Physical = new DamageTypeDescription.PhysicalData()
                            {
                                Form = PhysicalDamageForm.Bludgeoning | PhysicalDamageForm.Piercing | PhysicalDamageForm.Slashing
                            }
                        }
                    };
                    c.Conditions = ActionFlow.EmptyCondition();
                });
            });
            var AuraOfRighteousWrathBuff = Helpers.CreateBuff("AuraOfRighteousWrathBuff", bp => {
                bp.SetName("Overpowered Ability — Aura of Righteous Wrath");
                bp.SetDescription("This creature has two extra attacks and deal an additional 5d6 physical damage. It also has additional sneak attack damage.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_AuraOfRighteousWrath;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 2;
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.SneakAttack;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = AuraOfRighteousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = AuraOfRighteousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = AuraOfRighteousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.AdditionalLimb;
                });
            });
            var AuraOfRighteousWrathArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("AuraOfRighteousWrathArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(120);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(AuraOfRighteousWrathBuff.ToReference<BlueprintBuffReference>()));
            });
            var AuraOfRighteousWrathAreaBuff = Helpers.CreateBuff("AuraOfRighteousWrathAreaBuff", bp => {
                bp.SetName("Overpowered Ability — Aura of Righteous Wrath");
                bp.SetDescription("Allies within 120 feet of you has two extra attacks and deal an additional 5d6 physical damage. "
                    + "They also gain 1d6 sneak attack equal to 1/2 your character level.");
                bp.m_Icon = Icon_AuraOfRighteousWrath;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = AuraOfRighteousWrathArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var AuraOfRighteousWrathAbility = Helpers.CreateActivatableAbility("AuraOfRighteousWrathAbility", bp => {
                bp.SetName("Overpowered Ability — Aura of Righteous Wrath");
                bp.SetDescription("Allies within 120 feet of you has two extra attacks and deal an additional 5d6 physical damage. "
                    + "They also gain 1d6 sneak attack equal to 1/2 your character level.");
                bp.m_Icon = Icon_AuraOfRighteousWrath;
                bp.m_Buff = AuraOfRighteousWrathAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var AuraOfRighteousWrathFeature = Helpers.CreateFeature("AuraOfRighteousWrathFeature", bp => {
                bp.SetName("Overpowered Ability — Aura of Righteous Wrath");
                bp.SetDescription("Allies within 120 feet of you has two extra attacks and deal an additional 5d6 physical damage. "
                    + "They also gain 1d6 sneak attack equal to 1/2 your character level.");
                bp.m_Icon = Icon_AuraOfRighteousWrath;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AuraOfRighteousWrathAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(AuraOfRighteousWrathFeature);
        }
    }
}
