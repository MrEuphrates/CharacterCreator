using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CharacterCreator.Classes;
using CharacterCreator.Classes.SpecialRules;

namespace CharacterCreator.AbstractClasses
{
    #region Attributes
    //TODO I'm trying to easily include all of the special rules
    [XmlInclude(typeof(Acid))]
    [XmlInclude(typeof(ArmorBuster))]
    [XmlInclude(typeof(Blast))]
    [XmlInclude(typeof(Blind))]
    [XmlInclude(typeof(ChangeSpeed))]
    [XmlInclude(typeof(ChangeStrength))]
    [XmlInclude(typeof(ChangeMarksmanship))]
    [XmlInclude(typeof(ChangeTech))]
    [XmlInclude(typeof(CounterAttack))]
    [XmlInclude(typeof(Deafen))]
    [XmlInclude(typeof(DrainTime))]
    [XmlInclude(typeof(Encase))]
    [XmlInclude(typeof(Explosion))]
    [XmlInclude(typeof(Fear))]
    [XmlInclude(typeof(GreaterAcid))]
    [XmlInclude(typeof(GreaterCounterAttack))]
    [XmlInclude(typeof(GreaterIndirect))]
    [XmlInclude(typeof(GreaterNoDeflect))]
    [XmlInclude(typeof(GreaterNoDodge))]
    [XmlInclude(typeof(Heal))]
    [XmlInclude(typeof(IdentifyFriendFoe))]
    [XmlInclude(typeof(Indirect))]
    [XmlInclude(typeof(Leap))]
    [XmlInclude(typeof(NoArmorReduction))]
    [XmlInclude(typeof(NoDeflect))]
    [XmlInclude(typeof(NoDodge))]
    [XmlInclude(typeof(Paralyze))]
    [XmlInclude(typeof(PoisonMalignant))]
    [XmlInclude(typeof(PoisonResilient))]
    [XmlInclude(typeof(Pull))]
    [XmlInclude(typeof(Range))]
    [XmlInclude(typeof(CharacterCreator.Classes.SpecialRules.Radius))]
    [XmlInclude(typeof(RerollMisses))]
    [XmlInclude(typeof(RerollHits))]
    [XmlInclude(typeof(Reach))]
    [XmlInclude(typeof(Roll))]
    [XmlInclude(typeof(Slam))]
    [XmlInclude(typeof(Stream))]
    [XmlInclude(typeof(Stun))]
    [XmlInclude(typeof(SuperbAcid))]
    [XmlInclude(typeof(SuperbCounterAttack))]
    [XmlInclude(typeof(SuperbIndirect))]
    [XmlInclude(typeof(SuperbNoDeflect))]
    [XmlInclude(typeof(SuperbNoDodge))]
    [XmlInclude(typeof(TechAttack))]
    [XmlInclude(typeof(TechBlast))]
    [XmlInclude(typeof(TechBlind))]
    [XmlInclude(typeof(TechDeafen))]
    [XmlInclude(typeof(TechExplosion))]
    [XmlInclude(typeof(TechEncase))]
    [XmlInclude(typeof(TechMelee))]
    [XmlInclude(typeof(TechParalyze))]
    [XmlInclude(typeof(TechRange))]
    [XmlInclude(typeof(Teleport))]
    [XmlInclude(typeof(Throw))]
    [XmlInclude(typeof(Trip))]
    #endregion
    public abstract class SpecialRule
    {
        //=============================================================
        #region Properties
        /*The order in which special rules should have their cost calculated, from 0 to 100.
            For most, this will be 0, meaning the order is unimportant for them; however, for all others,
            the calculation must be made in numerical order.  For example, X Attacks depends on all other
            special rules being calculated before it can be calculated, too.
        */
        public abstract int CalculationOrder { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract List<SpecialRule> IncompatibleRules { get; }
        //TODO Serialization isn't working for spec rules, try making variables public instead of protected
        //TODO For some reason, IDictionary isn't allowed in a serializable class.  So I'm using a custom dictionary made by Paul Welter.
        //public Dictionary<string, SpecialRuleVariable> variables;
        public SerializableDictionary<string, SpecialRuleVariable> variables;
        //public virtual SerializableDictionary<string, SpecialRuleVariable> Variables
        public virtual SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if (variables == null) variables = new SerializableDictionary<string, SpecialRuleVariable>();
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
                    foreach (SpecialRuleVariable srv in Variables.Values)
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
        public abstract string NegationAndDuration { get; }
        public abstract string Effects { get; }
        public abstract string SyntaxSample { get; }
        public abstract string SyntaxActual { get; }
        #endregion
        //=============================================================


        //=============================================================
        #region Abstract Methods
        public abstract decimal calculateEnergyCost(decimal energyModifier);  //TODO Pretty sure when I start using params, this will change
        public abstract string howIsEnergyCostCalculated();
        #endregion
        //=============================================================


        //=============================================================
        #region Methods
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            //If the param is null, return False
            if (obj == null) return false;

            //If param cannot be cast as SpecialRule, return false
            SpecialRule r = obj as SpecialRule;
            if ((System.Object)r == null) return false;

            //If the names of the rules match, they are considered equal
            if (this.Name == r.Name) return true;

            return false;
        }

        public bool Equals(SpecialRule r)
        {
            if ((object)r == null) return false;

            //If the names of the rules match, they are considered equal
            if (this.Name == r.Name) return true;

            return false;
        }

        public string listVariables()
        {
            if (Variables == null || Variables.Count == 0) return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("Variables include:");
            foreach (KeyValuePair<string, SpecialRuleVariable> kvp in Variables) sb.Append("  " + kvp.Value.Description);
            return sb.ToString();
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

        public string listIncompatibleRules()
        {
            var rules = this.IncompatibleRules;
            if (rules.Count == 0) return "";
            if (rules.Count == 1) return "Incompatible with " + rules[0].Name + ".";
            if (rules.Count == 2) return "Incompatible with " + rules[0].Name + " and " + rules[1].Name + ".";
            StringBuilder sb = new StringBuilder();
            sb.Append("Incompatible with " + rules[0].Name);
            for (int i = 1; i < rules.Count; ++i)
            {
                if (i == rules.Count - 1) sb.Append(", and " + rules[i].Name);
                else sb.Append(", " + rules[i].Name);
            }
            sb.Append(".");
            return sb.ToString();
        }

        public virtual bool specialRuleIsValid(Ability ability, List<SpecialRule> rules)
        {
            return true;
        }
        #endregion
        //=============================================================
    }
}