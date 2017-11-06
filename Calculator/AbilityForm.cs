using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes;
using CharacterCreator.Classes.SpecialRules;

namespace CharacterCreator
{
    public partial class AbilityForm : Form
    {
        //=========================================================================
        #region Variables
        public Character character;
        public Ability ability;
        BindingSource bindingSource;
        #endregion
        //=========================================================================


        //=========================================================================
        #region Methods
        public AbilityForm(Character character)
        {
            InitializeComponent();
            this.character = character;
            ability = new Ability();
            setupForm();
        }

        public AbilityForm(Character character, Ability ability)
        {//TODO Have to work on the interactions between Character and Ability forms.
            InitializeComponent();
            this.character = character;
            this.ability = ability;
            setupForm();
        }

        private void setupForm()
        {
            //Setup the data binding
            bindingSource = new BindingSource();
            bindingSource.DataSource = ability;
            nudTime.DataBindings.Add("Value", bindingSource, "Time", false, DataSourceUpdateMode.OnPropertyChanged);
            txtName.DataBindings.Add("Text", bindingSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            nudEnergy.DataBindings.Add("Value", bindingSource, "Energy", false, DataSourceUpdateMode.OnPropertyChanged);
            nudDamageBase.DataBindings.Add("Value", bindingSource, "BaseDamage", false, DataSourceUpdateMode.OnPropertyChanged);
            nudDamageActual.DataBindings.Add("Value", bindingSource, "Damage", false, DataSourceUpdateMode.OnPropertyChanged);
            nudAttacks.DataBindings.Add("Value", bindingSource, "Attacks", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDisplay.DataBindings.Add("Text", bindingSource, "Syntax", false, DataSourceUpdateMode.OnPropertyChanged);
            cbxRequiresAdditionalInput.DataBindings.Add("Checked", bindingSource, "RequiresInput", false, DataSourceUpdateMode.OnPropertyChanged);
            //TODO For the rich textbox, setting the update mode to OnValidation supposedly fixes the typing issue I had, but may need more work to get it to load when the ability is loaded.
            rtbAdditionalInputDescription.DataBindings.Add("Text", bindingSource, "InputDescription", false, DataSourceUpdateMode.OnValidation);

            //TODO Bind the specials listbox to the ability's list of specials
            //listBoxSpecial.DataSource = ability.SpecialRules;
            listBoxSpecial.DataBindings.Add("DataSource", bindingSource, "SpecialRules", false, DataSourceUpdateMode.OnPropertyChanged);
            listBoxSpecial.DisplayMember = "SyntaxActual";
            
            //Setup the delays for the tooltip
            toolTip1.AutoPopDelay = 20000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            //TODO Finish the tooltips
            //Setup the tooltip for the controls
            toolTip1.SetToolTip(nudDamageBase, "The basic amount of damage dealt by this ability.  Must be a multiple of 10.  Leave as 0 if this ability " +
                "is not meant to deal damage.");
            toolTip1.SetToolTip(nudTime, "The amount of time which must be spent to use this ability.  Characters are limited to 10 per round.  The " +
                "recommended amount of Time for an ability is 1 per 100.  The energy cost increases if Time is below the recommended amount, and the " +
                "reverse is also true.");
            toolTip1.SetToolTip(txtName, "The name of this ability.  You may call it whatever you like, but the name should reflect what the ability does or represents.");
            toolTip1.SetToolTip(nudDamageActual, "Characters with stats of 6 or higher receive bonus damage for abilities which use that stat to attack.  For example, " +
                "melee abilities will gain 10% extra damage per point of Strength above 5, whereas ranged abilities gain this bonus per point of Marksmanship above 5.");
            //TODO Just realized the actual damage is tied to Strength, Marksmanship, or Tech, depending on which special rules are and are not selected.
        }
        
        private void updateAbility()
        {//TODO Likely in lieu of this method, what I want is to have Ability update itself when the properties change.
            //Whenever anything about this ability changes, this method needs to be called.
            ability.Time = nudTime.Value;
            ability.Name = txtName.Text;
            ability.BaseDamage = nudDamageBase.Value;
            ability.Damage = nudDamageActual.Value;
            List<SpecialRule> sr = new List<SpecialRule>();
            foreach (var i in listBoxSpecial.Items)
            {
                sr.Add((SpecialRule)i);
            }
            ability.SpecialRules = sr;

            //After updating everything about the Ability instance, update the energy cost and then record it.
            ability.Energy = nudEnergy.Value;
            ability.Attacks = nudAttacks.Value;

            //Output the ability as it will appear on a character sheet.
            txtDisplay.Text = ability.Syntax;
        }
        private void updateActualDamage()
        {
            nudDamageActual.Value = character.getActualDamage(nudDamageBase.Value, ability.SpecialRules);
        }
        #endregion
        //===================================================================


        //===================================================================
        #region Event Methods
        private void buttonAddSpecial_Click(object sender, EventArgs e)
        {
            SpecialForm sf = new SpecialForm(ability);
            sf.ShowDialog();
            updateActualDamage();
        }

        private void nudDamageBase_ValueChanged(object sender, EventArgs e)
        {
            if (nudDamageBase.Value % 10 != 0) nudDamageBase.Value = nudDamageBase.Value - nudDamageBase.Value % 10;
            //TODO This stuff triggers before the property is actually updated.  Do I have to just set the property here, rather than rely on bindings?
            ability.BaseDamage = nudDamageBase.Value;
            updateActualDamage();
        }

        private void cbxRequiresAdditionalInput_CheckedChanged(object sender, EventArgs e)
        {
            rtbAdditionalInputDescription.Enabled = cbxRequiresAdditionalInput.Checked;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //TODO Moved this call to the method which opened the form to begin with.
            //character.addAbility(ability);
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        #endregion
        //===================================================================

    }
}