using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Throw : SpecialRule
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
                return "Represents the effect of an ability allowing one character to lift and hurl another.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Strength contest against the attacker. The attacker receives +1 Strength per 50 damage the ability " +
                    "inflicts for this contest only. For every point by which the loser fails (attacker or defender), the victor moves the loser "+
                    "1\" away from them in the direction of their choosing, suffering obstruction damage normally.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new Blast());
                rules.Add(new Slam());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Throw";
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
            return baseDamage * 0.2m;
        }
        #endregion
    }
}
