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
    public partial class PassiveAbilityForm : Form
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
        public PassiveAbilityForm(Character character)
        {
            InitializeComponent();
            this.character = character;
            ability = new Ability();
            //Passive abilities always require input, and for automation purposes, has stats set behind the scenes.
            ability.RequiresInput = true;
            ability.Time = -1;
            ability.Energy = -1;
            ability.BaseDamage = -1;
            setupForm();
        }

        public PassiveAbilityForm(Character character, Ability ability)
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
            txtName.DataBindings.Add("Text", bindingSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            cbxRequiresAdditionalInput.DataBindings.Add("Checked", bindingSource, "RequiresInput", false, DataSourceUpdateMode.OnPropertyChanged);
            //With rich textboxes, OnValidation is the way to go; otherwise, every key resets the cursor.
            rtbAdditionalInputDescription.DataBindings.Add("Text", bindingSource, "InputDescription", false, DataSourceUpdateMode.OnValidation);

            //Setup the delays for the tooltip
            toolTip1.AutoPopDelay = 20000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            //Setup the tooltip for the controls
            //toolTip1.SetToolTip(nudTime, "The amount of time which must be spent to use this ability.  Characters are limited to 10 per round.  The " +
            //    "recommended amount of Time for an ability is 1 per 100.  The energy cost increases if Time is below the recommended amount, and the " +
            //    "reverse is also true.");
        }
        #endregion
        //===================================================================


        //===================================================================
        #region Event Methods

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