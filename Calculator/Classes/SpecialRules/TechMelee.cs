using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class TechMelee : SpecialRule
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
                return "Represents a melee attack utilizing the character's technical skills rather than their physical strength. Examples: a sword wielded by a robotic third arm; a "+
                    "point-blank gravity attack produced by portable gravity manipulators.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with Tech Melee are melee abilities that attack using the character's Tech stat instead of their Strength stat. This applies to hitting and damage bonuses, "+
                    "but does not apply to anything else using Strength.";
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
                return "Tech Melee";
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
                return "Tech Melee";
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
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return baseDamage * 0.2m;
        }
        #endregion
    }
}