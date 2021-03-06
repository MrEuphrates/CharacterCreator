﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class SuperbNoDeflect : NoDeflect
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
                return "Represents an effect which cannot ever be deflected, but can still be evaded and resisted by armor.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this special rule cannot be deflected and cannot be blocked or reduced by toughness, not even by targets with Superb Deflect.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = base.IncompatibleRules;
                rules.Add(new GreaterNoDeflect());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Superb No Deflect";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Superb NDe";
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return energyModifier * 4;
        }
        public override string howIsEnergyCostCalculated()
        {
            return "4 energy modifiers";
        }
        #endregion
    }
}
