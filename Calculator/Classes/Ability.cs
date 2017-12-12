using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRules;

namespace CharacterCreator.Classes
{
    public class Ability : INotifyPropertyChanged
    {
        public enum AbilityType { Basic, Special, Ability, Passive }
        //TODO What about "common" abilities, like regen, flying, cloaking, etc.?  How am I going to do those?  What about passive abilities?
        //===================================================================
        #region Properties
        private decimal time = 1;
        public decimal Time
        {
            get
            {
                return time;
            }
            set
            {
                if (value != time)
                {
                    time = value;
                    updateEnergyCost();
                    OnPropertyChanged("Time");
                }
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private decimal energy;
        public decimal Energy
        {
            get { return energy; }
            set
            {
                if (value != energy)
                {
                    energy = value;
                    OnPropertyChanged("Energy");
                }
            }
        }
        public decimal EnergyModifier
        {
            get
            {
                decimal baseMod = BaseDamage * 0.2m;
                if (baseMod % 5 != 0) baseMod = baseMod + (5 - (baseMod % 5));
                return baseMod;
            }
        }
        private decimal baseDamage;
        public decimal BaseDamage
        {
            get { return baseDamage; }
            set
            {
                if (value != baseDamage)
                {
                    baseDamage = value;
                    updateEnergyCost();
                    OnPropertyChanged("BaseDamage");
                }
            }
        }
        private decimal damage;
        public decimal Damage
        {
            get { return damage; }

            set
            {
                if (value != damage)
                {
                    damage = value;
                    OnPropertyChanged("Damage");
                }
            }
        }
        private decimal attacks = 1;
        public decimal Attacks
        {
            get
            {
                return attacks;
            }
            set
            {
                if (value != attacks)
                {
                    attacks = value;
                    updateEnergyCost();
                    OnPropertyChanged("Attacks");
                }
            }
        }
        private double characterPoints;
        public double CharacterPoints
        {
            get
            {
                return characterPoints;
            }
            set
            {
                if(value != characterPoints)
                {
                    characterPoints = value;
                    OnPropertyChanged("CharacterPoints");
                }
            }
        }
        protected bool isCommon = false;
        public bool IsCommon
        {
            get { return isCommon; }
        }
        protected string commonDescription;
        public string CommonDescription
        {
            get
            {
                return commonDescription;
            }
        }
        private bool requiresInput;
        public bool RequiresInput
        {
            get { return requiresInput; }
            set
            {
                if(value != requiresInput)
                {
                    requiresInput = value;
                    OnPropertyChanged("RequiresInput");
                }
            }
        }
        private string inputDescription;
        public string InputDescription
        {
            get { return inputDescription; }
            set
            {
                if(value != inputDescription)
                {
                    inputDescription = value;
                    OnPropertyChanged("InputDescription");
                }
            }
        }
        private List<SpecialRule> specialRules;
        public List<SpecialRule> SpecialRules
        {
            get
            {
                if (specialRules == null) specialRules = new List<SpecialRule>();
                return specialRules;
            }
            set
            {
                if(value != specialRules)
                {
                    specialRules = value;
                    updateEnergyCost();
                    OnPropertyChanged("SpecialRules");
                }
            }
        }
        public string Syntax
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if(Type == AbilityType.Passive) sb.AppendLine("- " + Name + " -/-");
                else
                {
                    sb.Append(Convert.ToInt32(Time) + " ");
                    sb.Append(Name + " ");
                    sb.Append(Convert.ToInt32(Energy) + "/");
                    if (BaseDamage == Damage) sb.Append(Convert.ToInt32(BaseDamage) + "  ");
                    else sb.Append(Convert.ToInt32(BaseDamage) + " (" + Convert.ToInt32(Damage) + ")  ");
                    if (Attacks > 1) sb.Append(Convert.ToInt32(Attacks) + " attacks.  ");
                    if (SpecialRules.Count == 1) sb.Append(SpecialRules[0].SyntaxActual);
                    else if (SpecialRules.Count > 1)
                    {
                        sb.Append(SpecialRules[0].SyntaxActual);
                        for (int i = 1; i < SpecialRules.Count; ++i) sb.Append(", " + SpecialRules[i].SyntaxActual);
                    }
                }
                if (RequiresInput && !IsCommon) sb.Append("  *** " + InputDescription);
                if (RequiresInput && IsCommon) sb.Append("  " + InputDescription);
                return sb.ToString();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public AbilityType Type
        {
            get
            {
                if (BaseDamage == 0) return AbilityType.Ability;
                var countOfRules = SpecialRules.Count;
                if (SpecialRules.Contains(new Range()) || SpecialRules.Contains(new TechRange())) --countOfRules;
                if (BaseDamage > 100 || countOfRules > 1) return AbilityType.Special;
                if (Time < 0) return AbilityType.Passive;
                return AbilityType.Basic;
            }
        }
        //For some reason, IDictionary isn't allowed in a serializable class.  So I'm using a custom dictionary made by Paul Welter.
        public SerializableDictionary<string, AbilityVariable> variables;
        public virtual SerializableDictionary<string, AbilityVariable> Variables
        {
            get
            {
                if (variables == null) variables = new SerializableDictionary<string, AbilityVariable>();
                return variables;
            }
        }
        protected DataTable variableTable;
        public DataTable VariableTable
        {
            get
            {
                if (variableTable == null)
                {
                    variableTable = new DataTable();
                    DataColumn col = new DataColumn();

                    //Add Parameter column
                    col.DataType = System.Type.GetType("System.String");
                    col.ColumnName = "Parameter";
                    col.ReadOnly = true;
                    col.Unique = true;
                    variableTable.Columns.Add(col);

                    //Add Description column
                    col = new DataColumn();
                    col.DataType = System.Type.GetType("System.String");
                    col.ColumnName = "Description";
                    col.ReadOnly = true;
                    col.Unique = false;
                    variableTable.Columns.Add(col);

                    //Add Input column
                    col = new DataColumn();
                    col.DataType = System.Type.GetType("System.Int32");
                    col.ColumnName = "Input";
                    col.ReadOnly = false;
                    col.Unique = false;
                    variableTable.Columns.Add(col);

                    //Add rows
                    DataRow row;
                    foreach (AbilityVariable srv in Variables.Values)
                    {
                        row = variableTable.NewRow();
                        row["Parameter"] = srv.Variable;
                        row["Description"] = srv.Description;
                        row["Input"] = srv.Value;
                        variableTable.Rows.Add(row);
                    }
                }
                return variableTable;
            }
        }
        public bool setVariable(string s, int d)
        {
            if (Variables.Keys.Contains(s))
            {
                Variables[s].Value = d;
                Variables[s].Validate();
                return true;
            }
            return false;
        }
        #endregion
        //===================================================================


        //===================================================================
        #region Methods
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public decimal getEnergyModifier(decimal baseDamage)
        {
            decimal baseMod = baseDamage * 0.2m;
            if (baseMod % 5 != 0) baseMod = baseMod + (5 - (baseMod % 5));
            return baseMod;
        }
        public override bool Equals(object obj)
        {
            //If the param is null, return False
            if (obj == null) return false;

            //If param cannot be cast as Ability, return false
            Ability r = obj as Ability;
            if ((System.Object)r == null) return false;

            //If the names of the abilities match, they are considered equal
            if (this.Name == r.Name) return true;

            return false;
        }
        public bool Equals(SpecialRule r)
        {
            if ((object)r == null) return false;

            //If the names of the abilities match, they are considered equal
            if (this.Name == r.Name) return true;

            return false;
        }
        private void updateEnergyCost()
        {
            //Get the energy modifiers.
            var totalEnergyModifier = EnergyModifier * Attacks;

            //Get energy cost based on time.
            var totalBaseDamage = BaseDamage * Attacks;
            var expectedTime = (totalBaseDamage - totalBaseDamage % 100) / 100;
            if (totalBaseDamage % 100 != 0) ++expectedTime;
            var timeEnergyCost = (expectedTime - Time) * totalEnergyModifier;

            //Get the base energy cost
            var baseEnergyCost = totalBaseDamage / 2;

            //Get the energy cost from the special rules
            decimal specialRulesEnergyCost = 0;
            foreach (SpecialRule rule in SpecialRules) specialRulesEnergyCost += rule.calculateEnergyCost(EnergyModifier);
            specialRulesEnergyCost *= Attacks;

            //Summarize energy costs.
            var totalEnergy = timeEnergyCost + baseEnergyCost + specialRulesEnergyCost;

            //Energy costs are always multiples of 5, so round up.
            if (totalEnergy % 5 != 0) totalEnergy = totalEnergy + (5 - totalEnergy % 5);

            //Set the ability's energy cost.
            Energy = totalEnergy;
        }
        public override string ToString() { return Name; }
        #endregion
        //===================================================================
    }
}