using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Classes.SpecialRuleVariables
{
    public class TenToNegativeTen : AbstractClasses.SpecialRuleVariable
    {
        public TenToNegativeTen(string variable) : base(variable){ }

        //Can't serialize without a parameterless constructor
        public TenToNegativeTen() : base("") { }

        public override string Description
        {
            get
            {
                return variable + ", ranging from -10 to 10.";
            }
        }

        public override void Validate()
        {
            //Ensure variable is between -10 and 10 and isn't 0.
            if (Value == 0) Value = 1;
            if (Value > 10) Value = 10;
            if (Value < -10) Value = 10;
        }
    }
}
