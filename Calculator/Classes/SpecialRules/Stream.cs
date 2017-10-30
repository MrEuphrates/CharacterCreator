using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

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
                return "An ability with this effect is directed from the attacker to a point on the field, and the affected area is drawn lengthwise (L) along this line.  If combined with Range, "+
                    "the Stream is drawn from the target rather than the attacker, and this ability scatters like with Radius and points directly away from the target location. "+
                    "Characters and objects in the area of effect (L x W) must defend against this ability.  Obstructions will block this ability, unless stated otherwise.";
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

        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            decimal squareInches = variables["L"].Value * variables["W"].Value;
            return Math.Ceiling(squareInches / 5m) * energyModifier;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "(L x W) / 5 x 1 energy modifier";
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if (variables == null)
                {
                    variables = new SerializableDictionary<string, SpecialRuleVariable>();
                    var srv = new Distance("L");
                    variables.Add(srv.Variable, srv);
                    var srv2 = new Distance("W");
                    variables.Add(srv2.Variable, srv2);
                }
                return variables;
            }
        }
    }
}
