using System.Xml.Serialization;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.AbstractClasses
{//TODO These attributes need to be replaced with the ability variables.
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
    public abstract class AbilityVariable
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
        public AbilityVariable(string variable)
        {
            this.variable = variable;
        }
    }
}
