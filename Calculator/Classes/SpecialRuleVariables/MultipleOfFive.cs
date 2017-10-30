using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Classes.SpecialRuleVariables
{
    public class MultipleOfFive : AbstractClasses.SpecialRuleVariable
    {
        public MultipleOfFive(string variable) : base(variable){ }

        //Can't serialize without a parameterless constructor
        public MultipleOfFive() : base("") { }

        public override string Description
        {
            get
            {
                return variable + ", a multiple of 5.";
            }
        }

        public override void Validate()
        {
            //Ensure M is a multiple of 5.
            if (Value % 5 != 0) Value = Value - Value % 5;
            if (Value < 5) Value = 5;
        }
    }
}
