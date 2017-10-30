using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CharacterCreator.Classes;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.AbstractClasses
{
    [XmlInclude(typeof(MultipleOfTen))]
    public abstract class SpecialRuleVariable
    {
        protected string variable;
        public string Variable
        {
            get
            {
                Validate();
                return variable;
            }
            set
            {
                variable = value;
                Validate();
            }
        }
        public abstract string Description { get; }
        public int Value { get; set; }
        public abstract void Validate();
        public override string ToString()
        {
            return Variable;
        }
        public SpecialRuleVariable(string variable)
        {
            this.variable = variable;
        }
    }
}
