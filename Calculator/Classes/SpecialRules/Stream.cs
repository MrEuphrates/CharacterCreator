using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    class Stream : AbstractClasses.SpecialRule
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
                return "Represents an effect mimicking a continuous flow, affecting all characters and objects in its path. Examples: flame-thrower.";
            }
        }

        public override string Effects
        {
            get
            {
                return "An ability with this effect is directed from the attacker to a point on the field, and the affected area is drawn lengthwise along this line.  If combined with Range, "+
                    "the Stream is drawn from the target rather than the attacker, and this ability scatters like with Radius and points directly away from the target location. "+
                    "Characters and objects in the area of effect must defend against this ability.  Obstructions will block this ability, unless stated otherwise.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new Radius());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Stream";
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
                return "Stream L W";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Stream " + variables["L"].Value + " " + variables["W"].Value;
            }
        }

        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            decimal squareInches = variables["L"].Value * variables["W"].Value;
            return Math.Ceiling(squareInches / 5m) * 0.2m * baseDamage;
        }
    }
}
