using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class IdentifyFriendFoe : SpecialRule
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
                return "Represents an ability with the capacity to identify friend from foe.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this rule will not harm allies, nor help foes.";
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
                return "Identify Friend/Foe";
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
                return "IFF";
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
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            //TODO Should IFF be damage-based, or should it depend on the effects of the ability?
            return energyModifier;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "1 energy modifier";
        }
        #endregion
    }
}
