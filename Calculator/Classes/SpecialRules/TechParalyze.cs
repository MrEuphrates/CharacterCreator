using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class TechParalyze : Paralyze
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
                return "Represents an effect causing the loss of the ability to move or feel throughout the body.  Unlike Paralyze, this represents an effect produced by technomancy and " +
                    "can only be effectively resisted likewise.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Tech contest against S.  If failed, affected characters are paralyzed for D rounds. Paralyzed characters are utterly helpless, "+
                    "unable to move, act, or defend themselves.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = base.IncompatibleRules;
                rules.Add(new Paralyze());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Tech Paralyze";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Tech Paralyze S/D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Tech Paralyze " + variables["S"].Value + "/" + variables["D"].Value;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //TODO This may not be a fair way to get the cost.  Like, is a Strength 5 Paralyze with a Duration of 2 really as good as a Strength 10 Paralyze with a Duration of 1?
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            var moddedS = variables["S"].Value + 3;
            return variables["D"].Value * 10 * moddedS;
        }
        public override string howIsEnergyCostCalculated()
        {
            return "10 x (S + 3) x D";
        }
        #endregion
    }
}
