﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class ChangeStrength : ChangeSpeed
    {
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
                return "Represents an effect which temporarily affects a character's Strength.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters may resist this effect with Might test. If they fail, or if they choose not to resist, their Strength is altered by C.  Their new " +
                   "Strength cannot exceed 12, nor be less than 2.  The effects of this rules cannot stack for the same stat, but they can counteract one another, " +
                   "and they can combine or offset other effects like Fear and Stun.";
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
                return "Change Strength";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "+/- C Strength D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                if (variables["C"].Value < 0) return variables["C"].Value + " Strength " + variables["D"].Value;
                return "+" + variables["C"].Value + " Strength " + variables["D"].Value;
            }
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if (variables == null)
                {
                    variables = new SerializableDictionary<string, SpecialRuleVariable>();
                    var srv = new Duration("D");
                    variables.Add(srv.Variable, srv);
                    var srv2 = new TenToNegativeTen("C");
                    variables.Add(srv2.Variable, srv2);
                }
                return variables;
            }
        }
    }
}
