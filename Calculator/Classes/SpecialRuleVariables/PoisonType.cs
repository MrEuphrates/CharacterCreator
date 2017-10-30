using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Classes.SpecialRuleVariables
{
    public class PoisonType : AbstractClasses.SpecialRuleVariable
    {
        public enum PType { Malignant, Resilient}
        public PType poisonType;

        public PoisonType(string variable) : base(variable){ }
        
        //Can't serialize without a parameterless constructor
        public PoisonType() : base("") { }

        public PoisonType(PType type) : base("")
        {
            string variable;
            this.poisonType = type;
            if (poisonType == PType.Malignant) variable = "Malignant";
            else variable = "Resilient";
            this.variable = variable;
        }

        public override string Description
        {
            get
            {
                return variable + ", the distance in inches.";
            }
        }

        public override void Validate()
        {
            //Ensure variable is an integer greater than 0.
            if (Value < 1) Value = 1;
        }
    }
}
