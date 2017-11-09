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
        {
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
            //With rich textboxes, OnValidation is the way to go; otherwise, every key resets the cursor.
            rtbAdditionalInputDescription.DataBindings.Add("Text", bindingSource, "InputDescription", false, DataSourceUpdateMode.OnValidation);

            //listBoxSpecial.DataSource = ability.SpecialRules;
            listBoxSpecial.DataBindings.Add("DataSource", bindingSource, "SpecialRules", false, DataSourceUpdateMode.OnPropertyChanged);
            listBoxSpecial.DisplayMember = "SyntaxActual";
            
            //Setup the delays for the tooltip
            toolTip1.AutoPopDelay = 20000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            //Setup the tooltip for the controls
            toolTip1.SetToolTip(nudTime, "The amount of time which must be spent to use this ability.  Characters are limited to 10 per round.  The " +
                "recommended amount of Time for an ability is 1 per 100.  The energy cost increases if Time is below the recommended amount, and the " +
                "reverse is also true.");
            toolTip1.SetToolTip(nudEnergy, "This is the amount of energy expended using this ability once.");
            toolTip1.SetToolTip(nudDamageBase, "The basic amount of damage dealt by this ability.  Must be a multiple of 10.  Leave as 0 if this ability " +
                "is not meant to deal damage.");
            toolTip1.SetToolTip(txtName, "The name of this ability.  You may call it whatever you like, but the name should reflect what the ability does or represents.");
            toolTip1.SetToolTip(nudDamageActual, "Characters with stats of 6 or higher receive bonus damage for abilities which use that stat to attack.  For example, " +
                "melee abilities will gain 10% extra damage per point of Strength above 5, whereas ranged abilities gain this bonus per point of Marksmanship above 5.");
            toolTip1.SetToolTip(nudAttacks, "The number of attacks made when using this ability.  The attacker may divide these attacks across targets however they see fit.  " +
                "Each attack is resolved separately and applies any effects individually.");
            toolTip1.SetToolTip(nudEnergyModifier, "The energy modifier is (usually) equal to 20% of an ability's damage.  Some rules have their cost tied to this value, and when " +
                "adding special rules, you will see this value referenced in the description of how the cost is calculated.");
            toolTip1.SetToolTip(buttonAddSpecial, "Click to add and edit special rules for this ability.");
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
            //This method is called before the bound class's property is actually updated.
            ability.BaseDamage = nudDamageBase.Value;
            updateActualDamage();
        }

        private void cbxRequiresAdditionalInput_CheckedChanged(object sender, EventArgs e)
        {
            rtbAdditionalInputDescription.Enabled = cbxRequiresAdditionalInput.Checked;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
        #endregion
        //===================================================================

    }
}