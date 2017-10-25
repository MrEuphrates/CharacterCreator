﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using System.Windows.Forms;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Indirect : SpecialRule
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
                return "Represents an effect which doesn't require a clear line of sight to its target in order to affect it. Examples: mortar weapons lob their shots over intervening " +
                    "terrain; seeker weapons capable of navigating obstacles.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with Indirect do not need line of site to target or affect a character. This does not enable the ability to target characters which are out of range, "+
                    "invisible, or unreachable, such as in a closed space.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                //TODO This rule is incompatible with an ability which isn't ranged, but I don't know how to handle that yet.
                return new List<SpecialRule>();
            }
        }

        public override string Name
        {
            get
            {
                return "Indirect";
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
        public override bool specialRuleIsValid(Ability ability, List<SpecialRule> rules)
        {
            bool isValid = false;
            if (rules.Contains(new Range())) isValid = true;
            if (rules.Contains(new TechRange())) isValid = true;
            if (rules.Contains(new Reach())) isValid = true;
            if (!isValid) MessageBox.Show(Name + " is incompatible with melee abilities.  Please select Range, Tech Range, or Reach first.");
            return isValid;
        }
        #endregion
    }
}
