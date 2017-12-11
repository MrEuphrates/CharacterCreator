using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;
using Calculator.Classes.CommonAbilities;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes;
using CharacterCreator.Classes.SpecialRules;

namespace CharacterCreator
{
    public partial class CommonAbilityForm : Form
    {
        #region Variables
        Character character = new Character();
        #endregion
        public CommonAbilityForm(Character character)
        {
            InitializeComponent();
            
            this.character = character;
        }
        
        
        //======================================================
        #region Event Methods
        private void SpecialForm_Load(object sender, EventArgs e)
        {
            //Until I find a better way, this list is typed manually.
            
            //Rules attached to this ability should be added first, for editing.
            //TODO Need to determine between Common Abilities and Non-Common, as common abilities can be Active or Passive Abilities).
            if (character.SpecialAbilities != null) foreach (Ability a in character.SpecialAbilities) if(a.IsCommon) clbAbilities.Items.Add(a, true);

            //Add the rest of the abilities, but don't add ones already added from the character.
            Ability ability = new ActiveCamouflage();
            if (!character.SpecialAbilities.Contains(ability)) clbAbilities.Items.Add(ability);
            ability = new Armor();
            if (!character.SpecialAbilities.Contains(ability)) clbAbilities.Items.Add(ability);
        }
        
        private void clbAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the name
            var ability = (Ability)clbAbilities.Items[clbAbilities.SelectedIndex];
            rtbAbilityDescription.Text = ability.Name;
            rtbAbilityDescription.Select(0, ability.Name.Length);
            rtbAbilityDescription.SelectionFont = new Font(rtbAbilityDescription.Font, FontStyle.Bold);

            //Get the description
            var description = "\n" + ability.InputDescription;
            rtbAbilityDescription.AppendText(description);
            rtbAbilityDescription.Select(ability.Name.Length, ability.Name.Length + description.Length);
            rtbAbilityDescription.SelectionFont = new Font(rtbAbilityDescription.Font, FontStyle.Regular);

            //TODO Some abilities will actually have variables, like Armor.            
            //List the variables, if there are any.
            //var variables = ability.listVariables();
            //if (variables != "") rtbAbilityDescription.AppendText("\n\n" + variables);
        }

        private void commandOK_Click(object sender, EventArgs e)
        {
            ////Get selected rules
            //var rules = getSelectedRules();

            ////Make sure the chosen rules are compatible.
            //if (!checkRulesCompatible(rules)) return;

            ////Make sure the chosen rules are valid.
            ////TODO Not working with special rules here.
            //foreach(SpecialRule rule in rules) if (!rule.specialRuleIsValid(ability, rules)) return;

            ////After confirming all selected rules are compatible, cycle through those with parameters and have the user provide them.
            //foreach(SpecialRule rule in rules)
            //{
            //    if (rule.Variables.Count == 0) continue;
            //    ParameterForm pform = new ParameterForm(rule);
            //    pform.ShowDialog();
            //}
            ////TODO Not working with special rules here.
            //ability.SpecialRules = rules;

            this.Dispose();
        }

        private bool checkRulesCompatible(List<SpecialRule> rules)
        {
            //Check that every selected rule is compatible with every other selected rule.
            foreach(SpecialRule rule in rules) if (!rule.IsCompatibleWith(rules)) return false;
            return true;
        }

        private List<SpecialRule> getSelectedRules()
        {
            //Gather the chosen rules into a list
            List<SpecialRule> rules = new List<SpecialRule>();
            for (int i = 0; i < clbAbilities.CheckedItems.Count; ++i) rules.Add((SpecialRule)clbAbilities.CheckedItems[i]);
            return rules;
        }

        private void clbSpecials_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                //var rules = getSelectedRules();
                //SpecialRule rule = (SpecialRule)clbAbilities.Items[e.Index];
                ////TODO Not working with special rules here.
                //if (!rule.specialRuleIsValid(this.ability, rules)) e.NewValue = e.CurrentValue;
            }
        }
        #endregion
        //======================================================
    }
}