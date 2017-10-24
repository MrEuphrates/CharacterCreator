using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class TechExplosion : Explosion
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
                return "Tech Explosions are essentially a combination of other special rules.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Tech Explosion is, in fact, a convenient way to combine three special rules into one.  It utilizes the rules for Tech Blast, No Dodge, and Radius.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = base.IncompatibleRules;
                rules.Add(new Explosion());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Tech Explosion";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Tech Explosion R/S";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                //TODO Returns whatever should appear on the character sheet.
                return "Tech Explosion " + variables["R"].Value + "/" + variables["S"].Value;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            var moddedS = variables["S"].Value + 3;
            return 5 * moddedS + variables["R"].Value * 0.2m * baseDamage;
        }
        
        #endregion
    }
}
