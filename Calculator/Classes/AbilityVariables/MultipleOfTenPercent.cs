namespace CharacterCreator.Classes.SpecialRuleVariables
{
    public class MultipleOfTenPercent : AbstractClasses.AbilityVariable
    {
        public MultipleOfTenPercent(string variable) : base(variable){ }

        //Can't serialize without a parameterless constructor
        public MultipleOfTenPercent() : base("") { }

        public override string Description
        {
            get
            {
                return variable + ", a multiple of 10% up to 50%.";
            }
        }

        public override void Validate()
        {
            //Ensure M is a multiple of 10, at least 10, and no more than 50.
            if (Value % 10 != 0) Value = Value - Value % 10;
            if (Value < 10) Value = 10;
            if (Value > 50) Value = 50;
        }
    }
}
