using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class ArmorBuster : SpecialRule
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
                return "Represents an effect specifically designed for penetrating heavy, vehicle-borne armor.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this effect ignore personal armor and reduce the effectiveness of vehicle and smart armor by 100%. This effect also functions like No Deflect.  " +
                    "Abilities with this rule used against non-vehicles suffer a -2 penalty when trying to hit their target, and double the cost of No Dodge when used in conjunction with it.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new NoArmorReduction());
                rules.Add(new NoDeflect());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Armor Buster";
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

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                return new Dictionary<string, SpecialRuleVariable>();
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return energyModifier * 3;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "3 energy modifiers.";
        }

        #endregion
    }
}
