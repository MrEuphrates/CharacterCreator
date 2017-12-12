using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Calculator;
using Calculator.Classes.CommonAbilities;
using CharacterCreator.Classes;

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
            ability = new Camouflage();
            if (!character.SpecialAbilities.Contains(ability)) clbAbilities.Items.Add(ability);
            ability = new Cloaking();
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
            var description = "\n" + ability.CommonDescription;
            rtbAbilityDescription.AppendText(description);
            rtbAbilityDescription.Select(ability.Name.Length, ability.Name.Length + description.Length);
            rtbAbilityDescription.SelectionFont = new Font(rtbAbilityDescription.Font, FontStyle.Regular);
        }

        private void commandOK_Click(object sender, EventArgs e)
        {
            //Get selected abilities
            var abilities = getSelectedAbilities();

            //TODO Cloaking optons aren't compatible with one another, armor is compatible with fly but its price can be changed by it, etc.
            //Make sure the chosen abilities are compatible.
            if (!checkAbilitiesCompatible(abilities)) return;

            //Make sure the chosen abilities are valid.
            //TODO Not sure if I'll be doing validation on abilities.
            //foreach (SpecialRule rule in rules) if (!rule.specialRuleIsValid(ability, rules)) return;

            //TODO I elected not to do armor, the only common ability with parameters.  If I decide to do it again, I'll bring this back.
            //After confirming all selected abilities are compatible, cycle through those with parameters and have the user provide them.
            //foreach (Ability ability in abilities)
            //{
            //    if (ability.Variables.Count == 0) continue;
            //    AbilityParameterForm pform = new AbilityParameterForm(ability);
            //    pform.ShowDialog();
            //}
            //TODO Need to add the abilities to the character
            foreach (Ability ability in abilities) character.addAbility(ability);

            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private bool checkAbilitiesCompatible(List<Ability> abilities)
        {
            //TODO Right now, I don't have code to actually check that abilities are compatible.  Actually, I might not bother with it at all.
            //Check that every selected rule is compatible with every other selected rule.
            //foreach(SpecialRule rule in rules) if (!rule.IsCompatibleWith(rules)) return false;
            return true;
        }

        private List<Ability> getSelectedAbilities()
        {
            //Gather the chosen rules into a list
            List<Ability> abilities = new List<Ability>();
            for (int i = 0; i < clbAbilities.CheckedItems.Count; ++i) abilities.Add((Ability)clbAbilities.CheckedItems[i]);
            return abilities;
        }

        private void clbAbilities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                //TODO Adapt for use with abilities.
                //var rules = getSelectedRules();
                //SpecialRule rule = (SpecialRule)clbAbilities.Items[e.Index];
                //if (!rule.specialRuleIsValid(this.ability, rules)) e.NewValue = e.CurrentValue;
            }
        }
        #endregion
        //======================================================
    }
}