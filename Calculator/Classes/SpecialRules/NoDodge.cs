﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class NoDodge : SpecialRule
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
                return "Represents an effect with characteristics making evasion impossible via ordinary means.  Examples: seeker weapons too accurate to evade; explosions which cause damage through "+
                    "spheric pressure waves.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this special rule cannot be dodged. If the target does not deflect, the ability will hit them.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new RerollHits());
                rules.Add(new RerollMisses());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "No Dodge";
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
                return "NDo";
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
            return energyModifier * 3;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "3 energy modifiers";
        }
        #endregion
    }
}
