using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Classes.SpecialRuleVariables
{
    public class Distance : AbstractClasses.SpecialRuleVariable
    {
        public Distance(string variable) : base(variable){ }

        //Can't serialize without a parameterless constructor
        public Distance() : base("") { }

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
