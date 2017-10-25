using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Paralyze : SpecialRule
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
                return "Represents an effect causing the loss of the ability to move or feel throughout the body. Examples: some poisons are known to do this; certain injuries can cause "+
                    "temporary or permanent paralysis.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Strength contest against S.  If failed, affected characters are paralyzed for D rounds. Paralyzed characters are utterly helpless, "+
                    "unable to move, act, or defend themselves.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                return new List<SpecialRule>();
            }
        }

        public override string Name
        {
            get
            {
                return "Paralyze";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "Paralyze lasts for D rounds. Unlike Encase, Paralyze's duration is not reduced by the environment or by attacks.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Paralyze S/D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Paralyze " + variables["S"].Value + "/" + variables["D"].Value;
            }
        }

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new Dictionary<string, SpecialRuleVariable>();
                    var srv = new Duration("D");
                    variables.Add(srv.Variable, srv);
                    var srv2 = new MaxTen("S");
                    variables.Add(srv2.Variable, srv2);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //TODO This may not be a fair way to get the cost.  Like, is a Strength 5 Paralyze with a Duration of 2 really as good as a Strength 10 Paralyze with a Duration of 1?
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return variables["D"].Value * 10 * variables["S"].Value;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "10 x D x S";
        }
        #endregion
    }
}
