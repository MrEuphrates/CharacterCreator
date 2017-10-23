using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class TechAttack : SpecialRule
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
                return "Tech Attacks are made strictly or predominantly through the SupleNet, bypassing ordinary means of defense.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Tech Attack indicates this attack cannot be deflected with the ordinary stat (i.e. Strength or Marksmanship) but instead the necessary stat is Tech.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                //TODO The special rules for which this is incompatible haven't been made yet.
                List<SpecialRule> rules = new List<SpecialRule>();
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get
            {
                return "Tech Attack";
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
                return "Tech Attack";
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

        public override string listIncompatibleRules()
        {
            //TODO Those rules haven't been designed yet.
            throw new NotImplementedException();
        }
        #endregion
    }
}