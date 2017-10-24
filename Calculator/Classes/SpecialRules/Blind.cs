using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Blind : SpecialRule
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
                return "Represents an effect which cancels a character's ability to perceive or process light. Examples: flash-bang grenades that overload light-sensitive organs; inky cloud "+
                    "which engulfs the character and blots out their surroundings.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Blinded characters operate at half Speed. For purposes of using Deflect or attacking a target, all of the character's stats are halved.";
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
                return "Blind";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "Affected characters make a Marksmanship test. If failed, they are blinded for the duration of the effect. This effect lasts D rounds.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Blind D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                //TODO Returns whatever should appear on the character sheet.
                return "Blind " + variables["D"].Value;
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
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return variables["D"].Value * 100;
        }
        
        #endregion
    }
}
