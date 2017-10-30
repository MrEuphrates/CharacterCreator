using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class TechBlast : Blast
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
                return "Represents a pressure wave capable of exerting significant force on impact.  Unlike Blast, this represents an effect which can only be effectively resisted via " +
                    "the target's technical prowess, rather than more conventional means.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Functions like Blast, except that affected characters make a Tech contest versus S, rather than a Strength contest.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = base.IncompatibleRules;
                rules.Add(new Blast());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Tech Blast";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "Characters which draw or win the Tech contest are not affected by this rule.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Tech Blast S";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Tech Blast " + variables["S"].Value;
            }
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new SerializableDictionary<string, SpecialRuleVariable>();
                    var srv = new MaxTen("S");
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
            decimal moddedS = variables["S"].Value + 3;
            return moddedS * 5;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "(S + 3) x 5";
        }
        #endregion
    }
}
