﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class SuperbAcid : GreaterAcid
    {
        #region Properties

        public override string Description
        {
            get
            {
                return "Represents a particularly persistent physically material harm, usually but not exclusively caused by a chemical reaction. Examples: Acid or Fire.  Superb "+
                    "Acid is even more difficult to remove than Greater Acid.";
            }
        }
        //TODO Have to do the Tech rules, too
        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                //TODO Greater versions are incompatible with their ordinary ones.
                //TODO The special rules for which this is incompatible haven't been made yet.
                List<SpecialRule> rules = new List<SpecialRule>();
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get
            {
                return "Superb Acid";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "A character may sacrifice 5 Time to negate one instance of this effect; otherwise, this effect persists until it is negated. "+
                    "Note that ordinary Acid costs 3 Time to negate one stack.  "+
                    "Instances of this effect still stack.";
            }
        }

        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return variables["M"].Value * 6;
        }

        public override string listIncompatibleRules()
        {
            //TODO Those rules haven't been designed yet.
            throw new NotImplementedException();
        }
        
        #endregion
    }
}
