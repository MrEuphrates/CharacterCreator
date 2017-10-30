using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class CounterAttack : SpecialRule
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
                return "Represents an ability which can be optimally used after a character successfully defends themselves. Examples: riposte; an off-hand attack which takes advantage of a "+
                    "free hand in combat.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this rule may be used immediately after the character successfully dodges or deflects an ability. This means the character can interrupt another "+
                    "character's turn. Play continues normally after this ability is executed.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
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
                return "Counter-Attack";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "This special rule may not be applied to an ability with a Time cost greater than 3.";
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

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                return new SerializableDictionary<string, SpecialRuleVariable>();
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //TODO Counter-attack may need to cost more based on what it does.
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return energyModifier;
        }
        public override bool specialRuleIsValid(Ability ability, List<SpecialRule> rules)
        {
            if(ability.Time > 3)
            {
                MessageBox.Show(this.Name + " may not be used with an ability costing more than 3 Time");
                return false;
            }
            return true;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "1 energy modifier";
        }
        #endregion
    }
}