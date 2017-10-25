using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class SuperbNoDodge : NoDodge
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
                return "Represents an effect with characteristics making evasion utterly impossible.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this special rule cannot be dodged, not even by a target with Superb Dodge.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = base.IncompatibleRules;
                rules.Add(new GreaterNoDodge());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Superb No Dodge";
            }
        }
        

        public override string SyntaxSample
        {
            get
            {
                return "Superb NDo";
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return baseDamage * 1.2m;
        }
        public override string howIsEnergyCostCalculated()
        {
            return "120% of the ability's base damage";
        }
        #endregion
    }
}
