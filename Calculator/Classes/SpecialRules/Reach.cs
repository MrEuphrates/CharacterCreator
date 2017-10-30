using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Reach : SpecialRule
    {
        #region Properties
        public override int CalculationOrder
        {
            get
            {
                return 0;
            }
        }

        public override string Description
        {
            get
            {
                return "Represents the effect of a melee ability which can reach further distances than the traditional melee range.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Melee abilities with this rule may target characters up to R inches away. In all other ways, this ability functions like a melee ability.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new Range());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Reach";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Reach R";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Reach " + variables["R"].Value;
            }
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new SerializableDictionary<string, SpecialRuleVariable>();
                    var srv = new Distance("R");
                    variables.Add(srv.Variable, srv);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            decimal range = variables["R"].Value;
            decimal modifiers = Math.Ceiling(range / 3m);
            return modifiers * energyModifier;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "R / 3 x 1 energy modifier";
        }

        #endregion
    }
}
