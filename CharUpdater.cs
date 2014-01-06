using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ShadowrunCharacterMaker
{
    public partial class CharUpdater : Form
    {

        NewCharacter newChar = new NewCharacter();
        Character character = new Character();                
        CharacterRaceSwitched raceSwitch = new CharacterRaceSwitched();

        public CharUpdater()
        {
            InitializeComponent();

            newChar.Create();

            System.Collections.Generic.List<AttributeUpDown> upDowns = new System.Collections.Generic.List<AttributeUpDown>();
            upDowns.Add(agilityUpDown);
            upDowns.Add(strengthUpDown);
            upDowns.Add(bodyUpDown);
            upDowns.Add(reactionUpDown);
            upDowns.Add(logicUpDown);
            upDowns.Add(charismaUpDown);
            upDowns.Add(intuitionUpDown);
            upDowns.Add(willpowerUpDown);
            upDowns.Add(magicUpDown);
            upDowns.Add(resonanceUpDown);
            upDowns.Add(edgeUpDown);

            foreach (AttributeUpDown n in upDowns)
            {
                n.SetParamCharacter(character, buildPoints);
            }

        }

        //adjusts attributes according to race per the methods in NewCharacter
        public void raceBox_SelectedIndexChanged(object sender, EventArgs e)
        {            
            switch (raceBox.Text)
            {
                case "Human":
                    this.SaveAttributes();
                    raceSwitch.StoreValues(character, newChar);
                    buildPoints.Text = character.buildPoints.ToString();                                        
                    if (raceSwitch.humanSwitch == false)
                    {
                        newChar.CreateHuman();
                        character.SetNewCharacterAttributes(newChar);
                        buildPoints.Text = character.buildPoints.ToString();
                    }
                    else
                    {
                        newChar.CreateHuman();
                        character.race = raceBox.Text;
                        raceSwitch.GetRaceValues(character);
                        buildPoints.Text = character.buildPoints.ToString();
                    }
                    this.PopulateValues();
                    break;
                case "Troll":
                    this.SaveAttributes();
                    raceSwitch.StoreValues(character, newChar);
                    if (raceSwitch.trollSwitch == false)
                    {
                        newChar.CreateTroll();
                        character.SetNewCharacterAttributes(newChar);
                        buildPoints.Text = character.buildPoints.ToString();
                    }
                    else
                    {
                        newChar.CreateTroll();
                        character.race = raceBox.Text;
                        raceSwitch.GetRaceValues(character);
                        buildPoints.Text = character.buildPoints.ToString();
                    }
                    this.PopulateValues();
                    break;
                case "Ork": 
                    this.SaveAttributes();
                    raceSwitch.StoreValues(character, newChar);
                    if (raceSwitch.orkSwitch == false)
                    {
                        newChar.CreateOrk();
                        character.SetNewCharacterAttributes(newChar);
                        buildPoints.Text = character.buildPoints.ToString();
                    }
                    else
                    {
                        newChar.CreateOrk();
                        character.race = raceBox.Text;
                        raceSwitch.GetRaceValues(character);
                        buildPoints.Text = character.buildPoints.ToString();
                    }
                    this.PopulateValues();                    
                    break;
                case "Elf": 
                    this.SaveAttributes();
                    raceSwitch.StoreValues(character, newChar);
                    if (raceSwitch.elfSwitch == false)
                    {
                        newChar.CreateElf();
                        character.SetNewCharacterAttributes(newChar);
                        buildPoints.Text = character.buildPoints.ToString();
                    }
                    else
                    {
                        newChar.CreateElf();
                        character.race = raceBox.Text;
                        raceSwitch.GetRaceValues(character);
                        buildPoints.Text = character.buildPoints.ToString();
                    }
                    this.PopulateValues();
                    break;
                case "Dwarf": 
                    this.SaveAttributes();
                    raceSwitch.StoreValues(character, newChar);
                    if (raceSwitch.dwarfSwitch == false)
                    {
                        newChar.CreateDwarf();
                        character.SetNewCharacterAttributes(newChar);
                        buildPoints.Text = character.buildPoints.ToString();
                    }
                    else
                    {
                        newChar.CreateDwarf();
                        character.race = raceBox.Text;
                        raceSwitch.GetRaceValues(character);
                        buildPoints.Text = character.buildPoints.ToString();
                    }
                    this.PopulateValues();
                    break;
                default: break;

            }
        }

        public void PopulateValues()
        {

            agilityUpDown.Minimum = newChar.agility[0];
            agilityUpDown.Maximum = newChar.agility[1];
            agilityUpDown.Value = character.agility;

            strengthUpDown.Minimum = newChar.strength[0];
            strengthUpDown.Maximum = newChar.strength[1];
            strengthUpDown.Value = character.strength;

            reactionUpDown.Minimum = newChar.reaction[0];
            reactionUpDown.Maximum = newChar.reaction[1];
            reactionUpDown.Value = character.reaction;

            bodyUpDown.Minimum = newChar.body[0];
            bodyUpDown.Maximum = newChar.body[1];
            bodyUpDown.Value = character.body;

            logicUpDown.Minimum = newChar.logic[0];
            logicUpDown.Maximum = newChar.logic[1];
            logicUpDown.Value = character.logic;

            willpowerUpDown.Minimum = newChar.willpower[0];
            willpowerUpDown.Maximum = newChar.willpower[1];
            willpowerUpDown.Value = character.willpower;

            intuitionUpDown.Minimum = newChar.intuition[0];
            intuitionUpDown.Maximum = newChar.intuition[1];
            intuitionUpDown.Value = character.intuition;

            charismaUpDown.Minimum = newChar.charisma[0];
            charismaUpDown.Maximum = newChar.charisma[1];
            charismaUpDown.Value = character.charisma;

            edgeUpDown.Minimum = newChar.edge[0];
            edgeUpDown.Maximum = newChar.edge[1];
            edgeUpDown.Value = character.edge;

            magicUpDown.Maximum = newChar.essence;
            magicUpDown.Value = character.magic;

            resonanceUpDown.Maximum = newChar.essence;
            resonanceUpDown.Value = character.resonance;
            
            InitiativeText.Text = character.initiative.ToString();

            EssenceText.Text = character.essence.ToString();

            buildPoints.Text = character.buildPoints.ToString();
            raceBox.Text = character.race;
        }


        //this is code to adjust the maximum value of the attribute up downs. Only one attribute can max out.
        //there is corresponding code in the AttributeUpDown class and in the Character class that works to achieve this
        public void AttributeUpDown_ValueChanged(object sender, EventArgs e)
        {
            AttributeUpDown attribute = (AttributeUpDown)sender;

            System.Collections.Generic.List<AttributeUpDown> upDowns = new System.Collections.Generic.List<AttributeUpDown>();
            upDowns.Add(agilityUpDown);
            upDowns.Add(strengthUpDown);
            upDowns.Add(bodyUpDown);
            upDowns.Add(reactionUpDown);
            upDowns.Add(logicUpDown);
            upDowns.Add(charismaUpDown);
            upDowns.Add(intuitionUpDown);
            upDowns.Add(willpowerUpDown);
            

            if (character.attributeMax == false)
            {
                if (attribute.Value == attribute.Maximum)
                {
                    upDowns.Remove(attribute);

                    foreach (AttributeUpDown n in upDowns)
                    {
                        n.Maximum = n.Maximum - 1;
                        n.maxReached = true;
                    }

                    character.attributeMax = true;
                }
            }
            else if (character.attributeMax == true && attribute.maxReached == false)
            {
                upDowns.Remove(attribute);

                foreach (AttributeUpDown n in upDowns)
                {
                    n.Maximum = n.Maximum + 1;
                    n.maxReached = false;
                }

                character.attributeMax = false;
            }
        }

        public void positiveButton_Click(object sender, EventArgs e)
        {
            PositiveQualities posQual = new PositiveQualities(character, QualitiesSelected, this);
            posQual.ShowDialog();
        }

        public void InitializeMagic()
        {
            magicUpDown.Minimum = 1;
            magicUpDown.Value = 1;
        }

        public void InitializeResonance()
        {
            resonanceUpDown.Minimum = 1;
            resonanceUpDown.Value = 1;
        }

        public void SaveAttributes()
        {
            character.agility = (int)agilityUpDown.Value;
            character.body = (int)bodyUpDown.Value;
            character.strength = (int)strengthUpDown.Value;
            character.reaction = (int)reactionUpDown.Value;
            character.logic = (int)logicUpDown.Value;
            character.charisma = (int)charismaUpDown.Value;
            character.intuition = (int)intuitionUpDown.Value;
            character.willpower = (int)willpowerUpDown.Value;
            character.edge = (int)edgeUpDown.Value;
            character.magic = (int)magicUpDown.Value;
            character.resonance = (int)resonanceUpDown.Value;            
        }

        public void ExceptionalAttribute()
        {

        }

        public void Aptitude()
        {

        }

        public void SaveButton_Click(object sender, EventArgs e)
        {   
            saveCharacter.ShowDialog();
            this.SaveAttributes();
            string filename = saveCharacter.InitialDirectory + saveCharacter.FileName;
            character.SaveCharacter(character,saveCharacter.FileName);
            character.PopulateQualityList(QualitiesSelected, character.listOfSelectedPositiveQualities);
        }

        public void LoadButton_Click(object sender, EventArgs e)
        {
            loadCharacter.ShowDialog();
            string filename = loadCharacter.FileName;
            character = character.LoadCharacter(character, filename);
            newChar.LoadRace(character.race);
            this.PopulateValues();
            character.RetrieveQualityList(QualitiesSelected, character.listOfSelectedPositiveQualities);
        }
    }
}
