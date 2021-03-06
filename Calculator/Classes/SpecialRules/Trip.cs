﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Trip : AbstractClasses.SpecialRule
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
                return "Represents an effect which throws a character off their feet.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Strength contest (for melee abilities) and Marksmanship contest (for non-melee abilities) against the "+
                    "attacker. Affected characters losing this contest are tripped. Tripped characters cannot move or evade.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
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
                return "Trip";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "This effect ends the moment a character is not in base-contact with an enemy, or a round passes without an enemy attacking them.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return Name;
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
            return 40;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "40";
        }
        #endregion
    }
}
