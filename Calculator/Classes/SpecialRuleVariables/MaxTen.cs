using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Classes.SpecialRuleVariables
{
    public class MaxTen : AbstractClasses.SpecialRuleVariable
    {
        public MaxTen(string variable) : base(variable){ }

        public override string Description
        {
            get
            {
                return variable + ", ranging from 1 to 10.";
            }
        }

        public override void Validate()
        {
            //Ensure varaible is between 1 and 10.
            if (Value < 1) Value = 1;
            if (Value > 10) Value = 10;
        }
    }
}
