using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Slam : SpecialRule
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
                return "Represents an ability which propels a target from the attacker through use of the attacker's physical strength.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Strength contest against the attacker. The attacker receives +1 Strength per 50 damage the ability inflicts for this contest only. For every "+
                    "point by which the affected character fails, they are moved 1\" directly away from the attacker, suffering obstruction damage normally.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new Blast());
                rules.Add(new Pull());
                rules.Add(new Range());
                rules.Add(new Throw());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Slam";
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
                return Name;
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return SyntaxSample;
            }
        }

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                return new Dictionary<string, SpecialRuleVariable>();
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return baseDamage * 0.2m;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "20% of the ability's base damage";
        }

        #endregion
    }
}
