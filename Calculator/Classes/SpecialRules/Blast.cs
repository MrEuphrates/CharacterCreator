using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Blast : SpecialRule
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
                return "Represents a pressure wave capable of exerting significant force on impact. Examples: the blast effect of a powerful explosion; the force exerted by compressed air "+
                    "which is violently released.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Strength contest versus S.  For every point the affected character loses by, they are moved 1\" directly away from the source.  "+
                    "Characters impacting obstructions suffer 10 damage per inch they did not move as a result.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new Pull());
                rules.Add(new Slam());
                rules.Add(new Throw());
                rules.Add(new Explosion());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Blast";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "Characters which draw or win the Strength contest are not affected by this rule.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Blast S";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Blast " + variables["S"].Value;
            }
        }

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new Dictionary<string, SpecialRuleVariable>();
                    var srv = new MaxTen("S");
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
            return variables["S"].Value * 5;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "5 x S";
        }

        #endregion
    }
}
