

#region using statements


#endregion

namespace MemeVault
{

    #region class MainForm
    /// <summary>
    /// This class is the Designer for the MainForm.cs
    /// </summary>
    partial class MainForm
    {
        
        #region Private Variables
        private Label AlternatesLabel;
        private ListBox AlternatesListBox;
        private System.ComponentModel.IContainer components = null;
        private Label ImageLabel;
        private PictureBox ImagePreview;
        private Label ImageStatsLabel;
        private RadioButton IndexMode;
        private PictureBox MoveFirstButton;
        private PictureBox MoveLastButton;
        private PictureBox MoveNextButton;
        private PictureBox MovePreviousButton;       
        private Label ResultsLabel;
        private Label SearchInfo;
        private RadioButton SearchMode;
        private Label SelectedAlternateLabel;
        private Label SelectedFileLabel;
        private Label SelectedImageLabel;
        private Label StatusLabel;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl MemeFolderControl;
        private DataJuggler.Win.Controls.Button SaveMemeFolderButton;
        private DataJuggler.Win.Controls.Objects.PanelExtender SearchPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender IndexPanel;
        private DataJuggler.Win.Controls.LabelTextBoxControl ImageNameControl;
        private DataJuggler.Win.Controls.Button DeleteButton;
        private DataJuggler.Win.Controls.Button EditButton;
        private DataJuggler.Win.Controls.Button AddButton;
        private DataJuggler.Win.Controls.Button SaveImageButton;
        private DataJuggler.Win.Controls.ProgressBar Graph;
        private DataJuggler.Win.Controls.LabelCheckBoxControl OnlyNotIndexedCheckBox;
        private DataJuggler.Win.Controls.LabelTextBoxControl SelectedAlternateControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IndexedCheckBox;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IndexedOnSaveCheckBox;
        private DataJuggler.Win.Controls.Button RescanButton;
        private DataJuggler.Win.Controls.Button DeleteImageButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl SearchTextBox;
        private DataJuggler.Win.Controls.Button SearchButton;
        private DataJuggler.Win.Controls.Objects.PanelExtender ResultsPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender CopyPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender panelExtender1;
        private DataJuggler.Win.Controls.Button CopySelectedButton;
        private DataJuggler.Win.Controls.Button EditAlternatesButton;
        private System.Windows.Forms.Timer CopyTimer;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
            /// <summary>
            ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MemeFolderControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            SaveMemeFolderButton = new DataJuggler.Win.Controls.Button();
            StatusLabel = new Label();
            IndexMode = new RadioButton();
            SearchMode = new RadioButton();
            SearchPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            ResultsPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            Results4 = new PictureViewer();
            Results10 = new PictureViewer();
            Results5 = new PictureViewer();
            Results9 = new PictureViewer();
            Results8 = new PictureViewer();
            Results3 = new PictureViewer();
            Results7 = new PictureViewer();
            Results2 = new PictureViewer();
            Results6 = new PictureViewer();
            Results1 = new PictureViewer();
            ResultsLabel = new Label();
            CopyPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            EditAlternatesButton = new DataJuggler.Win.Controls.Button();
            panelExtender1 = new DataJuggler.Win.Controls.Objects.PanelExtender();
            SelectedFileLabel = new Label();
            CopySelectedButton = new DataJuggler.Win.Controls.Button();
            SearchTextBox = new DataJuggler.Win.Controls.LabelTextBoxControl();
            SearchInfo = new Label();
            SearchButton = new DataJuggler.Win.Controls.Button();
            IndexPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            ReturnToSearchOnSave = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            DeleteImageButton = new DataJuggler.Win.Controls.Button();
            IndexedOnSaveCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            IndexedCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            SelectedImageLabel = new Label();
            SelectedAlternateLabel = new Label();
            SelectedAlternateControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            OnlyNotIndexedCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            ImageStatsLabel = new Label();
            MoveLastButton = new PictureBox();
            MoveNextButton = new PictureBox();
            MovePreviousButton = new PictureBox();
            MoveFirstButton = new PictureBox();
            SaveImageButton = new DataJuggler.Win.Controls.Button();
            DeleteButton = new DataJuggler.Win.Controls.Button();
            EditButton = new DataJuggler.Win.Controls.Button();
            AddButton = new DataJuggler.Win.Controls.Button();
            AlternatesLabel = new Label();
            AlternatesListBox = new ListBox();
            ImageNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            ImageLabel = new Label();
            ImagePreview = new PictureBox();
            Graph = new DataJuggler.Win.Controls.ProgressBar();
            RescanButton = new DataJuggler.Win.Controls.Button();
            CopyTimer = new System.Windows.Forms.Timer(components);
            SearchPanel.SuspendLayout();
            ResultsPanel.SuspendLayout();
            CopyPanel.SuspendLayout();
            IndexPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MoveLastButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MoveNextButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MovePreviousButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MoveFirstButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImagePreview).BeginInit();
            SuspendLayout();
            // 
            // MemeFolderControl
            // 
            MemeFolderControl.BackColor = Color.Transparent;
            MemeFolderControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.Folder;
            MemeFolderControl.ButtonColor = Color.LemonChiffon;
            MemeFolderControl.ButtonImage = (Image)resources.GetObject("MemeFolderControl.ButtonImage");
            MemeFolderControl.ButtonWidth = 48;
            MemeFolderControl.DarkMode = false;
            MemeFolderControl.DisabledLabelColor = Color.Empty;
            MemeFolderControl.Editable = true;
            MemeFolderControl.EnabledLabelColor = Color.Empty;
            MemeFolderControl.Filter = null;
            MemeFolderControl.Font = new Font("Calibri", 12F);
            MemeFolderControl.HideBrowseButton = false;
            MemeFolderControl.LabelBottomMargin = 0;
            MemeFolderControl.LabelColor = Color.LemonChiffon;
            MemeFolderControl.LabelFont = new Font("Calibri", 12F, FontStyle.Bold);
            MemeFolderControl.LabelText = "Meme Folder:";
            MemeFolderControl.LabelTopMargin = 0;
            MemeFolderControl.LabelWidth = 148;
            MemeFolderControl.Location = new Point(36, 23);
            MemeFolderControl.Name = "MemeFolderControl";
            MemeFolderControl.OnTextChangedListener = null;
            MemeFolderControl.OpenCallback = null;
            MemeFolderControl.ScrollBars = ScrollBars.None;
            MemeFolderControl.SelectedPath = null;
            MemeFolderControl.Size = new Size(730, 32);
            MemeFolderControl.StartPath = null;
            MemeFolderControl.TabIndex = 0;
            MemeFolderControl.TextBoxBottomMargin = 0;
            MemeFolderControl.TextBoxDisabledColor = Color.Empty;
            MemeFolderControl.TextBoxEditableColor = Color.Empty;
            MemeFolderControl.TextBoxFont = new Font("Calibri", 12F);
            MemeFolderControl.TextBoxTopMargin = 0;
            MemeFolderControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // SaveMemeFolderButton
            // 
            SaveMemeFolderButton.BackColor = Color.Transparent;
            SaveMemeFolderButton.ButtonText = "Save";
            SaveMemeFolderButton.FlatStyle = FlatStyle.Flat;
            SaveMemeFolderButton.ForeColor = Color.LemonChiffon;
            SaveMemeFolderButton.Location = new Point(654, 68);
            SaveMemeFolderButton.Name = "SaveMemeFolderButton";
            SaveMemeFolderButton.Size = new Size(112, 44);
            SaveMemeFolderButton.TabIndex = 1;
            SaveMemeFolderButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            SaveMemeFolderButton.UseMnemonic = true;
            SaveMemeFolderButton.Click += SaveMemeFolderButton_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.ForeColor = Color.LemonChiffon;
            StatusLabel.Location = new Point(36, 74);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(457, 33);
            StatusLabel.TabIndex = 2;
            StatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IndexMode
            // 
            IndexMode.AutoSize = true;
            IndexMode.BackColor = Color.Transparent;
            IndexMode.ForeColor = Color.LemonChiffon;
            IndexMode.Location = new Point(346, 112);
            IndexMode.Name = "IndexMode";
            IndexMode.Size = new Size(120, 27);
            IndexMode.TabIndex = 3;
            IndexMode.TabStop = true;
            IndexMode.Text = "Index Mode";
            IndexMode.UseVisualStyleBackColor = false;
            // 
            // SearchMode
            // 
            SearchMode.AutoSize = true;
            SearchMode.BackColor = Color.Transparent;
            SearchMode.ForeColor = Color.LemonChiffon;
            SearchMode.Location = new Point(176, 114);
            SearchMode.Name = "SearchMode";
            SearchMode.Size = new Size(129, 27);
            SearchMode.TabIndex = 4;
            SearchMode.TabStop = true;
            SearchMode.Text = "Search Mode";
            SearchMode.UseVisualStyleBackColor = false;
            SearchMode.CheckedChanged += SearchMode_CheckedChanged;
            // 
            // SearchPanel
            // 
            SearchPanel.BackColor = Color.Transparent;
            SearchPanel.Controls.Add(ResultsPanel);
            SearchPanel.Controls.Add(CopyPanel);
            SearchPanel.Controls.Add(SearchTextBox);
            SearchPanel.Controls.Add(SearchInfo);
            SearchPanel.Controls.Add(SearchButton);
            SearchPanel.Location = new Point(36, 188);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(1082, 606);
            SearchPanel.TabIndex = 5;
            // 
            // ResultsPanel
            // 
            ResultsPanel.Controls.Add(Results4);
            ResultsPanel.Controls.Add(Results10);
            ResultsPanel.Controls.Add(Results5);
            ResultsPanel.Controls.Add(Results9);
            ResultsPanel.Controls.Add(Results8);
            ResultsPanel.Controls.Add(Results3);
            ResultsPanel.Controls.Add(Results7);
            ResultsPanel.Controls.Add(Results2);
            ResultsPanel.Controls.Add(Results6);
            ResultsPanel.Controls.Add(Results1);
            ResultsPanel.Controls.Add(ResultsLabel);
            ResultsPanel.Dock = DockStyle.Bottom;
            ResultsPanel.Location = new Point(0, 85);
            ResultsPanel.Name = "ResultsPanel";
            ResultsPanel.Size = new Size(1082, 460);
            ResultsPanel.TabIndex = 14;
            // 
            // Results4
            // 
            Results4.BackgroundImageLayout = ImageLayout.Stretch;
            Results4.BorderColor = Color.Black;
            Results4.Image = null;
            Results4.Listener = null;
            Results4.Location = new Point(648, 32);
            Results4.Name = "Results4";
            Results4.Selected = false;
            Results4.Size = new Size(200, 200);
            Results4.TabIndex = 10;
            // 
            // Results10
            // 
            Results10.BackgroundImageLayout = ImageLayout.Stretch;
            Results10.BorderColor = Color.Black;
            Results10.Image = null;
            Results10.Listener = null;
            Results10.Location = new Point(864, 240);
            Results10.Name = "Results10";
            Results10.Selected = false;
            Results10.Size = new Size(200, 200);
            Results10.TabIndex = 13;
            // 
            // Results5
            // 
            Results5.BackgroundImageLayout = ImageLayout.Stretch;
            Results5.BorderColor = Color.Black;
            Results5.Image = null;
            Results5.Listener = null;
            Results5.Location = new Point(864, 32);
            Results5.Name = "Results5";
            Results5.Selected = false;
            Results5.Size = new Size(200, 200);
            Results5.TabIndex = 12;
            // 
            // Results9
            // 
            Results9.BackgroundImageLayout = ImageLayout.Stretch;
            Results9.BorderColor = Color.Black;
            Results9.Image = null;
            Results9.Listener = null;
            Results9.Location = new Point(648, 240);
            Results9.Name = "Results9";
            Results9.Selected = false;
            Results9.Size = new Size(200, 200);
            Results9.TabIndex = 11;
            // 
            // Results8
            // 
            Results8.BackgroundImageLayout = ImageLayout.Stretch;
            Results8.BorderColor = Color.Black;
            Results8.Image = null;
            Results8.Listener = null;
            Results8.Location = new Point(432, 240);
            Results8.Name = "Results8";
            Results8.Selected = false;
            Results8.Size = new Size(200, 200);
            Results8.TabIndex = 9;
            // 
            // Results3
            // 
            Results3.BackgroundImageLayout = ImageLayout.Stretch;
            Results3.BorderColor = Color.Black;
            Results3.Image = null;
            Results3.Listener = null;
            Results3.Location = new Point(432, 32);
            Results3.Name = "Results3";
            Results3.Selected = false;
            Results3.Size = new Size(200, 200);
            Results3.TabIndex = 8;
            // 
            // Results7
            // 
            Results7.BackgroundImageLayout = ImageLayout.Stretch;
            Results7.BorderColor = Color.Black;
            Results7.Image = null;
            Results7.Listener = null;
            Results7.Location = new Point(216, 240);
            Results7.Name = "Results7";
            Results7.Selected = false;
            Results7.Size = new Size(200, 200);
            Results7.TabIndex = 7;
            // 
            // Results2
            // 
            Results2.BackgroundImageLayout = ImageLayout.Stretch;
            Results2.BorderColor = Color.Black;
            Results2.Image = null;
            Results2.Listener = null;
            Results2.Location = new Point(216, 32);
            Results2.Name = "Results2";
            Results2.Selected = false;
            Results2.Size = new Size(200, 200);
            Results2.TabIndex = 6;
            // 
            // Results6
            // 
            Results6.BackgroundImageLayout = ImageLayout.Stretch;
            Results6.BorderColor = Color.Black;
            Results6.Image = null;
            Results6.Listener = null;
            Results6.Location = new Point(0, 240);
            Results6.Name = "Results6";
            Results6.Selected = false;
            Results6.Size = new Size(200, 200);
            Results6.TabIndex = 5;
            // 
            // Results1
            // 
            Results1.BackgroundImageLayout = ImageLayout.Stretch;
            Results1.BorderColor = Color.Black;
            Results1.Image = null;
            Results1.Listener = null;
            Results1.Location = new Point(0, 32);
            Results1.Name = "Results1";
            Results1.Selected = false;
            Results1.Size = new Size(200, 200);
            Results1.TabIndex = 4;
            // 
            // ResultsLabel
            // 
            ResultsLabel.BackColor = Color.Transparent;
            ResultsLabel.Dock = DockStyle.Top;
            ResultsLabel.ForeColor = Color.LemonChiffon;
            ResultsLabel.Location = new Point(0, 0);
            ResultsLabel.MaximumSize = new Size(640, 24);
            ResultsLabel.Name = "ResultsLabel";
            ResultsLabel.Size = new Size(640, 24);
            ResultsLabel.TabIndex = 3;
            ResultsLabel.Text = "No Results Found.";
            ResultsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CopyPanel
            // 
            CopyPanel.Controls.Add(EditAlternatesButton);
            CopyPanel.Controls.Add(panelExtender1);
            CopyPanel.Controls.Add(SelectedFileLabel);
            CopyPanel.Controls.Add(CopySelectedButton);
            CopyPanel.Dock = DockStyle.Bottom;
            CopyPanel.Location = new Point(0, 545);
            CopyPanel.Name = "CopyPanel";
            CopyPanel.Size = new Size(1082, 61);
            CopyPanel.TabIndex = 13;
            // 
            // EditAlternatesButton
            // 
            EditAlternatesButton.BackColor = Color.Transparent;
            EditAlternatesButton.ButtonText = "Edit Alternates";
            EditAlternatesButton.FlatStyle = FlatStyle.Flat;
            EditAlternatesButton.ForeColor = Color.LemonChiffon;
            EditAlternatesButton.Location = new Point(714, 8);
            EditAlternatesButton.Name = "EditAlternatesButton";
            EditAlternatesButton.Size = new Size(156, 44);
            EditAlternatesButton.TabIndex = 16;
            EditAlternatesButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            EditAlternatesButton.UseMnemonic = true;
            EditAlternatesButton.Click += EditAlternatesButton_Click;
            // 
            // panelExtender1
            // 
            panelExtender1.Dock = DockStyle.Left;
            panelExtender1.Location = new Point(0, 0);
            panelExtender1.Name = "panelExtender1";
            panelExtender1.Size = new Size(28, 61);
            panelExtender1.TabIndex = 15;
            // 
            // SelectedFileLabel
            // 
            SelectedFileLabel.BackColor = Color.Transparent;
            SelectedFileLabel.ForeColor = Color.LemonChiffon;
            SelectedFileLabel.Location = new Point(43, 18);
            SelectedFileLabel.Name = "SelectedFileLabel";
            SelectedFileLabel.Size = new Size(558, 24);
            SelectedFileLabel.TabIndex = 14;
            SelectedFileLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CopySelectedButton
            // 
            CopySelectedButton.BackColor = Color.Transparent;
            CopySelectedButton.ButtonText = "Copy";
            CopySelectedButton.FlatStyle = FlatStyle.Flat;
            CopySelectedButton.ForeColor = Color.LemonChiffon;
            CopySelectedButton.Location = new Point(613, 8);
            CopySelectedButton.Name = "CopySelectedButton";
            CopySelectedButton.Size = new Size(85, 44);
            CopySelectedButton.TabIndex = 13;
            CopySelectedButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            CopySelectedButton.UseMnemonic = true;
            CopySelectedButton.Click += CopySelectedButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.BackColor = Color.Transparent;
            SearchTextBox.BottomMargin = 0;
            SearchTextBox.Editable = true;
            SearchTextBox.Encrypted = false;
            SearchTextBox.Font = new Font("Calibri", 14.25F, FontStyle.Bold);
            SearchTextBox.Inititialized = true;
            SearchTextBox.LabelBottomMargin = 0;
            SearchTextBox.LabelColor = Color.LemonChiffon;
            SearchTextBox.LabelFont = new Font("Calibri", 14.25F, FontStyle.Bold);
            SearchTextBox.LabelText = "Search Text:";
            SearchTextBox.LabelTopMargin = 0;
            SearchTextBox.LabelWidth = 120;
            SearchTextBox.Location = new Point(11, 17);
            SearchTextBox.MultiLine = false;
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.OnTextChangedListener = null;
            SearchTextBox.PasswordMode = false;
            SearchTextBox.ScrollBars = ScrollBars.None;
            SearchTextBox.Size = new Size(586, 32);
            SearchTextBox.TabIndex = 5;
            SearchTextBox.TextBoxBottomMargin = 0;
            SearchTextBox.TextBoxDisabledColor = Color.LightGray;
            SearchTextBox.TextBoxEditableColor = Color.White;
            SearchTextBox.TextBoxFont = new Font("Calibri", 12F);
            SearchTextBox.TextBoxTopMargin = 0;
            SearchTextBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            SearchTextBox.KeyDownOccurred += SearchTextBox_KeyDownOccurred;
            // 
            // SearchInfo
            // 
            SearchInfo.BackColor = Color.Transparent;
            SearchInfo.ForeColor = Color.LemonChiffon;
            SearchInfo.Location = new Point(11, 44);
            SearchInfo.Name = "SearchInfo";
            SearchInfo.Size = new Size(554, 24);
            SearchInfo.TabIndex = 6;
            SearchInfo.Text = "Enter search terms separated by a space";
            SearchInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.Transparent;
            SearchButton.ButtonText = "Search";
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.ForeColor = Color.LemonChiffon;
            SearchButton.Location = new Point(613, 7);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(117, 44);
            SearchButton.TabIndex = 9;
            SearchButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            SearchButton.UseMnemonic = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // IndexPanel
            // 
            IndexPanel.BackColor = Color.Transparent;
            IndexPanel.Controls.Add(ReturnToSearchOnSave);
            IndexPanel.Controls.Add(DeleteImageButton);
            IndexPanel.Controls.Add(IndexedOnSaveCheckBox);
            IndexPanel.Controls.Add(IndexedCheckBox);
            IndexPanel.Controls.Add(SelectedImageLabel);
            IndexPanel.Controls.Add(SelectedAlternateLabel);
            IndexPanel.Controls.Add(SelectedAlternateControl);
            IndexPanel.Controls.Add(OnlyNotIndexedCheckBox);
            IndexPanel.Controls.Add(ImageStatsLabel);
            IndexPanel.Controls.Add(MoveLastButton);
            IndexPanel.Controls.Add(MoveNextButton);
            IndexPanel.Controls.Add(MovePreviousButton);
            IndexPanel.Controls.Add(MoveFirstButton);
            IndexPanel.Controls.Add(SaveImageButton);
            IndexPanel.Controls.Add(DeleteButton);
            IndexPanel.Controls.Add(EditButton);
            IndexPanel.Controls.Add(AddButton);
            IndexPanel.Controls.Add(AlternatesLabel);
            IndexPanel.Controls.Add(AlternatesListBox);
            IndexPanel.Controls.Add(ImageNameControl);
            IndexPanel.Controls.Add(ImageLabel);
            IndexPanel.Controls.Add(ImagePreview);
            IndexPanel.Location = new Point(36, 195);
            IndexPanel.Name = "IndexPanel";
            IndexPanel.Size = new Size(1082, 511);
            IndexPanel.TabIndex = 6;
            // 
            // ReturnToSearchOnSave
            // 
            ReturnToSearchOnSave.BackColor = Color.Transparent;
            ReturnToSearchOnSave.CheckBoxHorizontalOffSet = 4;
            ReturnToSearchOnSave.CheckBoxVerticalOffSet = 3;
            ReturnToSearchOnSave.CheckChangedListener = null;
            ReturnToSearchOnSave.Checked = true;
            ReturnToSearchOnSave.Editable = true;
            ReturnToSearchOnSave.Font = new Font("Calibri", 12F);
            ReturnToSearchOnSave.LabelColor = Color.LemonChiffon;
            ReturnToSearchOnSave.LabelFont = new Font("Calibri", 14.25F);
            ReturnToSearchOnSave.LabelText = "Return To Search On Save:";
            ReturnToSearchOnSave.LabelWidth = 216;
            ReturnToSearchOnSave.Location = new Point(596, 458);
            ReturnToSearchOnSave.Name = "ReturnToSearchOnSave";
            ReturnToSearchOnSave.Size = new Size(240, 28);
            ReturnToSearchOnSave.TabIndex = 24;
            ReturnToSearchOnSave.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            ReturnToSearchOnSave.Visible = false;
            // 
            // DeleteImageButton
            // 
            DeleteImageButton.BackColor = Color.Transparent;
            DeleteImageButton.ButtonText = "Delete";
            DeleteImageButton.FlatStyle = FlatStyle.Flat;
            DeleteImageButton.ForeColor = Color.LemonChiffon;
            DeleteImageButton.Location = new Point(32, 450);
            DeleteImageButton.Name = "DeleteImageButton";
            DeleteImageButton.Size = new Size(82, 44);
            DeleteImageButton.TabIndex = 23;
            DeleteImageButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            DeleteImageButton.UseMnemonic = true;
            DeleteImageButton.Click += DeleteImageButton_Click;
            // 
            // IndexedOnSaveCheckBox
            // 
            IndexedOnSaveCheckBox.BackColor = Color.Transparent;
            IndexedOnSaveCheckBox.CheckBoxHorizontalOffSet = 4;
            IndexedOnSaveCheckBox.CheckBoxVerticalOffSet = 3;
            IndexedOnSaveCheckBox.CheckChangedListener = null;
            IndexedOnSaveCheckBox.Checked = true;
            IndexedOnSaveCheckBox.Editable = true;
            IndexedOnSaveCheckBox.Font = new Font("Calibri", 12F);
            IndexedOnSaveCheckBox.LabelColor = Color.LemonChiffon;
            IndexedOnSaveCheckBox.LabelFont = new Font("Calibri", 14.25F);
            IndexedOnSaveCheckBox.LabelText = "Indexed On Save:";
            IndexedOnSaveCheckBox.LabelWidth = 148;
            IndexedOnSaveCheckBox.Location = new Point(408, 458);
            IndexedOnSaveCheckBox.Name = "IndexedOnSaveCheckBox";
            IndexedOnSaveCheckBox.Size = new Size(180, 28);
            IndexedOnSaveCheckBox.TabIndex = 22;
            IndexedOnSaveCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // IndexedCheckBox
            // 
            IndexedCheckBox.BackColor = Color.Transparent;
            IndexedCheckBox.CheckBoxHorizontalOffSet = 4;
            IndexedCheckBox.CheckBoxVerticalOffSet = 3;
            IndexedCheckBox.CheckChangedListener = null;
            IndexedCheckBox.Checked = false;
            IndexedCheckBox.Editable = true;
            IndexedCheckBox.Font = new Font("Calibri", 12F);
            IndexedCheckBox.LabelColor = Color.LemonChiffon;
            IndexedCheckBox.LabelFont = new Font("Calibri", 14.25F);
            IndexedCheckBox.LabelText = "Indexed:";
            IndexedCheckBox.LabelWidth = 100;
            IndexedCheckBox.Location = new Point(147, 458);
            IndexedCheckBox.Name = "IndexedCheckBox";
            IndexedCheckBox.Size = new Size(129, 28);
            IndexedCheckBox.TabIndex = 20;
            IndexedCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // SelectedImageLabel
            // 
            SelectedImageLabel.BackColor = Color.Transparent;
            SelectedImageLabel.ForeColor = Color.LemonChiffon;
            SelectedImageLabel.Location = new Point(43, 81);
            SelectedImageLabel.Name = "SelectedImageLabel";
            SelectedImageLabel.Size = new Size(271, 33);
            SelectedImageLabel.TabIndex = 19;
            SelectedImageLabel.Text = "Selected Image";
            SelectedImageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelectedAlternateLabel
            // 
            SelectedAlternateLabel.BackColor = Color.Transparent;
            SelectedAlternateLabel.ForeColor = Color.LemonChiffon;
            SelectedAlternateLabel.Location = new Point(409, 81);
            SelectedAlternateLabel.Name = "SelectedAlternateLabel";
            SelectedAlternateLabel.Size = new Size(271, 33);
            SelectedAlternateLabel.TabIndex = 18;
            SelectedAlternateLabel.Text = "Selected Alternate";
            SelectedAlternateLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelectedAlternateControl
            // 
            SelectedAlternateControl.BackColor = Color.Transparent;
            SelectedAlternateControl.BottomMargin = 0;
            SelectedAlternateControl.Editable = true;
            SelectedAlternateControl.Encrypted = false;
            SelectedAlternateControl.Font = new Font("Calibri", 12F, FontStyle.Bold);
            SelectedAlternateControl.Inititialized = true;
            SelectedAlternateControl.LabelBottomMargin = 0;
            SelectedAlternateControl.LabelColor = Color.LemonChiffon;
            SelectedAlternateControl.LabelFont = new Font("Calibri", 12F, FontStyle.Bold);
            SelectedAlternateControl.LabelText = "Name:";
            SelectedAlternateControl.LabelTopMargin = 0;
            SelectedAlternateControl.LabelWidth = 80;
            SelectedAlternateControl.Location = new Point(398, 117);
            SelectedAlternateControl.MultiLine = false;
            SelectedAlternateControl.Name = "SelectedAlternateControl";
            SelectedAlternateControl.OnTextChangedListener = null;
            SelectedAlternateControl.PasswordMode = false;
            SelectedAlternateControl.ScrollBars = ScrollBars.None;
            SelectedAlternateControl.Size = new Size(293, 32);
            SelectedAlternateControl.TabIndex = 17;
            SelectedAlternateControl.TextBoxBottomMargin = 0;
            SelectedAlternateControl.TextBoxDisabledColor = Color.LightGray;
            SelectedAlternateControl.TextBoxEditableColor = Color.White;
            SelectedAlternateControl.TextBoxFont = new Font("Calibri", 12F);
            SelectedAlternateControl.TextBoxTopMargin = 0;
            SelectedAlternateControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            SelectedAlternateControl.KeyDownOccurred += SelectedAlternateControl_KeyDownOccurred;
            // 
            // OnlyNotIndexedCheckBox
            // 
            OnlyNotIndexedCheckBox.BackColor = Color.Transparent;
            OnlyNotIndexedCheckBox.CheckBoxHorizontalOffSet = 4;
            OnlyNotIndexedCheckBox.CheckBoxVerticalOffSet = 2;
            OnlyNotIndexedCheckBox.CheckChangedListener = null;
            OnlyNotIndexedCheckBox.Checked = false;
            OnlyNotIndexedCheckBox.Editable = true;
            OnlyNotIndexedCheckBox.Font = new Font("Calibri", 12F);
            OnlyNotIndexedCheckBox.LabelColor = Color.LemonChiffon;
            OnlyNotIndexedCheckBox.LabelFont = new Font("Calibri", 14.25F);
            OnlyNotIndexedCheckBox.LabelText = "Show Only Not Indexed:";
            OnlyNotIndexedCheckBox.LabelWidth = 260;
            OnlyNotIndexedCheckBox.Location = new Point(114, 43);
            OnlyNotIndexedCheckBox.Name = "OnlyNotIndexedCheckBox";
            OnlyNotIndexedCheckBox.Size = new Size(282, 28);
            OnlyNotIndexedCheckBox.TabIndex = 16;
            OnlyNotIndexedCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ImageStatsLabel
            // 
            ImageStatsLabel.BackColor = Color.Transparent;
            ImageStatsLabel.ForeColor = Color.LemonChiffon;
            ImageStatsLabel.Location = new Point(18, 4);
            ImageStatsLabel.Name = "ImageStatsLabel";
            ImageStatsLabel.Size = new Size(374, 33);
            ImageStatsLabel.TabIndex = 15;
            ImageStatsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MoveLastButton
            // 
            MoveLastButton.BackgroundImage = (Image)resources.GetObject("MoveLastButton.BackgroundImage");
            MoveLastButton.BackgroundImageLayout = ImageLayout.Stretch;
            MoveLastButton.Location = new Point(627, 8);
            MoveLastButton.Name = "MoveLastButton";
            MoveLastButton.Size = new Size(64, 64);
            MoveLastButton.TabIndex = 14;
            MoveLastButton.TabStop = false;
            MoveLastButton.EnabledChanged += MoveLastButton_EnabledChanged;
            MoveLastButton.Click += MoveLastButton_Click;
            MoveLastButton.MouseEnter += ButtonEnter;
            MoveLastButton.MouseLeave += ButtonLeave;
            // 
            // MoveNextButton
            // 
            MoveNextButton.BackgroundImage = (Image)resources.GetObject("MoveNextButton.BackgroundImage");
            MoveNextButton.BackgroundImageLayout = ImageLayout.Stretch;
            MoveNextButton.Location = new Point(557, 8);
            MoveNextButton.Name = "MoveNextButton";
            MoveNextButton.Size = new Size(64, 64);
            MoveNextButton.TabIndex = 13;
            MoveNextButton.TabStop = false;
            MoveNextButton.EnabledChanged += MoveNextButton_EnabledChanged;
            MoveNextButton.Click += MoveNextButton_Click;
            MoveNextButton.MouseEnter += ButtonEnter;
            MoveNextButton.MouseLeave += ButtonLeave;
            // 
            // MovePreviousButton
            // 
            MovePreviousButton.BackgroundImage = (Image)resources.GetObject("MovePreviousButton.BackgroundImage");
            MovePreviousButton.BackgroundImageLayout = ImageLayout.Stretch;
            MovePreviousButton.Location = new Point(487, 8);
            MovePreviousButton.Name = "MovePreviousButton";
            MovePreviousButton.Size = new Size(64, 64);
            MovePreviousButton.TabIndex = 12;
            MovePreviousButton.TabStop = false;
            MovePreviousButton.EnabledChanged += MovePreviousButton_EnabledChanged;
            MovePreviousButton.Click += MovePreviousButton_Click;
            MovePreviousButton.MouseEnter += ButtonEnter;
            MovePreviousButton.MouseLeave += ButtonLeave;
            // 
            // MoveFirstButton
            // 
            MoveFirstButton.BackgroundImage = (Image)resources.GetObject("MoveFirstButton.BackgroundImage");
            MoveFirstButton.BackgroundImageLayout = ImageLayout.Stretch;
            MoveFirstButton.Location = new Point(415, 8);
            MoveFirstButton.Name = "MoveFirstButton";
            MoveFirstButton.Size = new Size(64, 64);
            MoveFirstButton.TabIndex = 11;
            MoveFirstButton.TabStop = false;
            MoveFirstButton.EnabledChanged += MoveFirstButton_EnabledChanged;
            MoveFirstButton.Click += MoveFirstButton_Click;
            MoveFirstButton.MouseEnter += ButtonEnter;
            MoveFirstButton.MouseLeave += ButtonLeave;
            // 
            // SaveImageButton
            // 
            SaveImageButton.BackColor = Color.Transparent;
            SaveImageButton.ButtonText = "Save";
            SaveImageButton.FlatStyle = FlatStyle.Flat;
            SaveImageButton.ForeColor = Color.LemonChiffon;
            SaveImageButton.Location = new Point(309, 450);
            SaveImageButton.Name = "SaveImageButton";
            SaveImageButton.Size = new Size(82, 44);
            SaveImageButton.TabIndex = 10;
            SaveImageButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            SaveImageButton.UseMnemonic = true;
            SaveImageButton.EnabledChanged += SaveImageButton_EnabledChanged;
            SaveImageButton.Click += SaveImageButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = Color.Transparent;
            DeleteButton.ButtonText = "Delete";
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.ForeColor = Color.LemonChiffon;
            DeleteButton.Location = new Point(610, 360);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(82, 44);
            DeleteButton.TabIndex = 9;
            DeleteButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            DeleteButton.UseMnemonic = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EditButton
            // 
            EditButton.BackColor = Color.Transparent;
            EditButton.ButtonText = "Edit";
            EditButton.FlatStyle = FlatStyle.Flat;
            EditButton.ForeColor = Color.LemonChiffon;
            EditButton.Location = new Point(515, 360);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(82, 44);
            EditButton.TabIndex = 8;
            EditButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            EditButton.UseMnemonic = true;
            EditButton.Click += EditButton_Click;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.Transparent;
            AddButton.ButtonText = "&Add";
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.ForeColor = Color.LemonChiffon;
            AddButton.Location = new Point(420, 360);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(82, 44);
            AddButton.TabIndex = 7;
            AddButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            AddButton.UseMnemonic = true;
            AddButton.Click += AddButton_Click;
            // 
            // AlternatesLabel
            // 
            AlternatesLabel.BackColor = Color.Transparent;
            AlternatesLabel.ForeColor = Color.LemonChiffon;
            AlternatesLabel.Location = new Point(420, 152);
            AlternatesLabel.Name = "AlternatesLabel";
            AlternatesLabel.Size = new Size(256, 33);
            AlternatesLabel.TabIndex = 6;
            AlternatesLabel.Text = "Alternates";
            AlternatesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AlternatesListBox
            // 
            AlternatesListBox.FormattingEnabled = true;
            AlternatesListBox.Location = new Point(420, 188);
            AlternatesListBox.Name = "AlternatesListBox";
            AlternatesListBox.Size = new Size(272, 165);
            AlternatesListBox.TabIndex = 5;
            AlternatesListBox.SelectedIndexChanged += AlternatesListBox_SelectedIndexChanged;
            AlternatesListBox.DoubleClick += AlternatesListBox_DoubleClick;
            // 
            // ImageNameControl
            // 
            ImageNameControl.BackColor = Color.Transparent;
            ImageNameControl.BottomMargin = 0;
            ImageNameControl.Editable = true;
            ImageNameControl.Encrypted = false;
            ImageNameControl.Font = new Font("Calibri", 12F, FontStyle.Bold);
            ImageNameControl.Inititialized = true;
            ImageNameControl.LabelBottomMargin = 0;
            ImageNameControl.LabelColor = Color.LemonChiffon;
            ImageNameControl.LabelFont = new Font("Calibri", 12F, FontStyle.Bold);
            ImageNameControl.LabelText = "Name:";
            ImageNameControl.LabelTopMargin = 0;
            ImageNameControl.LabelWidth = 80;
            ImageNameControl.Location = new Point(32, 117);
            ImageNameControl.MultiLine = false;
            ImageNameControl.Name = "ImageNameControl";
            ImageNameControl.OnTextChangedListener = null;
            ImageNameControl.PasswordMode = false;
            ImageNameControl.ScrollBars = ScrollBars.None;
            ImageNameControl.Size = new Size(293, 32);
            ImageNameControl.TabIndex = 4;
            ImageNameControl.TextBoxBottomMargin = 0;
            ImageNameControl.TextBoxDisabledColor = Color.LightGray;
            ImageNameControl.TextBoxEditableColor = Color.White;
            ImageNameControl.TextBoxFont = new Font("Calibri", 12F);
            ImageNameControl.TextBoxTopMargin = 0;
            ImageNameControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ImageLabel
            // 
            ImageLabel.BackColor = Color.Transparent;
            ImageLabel.ForeColor = Color.LemonChiffon;
            ImageLabel.Location = new Point(32, 152);
            ImageLabel.Name = "ImageLabel";
            ImageLabel.Size = new Size(256, 33);
            ImageLabel.TabIndex = 3;
            ImageLabel.Text = "Preview";
            ImageLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ImagePreview
            // 
            ImagePreview.BackgroundImageLayout = ImageLayout.Stretch;
            ImagePreview.Location = new Point(32, 188);
            ImagePreview.Name = "ImagePreview";
            ImagePreview.Size = new Size(360, 256);
            ImagePreview.TabIndex = 0;
            ImagePreview.TabStop = false;
            // 
            // Graph
            // 
            Graph.BackColor = Color.DarkGray;
            Graph.BackgroundColor = Color.DarkGray;
            Graph.BorderStyle = BorderStyle.FixedSingle;
            Graph.ForeColor = Color.DodgerBlue;
            Graph.Location = new Point(36, 152);
            Graph.Maximum = 100;
            Graph.Name = "Graph";
            Graph.SetOverflowToMax = true;
            Graph.Size = new Size(730, 22);
            Graph.TabIndex = 7;
            Graph.Value = 0;
            Graph.Visible = false;
            // 
            // RescanButton
            // 
            RescanButton.BackColor = Color.Transparent;
            RescanButton.ButtonText = "Scan Folder";
            RescanButton.FlatStyle = FlatStyle.Flat;
            RescanButton.ForeColor = Color.LemonChiffon;
            RescanButton.Location = new Point(505, 68);
            RescanButton.Name = "RescanButton";
            RescanButton.Size = new Size(137, 44);
            RescanButton.TabIndex = 8;
            RescanButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            RescanButton.UseMnemonic = true;
            RescanButton.EnabledChanged += RescanButton_EnabledChanged;
            RescanButton.Click += RescanButton_Click;
            // 
            // CopyTimer
            // 
            CopyTimer.Interval = 3000;
            CopyTimer.Tick += CopyTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1156, 806);
            Controls.Add(RescanButton);
            Controls.Add(Graph);
            Controls.Add(SearchMode);
            Controls.Add(IndexMode);
            Controls.Add(StatusLabel);
            Controls.Add(SaveMemeFolderButton);
            Controls.Add(MemeFolderControl);
            Controls.Add(IndexPanel);
            Controls.Add(SearchPanel);
            DoubleBuffered = true;
            Font = new Font("Calibri", 14.25F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meme Vault 1.0.0";
            Activated += MainForm_Activated;
            SearchPanel.ResumeLayout(false);
            ResultsPanel.ResumeLayout(false);
            CopyPanel.ResumeLayout(false);
            IndexPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MoveLastButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)MoveNextButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)MovePreviousButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)MoveFirstButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImagePreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        #endregion

        #region Properties

        #endregion

        private PictureViewer Results10;
        private PictureViewer Results5;
        private PictureViewer Results9;
        private PictureViewer Results4;
        private PictureViewer Results8;
        private PictureViewer Results3;
        private PictureViewer Results7;
        private PictureViewer Results2;
        private PictureViewer Results6;
        private PictureViewer Results1;
        private DataJuggler.Win.Controls.LabelCheckBoxControl ReturnToSearchOnSave;
    }
    #endregion

}
