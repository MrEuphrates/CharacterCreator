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

namespace Calculator
{
    public partial class ParameterForm : Form
    {
        SpecialRule rule;
        //DataSet dataSet;
        //TODO The parameter form shouldn't know how to define the table, it should only know how to display the table and be able to feed input back.
        public ParameterForm(SpecialRule rule)
        {
            InitializeComponent();
            this.rule = rule;

            //Fill in the DGV from the special rule
            dgvParameters.DataSource = rule.VariableTable;
            dgvParameters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            //Fill the info box
            populateDescription();
        }

        private void populateDescription()
        {
            //Get the name
            rtbSpecialDescription.Text = rule.Name;
            rtbSpecialDescription.Select(0, rule.Name.Length);
            rtbSpecialDescription.SelectionFont = new Font(rtbSpecialDescription.Font, FontStyle.Bold);

            //List the variables, if there are any.
            var variables = rule.listVariables();
            if (variables != "") rtbSpecialDescription.AppendText("\n\n" + variables);
            rtbSpecialDescription.Select(rule.Name.Length, rule.Name.Length + variables.Length);
            rtbSpecialDescription.SelectionFont = new Font(rtbSpecialDescription.Font, FontStyle.Regular);

            //The effects.
            rtbSpecialDescription.AppendText("\n\n" + rule.Effects);

            //List the negation and duration rules, if there are any.
            var negation = rule.NegationAndDuration;
            if (negation != "") rtbSpecialDescription.AppendText("\n\n" + negation);
        }

        private void dgvParameters_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //TODO What if the user types in text, invalid characters, or an actual decimal?
            //Get the value entered, set it for the appropriate variable for this rule, then validate it.  Update the cell if the variable is invalid.
            decimal value = (decimal)dgvParameters[e.ColumnIndex, e.RowIndex].Value;
            string parameter = (string)dgvParameters["Parameter", e.RowIndex].Value;
            rule.setVariable(parameter, value);
            //If validation changed the value in the special rule, update the DGV accordingly
            if (rule.Variables[parameter].Value != value) dgvParameters[e.ColumnIndex, e.RowIndex].Value = rule.Variables[parameter].Value;
        }
    }
}