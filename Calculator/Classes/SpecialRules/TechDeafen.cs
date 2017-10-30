using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class TechDeafen : Deafen
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
                return "Represents an effect which cancels a character's ability to perceive or process sound.  Unlike Deafen, this effect is produced via technomancy and can only be "+
                    "effectively resisted via a target's technical skill.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = base.IncompatibleRules;
                rules.Add(new Deafen());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Tech Deafen";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "Affected characters make a Tech test. If failed, they are deafened for the duration of the effect. This effect lasts D rounds.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Tech Deafen D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Tech Deafen " + variables["D"].Value;
            }
        }
        #endregion
    }
}
