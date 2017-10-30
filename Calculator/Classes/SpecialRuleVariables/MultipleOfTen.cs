using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Classes.SpecialRuleVariables
{
    public class MultipleOfTen : AbstractClasses.SpecialRuleVariable
    {
        public MultipleOfTen(string variable) : base(variable){ }

        //TODO Can't serialize without a parameterless constructor
        public MultipleOfTen() : base("") { }

        public override string Description
        {
            get
            {
                return variable + ", a multiple of 10.";
            }
        }

        public override void Validate()
        {
            //Ensure M is a multiple of 10.
            if (Value % 10 != 0) Value = Value - Value % 10;
            if (Value < 10) Value = 10;
        }
    }
}
