﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class RerollMisses : SpecialRule
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
                return "Represents an effect which is exceptionally easy to hit with, or difficult to defend against, but is not so strong as to warrant the effect No Dodge or No Deflect.";
            }
        }

        public override string Effects
        {
            get
            {
                return "When defenders successfully dodge or deflect an ability with this rule, they must do a second, identical contest and accept the second result.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new NoDodge());
                rules.Add(new NoDeflect());
                rules.Add(new RerollHits());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Re-roll Misses";
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
                return "Re-roll Misses";
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
            return energyModifier;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "1 energy modifier";
        }
        #endregion
    }
}
