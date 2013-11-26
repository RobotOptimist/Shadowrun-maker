using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowrunCharacterMaker
{
    
   struct AgilitySkills
   {
            public int archery, automatics, blades, clubs, escapeArtist, exoticMelee, exoticRanged, forgery, gunnery, gymnastics,
                heavyWeapons, infiltration, locksmith, longarms, palming, pistols, throwingWeapons, unarmedCombat;
   }


    public class NewCharacter
    {
        public int bp { get; set; }

        public int[] agility { get; set; }
        public int[] body {get; set;}
        public int[] strength {get; set;}
        public int[] reaction{get; set;}
        public int[] logic{get; set;}
        public int[] intuition{get; set;}
        public int[] charisma {get; set;}
        public int[] willpower{get; set;}
        public int[] edge{get; set;}
        public int[] initiative { get; set; }
        public int essence{get; set;}
        public int magic{get; set;}
        public int resonance{get; set;}

        public string name{get; set;}
        public string race {get; set;}
        
        //attribute array first element is starting/minimum value, second element is max natural value, third element is max modified value
        public void Create()
        {
            name = "default";
            race = "none";    
            agility =  new int[3] {1, 1, 1};
            body = new int[3] { 1, 1, 1 };
            strength = new int[3] { 1, 1, 1 };
            reaction = new int[3] { 1, 1, 1 };
            logic = new int[3] { 1, 1, 1 };
            intuition = new int[3] { 1, 1, 1 };
            charisma = new int[3] { 1, 1, 1 };
            willpower = new int[3] { 1, 1, 1 };
            edge = new int[2] { 1, 1 };
            initiative = new int[3] { 1, 1, 1, };
            essence = 6;
            magic = 0;
            resonance = 0;
            bp = 400;
        }

        public void CreateHuman(string charName)
        {
            name = charName;
            race = "Human";
            agility = new int[3] { 1, 6, 9 };
            body = new int[3] { 1, 6, 9 };
            strength = new int[3] { 1, 6, 9 };
            reaction = new int[3] { 1, 6, 9 };
            logic = new int[3] { 1, 6, 9 };
            intuition = new int[3] { 1, 6, 9 };
            charisma = new int[3] { 1, 6, 9 };
            willpower = new int[3] { 1, 6, 9 };
            edge = new int[2] { 2, 7 };
            initiative = new int[3] { 2, 12, 18, };
            essence = 6;
            magic = 0;
            resonance = 0;
            bp = 400;
        }

        public void CreateTroll(string charName)
        {
            name = charName;
            race = "Troll";
            agility = new int[3] { 1, 5, 7 };
            body = new int[3] { 5, 10, 15 };
            strength = new int[3] { 5, 10, 15 };
            reaction = new int[3] { 1, 6, 9 };
            logic = new int[3] { 1, 5, 7 };
            intuition = new int[3] { 1, 5, 7 };
            charisma = new int[3] { 1, 4, 6 };
            willpower = new int[3] { 1, 6, 9 };
            edge = new int[2] { 1, 6 };
            initiative = new int[3] { 2, 11, 16, };
            essence = 6;
            magic = 0;
            resonance = 0;
            bp = 360;
        }

        public void CreateOrk(string charName)
        {
            name = charName;
            race = "Ork";
            agility = new int[3] { 1, 6, 9 };
            body = new int[3] { 4, 9, 13 };
            strength = new int[3] { 3, 8, 12 };
            reaction = new int[3] { 1, 6, 9 };
            logic = new int[3] { 1, 5, 7 };
            intuition = new int[3] { 1, 6, 9 };
            charisma = new int[3] { 1, 5, 7 };
            willpower = new int[3] { 1, 6, 9 };
            edge = new int[2] { 1, 6 };
            initiative = new int[3] { 2, 12, 18, };
            essence = 6;
            magic = 0;
            resonance = 0;
            bp = 380;
        }

        public void CreateDwarf(string charName)
        {
            name = charName;
            race = "Dwarf";
            agility = new int[3] { 1, 6, 9 };
            body = new int[3] { 2, 7, 10 };
            strength = new int[3] { 3, 8, 12 };
            reaction = new int[3] { 1, 5, 7 };
            logic = new int[3] { 1, 6, 9 };
            intuition = new int[3] { 1, 6, 9 };
            charisma = new int[3] { 1, 6, 9 };
            willpower = new int[3] { 2, 7, 10 };
            edge = new int[2] { 1, 6 };
            initiative = new int[3] { 2, 11, 16, };
            essence = 6;
            magic = 0;
            resonance = 0;
            bp = 375;
        }

        public void CreateElf(string charName)
        {
            name = charName;
            race = "Elf";
            agility = new int[3] { 2, 7, 10 };
            body = new int[3] { 1, 6, 9 };
            strength = new int[3] { 1, 6, 9 };
            reaction = new int[3] { 1, 6, 9 };
            logic = new int[3] { 1, 6, 9 };
            intuition = new int[3] { 1, 6, 9 };
            charisma = new int[3] { 3, 8, 12 };
            willpower = new int[3] { 1, 6, 9 };
            edge = new int[2] { 1, 6 };
            initiative = new int[3] { 2, 12, 18, };
            essence = 6;
            magic = 0;
            resonance = 0;
            bp = 370;
        }
    }

}
