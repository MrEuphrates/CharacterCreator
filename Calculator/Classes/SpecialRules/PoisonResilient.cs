﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class PoisonResilient : SpecialRule
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
                return "Represents an effect which harms characters when absorbed or introduced and cannot be resisted naturally. Examples: weaponized poisons; unnatural blights.";
            }
        }

        public override string Effects
        {
            get
            {
                return "This poison causes 1d6xM damage every round for D rounds.";
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
                return "Poison (Resilient)";
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
                return "Resilient Poison 1d6xM D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Resilient Poison 1d6x" + variables["M"].Value + " " + variables["D"].Value;
            }
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new SerializableDictionary<string, SpecialRuleVariable>();
                    var mot = new MultipleOfTen("M");
                    variables.Add(mot.Variable, mot);
                    var str = new Duration("D");
                    variables.Add(str.Variable, str);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return variables["M"].Value * variables["D"].Value * 3;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "3 x M x D";
        }
        #endregion
    }
}
