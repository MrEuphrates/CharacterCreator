using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Acid : SpecialRule
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
                return "Represents a physically persistent material harm, usually but not exclusively caused by a chemical reaction. Examples: Acid or Fire.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Each round, affected characters suffer 1d6 x M damage.  This damage is reduced by armor but not toughness.";
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
                return "Acid";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "A character may sacrifice 3 Time to negate one instance of this effect; otherwise, this effect persists until it is negated. "+
                    "Instances of this effect stack.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return Name + " M";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return Name + " " + variables["M"].Value;
            }
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new SerializableDictionary<string, SpecialRuleVariable>();
                    var mot = new MultipleOfTen("M");
                    variables.Add(mot.Variable, mot);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return variables["M"].Value * 4;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "4 x M";
        }

        #endregion
    }
}
