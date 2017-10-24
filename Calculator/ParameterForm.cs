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
            //dataSet = new DataSet();
            //dataSet.Tables.Add(rule.VariableTable);
            dgvParameters.DataSource = rule.VariableTable;
        }
    }
}