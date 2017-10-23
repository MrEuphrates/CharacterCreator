using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Classes.SpecialRuleVariables
{
    public class Radius : AbstractClasses.SpecialRuleVariable
    {
        public Radius(string variable) : base(variable){ }

        public override string Description
        {
            get
            {
                return variable + ", the radius in inches.";
            }
        }

        public override void Validate()
        {
            //Ensure variable is an integer greater than 0.
            if (Value < 1) Value = 1;
        }
    }
}
