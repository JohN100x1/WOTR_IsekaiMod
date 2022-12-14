using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace IsekaiMod.Content.Backgrounds
{
    internal class Gamer
    {
        public static void Add()
        {
            // Background
            var BackgroundGamer = Helpers.CreateFeature("BackgroundGamer", bp => {
                bp.SetName("Gamer");
                bp.SetDescription("The Gamer has a +4 competence bonus to all knowledge, lore, and perception checks.\n"
                    + "If the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} or armor proficiency granted by the selected background "
                    + "from her class during character creation, then the corresponding {g|Encyclopedia:Bonus}bonuses{/g} from background change to a +1 competence bonus in case of skills, "
                    + "a +1 enhancement bonus in case of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case of armor proficiency.");
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillKnowledgeWorld;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillKnowledgeArcana;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillLoreReligion;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillLoreNature;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillPerception;
                    c.Value = 4;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.Register(BackgroundGamer);
        }
    }
}
