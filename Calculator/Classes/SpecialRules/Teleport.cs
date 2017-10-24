using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Teleport : SpecialRule
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
                return "Represents an effect allowing a character to instantly (or near-instantly) transplant from their current position to another as part of the attack.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Either after the ability finishes or immediately before executing it, the character may move up to D inches away from their current position. This position can be "+
                    "anywhere within D inches, up or down, and ignores intervening obstacles.  The destination must be viable: a character cannot teleport into another character or into a wall."+
                    "  Unlike other forms of movement, this kind does not evoke free attacks.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new Leap());
                rules.Add(new Roll());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Teleport";
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
                return "Teleport D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Teleport " + variables["D"].Value;
            }
        }

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new Dictionary<string, SpecialRuleVariable>();
                    var srv = new Distance("D");
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
            return variables["D"].Value * 40;
        }
        #endregion
    }
}