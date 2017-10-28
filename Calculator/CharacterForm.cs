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
using System.Xml.Serialization;
using System.IO;

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

            refreshListBoxes();
        }
        private void refreshListBoxes()
        {
            //Bind the abilities lists to their appropriate listboxes.
            listBoxAttacksBasic.DataSource = null;
            listBoxAttacksBasic.DataSource = character.BasicAttacks;
            listBoxAttacksBasic.DisplayMember = "Syntax";

            listBoxAttacksSpecial.DataSource = null;
            listBoxAttacksSpecial.DataSource = character.SpecialAttacks;
            listBoxAttacksSpecial.DisplayMember = "Syntax";

            listBoxAbilities.DataSource = null;
            listBoxAbilities.DataSource = character.SpecialAbilities;
            listBoxAbilities.DisplayMember = "Syntax";
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
            updateStats();//TODO If this is all these events do, they should be using the same event handler, rather than four different ones.
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
        private void buttonAddAbility_Click(object sender, EventArgs e)
        {
            AbilityForm af = new AbilityForm(character);
            af.ShowDialog();
            refreshListBoxes();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string path = "D:\\CharacterCreatorTest\\testoutput";
            FileStream outFile = File.Create(path);
            XmlSerializer formatter = new XmlSerializer(character.GetType());
            formatter.Serialize(outFile, character);
            outFile.Close();
            MessageBox.Show("Saved");
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            string file = "D:\\CharacterCreatorTest\\testoutput";
            XmlSerializer formatter = new XmlSerializer(character.GetType());
            FileStream characterFile = new FileStream(file, FileMode.Open);
            byte[] buffer = new byte[characterFile.Length];
            characterFile.Read(buffer, 0, (int)characterFile.Length);
            MemoryStream stream = new MemoryStream(buffer);
            //return (List<A>)formatter.Deserialize(stream);
            Character loadedCharacter = (Character)formatter.Deserialize(stream);
            MessageBox.Show(loadedCharacter.Name);
            stream.Close();
            characterFile.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            character.Name = txtName.Text;
        }
        #endregion


    }
}
