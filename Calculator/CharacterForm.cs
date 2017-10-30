using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using CharacterCreator.Classes;

namespace CharacterCreator
{
    public partial class CharacterForm : Form
    {
        #region Variables
        Character character;
        double startingCharacterPoints;
        #endregion

        //=================================================================
        #region Methods
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
            if (nudCharacterPoints.Value < 0)
            {
                MessageBox.Show("Your total character points exceeds the limit selected.  Limit: "
                    + startingCharacterPoints + "  Yours: " + nudCharacterPoints.Value);
            }
        }
        #endregion
        //===================================================================


        //============================================================================================================
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

        private void buttonAddAbility_Click(object sender, EventArgs e)
        {
            AbilityForm af = new AbilityForm(character);
            af.ShowDialog();
            refreshListBoxes();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            character.Name = txtName.Text;
        }

        /*TODO
         * Here I am recording information on what it takes to serialize my objects.
         * Regarding special rules, the SpecialRule base class (currently) has to have an XmlInclude attribute for every special rule to indicate they should be serialized.  Need a better way.
         * Regarding variables, I had to use a custom class, SerializableDictionary, to use a dictionary, and as with special rules, I had to add an XmlInclude attribute for every variable
         *      to the base class, SpecialRuleVariable.
         * */
        private void cmdSave_Click(object sender, EventArgs e)
        {
            string path = "C:\\CharacterCreatorTest\\testoutput.coca";
            FileStream outFile = File.Create(path);
            try
            {
                XmlSerializer formatter = new XmlSerializer(character.GetType());
                formatter.Serialize(outFile, character);
                MessageBox.Show("Saved");
            }
            catch (Exception exe)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Exception: " + exe.Message);
                if (exe.InnerException != null) sb.Append("\n\nInner Exception: " + exe.InnerException.Message);
                if (exe.InnerException.InnerException != null) sb.Append("\n\nInner x2 exception: " + exe.InnerException.InnerException.Message);
                if (exe.InnerException.InnerException.InnerException != null) sb.Append("\n\nInner x3 exception: " + exe.InnerException.InnerException.InnerException.Message);
                if (exe.InnerException.InnerException.InnerException.InnerException != null) sb.Append("\n\nInner x4 exception: " + exe.InnerException.InnerException.InnerException.InnerException.Message);
                if (exe.InnerException.InnerException.InnerException.InnerException.InnerException != null) sb.Append("\n\nInner x5 exception: " + exe.InnerException.InnerException.InnerException.InnerException.InnerException.Message);
                if (exe.InnerException.InnerException.InnerException.InnerException.InnerException.InnerException != null) sb.Append("\n\nInner x6 exception: " + exe.InnerException.InnerException.InnerException.InnerException.InnerException.InnerException.Message);
                MessageBox.Show(sb.ToString());
            }
            finally
            {
                outFile.Close();
            }
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            string file = "C:\\CharacterCreatorTest\\testoutput.coca";
            XmlSerializer formatter = new XmlSerializer(character.GetType());
            FileStream characterFile = new FileStream(file, FileMode.Open);
            byte[] buffer = new byte[characterFile.Length];
            characterFile.Read(buffer, 0, (int)characterFile.Length);
            MemoryStream stream = new MemoryStream(buffer);
            try
            {
                Character loadedCharacter = (Character)formatter.Deserialize(stream);
                MessageBox.Show("Here's the syntax of the first special ability: " + loadedCharacter.SpecialAbilities[0].Syntax);
            }
            catch(Exception exe)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Exception: " + exe.Message);
                if (exe.InnerException != null) sb.Append("\n\nInner Exception: " + exe.InnerException.Message);
                MessageBox.Show(sb.ToString());
            }
            finally
            {
                stream.Close();
                characterFile.Close();
            }
            
        }
        #endregion
        //============================================================================================================
    }
}