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
    public partial class PositiveQualities : Form
    {

        Character character;
        ListBox quallist;
        CharUpdater charupdater;

        public PositiveQualities(Character charpass, ListBox qualpass, CharUpdater charupdaterpass)
        {            
            InitializeComponent();

            character = charpass;
            quallist = qualpass;
            charupdater = charupdaterpass;

            if (character.magic > 0)
            {
                PQualitiesList.Items.Remove("Adept");
                PQualitiesList.Items.Remove("Magician");
                PQualitiesList.Items.Remove("Mystic Adept");
                PQualitiesList.Items.Remove("Technomancer");
            }
            
            
        }

        private void PositiveQualities_Load(object sender, EventArgs e)
        {

        }

        public void AddPQuality_Click(Object sender, EventArgs e)
        {
            switch (PQualitiesList.Text)
            {
                case "Adept":
                    var result =MessageBox.Show("By selecting this you cannot choose Magician, Technomancer, or Mystic Adept", "Magic Warning",
                        MessageBoxButtons.OKCancel, 
                        MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        character.adept = true;
                        charupdater.InitializeMagic();
                        quallist.Items.Add("Adept");
                        PQualitiesList.Items.Remove("Magician");
                        PQualitiesList.Items.Remove("Technomancer");
                        PQualitiesList.Items.Remove("Mystic Adept");
                        character.buildPoints = character.BuildPointCost(character.buildPoints, 5, true, false);
                        break;
                    }
                    else
                    {
                        break;
                    }
                case "Ambidextrous": character.ambidextrous = true;
                    quallist.Items.Add("Ambidextrous");
                    PQualitiesList.Items.Remove("Ambidextrous");
                    character.buildPoints = character.BuildPointCost(character.buildPoints, 5, true, false);
                    break;
                case "Animal Empathy": character.animalEmpathy = true;
                    quallist.Items.Add("Animal Empathy");
                    PQualitiesList.Items.Remove("Animal Empathy");
                    character.buildPoints = character.BuildPointCost(character.buildPoints, 10, true, false);
                    break;
                case "Aptitude": character.aptitude = true;
                    quallist.Items.Add("Aptitude");
                    PQualitiesList.Items.Remove("Aptitude");
                    character.buildPoints = character.BuildPointCost(character.buildPoints, 10, true, false);
                    break;
                case "Astral Chameleon": 
                    break;
                case "Blandness": break;
                case "Codeslinger": break;
                case "Double Jointed": break;
                case "Erased Criminal Sin": break;
                case "Erased Any Sin": break;
                case "Exceptional Attribute": break;
                case "First Impression": break;
                case "Focused Concentration Rating One": break;
                case "Focused Concentration Rating Two": break;
                case "Guts": break;
                case "High Pain Tolerance Rating One": break;
                case "High Pain Tolerance Rating Two": break;
                case "High Pain Tolerance Rating Three": break;
                case "Home Ground": break;
                case "Human Looking": break;
                case "Lucky": break;
                case "Magician": break;
                case "Magic Resistance Rating One": break;
                case "Magic Resistance Rating Two": break;
                case "Magic Resistance Rating Three": break;
                case "Magic Resistance Rating Four": break;
                case "Mentor Spirit": break;
                case "Murky Link": break;
                case "Mystic Adept": break;
                case "Natural Hardening": break;
                case "Natural Immunity Rating One": break;
                case "Natural Immunity Rating Two": break;
                case "Natural Immunity Rating Three": break;
                case "Photographic Memory": break;
                case "Quick Healer": break;
                case "Resistance to Pathogens/Toxins Rating One": break;
                case "Resistance to Pathogens/Toxins Rating Two": break;
                case "Spirit Affinity": break;
                case "Technomancer": break;
                case "Toughness": break;
                case "Will to Live Rating One": break;
                case "Will to Live Rating Two": break;
                case "Will to Live Rating Three": break;
                default: break;
            }
        }
    }
}
