using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator.Classes;

namespace CharacterCreator
{
    public partial class CharacterForm : Form
    {
        #region Variables
        Character character;
        double startingCharacterPoints;
        #endregion
        public CharacterForm(double characterPoints)
        {
            InitializeComponent();
            nudCharacterPoints.Value = (int)characterPoints;
            startingCharacterPoints = characterPoints;
            character = new Character();
            updateStats();
        }

        private void updateStats()
        {
            int speed, strength, marksmanship, tech;
            speed = (int)nudSpeed.Value;
            strength = (int)nudStrength.Value;
            marksmanship = (int)nudMarksmanship.Value;
            tech = (int)nudTech.Value;

            character.Speed = speed;
            character.Strength = strength;
            character.Marksmanship = marksmanship;
            character.Tech = tech;
            nudMight.Value = (int)character.calculateMight();

            updateRemainingCharacterPoints();
        }
        private void updateRemainingCharacterPoints()
        {
            nudCharacterPoints.Value = (int)startingCharacterPoints - (int)character.calculateCharacterPoints();
            validateCharacter();
        }
        private void validateCharacter()
        {
            if(nudCharacterPoints.Value < 0)
            {
                MessageBox.Show("Your total character points exceeds the limit selected.  Limit: " 
                    + startingCharacterPoints + "  Yours: " + nudCharacterPoints.Value);
            }
        }

        #region Event Methods
        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            updateStats();
        }
        private void nudStrength_ValueChanged(object sender, EventArgs e)
        {
            updateStats();
        }
        private void nudMarksmanship_ValueChanged(object sender, EventArgs e)
        {
            updateStats();
        }
        private void nudTech_ValueChanged(object sender, EventArgs e)
        {
            updateStats();
        }
        #endregion

        private void buttonAddAbility_Click(object sender, EventArgs e)
        {
            AbilityForm af = new AbilityForm(character);
            af.ShowDialog();
        }
    }
}
