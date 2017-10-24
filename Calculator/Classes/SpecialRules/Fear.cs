using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Fear : SpecialRule
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
                return "Represents an effect instilling fear in another creature, affecting their ability to focus and fight effectively. Examples: a kind of nightmare effect, planting "+
                    "hallucinations in the target's brain; a blood-curdling roar, awakening the target's primal fears.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Might contest against M. For every point the affected character loses by, their stats are reduced by 1.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new Stun());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Fear";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "Fear persists until it is overcome. Affected characters make a Might test every round, negating the Fear once this test passes. Note that unlike the initial effect "+
                    "requiring a contest against M, this is a test, not a contest.  Fear does not stack.  Affected " +
                    "characters which draw or win the contest are not affected by Fear.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Fear M";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                //TODO Returns whatever should appear on the character sheet.
                return "Fear " + variables["M"].Value;
            }
        }

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new Dictionary<string, SpecialRuleVariable>();
                    var srv = new MaxTen("M");
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
            return variables["M"].Value * 20;
        }
        
        #endregion
    }
}
