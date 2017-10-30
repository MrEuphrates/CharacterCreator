using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Roll : SpecialRule
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
                return "Represents an effect allowing a character to roll or similarly dash from their current position as part of the attack.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Either after the ability finishes or immediately before executing it, the character may move up to D inches away from their current position. They may not move "+
                    "vertically and cannot pass through obstructions.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new Leap());
                rules.Add(new Teleport());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Roll";
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
                return "Roll D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Roll " + variables["D"].Value;
            }
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new SerializableDictionary<string, SpecialRuleVariable>();
                    var srv = new Distance("D");
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
            return variables["D"].Value * 20;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "20 x D";
        }

        #endregion
    }
}
