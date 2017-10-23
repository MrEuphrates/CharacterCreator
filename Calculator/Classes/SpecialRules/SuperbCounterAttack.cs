using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class SuperbCounterAttack : GreaterCounterAttack
    {
        #region Properties

        public override string Description
        {
            get
            {
                return "Represents a truly exceptional ability which can be optimally used after a character successfully defends themselves. Examples: riposte; an off-hand attack which "+
                    "takes advantage of a "+
                    "free hand in combat.  Superb Counter-Attack allows for more Time-intensive abilities to be used than Greater Counter-Attack.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                //TODO Counter attack is unique in that it's restrictions are based on the ability's stats.  Not sure how to handle this, either here or under calculating costs.
                //TODO The special rules for which this is incompatible haven't been made yet.
                List<SpecialRule> rules = new List<SpecialRule>();
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get
            {
                return "Superb Counter-Attack";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "This special rule may not be applied to an ability with a Time cost greater than 7.";
            }
        }

        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //TODO Counter-attack may need to cost more based on what it does.
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return baseDamage * 0.6m;
        }

        public override string listIncompatibleRules()
        {
            //TODO Those rules haven't been designed yet.
            throw new NotImplementedException();
        }
        #endregion
    }
}