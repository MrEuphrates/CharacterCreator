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
    #region Attributes
    [XmlInclude(typeof(Distance))]
    [XmlInclude(typeof(Duration))]
    [XmlInclude(typeof(MaxTen))]
    [XmlInclude(typeof(MultipleOfFive))]
    [XmlInclude(typeof(MultipleOfTen))]
    [XmlInclude(typeof(PoisonType))]
    [XmlInclude(typeof(Radius))]
    [XmlInclude(typeof(TenToNegativeTen))]
    #endregion
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
