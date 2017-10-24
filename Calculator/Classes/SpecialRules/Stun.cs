using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Stun : SpecialRule
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
                return "Represents an effect which stuns a character, disorienting them.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Strength contest (for melee stun) and a Marksmanship contest (for non-melee stun) against P.  For every point the affected character loses "+
                    "by, their stats are reduced by 1.  Affected characters which draw or win the contest are not affected by Stun.  Stun does not stack.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new Fear());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Stun";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "Stun lasts for one round.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Stun P";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Stun " + variables["P"].Value;
            }
        }

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new Dictionary<string, SpecialRuleVariable>();
                    var srv = new MaxTen("P");
                    variables.Add(srv.Variable, srv);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return variables["P"].Value * 10;
        }
        
        #endregion
    }
}
