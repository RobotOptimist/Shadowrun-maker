﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShadowrunCharacterMaker
{
    class AttributeUpDown : NumericUpDown
    {
        
        Character character;
        MaskedTextBox bp;
        public bool maxReached;       

        public void SetParamCharacter(Character newChar, MaskedTextBox buildP)
        {
            character = newChar;
            bp = buildP;
            maxReached = false;
        }

        public override void DownButton()
        {
            int bpCredit;
            if (this.Value == this.Maximum && maxReached == false)
            {
                bpCredit = 25;
                character.buildPoints = character.BuildPointCost(character.buildPoints, bpCredit, false, true);
                bp.Text = character.buildPoints.ToString();
            }
            else if (this.Value == this.Minimum)
            {
                bp.Text = character.buildPoints.ToString();
            }
            else
            {
                bpCredit = 10;
                character.buildPoints = character.BuildPointCost(character.buildPoints, bpCredit, false, true);
                bp.Text = character.buildPoints.ToString();
            }
            base.DownButton();
        }

        public override void UpButton()
        {
            int bpCost;

            if (this.Value == this.Maximum-1 && maxReached == false)
            {
                bpCost = 25;
                character.buildPoints = character.BuildPointCost(character.buildPoints, bpCost, true, true);
                bp.Text = character.buildPoints.ToString();
            }
            else if (this.Value == this.Maximum)
            {
                bp.Text = character.buildPoints.ToString();
            }
            else
            {
                bpCost = 10;
                character.buildPoints = character.BuildPointCost(character.buildPoints, bpCost, true, true);
                bp.Text = character.buildPoints.ToString();
            }
            base.UpButton();
        }
    }
}
