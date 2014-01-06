namespace ShadowrunCharacterMaker
{
    partial class PositiveQualities
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PQualitiesList = new System.Windows.Forms.ListBox();
            this.AddPQuality = new System.Windows.Forms.Button();
            this.PQualityDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PQualitiesList
            // 
            this.PQualitiesList.FormattingEnabled = true;
            this.PQualitiesList.Items.AddRange(new object[] {
            "Adept",
            "Ambidextrous",
            "Animal Empathy",
            "Aptitude",
            "Astral Chameleon",
            "Blandness",
            "Codeslinger",
            "Double Jointed",
            "Erased Criminal Sin",
            "Erased Any Sin",
            "Exceptional Attribute",
            "First Impression",
            "Focused Concentration Rating One",
            "Focused Concentration Rating Two",
            "Guts",
            "High Pain Tolerance Rating One",
            "High Pain Tolerance Rating Two",
            "High Pain Tolerance Rating Three",
            "Home Ground",
            "Human Looking",
            "Lucky",
            "Magician",
            "Magic Resistance Rating One",
            "Magic Resistance Rating Two",
            "Magic Resistance Rating Three",
            "Magic Resistance Rating Four",
            "Mentor Spirit",
            "Murky Link",
            "Mystic Adept",
            "Natural Hardening",
            "Natural Immunity Rating One",
            "Natural Immunity Rating Two",
            "Photographic Memory",
            "Quick Healer",
            "Resistance to Pathogens/Toxins Rating One",
            "Resistance to Pathogens/Toxins Rating Two",
            "Spirit Affinity",
            "Technomancer",
            "Toughness",
            "Will to Live Rating One",
            "Will to Live Rating Two",
            "Will to Live Rating Three"});
            this.PQualitiesList.Location = new System.Drawing.Point(16, 31);
            this.PQualitiesList.Name = "PQualitiesList";
            this.PQualitiesList.Size = new System.Drawing.Size(287, 173);
            this.PQualitiesList.TabIndex = 0;
            // 
            // AddPQuality
            // 
            this.AddPQuality.Location = new System.Drawing.Point(16, 225);
            this.AddPQuality.Name = "AddPQuality";
            this.AddPQuality.Size = new System.Drawing.Size(112, 25);
            this.AddPQuality.TabIndex = 1;
            this.AddPQuality.Text = "Add";
            this.AddPQuality.UseVisualStyleBackColor = true;
            this.AddPQuality.Click += new System.EventHandler(this.AddPQuality_Click);
            // 
            // PQualityDone
            // 
            this.PQualityDone.Location = new System.Drawing.Point(154, 225);
            this.PQualityDone.Name = "PQualityDone";
            this.PQualityDone.Size = new System.Drawing.Size(112, 25);
            this.PQualityDone.TabIndex = 2;
            this.PQualityDone.Text = "Done";
            this.PQualityDone.UseVisualStyleBackColor = true;
            this.PQualityDone.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // PositiveQualities
            // 
            this.AcceptButton = this.PQualityDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.PQualityDone;
            this.ClientSize = new System.Drawing.Size(344, 262);
            this.Controls.Add(this.PQualityDone);
            this.Controls.Add(this.AddPQuality);
            this.Controls.Add(this.PQualitiesList);
            this.Name = "PositiveQualities";
            this.Text = "Positive Qualities";
            this.Load += new System.EventHandler(this.PositiveQualities_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox PQualitiesList;
        private System.Windows.Forms.Button AddPQuality;
        private System.Windows.Forms.Button PQualityDone;
        
    }
}