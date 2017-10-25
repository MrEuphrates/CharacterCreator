using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class TechRange : SpecialRule
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
                return "Represents a ranged attack utilizing the character's technical skills rather than their marksmanship abilities. Examples: a gun wielded by a robotic third arm; "+
                    "a fireball attack produced by a powerful gauntlet.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this special rule may target anything up to R inches away from the attacker, provided that line-of-sight can be drawn from the attacker to the defender.  "+
                    "Using this ability while in melee allows enemies in melee to make a free Normal attack before the Range attack is made.  Unlike with Range, abilities with this rule "+
                    "use the Tech stat to attack.  Using the Tech stat affects hitting and bonus damage, but nothing else that would otherwise use Marksmanship.  Attackers without a Tech "+
                    "stat cannot use this special rule unless the ability includes the "+
                    "No Dodge and No Deflect special rules.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new TechMelee());
                rules.Add(new Range());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Tech Range";
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
                return "Tech Range R";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Tech Range " + variables["R"].Value;
            }
        }

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new Dictionary<string, SpecialRuleVariable>();
                    var srv = new Distance("R");
                    variables.Add(srv.Variable, srv);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            //TODO Range is interesting because it doesn't work quite like other special rules in its affect on an ability.  Not sure how to handle that yet.
            decimal range = variables["R"].Value;
            decimal modifiers = Math.Ceiling(range / 5m);
            ++modifiers;
            return modifiers * 0.2m * baseDamage;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "((R / 5) + 1) x 20% of the ability's base damage";
        }
        #endregion
    }
}
