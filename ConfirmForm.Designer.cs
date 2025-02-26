

#region using statements


#endregion

namespace MemeVault
{

    #region class ConfirmForm
    /// <summary>
    /// This class is the designer for the ConfirmForm
    /// </summary>
    partial class ConfirmForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private Label StatusLabel;
        private DataJuggler.Win.Controls.Button DeleteButton;
        private DataJuggler.Win.Controls.Button YesButton;
        private DataJuggler.Win.Controls.Button NoButton;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
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
        #endregion

        #region InitializeComponent()
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            YesButton = new DataJuggler.Win.Controls.Button();
            NoButton = new DataJuggler.Win.Controls.Button();
            StatusLabel = new Label();
            DoNotShowAgainCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            SuspendLayout();
            // 
            // YesButton
            // 
            YesButton.BackColor = Color.Transparent;
            YesButton.ButtonText = "Yes";
            YesButton.FlatStyle = FlatStyle.Flat;
            YesButton.Font = new Font("Calibri", 14.25F);
            YesButton.ForeColor = Color.LemonChiffon;
            YesButton.Location = new Point(60, 167);
            YesButton.Margin = new Padding(5);
            YesButton.Name = "YesButton";
            YesButton.Size = new Size(82, 41);
            YesButton.TabIndex = 10;
            YesButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            YesButton.UseMnemonic = true;
            YesButton.Click += YesButton_Click;
            // 
            // NoButton
            // 
            NoButton.BackColor = Color.Transparent;
            NoButton.ButtonText = "No";
            NoButton.FlatStyle = FlatStyle.Flat;
            NoButton.Font = new Font("Calibri", 14.25F);
            NoButton.ForeColor = Color.LemonChiffon;
            NoButton.Location = new Point(248, 167);
            NoButton.Margin = new Padding(5);
            NoButton.Name = "NoButton";
            NoButton.Size = new Size(82, 41);
            NoButton.TabIndex = 11;
            NoButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            NoButton.UseMnemonic = true;
            NoButton.Click += NoButton_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.Font = new Font("Calibri", 14.25F);
            StatusLabel.ForeColor = Color.LemonChiffon;
            StatusLabel.Location = new Point(20, 28);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(364, 100);
            StatusLabel.TabIndex = 12;
            StatusLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // DoNotShowAgainCheckBox
            // 
            DoNotShowAgainCheckBox.BackColor = Color.Transparent;
            DoNotShowAgainCheckBox.CheckBoxHorizontalOffSet = 4;
            DoNotShowAgainCheckBox.CheckBoxVerticalOffSet = 2;
            DoNotShowAgainCheckBox.CheckChangedListener = null;
            DoNotShowAgainCheckBox.Checked = false;
            DoNotShowAgainCheckBox.Editable = true;
            DoNotShowAgainCheckBox.Font = new Font("Calibri", 14.25F);
            DoNotShowAgainCheckBox.LabelColor = Color.LemonChiffon;
            DoNotShowAgainCheckBox.LabelFont = new Font("Calibri", 14.25F);
            DoNotShowAgainCheckBox.LabelText = "Do Not Show Again";
            DoNotShowAgainCheckBox.LabelWidth = 160;
            DoNotShowAgainCheckBox.Location = new Point(96, 131);
            DoNotShowAgainCheckBox.Name = "DoNotShowAgainCheckBox";
            DoNotShowAgainCheckBox.Size = new Size(185, 28);
            DoNotShowAgainCheckBox.TabIndex = 17;
            DoNotShowAgainCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ConfirmForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.BlackImage;
            ClientSize = new Size(404, 225);
            Controls.Add(DoNotShowAgainCheckBox);
            Controls.Add(StatusLabel);
            Controls.Add(NoButton);
            Controls.Add(YesButton);
            Font = new Font("Microsoft Sans Serif", 14.25F);
            Name = "ConfirmForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Test";
            ResumeLayout(false);
        }
        #endregion

        #endregion

        #region Properties

        #endregion

        private DataJuggler.Win.Controls.LabelCheckBoxControl DoNotShowAgainCheckBox;
    }
    #endregion

}
