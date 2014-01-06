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

            character.RetrieveQualityList(PQualitiesList,character.listOfUnselectedPositiveQualities);
            
        }

        private void PositiveQualities_Load(object sender, EventArgs e)
        {

        }

        public void AddPQuality_Click(Object sender, EventArgs e)
        {
            string magicWarning = "By selecting this you cannot choose any other quality that grants magical or resonance ability. Additionally, you may not have Magic Resistance";
            string resonanceWarning = "By selecting this you cannot choose any other quality that grants magical or resonance ability.";
            switch (PQualitiesList.Text)
            {
                case "Adept":
                        var result =MessageBox.Show(magicWarning, "Magic Warning",
                        MessageBoxButtons.OKCancel, 
                        MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        character.Adept(true);
                        if (character.adept == false)
                        {
                            break;
                        }
                        charupdater.InitializeMagic();
                        quallist.Items.Add("Adept");
                        PQualitiesList.Items.Remove("Adept");
                        PQualitiesList.Items.Remove("Magician");
                        PQualitiesList.Items.Remove("Technomancer");
                        PQualitiesList.Items.Remove("Mystic Adept");
                        PQualitiesList.Items.Remove("Magic Resistance Rating One");
                        PQualitiesList.Items.Remove("Magic Resistance Rating Two");
                        PQualitiesList.Items.Remove("Magic Resistance Rating Three");
                        PQualitiesList.Items.Remove("Magic Resistance Rating Four");
                        break;
                    }
                    else
                    {
                        break;
                    }
                case "Ambidextrous": character.Ambidextrous(true);
                    if (character.ambidextrous == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Ambidextrous");
                    PQualitiesList.Items.Remove("Ambidextrous");
                    break;
                case "Animal Empathy": character.AnimalEmpathy(true);
                    if (character.animalEmpathy == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Animal Empathy");
                    PQualitiesList.Items.Remove("Animal Empathy");
                    break;
                case "Aptitude": character.Aptitude(true);
                    if (character.aptitude == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Aptitude");
                    PQualitiesList.Items.Remove("Aptitude");
                    break;
                case "Astral Chameleon": character.AstralChameleon(true);
                    if (character.astralChameleon == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Astral Chameleon");
                    PQualitiesList.Items.Remove("Astral Chameleon");
                    break;
                case "Blandness": character.Blandness(true);
                    if (character.blandness == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Blandness");
                    PQualitiesList.Items.Remove("Blandness");
                    break;
                case "Codeslinger": character.Codeslinger(true);
                    if (character.codeslinger == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Codeslinger");
                    PQualitiesList.Items.Remove("Codeslinger");
                    break;
                case "Double Jointed": character.DoubleJointed(true);
                    if (character.doubleJointed == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Double Jointed");
                    PQualitiesList.Items.Remove("Double Jointed");
                    break;
                case "Erased Criminal Sin": character.ErasedCriminalSin(true);
                    if (character.erasedCriminalSin == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Erased Criminal Sin");
                    PQualitiesList.Items.Remove("Erased Criminal Sin");
                    break;
                case "Erased Any Sin": character.ErasedAnySin(true);
                    if (character.erasedAnySin == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Erased Any Sin");
                    PQualitiesList.Items.Remove("Erased Any Sin");
                    break;
                case "Exceptional Attribute": character.ExceptionalAttribute(true);
                    if (character.exceptionalAttribute == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Exceptional Attribute");
                    PQualitiesList.Items.Remove("Exceptional Attribute");
                    break;
                case "First Impression": character.FirstImpression(true);
                    if (character.firstImpression == false)
                    {
                        break;
                    }
                    quallist.Items.Add("First Impression");
                    PQualitiesList.Items.Remove("First Impresssion");
                    break;
                case "Focused Concentration Rating One": character.FocusedConcentration(true, 1);
                    if (character.focusedConcentration == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Focused Concentration Rating One");
                    PQualitiesList.Items.Remove("Focused Concentration Rating One");
                    break;
                case "Focused Concentration Rating Two": character.FocusedConcentration(true, 2);
                    if (character.focusedConcentration2 == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Focused Concentration Rating Two");
                    PQualitiesList.Items.Remove("Focused Concentration Rating Two");
                    quallist.Items.Add("Focused Concentration Rating One");
                    PQualitiesList.Items.Remove("Focused Concentration Rating One");
                    break;
                case "Guts": character.Guts(true);
                    if (character.guts == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Guts");
                    PQualitiesList.Items.Remove("Guts");
                    break;
                case "High Pain Tolerance Rating One": character.HighPainTolerance(true, 1);
                    if (character.highPainTolerance == false)
                    {
                        break;
                    }
                    quallist.Items.Add("High Pain Tolerance Rating One");
                    PQualitiesList.Items.Remove("High Pain Tolerance Rating One");
                    break;
                case "High Pain Tolerance Rating Two": character.HighPainTolerance(true, 2);
                    if (character.highPainTolerance2 == false)
                    {
                        break;
                    }
                    quallist.Items.Add("High Pain Tolerance Rating Two");
                    quallist.Items.Add("High Pain Tolerance Rating One");
                    PQualitiesList.Items.Remove("High Pain Tolerance Rating Two");
                    PQualitiesList.Items.Remove("High Pain Tolerance Rating One");
                    break;
                case "High Pain Tolerance Rating Three": character.HighPainTolerance(true, 3);
                    if (character.highPainTolerance3 == false)
                    {
                        break;
                    }
                    quallist.Items.Add("High Pain Tolerance Rating Three");
                    quallist.Items.Add("High Pain Tolerance Rating Two");
                    quallist.Items.Add("High Pain Tolerance Rating One");
                    PQualitiesList.Items.Remove("High Pain Tolerance Rating Three");
                    PQualitiesList.Items.Remove("High Pain Tolerance Rating Two");
                    PQualitiesList.Items.Remove("High Pain Tolerance Rating One");
                    break;
                case "Home Ground": character.HomeGround(true);
                    if (character.homeGround == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Home Ground");
                    PQualitiesList.Items.Remove("Home Ground");
                    break;
                case "Human Looking": character.HumanLooking(true);
                    if (character.humanLooking == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Human Looking");
                    PQualitiesList.Items.Remove("Human Looking");
                    break;
                case "Lucky": character.Lucky(true);
                    if (character.lucky == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Lucky");
                    PQualitiesList.Items.Remove("Lucky");
                    break;
                case "Magician": 
                        result =MessageBox.Show(magicWarning, "Magic Warning",
                        MessageBoxButtons.OKCancel, 
                        MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        character.Magician(true);
                        if (character.magician == false)
                        {
                            break;
                        }
                        charupdater.InitializeMagic();
                        quallist.Items.Add("Magician");
                        PQualitiesList.Items.Remove("Adept");
                        PQualitiesList.Items.Remove("Magician");
                        PQualitiesList.Items.Remove("Technomancer");
                        PQualitiesList.Items.Remove("Mystic Adept");
                        PQualitiesList.Items.Remove("Magic Resistance Rating One");
                        PQualitiesList.Items.Remove("Magic Resistance Rating Two");
                        PQualitiesList.Items.Remove("Magic Resistance Rating Three");
                        PQualitiesList.Items.Remove("Magic Resistance Rating Four");
                        break;
                    }
                    else
                    {
                        break;
                    }
                case "Magic Resistance Rating One": character.MagicResistance(true, 1);
                    if (character.magicResistance == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Magic Resistance Rating One");
                    PQualitiesList.Items.Remove("Magic Resistance Rating One");
                    break;
                case "Magic Resistance Rating Two": character.MagicResistance(true, 2);
                    if (character.magicResistance2 == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Magic Resistance Rating Two");
                    PQualitiesList.Items.Remove("Magic Resistance Rating Two");
                    quallist.Items.Add("Magic Resistance Rating One");
                    PQualitiesList.Items.Remove("Magic Resistance Rating One");
                    break;
                case "Magic Resistance Rating Three": character.MagicResistance(true, 3);
                    if (character.magicResistance3 == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Magic Resistance Rating Three");
                    PQualitiesList.Items.Remove("Magic Resistance Rating Three");
                    quallist.Items.Add("Magic Resistance Rating Two");
                    PQualitiesList.Items.Remove("Magic Resistance Rating Two");
                    quallist.Items.Add("Magic Resistance Rating One");
                    PQualitiesList.Items.Remove("Magic Resistance Rating One");
                    break;
                case "Magic Resistance Rating Four": character.MagicResistance(true, 4);
                    if (character.magicResistance4 == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Magic Resistance Rating Four");
                    PQualitiesList.Items.Remove("Magic Resistance Rating Four");
                    quallist.Items.Add("Magic Resistance Rating Three");
                    PQualitiesList.Items.Remove("Magic Resistance Rating Three");
                    quallist.Items.Add("Magic Resistance Rating Two");
                    PQualitiesList.Items.Remove("Magic Resistance Rating Two");
                    quallist.Items.Add("Magic Resistance Rating One");
                    PQualitiesList.Items.Remove("Magic Resistance Rating One");
                    break;
                case "Mentor Spirit": character.MentorSpirit(true);
                    if (character.mentorSpirit == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Mentor Spirit");
                    PQualitiesList.Items.Remove("Mentor Spirit");
                    break;
                case "Murky Link": character.MurkyLink(true);
                    if (character.murkyLink == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Murky Link");
                    PQualitiesList.Items.Remove("Murky Link");
                    break;
                case "Mystic Adept": 
                        result =MessageBox.Show(magicWarning, "Magic Warning",
                        MessageBoxButtons.OKCancel, 
                        MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        character.MysticAdept(true);
                        if (character.mysticAdept == false)
                        {
                            break;
                        }
                        charupdater.InitializeMagic();
                        quallist.Items.Add("Mystic Adept");
                        PQualitiesList.Items.Remove("Adept");
                        PQualitiesList.Items.Remove("Magician");
                        PQualitiesList.Items.Remove("Technomancer");
                        PQualitiesList.Items.Remove("Mystic Adept");
                        PQualitiesList.Items.Remove("Magic Resistance Rating One");
                        PQualitiesList.Items.Remove("Magic Resistance Rating Two");
                        PQualitiesList.Items.Remove("Magic Resistance Rating Three");
                        PQualitiesList.Items.Remove("Magic Resistance Rating Four");
                        break;
                    }
                    else
                    {
                        break;
                    }
                case "Natural Hardening": character.NaturalHardening(true);
                    if (character.naturalHardening == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Natural Hardening");
                    PQualitiesList.Items.Remove("Natural Hardening");
                    break;
                case "Natural Immunity Rating One": character.NaturalImmunity(true, 1);
                    if (character.naturalImmunity == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Natural Immunity Rating One");
                    PQualitiesList.Items.Remove("Natural Immunity Rating One");
                    break;
                case "Natural Immunity Rating Two": character.NaturalImmunity(true, 2);
                    if (character.naturalImmunity2 == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Natural Immunity Rating Two");
                    PQualitiesList.Items.Remove("Natural Immunity Rating Two");
                    quallist.Items.Add("Natural Immunity Rating One");
                    PQualitiesList.Items.Remove("Natural Immunity Rating One");                    
                    break;
                case "Photographic Memory": character.PhotographicMemory(true);
                    if (character.photographicMemory == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Photographic Memory");
                    PQualitiesList.Items.Remove("Photographic Memory");
                    break;
                case "Quick Healer": character.QuickHealer(true);
                    if (character.quickHealer == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Quick Healer");
                    PQualitiesList.Items.Remove("Quick Healer");
                    break;
                case "Resistance to Pathogens/Toxins Rating One": character.ResistPathogens(true, 1);
                    if (character.resistPathogens == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Resistance to Pathogens/Toxins Rating One");
                    PQualitiesList.Items.Remove("Resistance to Pathogens/Toxins Rating One");
                    break;
                case "Resistance to Pathogens/Toxins Rating Two": character.ResistPathogens(true, 2);
                    if (character.resistPathogens2 == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Resistance to Pathogens/Toxins Rating Two");
                    PQualitiesList.Items.Remove("Resistance to Pathogens/Toxins Rating Two");
                    quallist.Items.Add("Resistance to Pathogens/Toxins Rating One");
                    PQualitiesList.Items.Remove("Resistance to Pathogens/Toxins Rating One");
                    break;
                case "Spirit Affinity": character.SpiritAffinity(true);
                    if (character.spiritAffinity == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Spirit Affinity");
                    PQualitiesList.Items.Remove("Spirit Affinity");
                    break;
                case "Technomancer": 
                        result =MessageBox.Show(resonanceWarning, "Resonance Warning",
                        MessageBoxButtons.OKCancel, 
                        MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        character.Technomancer(true);
                        if (character.technomancer == false)
                        {
                            break;
                        }
                        charupdater.InitializeResonance();
                        quallist.Items.Add("Technomancer");
                        PQualitiesList.Items.Remove("Adept");
                        PQualitiesList.Items.Remove("Magician");
                        PQualitiesList.Items.Remove("Technomancer");
                        PQualitiesList.Items.Remove("Mystic Adept");                        
                        break;
                    }
                    else
                    {
                        break;
                    };
                case "Toughness": character.Toughness(true);
                    if (character.toughness == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Toughness");
                    PQualitiesList.Items.Remove("Toughness");
                    break;
                case "Will to Live Rating One": character.WillToLive(true, 1);
                    if (character.willToLive == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Will to Live Rating One");
                    PQualitiesList.Items.Remove("Will to Live Rating One");
                    break;
                case "Will to Live Rating Two": character.WillToLive(true, 2);
                    if (character.willToLive2 == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Will to Live Rating Two");
                    PQualitiesList.Items.Add("Will to Live Rating Two");
                    quallist.Items.Add("Will to Live Rating One");
                    PQualitiesList.Items.Remove("Will to Live Rating One");
                    break;
                case "Will to Live Rating Three": character.WillToLive(true, 3);
                    if (character.willToLive3 == false)
                    {
                        break;
                    }
                    quallist.Items.Add("Will to Live Rating Three");
                    PQualitiesList.Items.Remove("Will to Live Rating Three");
                    quallist.Items.Add("Will to Live Rating Two");
                    PQualitiesList.Items.Add("Will to Live Rating Two");
                    quallist.Items.Add("Will to Live Rating One");
                    PQualitiesList.Items.Remove("Will to Live Rating One");
                    break;
                default: break;
            }
        }

        public void DoneButton_Click(Object sender, EventArgs e)
        {
            character.PopulateQualityList(PQualitiesList, character.listOfUnselectedPositiveQualities);           
        }
    }
}
