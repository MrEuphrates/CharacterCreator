﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class NoDeflect : SpecialRule
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
                return "Represents an effect which cannot be deflected by ordinary means, but can still be evaded and resisted by armor. Examples: an instantaneous attack may not have perfect "+
                    "accuracy, but it would be too fast to deflect; a hidden ballistic attack would not offer the defender a chance to deflect the attack.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this special rule cannot be deflected and cannot be blocked or reduced by toughness.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new ArmorBuster());
                rules.Add(new RerollHits());
                rules.Add(new RerollMisses());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "No Deflect";
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
                return "NDe";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return SyntaxSample;
            }
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                return new SerializableDictionary<string, SpecialRuleVariable>();
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return energyModifier * 2;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "2 energy modifiers";
        }
        #endregion
    }
}
