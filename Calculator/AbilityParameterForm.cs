using System;
using System.Drawing;
using System.Windows.Forms;
using CharacterCreator.Classes;

namespace Calculator
{
    public partial class AbilityParameterForm : Form
    {
        Ability ability;
        
        public AbilityParameterForm(Ability ability)
        {
            InitializeComponent();
            this.ability = ability;

            //Fill in the DGV from the special rule
            dgvParameters.DataSource = ability.VariableTable;
            dgvParameters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            //Fill the info box
            populateDescription();
        }

        private void populateDescription()
        {
            //Get the name
            rtbAbilityDescription.Text = ability.Name;
            rtbAbilityDescription.Select(0, ability.Name.Length);
            rtbAbilityDescription.SelectionFont = new Font(rtbAbilityDescription.Font, FontStyle.Bold);

            //Get the description
            var description = "\n" + ability.CommonDescription;
            rtbAbilityDescription.AppendText(description);
            rtbAbilityDescription.Select(ability.Name.Length, ability.Name.Length + description.Length);
            rtbAbilityDescription.SelectionFont = new Font(rtbAbilityDescription.Font, FontStyle.Regular);
        }

        private void dgvParameters_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //If the user types in text, invalid characters, or an actual decimal, I'll just let an uncaught exception happen.
            //Get the value entered, set it for the appropriate variable for this rule, then validate it.  Update the cell if the variable is invalid.
            int value = (int)dgvParameters[e.ColumnIndex, e.RowIndex].Value;
            string parameter = (string)dgvParameters["Parameter", e.RowIndex].Value;
            ability.setVariable(parameter, value);
            //If validation changed the value in the special rule, update the DGV accordingly
            if (ability.Variables[parameter].Value != value) dgvParameters[e.ColumnIndex, e.RowIndex].Value = ability.Variables[parameter].Value;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            for(int i=0; i<dgvParameters.Rows.Count;++i)
            {
                string parameter = (string)dgvParameters["Parameter", i].Value;
                ability.Variables[parameter].Value = (int)dgvParameters["Input", i].Value;
            }
            this.Dispose();
        }
    }
}