using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class TechPoisonMalignant : PoisonMalignant
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
                return "Represents an effect which harms characters when absorbed or introduced, but can be resisted naturally. Examples: neuro-toxins; venomous bites.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Strength contest against S to resist the poison. The poison causes damage each round the character fails until they succeed.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = base.IncompatibleRules;
                rules.Add(new PoisonMalignant());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Poison (Malignant)";
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
                return "Malignant Poison 1d6xM S";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                //TODO Returns whatever should appear on the character sheet.
                return "Malignant Poison 1d6x" + variables["M"].Value + " " + variables["S"].Value;
            }
        }

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new Dictionary<string, SpecialRuleVariable>();
                    var mot = new MultipleOfTen("M");
                    variables.Add(mot.Variable, mot);
                    var str = new MaxTen("S");
                    variables.Add(str.Variable, str);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return variables["M"].Value * variables["S"].Value;
        }
        #endregion
    }
}