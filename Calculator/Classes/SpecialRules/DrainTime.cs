using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class DrainTime : SpecialRule
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
                return "Represents an effect causing a creature to waste or somehow lose time, leaving them with less of it to act on their own turn.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Might test. If failed, they lose D Time. Any excess loss is carried over into the next round.";
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
                return "Drain Time";
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
                return "Drain Time D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Drain Time " + variables["D"].Value;
            }
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new SerializableDictionary<string, SpecialRuleVariable>();
                    var srv = new MaxTen("D");
                    variables.Add(srv.Variable, srv);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return variables["D"].Value * 25;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "25 x D";
        }

        #endregion
    }
}
