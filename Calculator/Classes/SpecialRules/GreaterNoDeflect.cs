using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class GreaterNoDeflect : NoDeflect
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
                return "Represents an effect which cannot be deflected, but can still be evaded and resisted by armor.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this special rule cannot be deflected and cannot be blocked or reduced by toughness, not even by targets with Greater Deflect.";
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
                return "Greater No Deflect";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Greater NDe";
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return baseDamage * 0.6m;
        }

        public override string listIncompatibleRules()
        {
            //TODO Those rules haven't been designed yet.
            throw new NotImplementedException();
        }
        #endregion
    }
}
