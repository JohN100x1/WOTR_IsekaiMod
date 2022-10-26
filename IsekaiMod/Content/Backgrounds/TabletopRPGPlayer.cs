﻿using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.EntitySystem.Stats;

namespace IsekaiMod.Content.Backgrounds
{
    internal class TabletopRPGPlayer
    {
        public static void Add()
        {
            var BackgroundTabletopRPGPlayer = Helpers.CreateBlueprint<BlueprintFeature>("BackgroundTabletopRPGPlayer", bp => {
                bp.SetName("Tabletop RPG Player");
                bp.SetDescription("The Tabletop RPG Player adds {g|Encyclopedia:Lore_Nature}Lore (Nature){/g}, {g|Encyclopedia:Lore_Religion}Lore (Religion){/g}, "
                    + "{g|Encyclopedia:Knowledge_World}Knowledge (World){/g} and {g|Encyclopedia:Knowledge_Arcana}Knowledge (Arcana){/g} to the list of her class {g|Encyclopedia:Skills}skills{/g} "
                    + "and can use her {g|Encyclopedia:Wisdom}Wisdom{/g} instead of {g|Encyclopedia:Intelligence}Intelligence{/g} while attempting Knowledge (World) or Knowledge (Arcana) "
                    + "{g|Encyclopedia:Check}checks{/g}.\n"
                    + "If the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} or armor proficiency granted by the selected background "
                    + "from her class during character creation, then the corresponding {g|Encyclopedia:Bonus}bonuses{/g} from background change to a +1 competence bonus in case of skills, "
                    + "a +1 enhancement bonus in case of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case of armor proficiency.");
                bp.m_Icon = null;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                
                // Add Lore (Nature), Lore (Religion), Knowledge (World), and Knowledge (Arcana) to class skills
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeWorld;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeWorld;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeArcana;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeArcana;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillLoreReligion;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillLoreReligion;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillLoreNature;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillLoreNature;
                });

                // Use Wisdom instead of Intelligence for Knowledge (World) and Knowledge (Arcana) checks
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillKnowledgeWorld;
                    c.BaseAttributeReplacement = StatType.Wisdom;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillKnowledgeArcana;
                    c.BaseAttributeReplacement = StatType.Wisdom;
                });
            });
        }
    }
}