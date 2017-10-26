using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Deafen : SpecialRule
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
                return "Represents an effect which cancels a character's ability to perceive or process sound. Examples: flash-bang grenades that overload sound-processing organs; "+
                    "a \"cone - of - silence\" effect, blocking out inbound sound.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Deafened characters automatically lose drawn contests, and suffer a -1 penalty to their contest rolls when flanked.";
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
                return "Deafen";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "Affected characters make a Marksmanship test. If failed, they are deafened for the duration of the effect. This effect lasts D rounds.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Deafen D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Deafen " + variables["D"].Value;
            }
        }

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new Dictionary<string, SpecialRuleVariable>();
                    var srv = new Duration("D");
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
            return variables["D"].Value * 50;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "50 x D";
        }

        #endregion
    }
}
