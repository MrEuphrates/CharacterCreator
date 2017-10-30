using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Range : SpecialRule
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
                return "Represents the effect of an ability capable of acting on targets outside of melee.  Examples: firearms; throwing weapons.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this special rule may target anything up to R inches away from the attacker, provided that line-of-sight can be drawn from the attacker to the defender.  "+
                    "Using this ability while in melee allows enemies in melee to make a free Normal attack before the Range attack is made.  Abilities with this rule use the Marksmanship "+
                    "stat to attack, and attacks receive bonus damage using this stat.  Attackers without a Marksmanship stat cannot use this special rule unless the ability includes the "+
                    "No Dodge and No Deflect special rules.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new TechMelee());
                rules.Add(new Reach());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Range";
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
                return "Range R";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Range " + variables["R"].Value;
            }
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new SerializableDictionary<string, SpecialRuleVariable>();
                    var srv = new Distance("R");
                    variables.Add(srv.Variable, srv);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            decimal range = variables["R"].Value;
            decimal modifiers = Math.Ceiling(range / 5m);
            return modifiers * energyModifier;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "R / 5 x 1 energy modifier";
        }

        #endregion
    }
}
