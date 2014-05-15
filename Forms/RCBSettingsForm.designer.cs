namespace RCBuddy.Forms
{
    partial class RCBSettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.RCBToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.privacyCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.apiKeyBox = new System.Windows.Forms.TextBox();
            this.SaveSettings = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.screenshotCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Privacy";
            this.RCBToolTip.SetToolTip(this.label2, "If enabled, no account related information will be send to our server (character " +
        "name and realm), instead it will be encrypted locally");
            // 
            // privacyCheckBox
            // 
            this.privacyCheckBox.AutoSize = true;
            this.privacyCheckBox.Location = new System.Drawing.Point(151, 57);
            this.privacyCheckBox.Name = "privacyCheckBox";
            this.privacyCheckBox.Size = new System.Drawing.Size(15, 14);
            this.privacyCheckBox.TabIndex = 9;
            this.RCBToolTip.SetToolTip(this.privacyCheckBox, "If enabled, no account related information will be send to our server (character " +
        "name and realm), instead it will be encrypted locally");
            this.privacyCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "API Key";
            this.RCBToolTip.SetToolTip(this.label1, "Your API key can be found on the website");
            // 
            // apiKeyBox
            // 
            this.apiKeyBox.Location = new System.Drawing.Point(151, 32);
            this.apiKeyBox.Name = "apiKeyBox";
            this.apiKeyBox.Size = new System.Drawing.Size(113, 20);
            this.apiKeyBox.TabIndex = 7;
            this.RCBToolTip.SetToolTip(this.apiKeyBox, "Your API key can be found on the website");
            // 
            // SaveSettings
            // 
            this.SaveSettings.Location = new System.Drawing.Point(32, 110);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(75, 23);
            this.SaveSettings.TabIndex = 13;
            this.SaveSettings.Text = "Save settings";
            this.SaveSettings.UseVisualStyleBackColor = true;
            this.SaveSettings.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Screenshots on level up";
            // 
            // screenshotCheckBox
            // 
            this.screenshotCheckBox.AutoSize = true;
            this.screenshotCheckBox.Location = new System.Drawing.Point(151, 78);
            this.screenshotCheckBox.Name = "screenshotCheckBox";
            this.screenshotCheckBox.Size = new System.Drawing.Size(15, 14);
            this.screenshotCheckBox.TabIndex = 11;
            this.screenshotCheckBox.UseVisualStyleBackColor = true;
            // 
            // RCBSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 165);
            this.Controls.Add(this.SaveSettings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.screenshotCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.privacyCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.apiKeyBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RCBSettingsForm";
            this.Text = "RCBuddy Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip RCBToolTip;
        private System.Windows.Forms.Button SaveSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox screenshotCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox privacyCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox apiKeyBox;

    }
}