using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes.CommonAbilities
{
    public class AbilityPassive : CharacterCreator.Classes.Ability
    {
        public AbilityPassive()
        {
            Time = -1;
            Energy = -1;
            Damage = -1;
            RequiresInput = true;
        }
    }
}
