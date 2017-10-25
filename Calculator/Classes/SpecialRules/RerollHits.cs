using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class RerollHits : SpecialRule
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
                return "Represents an effect which is exceptionally difficult to hit with, or easy to defend against.";
            }
        }

        public override string Effects
        {
            get
            {
                return "When defenders fail to dodge or deflect an ability with this rule, they may do a second, identical contest and accept the second result.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new NoDodge());
                rules.Add(new NoDeflect());
                rules.Add(new RerollMisses());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Re-roll Hits";
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
            return baseDamage * -0.4m;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "-40% of the ability's base damage";
        }
        #endregion
    }
}
