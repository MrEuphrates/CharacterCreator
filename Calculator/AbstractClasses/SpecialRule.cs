using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.Classes;

namespace CharacterCreator.AbstractClasses
{
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
        protected Dictionary<string, SpecialRuleVariable> variables;
        public virtual IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null) variables = new Dictionary<string, SpecialRuleVariable>();
                return variables;
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
        public abstract string listIncompatibleRules();

        public abstract decimal calculateEnergyCost(decimal baseDamage);  //TODO Pretty sure when I start using params, this will change
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
        #endregion
        //=============================================================
    }
}
