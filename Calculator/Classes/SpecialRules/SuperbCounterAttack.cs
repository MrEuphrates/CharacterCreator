using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                List<SpecialRule> rules = base.IncompatibleRules;
                rules.Add(new GreaterCounterAttack());
                return rules;
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
        public override bool specialRuleIsValid(Ability ability, List<SpecialRule> rules)
        {
            if (ability.Time > 7)
            {
                MessageBox.Show(this.Name + " may not be used with an ability costing more than 7 Time");
                return false;
            }
            return true;
        }
        public override string howIsEnergyCostCalculated()
        {
            return "60% of the ability's base damage";
        }
        #endregion
    }
}