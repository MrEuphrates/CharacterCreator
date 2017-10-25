using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Radius : SpecialRule
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
                return "Represents the effect of an ability to affect everything within a radius of some origin. Examples: frag grenades shower everything within a certain radius in deadly "+
                    "shrapnel; flashbang grenades blind and deafen everything within a radius of its detonation.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Radius is a complicated rule:" +
                    "\nCenter of the radius:" +
                    "\nIf this ability is not combined with Range or Tech Range, the radius is centered on the user." +
                    "\nIf combined with Range or Tech Range, the radius is centered on the target, and the target may be a spot on the field rather than a character or object. If the " +
                    "ability misses, it randomly scatters a distance from the target equal to the difference in the results of the contest roll. Ties count as a difference of 1\" for " +
                    "purposes of this measure." +
                    "\n\nTargets:" +
                    "\nAll objects and characters within R inches of the origin must defend against the attack in order to avoid being hit.  Note that, without No Dodge and No Deflect, " +
                    "affected characters are not automatically hit: they can still defend against the attack." +
                    "\nThe attacker is automatically hit if they are within R inches of the origin." +
                    "\nObstructions can provide partial or total cover against the effect, provided they can absorb the effects of the ability.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                var rules = new List<SpecialRule>();
                rules.Add(new Stream());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Radius";
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
                return "Radius R";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Range " + variables["R"].Value;
            }
        }

        public override IDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new Dictionary<string, SpecialRuleVariable>();
                    var srv = new CharacterCreator.Classes.SpecialRuleVariables.Radius("R");
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
            return baseDamage * variables["R"].Value * 0.2m;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "R x 20% of the ability's base damage";
        }

        #endregion
    }
}
