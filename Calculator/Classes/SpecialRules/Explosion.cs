using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Explosion : SpecialRule
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
                return "Explosions are essentially a combination of other special rules.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Explosion is, in fact, a convenient way to combine three special rules into one. It utilizes the rules for Blast, No Dodge, and Radius.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = new List<SpecialRule>();
                rules.Add(new Blast());
                rules.Add(new NoDodge());
                rules.Add(new Radius());
                rules.Add(new Pull());
                rules.Add(new Slam());
                rules.Add(new Throw());
                rules.Add(new TechBlast());
                rules.Add(new SuperbNoDodge());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Explosion";
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
                return "Explosion R/S";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Explosion " + variables["R"].Value + "/" + variables["S"].Value;
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
                    var srv2 = new MaxTen("S");
                    variables.Add(srv2.Variable, srv2);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return 5 * variables["S"].Value + variables["R"].Value * 0.2m * baseDamage;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "5 x S + R x 20% of the ability's base damage";
        }

        #endregion
    }
}
