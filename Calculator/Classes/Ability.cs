using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRules;

namespace CharacterCreator.Classes
{
    public class Ability : INotifyPropertyChanged
    {
        public enum AbilityType { Basic, Special, Ability }

        //===================================================================
        #region Properties
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);//TODO Handle property changes.  This includes energy cost calcs, damage calcs, etc.  Have to test with damage first.
            //TODO Some properties, like Damage (actual) and energy, are never set on the form.  If I update those properties in the class, will they reflect on the form?
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        private decimal time = 1;
        public decimal Time
        {
            get
            {
                return time;
            }
            set
            {
                if(value != time)
                {
                    time = value;
                    updateEnergyCost();
                    OnPropertyChanged("Time");//TODO This line needs to be added to every property for which I want to raise the property changed event.
                }
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if(value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private decimal energy;
        public decimal Energy
        {
            get { return energy; }
            set
            {
                if(value != energy)
                {
                    energy = value;
                    OnPropertyChanged("Energy");//TODO Success!  The control on the form reflects the enery cost!  Now I need to bind all of the relevant controls and make sure event handling is setup for the appropriate properties.
                }
            }
        }
        public decimal EnergyModifier
        {
            get
            {
                decimal baseMod = BaseDamage * 0.2m;
                if (baseMod % 5 != 0) baseMod = baseMod + (5 - (baseMod % 5));
                return baseMod;
            }
        }
        private decimal baseDamage;
        public decimal BaseDamage
        {
            get { return baseDamage; }
            set
            {
                if(value != baseDamage)
                {
                    baseDamage = value;
                    updateEnergyCost();
                    OnPropertyChanged("BaseDamage");
                }
            }
        }
        public decimal Damage { get; set; }
        private decimal attacks = 1;
        public decimal Attacks
        {
            get
            {
                return attacks;
            }
            set
            {
                if(value != attacks)
                {
                    attacks = value;
                    updateEnergyCost();
                    OnPropertyChanged("Attacks");
                }
            }
        }
        public double CharacterPoints { get; }
        private bool requiresInput;
        public bool RequiresInput
        {
            get { return requiresInput; }
            set
            {
                if(value != requiresInput)
                {
                    requiresInput = value;
                    OnPropertyChanged("RequiresInput");
                }
            }
        }
        private string inputDescription;
        public string InputDescription
        {
            get { return inputDescription; }
            set
            {
                if(value != inputDescription)
                {
                    inputDescription = value;
                    OnPropertyChanged("InputDescription");
                }
            }
        }
        private List<SpecialRule> specialRules;
        public List<SpecialRule> SpecialRules
        {
            get
            {
                if (specialRules == null) specialRules = new List<SpecialRule>();
                return specialRules;
            }
            set
            {
                if(value != specialRules)
                {
                    specialRules = value;
                    updateEnergyCost();
                    OnPropertyChanged("SpecialRules");
                }
            }
        }
        public string Syntax
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Convert.ToInt32(Time) + " ");
                sb.Append(Name + " ");
                sb.Append(Convert.ToInt32(Energy) + "/");
                if (BaseDamage == Damage) sb.Append(Convert.ToInt32(BaseDamage) + "  ");
                else sb.Append(Convert.ToInt32(BaseDamage) + " (" + Convert.ToInt32(Damage) + ")  ");
                if (Attacks > 1) sb.Append(Convert.ToInt32(Attacks) + " attacks.  ");
                if (SpecialRules.Count == 1) sb.Append(SpecialRules[0].SyntaxActual);
                else if (SpecialRules.Count > 1)
                {
                    sb.Append(SpecialRules[0].SyntaxActual);
                    for (int i = 1; i < SpecialRules.Count; ++i) sb.Append(", " + SpecialRules[i].SyntaxActual);
                }
                if (RequiresInput) sb.Append("  *** " + InputDescription);
                return sb.ToString();
            }
        }
        private AbilityType abilityType;

        public event PropertyChangedEventHandler PropertyChanged;

        public AbilityType Type
        {
            get
            {
                if (BaseDamage == 0) return AbilityType.Ability;
                var countOfRules = SpecialRules.Count;
                if (SpecialRules.Contains(new Range()) || SpecialRules.Contains(new TechRange())) --countOfRules;
                if (BaseDamage > 100 || countOfRules > 1) return AbilityType.Special;
                return AbilityType.Basic;
            }
        }
        #endregion
        //===================================================================


        //===================================================================
        #region Methods
        public decimal getEnergyModifier(decimal baseDamage)
        {
            decimal baseMod = baseDamage * 0.2m;
            if (baseMod % 5 != 0) baseMod = baseMod + (5 - (baseMod % 5));
            return baseMod;
        }
        public override bool Equals(object obj)
        {
            //If the param is null, return False
            if (obj == null) return false;

            //If param cannot be cast as Ability, return false
            Ability r = obj as Ability;
            if ((System.Object)r == null) return false;

            //If the names of the abilities match, they are considered equal
            if (this.Name == r.Name) return true;

            return false;
        }
        public bool Equals(SpecialRule r)
        {
            if ((object)r == null) return false;

            //If the names of the abilities match, they are considered equal
            if (this.Name == r.Name) return true;

            return false;
        }
        private void updateEnergyCost()
        {
            //Get the energy modifiers.
            var totalEnergyModifier = EnergyModifier * Attacks;

            //Get energy cost based on time.
            var totalBaseDamage = BaseDamage * Attacks;
            var expectedTime = (totalBaseDamage - totalBaseDamage % 100) / 100;
            if (totalBaseDamage % 100 != 0) ++expectedTime;
            var timeEnergyCost = (expectedTime - Time) * totalEnergyModifier;

            //Get the base energy cost
            var baseEnergyCost = totalBaseDamage / 2;

            //Get the energy cost from the special rules
            decimal specialRulesEnergyCost = 0;
            foreach (SpecialRule rule in SpecialRules) specialRulesEnergyCost += rule.calculateEnergyCost(EnergyModifier);
            specialRulesEnergyCost *= Attacks;

            //Summarize energy costs.
            var totalEnergy = timeEnergyCost + baseEnergyCost + specialRulesEnergyCost;

            //Energy costs are always multiples of 5, so round up.
            if (totalEnergy % 5 != 0) totalEnergy = totalEnergy + (5 - totalEnergy % 5);

            //Set the ability's energy cost.
            Energy = totalEnergy;
        }
        #endregion
        //===================================================================
    }
}