

#region using statements

using DataAccessComponent.Connection;
using DataAccessComponent.DataGateway;
using DataJuggler.Win.Controls;
using DataJuggler.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using Image = ObjectLibrary.BusinessObjects.Image;
using SysImage = System.Drawing.Image;
using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.PixelDatabase;
using MemeVault.Interfaces;
using System.Drawing.Design;

#endregion

namespace MemeVault
{

    #region class MainForm
    /// <summary>
    /// This class is the Main Form for this app
    /// </summary>
    public partial class MainForm : Form, ITextChanged, ICheckChangedListener, IPictureViewerListener
    {

        #region Private Variables
        private Admin admin;
        private List<Image> allImages;
        private bool firstActivationComplete;
        private ScreenTypeEnum screenType;
        private Image selectedImage;
        private Alternate selectedAlternate;
        private string selectedImageHash;
        private int selectedImageIndex;
        private EditTypeEnum editMode;
        private PictureViewer selectedPicture;
        private bool imageOutOfContext;
        private string copyPath;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

        #region AddButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'AddButton' is clicked.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // if the value for HasSelectedImage is true
            if (HasSelectedImage)
            {
                // Create a new instance of an 'Alternate' object.
                Alternate alternate = new Alternate();

                // Alternate
                SelectedImage.Alternates.Add(alternate);

                // Set the SelectedAlternate
                SelectedAlternate = alternate;

                // Display the Alternates for the SelectedImage
                DisplayAlternates();

                // Set EditMode to true
                EditMode = EditTypeEnum.AddNewMode;

                // Enable or disable controls
                UIEnable();

                // Erase
                SelectedAlternateControl.Text = "";

                // Set Focus to the TextBox
                SelectedAlternateControl.SetFocusToTextBox();
            }
        }
        #endregion

        #region AlternatesListBox_DoubleClick(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Alternates List Box _ Double Click
        /// </summary>
        private void AlternatesListBox_DoubleClick(object sender, EventArgs e)
        {
            // if the value for HasSelectedAlternate is true
            if (HasSelectedAlternate)
            {
                // Enter Edit Mode via Edit
                EditButton_Click(EditButton, null);
            }
        }
        #endregion

        #region AlternatesListBox_SelectedIndexChanged(object sender, EventArgs e)
        /// <summary>
        /// event is fired when a selection is made in the 'AlternatesListBox_'.
        /// </summary>
        private void AlternatesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selectedIndex
            int index = AlternatesListBox.SelectedIndex;

            // if the value for HasSelectedImage is true
            if (HasSelectedImage)
            {
                // if in range
                if (NumericHelper.IsInRange(index, 0, SelectedImage.Alternates.Count - 1))
                {
                    // Set the SelectedAlternate
                    SelectedAlternate = SelectedImage.Alternates[index];

                    // Display the name
                    SelectedAlternateControl.Text = SelectedAlternate.Name;
                }
            }
        }
        #endregion

        #region ButtonEnter(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Button Enter
        /// </summary>
        private void ButtonEnter(object sender, EventArgs e)
        {
            // Change the cursor to a hand
            Cursor = Cursors.Hand;
        }
        #endregion

        #region ButtonLeave(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Button Enter
        /// </summary>
        private void ButtonLeave(object sender, EventArgs e)
        {
            // Change the cursor back to the default pointer
            Cursor = Cursors.Default;
        }
        #endregion

        #region CopySelectedButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'CopySelectedButton' is clicked.
        /// </summary>
        private void CopySelectedButton_Click(object sender, EventArgs e)
        {
            // if the value for HasSelectedPicture is true
            if ((HasSelectedPicture) && (FileHelper.Exists(SelectedPicture.Path)))
            {
                // Set the CopyPath
                CopyPath = SelectedPicture.Path;

                // Copy the image to the Clipboard
                Clipboard.SetImage(SysImage.FromFile(SelectedPicture.Path));

                // Set to Copied
                SelectedFileLabel.Text = "Copied";

                // Update the UI - May not be needed
                Refresh();
                Application.DoEvents();

                // Enable the Timer
                CopyTimer.Start();
            }
        }
        #endregion

        #region CopyTimer_Tick(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Copy Timer _ Tick
        /// </summary>
        private void CopyTimer_Tick(object sender, EventArgs e)
        {
            // Disable
            CopyTimer.Enabled = false;

            // if the value for HasSelectedPicture is true
            if ((HasSelectedPicture) && (TextHelper.Exists(copyPath)))
            {
                // restore the label
                SelectedFileLabel.Text = CopyPath;
            }
        }
        #endregion

        #region DeleteButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'DeleteButton' is clicked.
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // if the SelectedAlternate Exists
            if (HasSelectedAlternate)
            {
                // Remove this Alternate
                SelectedImage.Alternates.Remove(SelectedAlternate);

                // if this is an existing record
                if (!SelectedAlternate.IsNew)
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway(ConnectionConstants.Name);

                    // Delete this Alternate
                    bool deleted = gateway.DeleteAlternate(SelectedAlternate.Id);

                    // if the value for deleted is true
                    if (deleted)
                    {
                        // Removed
                        StatusLabel.Text = "Alternate Deleted";
                    }
                }
                else
                {
                    // Removed
                    StatusLabel.Text = "Alternate Removed";
                }

                // remove this item
                SelectedAlternate = null;

                // Redisplay
                DisplayAlternates();

                // Enable or disable controls
                UIEnable();
            }
        }
        #endregion

        #region DeleteImageButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'DeleteImageButton' is clicked.
        /// </summary>
        private void DeleteImageButton_Click(object sender, EventArgs e)
        {
            // if the value for HasAdmin is true
            if (HasAdmin)
            {
                // If the Admin object does not have a SuppressDeletePrompt property
                if (!Admin.SuppressDeletePrompt)
                {
                    // Create a new instance of a 'ConfirmForm' object.
                    ConfirmForm confirmForm = new ConfirmForm();

                    // Setup the label
                    confirmForm.Setup("Delete this image? This action can not be undone.");

                    // show the form
                    confirmForm.ShowDialog();

                    // perform delete
                    if (confirmForm.Response == YesNoResponse.Yes)
                    {
                        // if this was updated while the form was shown
                        if (confirmForm.DeleteSuppressed)
                        {
                            // Set this value
                            Admin.SuppressDeletePrompt = true;
                        }

                        // Delete selected image from database
                        PerformDelete();
                    }
                }
                else
                {
                    // Delete selected image from database
                    PerformDelete();
                }
            }
        }
        #endregion

        #region EditAlternatesButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'EditAlternatesButton' is clicked.
        /// </summary>
        private void EditAlternatesButton_Click(object sender, EventArgs e)
        {
            // if the SelectedPicture exists and has an Image
            if ((HasSelectedPicture) && (SelectedPicture.HasImage))
            {
                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway(ConnectionConstants.Name);

                // Find the image by Id
                Image image = gateway.FindImage(SelectedPicture.Image.ImageId);

                // If the image object exists
                if (NullHelper.Exists(image))
                {
                    // Check IndexMode
                    IndexMode.Checked = true;

                    // Set the SelectedImage
                    SelectedImage = image;

                    // if the SelectedIndex is Index and Only Not Indexed is checked
                    ImageOutOfContext = (SelectedImage.Indexed == OnlyNotIndexedCheckBox.Checked);

                    // if the value for ImageOutOfContext is false
                    if (!ImageOutOfContext)
                    {
                        // if only not index
                        if (OnlyNotIndexedCheckBox.Checked)
                        {
                            // Set the SelectedImageIndex
                            SelectedImageIndex = UnindexedImages.FindIndex(x => x.Id == image.Id);
                        }
                        else
                        {
                            // Set the SelectedImageIndex
                            SelectedImageIndex = AllImages.FindIndex(x => x.Id == image.Id);
                        }
                    }

                    // Change Imgages
                    DisplayIndexStats();

                    // Display the current image
                    SetupSelectedImage();

                    // Enable or disable controls
                    UIEnable();
                }
            }
        }
        #endregion
        
        #region EditButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'EditButton' is clicked.
        /// </summary>
        private void EditButton_Click(object sender, EventArgs e)
        {
            // Set EditMode
            EditMode = EditTypeEnum.EditMode;

            // Enable or disable controls
            UIEnable();

            // Set Focus To TextBox
            SelectedAlternateControl.SetFocusToTextBox();
        }
        #endregion

        #region MainForm_Activated(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Main Form _ Activated
        /// </summary>
        private void MainForm_Activated(object sender, EventArgs e)
        {
            // if first time
            if (!FirstActivationComplete)
            {
                // Select SearchMode
                SearchMode.Checked = true;

                // Default to Checked
                OnlyNotIndexedCheckBox.Checked = true;

                // Only fire once
                FirstActivationComplete = true;

                // Setup the Listener
                ImageNameControl.OnTextChangedListener = this;
                OnlyNotIndexedCheckBox.CheckChangedListener = this;
                IndexedCheckBox.CheckChangedListener = this;
                IndexedOnSaveCheckBox.CheckChangedListener = this;
                SelectedAlternateControl.OnTextChangedListener = this;
            }
        }
        #endregion

        #region MoveFirstButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'MoveFirstButton' is clicked.
        /// </summary>
        private void MoveFirstButton_Click(object sender, EventArgs e)
        {
            // Move the first item
            SelectedImageIndex = 0;

            // Change Imgages
            DisplayIndexStats();

            // Display the current image
            SetupSelectedImage();

            // Enable or disable controls
            UIEnable();
        }
        #endregion

        #region MoveFirstButton_EnabledChanged(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Move First Button _ Enabled Changed
        /// </summary>
        private void MoveFirstButton_EnabledChanged(object sender, EventArgs e)
        {
            // If the value for the property MoveNextButton.Enabled is true
            if (MoveFirstButton.Enabled)
            {
                // Use Enabled
                MoveFirstButton.BackgroundImage = Properties.Resources.VCRMoveFirst;
            }
            else
            {
                // Use Disabled
                MoveFirstButton.BackgroundImage = Properties.Resources.VCRMoveFirstGray;
            }
        }
        #endregion

        #region MoveLastButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'MoveLastButton' is clicked.
        /// </summary>
        private void MoveLastButton_Click(object sender, EventArgs e)
        {
            // if only the unindexed should be shown
            if (OnlyNotIndexedCheckBox.Checked)
            {
                // Set to the last one
                SelectedImageIndex = UnindexedImagesCount - 1;
            }
            else
            {
                // Set to the last image
                SelectedImageIndex = AllImagesCount - 1;
            }

            // Change Imgages
            DisplayIndexStats();

            // Display the current image
            SetupSelectedImage();

            // Enable or disable controls
            UIEnable();
        }
        #endregion

        #region MoveLastButton_EnabledChanged(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Move Last Button _ Enabled Changed
        /// </summary>
        private void MoveLastButton_EnabledChanged(object sender, EventArgs e)
        {
            // If the value for the property MoveLastButton.Enabled is true
            if (MoveLastButton.Enabled)
            {
                // Use Enable Button
                MoveLastButton.BackgroundImage = Properties.Resources.VCRMoveLast;
            }
            else
            {
                // Use Disabled Button
                MoveLastButton.BackgroundImage = Properties.Resources.VCRMoveLastGray;
            }
        }
        #endregion

        #region MoveNextButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'MoveNextButton' is clicked.
        /// </summary>
        private void MoveNextButton_Click(object sender, EventArgs e)
        {
            // Increment the value for SelectedImageIndex
            SelectedImageIndex++;

            // Change Imgages
            DisplayIndexStats();

            // Display the current image
            SetupSelectedImage();

            // Enable or disable controls
            UIEnable();
        }
        #endregion

        #region MoveNextButton_EnabledChanged(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Move Next Button _ Enabled Changed
        /// </summary>
        private void MoveNextButton_EnabledChanged(object sender, EventArgs e)
        {
            // If the value for the property MoveNextButton.Enabled is true
            if (MoveNextButton.Enabled)
            {
                // Use Enabled
                MoveNextButton.BackgroundImage = Properties.Resources.VCRMoveNext;
            }
            else
            {
                // Use Disabled
                MoveNextButton.BackgroundImage = Properties.Resources.VCRMoveNextGray;
            }
        }
        #endregion

        #region MovePreviousButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'MovePreviousButton' is clicked.
        /// </summary>
        private void MovePreviousButton_Click(object sender, EventArgs e)
        {
            // If the value for SelectedImageIndex is greater than zero
            if (SelectedImageIndex > 0)
            {
                // Decrement the value for SelectedImageIndex
                SelectedImageIndex--;

                // Change Imgages
                DisplayIndexStats();

                // Display the current image
                SetupSelectedImage();

                // Enable or disable controls
                UIEnable();
            }
        }
        #endregion

        #region MovePreviousButton_EnabledChanged(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Move Previous Button _ Enabled Changed
        /// </summary>
        private void MovePreviousButton_EnabledChanged(object sender, EventArgs e)
        {
            // If the value for the property MoveNextButton.Enabled is true
            if (MovePreviousButton.Enabled)
            {
                // Use Enabled
                MovePreviousButton.BackgroundImage = Properties.Resources.VCRMovePrevious;
            }
            else
            {
                // Use Disabled
                MovePreviousButton.BackgroundImage = Properties.Resources.VCRMovePreviousMin;
            }
        }
        #endregion

        #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
        /// <summary>
        /// event is fired when On Check Changed
        /// </summary>
        public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
        {
            // if this is the IndexCheckBox
            if (sender.Name == IndexedCheckBox.Name)
            {
                // if the value for HasSelectedImage is true
                if (HasSelectedImage)
                {
                    // Set the new value
                    SelectedImage.Indexed = IndexedCheckBox.Checked;
                }
            }
            else if (sender.Name == IndexedOnSaveCheckBox.Name)
            {
                if (Admin.IndexOnSave != isChecked)
                {
                    // Setup the new value
                    Admin.IndexOnSave = isChecked;

                    // Setup the Name
                    Gateway gateway = new Gateway(ConnectionConstants.Name);

                    // Update the Admin
                    bool saved = gateway.SaveAdmin(ref admin);

                    // if the value for saved is true
                    if (saved)
                    {
                        // Show a message
                        StatusLabel.Text = "Indexed On Save Set To " + isChecked;
                    }
                }
            }
            else if (sender.Name == OnlyNotIndexedCheckBox.Name)
            {
                // Set to 0
                SelectedImageIndex = 0;

                // Set the SelectedImage
                DisplayIndexStats();

                // Display the current image
                SetupSelectedImage();
            }

            // Enable or disable controls
            UIEnable();
        }
        #endregion

        #region OnTextChanged(Control sender, string text)
        /// <summary>
        /// event is fired when On Text Changed
        /// </summary>
        public void OnTextChanged(Control sender, string text)
        {
            if (sender.Name == ImageNameControl.Name)
            {
                // if the value for HasSelectedImage is true
                if (HasSelectedImage)
                {
                    // Set the Image Name
                    SelectedImage.Name = text;
                }
            }
            else if (sender.Name == SelectedAlternateControl.Name)
            {
                // if the value for HasSelectedAlternate is true
                if (HasSelectedAlternate)
                {
                    // Set the SelectedAlternate
                    SelectedAlternate.Name = text;
                }
            }
        }
        #endregion

        #region RescanButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'RescanButton' is clicked.
        /// </summary>
        private void RescanButton_Click(object sender, EventArgs e)
        {
            // Call this same code. This rescans and displays everything
            SearchMode_CheckedChanged(this, null);
        }
        #endregion

        #region RescanButton_EnabledChanged(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Rescan Button _ Enabled Changed
        /// </summary>
        private void RescanButton_EnabledChanged(object sender, EventArgs e)
        {
            // if Enabled
            if (RescanButton.Enabled)
            {
                // Light on Dark
                RescanButton.ForeColor = Color.LemonChiffon;
            }
            else
            {
                // Dark on Dark
                RescanButton.ForeColor = Color.DarkGray;
            }
        }
        #endregion

        #region SaveImageButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'SaveImageButton' is clicked.
        /// </summary>
        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            // local
            int savedCount = 0;

            // if the value for HasSelectedImage is true
            if (HasSelectedImage)
            {
                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway(ConnectionConstants.Name);

                // if Indexed on Save is checked
                if (IndexedOnSaveCheckBox.Checked)
                {
                    // Set to true
                    SelectedImage.Indexed = true;
                }

                // save
                bool saved = gateway.SaveImage(ref selectedImage);

                // if the value for saved is true
                if (saved)
                {
                    // Increment the value for savedCount
                    savedCount++;

                    // If the SelectedImage.Alternates collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(SelectedImage.Alternates))
                    {
                        // Iterate the collection of Alternate objects
                        foreach (Alternate alternate in SelectedImage.Alternates)
                        {
                            // Update the Id
                            alternate.ImageId = SelectedImage.Id;

                            // clone the Alternate                            
                            Alternate clone = alternate.Clone();

                            // Save this
                            saved = gateway.SaveAlternate(ref clone);

                            // if the value for saved is true
                            if (saved)
                            {
                                // Increment the value for savedCount
                                savedCount++;
                            }
                        }

                        // Must be erased before advancing to next image
                        SelectedAlternate = null;

                        // Erase
                        SelectedImage = null;

                        // Reset to 0
                        SelectedImageIndex = 0;

                        // If the value for the property ReturnToSearchOnSave.Checked is true
                        if ((ReturnToSearchOnSave.Checked) && (ImageOutOfContext))
                        {
                            // Exit Edit Mode
                            ImageOutOfContext = false;

                            // Switch to Search
                            SearchMode.Checked = true;

                            // if the value for HasSelectedPicture is true
                            if (HasSelectedPicture)
                            {
                                // Set Selected To False on Return Else Things Are Messed Up
                                SelectedPicture.Selected = false;
                            }

                            // Setup the Screen for Search
                            UIEnable();
                        }
                        else
                        {
                            // Set the SelectedImage
                            DisplayIndexStats();

                            // Reserialize
                            SelectedImageHash = Morpheus.Serialize(SelectedImage);

                            // Handle buttons
                            UIEnable();
                        }

                        // Show a message
                        StatusLabel.Text = "Saved Image + " + (savedCount - 1) + " Alternates.";
                    }
                }
            }
        }
        #endregion

        #region SaveImageButton_EnabledChanged(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Save Image Button _ Enabled Changed
        /// </summary>
        private void SaveImageButton_EnabledChanged(object sender, EventArgs e)
        {
            // if Enabled
            if (SaveImageButton.Enabled)
            {
                // Light on Dark
                SaveImageButton.ForeColor = Color.LemonChiffon;
            }
            else
            {
                // Dark on Dark
                SaveImageButton.ForeColor = Color.DarkGray;
            }
        }
        #endregion

        #region SaveMemeFolderButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'SaveMemeFolderButton' is clicked.
        /// </summary>
        private void SaveMemeFolderButton_Click(object sender, EventArgs e)
        {
            // Create a new instance of a 'Gateway' object.
            Gateway gateway = new Gateway(ConnectionConstants.Name);

            // Set the MemeFolder
            admin.MemeFolder = MemeFolderControl.Text;

            // perform the save
            bool saved = gateway.SaveAdmin(ref admin);

            // if the value for saved is true
            if (saved)
            {
                // Perform Save
                StatusLabel.Text = "Meme Folder Saved.";

                // Select Index Mode For Now
                IndexMode.Checked = true;
            }
        }
        #endregion

        #region SearchButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'SearchButton' is clicked.
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            // Show the ResultsPanel
            ResultsPanel.Visible = true;

            // Hide all the PictureBoxes and set Selected to False
            UIVisibility(false);

            // Erase
            SelectedPicture = null;

            // Get the SearchText
            string searchText = SearchTextBox.Text;

            // Erase any selections
            SelectedPicture = null;
            SelectedFileLabel.Text = "";

            // If the searchText string exists
            if (TextHelper.Exists(searchText))
            {
                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway(ConnectionConstants.Name);

                // Load the Results
                List<ImageView> results = gateway.LoadImageViewsForSearch(searchText);

                // Display the Results
                DisplayResults(results);
            }
            else
            {
                // Show a message
                ResultsLabel.Text = "You must enter Search Text";
            }

            // Enable or disable controls
            UIEnable();
        }
        #endregion

        #region SearchMode_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Search Mode _ Checked Changed
        /// </summary>
        private void SearchMode_CheckedChanged(object sender, EventArgs e)
        {
            // Need to set this
            ImageOutOfContext = false;

            // Create a new instance of a 'Gateway' object.
            Gateway gateway = new Gateway(ConnectionConstants.Name);

            // if Checked
            if (SearchMode.Checked)
            {
                // Search Mode

                // Set to Search
                ScreenType = ScreenTypeEnum.Search;
            }
            else
            {
                // Index Mode

                // Set to Index
                ScreenType = ScreenTypeEnum.Index;

                // Setup Screen here before scanning
                UIEnable();

                // Only Scan Once
                if (!HasAllImages)
                {
                    // Scan Images
                    ScanDirectoryForImages();
                }

                // Load all the Images
                AllImages = gateway.LoadImages();

                // Display 1 of 257 (for example)
                DisplayIndexStats();
            }

            // Enable or disable controls
            UIEnable();
        }
        #endregion

        #region SearchTextBox_KeyDownOccurred(object sender, KeyEventArgs e)
        /// <summary>
        /// event is fired when Search Text Box _ Key Down Occurred
        /// </summary>
        private void SearchTextBox_KeyDownOccurred(object sender, KeyEventArgs e)
        {
            // if enter pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Handles Beep
                e.SuppressKeyPress = true;

                // Call Search so its one place
                SearchButton_Click(null, null);
            }
        }
        #endregion

        #region SelectedAlternateControl_KeyDownOccurred(object sender, KeyEventArgs e)
        /// <summary>
        /// event is fired when Selected Alternate Control _ Key Down Occurred
        /// </summary>
        private void SelectedAlternateControl_KeyDownOccurred(object sender, KeyEventArgs e)
        {
            // if enter pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Handles Beep
                e.SuppressKeyPress = true;

                // Display The Alternates
                DisplayAlternates();

                // Exit Edit Mode
                EditMode = EditTypeEnum.DisplayOnly;

                // Lose Focus
                UIEnable();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                // Handles Beep
                e.SuppressKeyPress = true;

                if ((EditMode == EditTypeEnum.AddNewMode) && (HasSelectedAlternate))
                {
                    // Remove
                    SelectedImage.Alternates.Remove(SelectedAlternate);
                }

                // Return
                EditMode = EditTypeEnum.DisplayOnly;

                // Display the Alternates
                DisplayAlternates();

                // Enable or disable controls
                UIEnable();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region PictureViewerSelectionChanged(PictureViewer pictureViewer)
        /// <summary>
        /// Clears the Selected property on all PictureViewer objects Results1 - Results10 if not the new selected picture
        /// </summary>
        /// <param name="newSelectedPictureName">The name of the newly selected PictureViewer</param>
        public void PictureViewerSelectionChanged(PictureViewer pictureViewer)
        {
            // If the pictureViewer object exists
            if (NullHelper.Exists(pictureViewer))
            {
                // If the value for the property pictureViewer.Selected is true
                if (pictureViewer.Selected)
                {
                    // Set the SelectedPicture
                    SelectedPicture = pictureViewer;
                }
                else if ((HasSelectedPicture) && (SelectedPicture.Name == pictureViewer.Name))
                {
                    // erase
                    SelectedPicture = null;
                }
            }

            // if the value for HasSelectedPicture is true
            if (HasSelectedPicture)
            {
                // Set the Path
                SelectedFileLabel.Text = SelectedPicture.Path;
            }
            else
            {
                // Erase the Path
                SelectedFileLabel.Text = "";
            }

            // Enable or disable controls
            UIEnable();
        }
        #endregion

        #region DisplayAlternates()
        /// <summary>
        /// Display Alternates
        /// </summary>
        public void DisplayAlternates()
        {
            // local
            int index = -1;
            int selectedIndex = -1;

            // Clear
            AlternatesListBox.Items.Clear();

            // if the value for HasSelectedImage is true
            if (HasSelectedImage)
            {
                // If the value for the property selectedImage.HasAlternates is true
                if (selectedImage.HasAlternates)
                {
                    // Iterate the collection of Alternate objects
                    foreach (Alternate alternate in SelectedImage.Alternates)
                    {
                        // set the index
                        index++;

                        // if the Alternate name exists
                        if (TextHelper.Exists(alternate.Name))
                        {
                            // Add this item
                            AlternatesListBox.Items.Add(alternate);

                            // If the value for the property .HasSelectedAlternate is true
                            if ((HasSelectedAlternate) && (alternate.Name == SelectedAlternate.Name))
                            {
                                // Set the selectedIndex
                                selectedIndex = index;
                            }
                        }
                    }


                    // if in range
                    if (NumericHelper.IsInRange(selectedIndex, 0, AlternatesListBox.Items.Count - 1))
                    {
                        // Set the SelectedIndex
                        AlternatesListBox.SelectedIndex = selectedIndex;
                    }
                    else
                    {
                        // Nothing Selected
                        AlternatesListBox.SelectedIndex = -1;
                    }
                }
            }
        }
        #endregion

        #region DisplayIndexStats(int selectedImageIndex = -1)
        /// <summary>
        /// Display Index Stats
        /// </summary>
        public void DisplayIndexStats(int selectedImageIndex = -1)
        {
            // if there is at least one image
            if (AllImagesCount > 0)
            {
                // if the Image is out of context
                if (ImageOutOfContext)
                {
                    // Setup the labels
                    ImageStatsLabel.Text = "Editing Image " + SelectedImage.Name;

                    // Do Not Set the SelectedImage here, it should be already set
                }
                else
                {
                    // if Only
                    if (OnlyNotIndexedCheckBox.Checked)
                    {
                        // if was passed in to this method
                        if (selectedImageIndex >= 0)
                        {
                            // Ensure Index Exists
                            if (NumericHelper.IsInRange(selectedImageIndex, 0, UnindexedImagesCount))
                            {
                                // Set the Property
                                SelectedImageIndex = selectedImageIndex;
                            }
                            else
                            {
                                // Reset to 0
                                SelectedImageIndex = 0;
                            }
                        }

                        if (SelectedImageIndex >= UnindexedImagesCount)
                        {
                            // Subtract 1
                            SelectedImageIndex = UnindexedImagesCount - 1;
                        }

                        // Setup the labels
                        ImageStatsLabel.Text = "Image " + (SelectedImageIndex + 1) + " of " + UnindexedImagesCount;

                        // if the index is in range
                        if (NumericHelper.IsInRange(SelectedImageIndex, 0, UnindexedImagesCount -1))
                        {
                            // Set the SelectedImage
                            SelectedImage = UnindexedImages[SelectedImageIndex];
                        }
                    }
                    else
                    {
                        // if was passed in to this method
                        if (selectedImageIndex >= 0)
                        {
                            // Ensure Index Exists
                            if (NumericHelper.IsInRange(selectedImageIndex, 0, AllImagesCount))
                            {
                                // Set the Property
                                SelectedImageIndex = selectedImageIndex;
                            }
                            else
                            {
                                // Reset to 0
                                SelectedImageIndex = 0;
                            }
                        }

                        // Setup the labels
                        ImageStatsLabel.Text = "Image " + (SelectedImageIndex + 1) + " of " + AllImagesCount;

                        // if the index is in range
                        if (NumericHelper.IsInRange(SelectedImageIndex, 0, AllImagesCount -1))
                        {
                            // Set the SelectedImage
                            SelectedImage = AllImages[SelectedImageIndex];
                        }
                    }
                }

                // if the value for HasSelectedImage is true
                if (HasSelectedImage)
                {
                    // Display the SelectedIimage
                    SetupSelectedImage();
                }
                else
                {
                    // Erase
                    ImageNameControl.Text = "";
                }
            }
            else
            {
                // Show a message
                ImageStatsLabel.Text = "No Images";

                // Erase
                ImageNameControl.Text = "";
            }
        }
        #endregion

        #region DisplayResult(ImageView image, int count)
        /// <summary>
        /// Display Result
        /// </summary>
        public void DisplayResult(ImageView image, int count)
        {  
            // If the image object exists
            if (NullHelper.Exists(image))
            {
                switch (count)
                {
                    case 1:

                        // Set Background Image
                        Results1.BackgroundImage = SysImage.FromFile(image.Path);

                        // Set the Path
                        Results1.Image = image;

                        // Show This Result
                        Results1.Visible = true;

                        // required
                        break;

                    case 2:

                        // Set Background Image
                        Results2.BackgroundImage = SysImage.FromFile(image.Path);

                        // Set the Path
                        Results2.Image = image;

                        // Show This Result
                        Results2.Visible = true;

                        // required
                        break;

                    case 3:

                        // Set Background Image
                        Results3.BackgroundImage = SysImage.FromFile(image.Path);

                        // Set the Path
                        Results3.Image = image;

                        // Show This Result
                        Results3.Visible = true;

                        // required
                        break;

                    case 4:

                        // Set Background Image
                        Results4.BackgroundImage = SysImage.FromFile(image.Path);

                        // Set the Path
                        Results4.Image = image;

                        // Show This Result
                        Results4.Visible = true;

                        // required
                        break;

                    case 5:

                        // Set Background Image
                        Results5.BackgroundImage = SysImage.FromFile(image.Path);

                        // Set the Path
                        Results5.Image = image;

                        // Show This Result
                        Results5.Visible = true;

                        // required
                        break;

                    case 6:

                        // Set Background Image
                        Results6.BackgroundImage = SysImage.FromFile(image.Path);

                        // Set the Path
                        Results6.Image = image;

                        // Show This Result
                        Results6.Visible = true;

                        // required
                        break;

                    case 7:

                        // Set Background Image
                        Results7.BackgroundImage = SysImage.FromFile(image.Path);

                        // Set the Path
                        Results7.Image = image;

                        // Show This Result
                        Results7.Visible = true;

                        // required
                        break;

                    case 8:

                        // Set Background Image
                        Results8.BackgroundImage = SysImage.FromFile(image.Path);

                        // Set the Path
                        Results8.Image = image;

                        // Show This Result
                        Results8.Visible = true;

                        // required
                        break;

                    case 9:

                        // Set Background Image
                        Results9.BackgroundImage = SysImage.FromFile(image.Path);

                        // Set the Path
                        Results9.Image = image;

                        // Show This Result
                        Results9.Visible = true;

                        // required
                        break;

                    case 10:

                        // Set Background Image
                        Results10.BackgroundImage = SysImage.FromFile(image.Path);

                        // Set the Path
                        Results10.Image = image;

                        // Show This Result
                        Results10.Visible = true;

                        // required
                        break;

                    default:
                        // Handle cases where count is out of the expected range if necessary
                        break;
                }
            }
        }
        #endregion

        #region DisplayResults()
        /// <summary>
        /// Display Results
        /// </summary>
        public void DisplayResults(List<ImageView> results)
        {
            // local
            int count = 0;

            // Hide them all
            UIVisibility(false);

            // If the results collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(results))
            {
                // Show a message
                ResultsLabel.Text = "Display results 1 - " + results.Count;

                // Iterate the collection of ImageView objects
                foreach (ImageView result in results)
                {
                    // verify the result exists on disk
                    if (FileHelper.Exists(result.Path))
                    {
                        // Increment the value for count
                        count++;

                        // Display the result and show this picture box
                        DisplayResult(result, count);
                    }
                }
            }
            else
            {
                // Show a message
                ResultsLabel.Text = "No matching images. Only Indexed Images Will Show Up";
            }

            // Enable or disable controls
            UIEnable();
        }
        #endregion

        #region Init()
        /// <summary>
        ///  This method performs initializations for this object.
        /// </summary>
        public void Init()
        {
            // Create a new instance of a 'Gateway' object.
            Gateway gateway = new Gateway(ConnectionConstants.Name);

            // Set the Admin object
            Admin = gateway.LoadAdmins().FirstOrDefault();

            // If the admin object does not exist
            if (NullHelper.IsNull(admin))
            {
                // Create a new instance of an 'admin' object.
                Admin = new Admin();
            }

            // Display the MemeFolder (if set)
            MemeFolderControl.Text = Admin.MemeFolder;

            // Set Index
            IndexedOnSaveCheckBox.Checked = Admin.IndexOnSave;

            // Setup the Listeners
            Results1.Listener = this;
            Results2.Listener = this;
            Results3.Listener = this;
            Results4.Listener = this;
            Results5.Listener = this;
            Results6.Listener = this;
            Results7.Listener = this;
            Results8.Listener = this;
            Results9.Listener = this;
            Results10.Listener = this;

            // Hide them all
            UIVisibility(false);
        }
        #endregion

        #region PerformDelete()
        /// <summary>
        /// Perform Delete
        /// </summary>
        public void PerformDelete()
        {
            // if the value for HasSelectedImage is true
            if (HasSelectedImage)
            {
                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway(ConnectionConstants.Name);

                // Perofrm delete
                bool deleted = gateway.DeleteImage(SelectedImage.Id);

                // if deleted
                if (deleted)
                {  
                    // Clone the image
                    Image copy = SelectedImage.Clone();

                    // Remove this image
                    int index = AllImages.FindIndex(x => x.Id == SelectedImage.Id);

                    // ensure in range
                    if (NumericHelper.IsInRange(index, 0, AllImagesCount -1))
                    {
                        // Remove this image
                        AllImages.RemoveAt(index);

                        // Remove
                        ImagePreview.BackgroundImage = null;

                        // Erase
                        SelectedImage = null;
                        SelectedImageIndex = SelectedImageIndex -1;

                        // if less than zero
                        if (SelectedImageIndex < 0)
                        {
                            // reset
                            SelectedImageIndex = 0;
                        }

                        // Must be erased before advancing to next image
                        SelectedAlternate = null;

                        // if Image Out of Context
                        if (ImageOutOfContext && ReturnToSearchOnSave.Checked)
                        {
                            // Return to search
                            SearchMode.Checked = true;

                            // Exit imageOutOfContext Mode
                            imageOutOfContext = false;

                            // Return to search
                            UIVisibility(false);

                            // Return to search
                            UIEnable();
                        }
                        else
                        {
                            // Set the SelectedImage
                            DisplayIndexStats();

                            // Reserialize
                            SelectedImageHash = "";

                            // Show a message
                            StatusLabel.Text = "Image Deleted.";

                            // Handle buttons
                            UIEnable();
                        }

                        // Delete the file on disk
                        File.Delete(copy.Path);
                    }
                }
            }
        }
        #endregion

        #region ScanDirectoryForImages()
        /// <summary>
        /// Scan Directory For Images
        /// </summary>
        public void ScanDirectoryForImages()
        {
            // local
            int savedCount = 0;

            // If the Directory exists
            if (FolderHelper.Exists(MemeFolder))
            {
                // Create the files
                List<string> files = new List<string>();

                List<string> extensions = new List<string>();
                extensions.Add(".png");
                extensions.Add(".jpg");

                // Get the files in the directory
                FileHelper.GetFilesRecursively(MemeFolder, ref files, extensions);

                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway(ConnectionConstants.Name);

                // If the files collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(files))
                {
                    // Show a message
                    StatusLabel.Text = "Scanning Meme Folder...";

                    // Refresh
                    Refresh();
                    Application.DoEvents();

                    // Show the Graph
                    Graph.Visible = true;
                    Graph.Value = 0;
                    Graph.Maximum = files.Count;
                    int count = 0;

                    // Iterate the collection of string objects
                    foreach (string file in files)
                    {
                        // Increment the value for count
                        count++;

                        // Create a new instance of a 'FileInfo' object.
                        FileInfo fileInfo = new FileInfo(file);

                        // Check if the file already exists
                        Image image = gateway.FindImageByName(fileInfo.Name);

                        // if not saved
                        if (NullHelper.IsNull(image))
                        {
                            // Save the image
                            image = new Image();

                            // Set Properties
                            image.Name = fileInfo.Name;
                            image.Path = file;

                            // Save this image
                            bool saved = gateway.SaveImage(ref image);

                            // if the value for saved is true
                            if (saved)
                            {
                                // Increment the value for savedCount
                                savedCount++;
                            }

                            // Update the Graph
                            Graph.Value = count;

                            // Update the UI
                            Refresh();
                            Application.DoEvents();
                        }
                    }

                    // Show a message
                    StatusLabel.Text = "Saved " + savedCount + " images.";

                    // Hide the Graph
                    Graph.Visible = false;
                }
            }
        }
        #endregion

        #region SetupSelectedImage()
        /// <summary>
        /// Setup Selected Image
        /// </summary>
        public void SetupSelectedImage()
        {
            // if the SelectedImage exists
            if (HasSelectedImage)
            {
                // Serialize
                SelectedImageHash = Morpheus.Serialize(SelectedImage);

                // Setup the Name
                ImageNameControl.Text = SelectedImage.Name;

                // Check the box if Indexed
                IndexedCheckBox.Checked = SelectedImage.Indexed;

                // Load the PixelDatabase
                PixelDatabase pixelDatabase = PixelDatabaseLoader.LoadPixelDatabase(SelectedImage.Path, null);

                // If the pixelDatabase object exists
                if (NullHelper.Exists(pixelDatabase))
                {
                    // Set the PreviewImage
                    ImagePreview.BackgroundImage = pixelDatabase.DirectBitmap.Bitmap;

                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway(ConnectionConstants.Name);

                    // Load the Alternates
                    SelectedImage.Alternates = gateway.LoadAlternatesForImageId(SelectedImage.Id);

                    // Display the Alternates
                    DisplayAlternates();

                    // Enable or disable controls
                    UIEnable();
                }
            }
        }
        #endregion

        #region UIEnable()
        /// <summary>
        /// Enable or Disable or Hide or Show controls
        /// </summary>
        public void UIEnable()
        {
            if (ScreenType == ScreenTypeEnum.Search)
            {
                // Show the SearchPanel
                SearchPanel.Visible = true;
                IndexPanel.Visible = false;
            }
            else
            {
                // Show the IndexPanel
                IndexPanel.Visible = true;
                SearchPanel.Visible = false;
            }

            // Only enable the Rescan button on Index mode
            RescanButton.Enabled = IndexMode.Checked;

            // if the value for HasSelectedImage is true
            if (HasSelectedImage)
            {
                // Set the Name
                SelectedImage.Name = ImageNameControl.Text;

                // if the don't match, enable the Save button
                SaveImageButton.Enabled = !Morpheus.Compare(SelectedImage, SelectedImageHash);
            }
            else
            {
                // Not enabled
                SaveImageButton.Enabled = false;
            }

            // if the value for HasSelectedImage is true
            if (HasSelectedImage)
            {
                // Image is not in the UnindexedImages
                if (imageOutOfContext)
                {
                    // Use Gray Buttons
                    MoveFirstButton.Enabled = false;
                    MovePreviousButton.Enabled = false;
                    MoveNextButton.Enabled = false;
                    MoveLastButton.Enabled = false;
                }
                else
                {
                    // locals
                    bool enableMovePrevious = false;
                    bool enableMoveNext = false;

                    // if OnlyNonIndexed is checked
                    if (OnlyNotIndexedCheckBox.Checked)
                    {
                        // You can move to the first one if not the first one already
                        enableMovePrevious = ((UnindexedImagesCount > 0) && (SelectedImageIndex > 0));
                        enableMoveNext = (UnindexedImagesCount > (SelectedImageIndex + 1));
                    }
                    else
                    {
                        // You can move to the first one if not the first one already
                        enableMovePrevious = ((AllImagesCount > 0) && (SelectedImageIndex > 0));
                        enableMoveNext = (AllImagesCount > (SelectedImageIndex + 1));
                    }

                    MoveFirstButton.Enabled = enableMovePrevious;
                    MovePreviousButton.Enabled = enableMovePrevious;
                    MoveNextButton.Enabled = enableMoveNext;
                    MoveLastButton.Enabled = enableMoveNext;
                }

                // All Disabled
                AddButton.Enabled = true;
                EditButton.Enabled = true;
                DeleteButton.Enabled = true;
                SelectedAlternateLabel.Visible = HasSelectedAlternate;
                SelectedAlternateControl.Visible = HasSelectedAlternate;
                SelectedAlternateControl.Enabled = (EditMode != EditTypeEnum.DisplayOnly);
                AlternatesLabel.Visible = true;
                AlternatesListBox.Visible = true;
                AddButton.Visible = true;
                EditButton.Visible = true;
                DeleteButton.Visible = true;
                IndexedCheckBox.Visible = true;

                // Add is Enabled
                AddButton.Enabled = true;

                // if the value for HasSelectedAlternate is true
                EditButton.Enabled = HasSelectedAlternate;
                DeleteButton.Enabled = HasSelectedAlternate;
            }
            else
            {
                // Use Gray Buttons
                MoveFirstButton.Enabled = false;
                MovePreviousButton.Enabled = false;
                MoveNextButton.Enabled = false;
                MoveLastButton.Enabled = false;

                // All Disabled
                AddButton.Enabled = false;
                EditButton.Enabled = false;
                DeleteButton.Enabled = false;
                SelectedAlternateLabel.Visible = false;
                SelectedAlternateControl.Visible = false;
                AlternatesLabel.Visible = false;
                AlternatesListBox.Visible = false;
                AddButton.Visible = false;
                EditButton.Visible = false;
                DeleteButton.Visible = false;
                IndexedCheckBox.Visible = false;
            }

            // if IndexMode
            if (IndexMode.Checked)
            {
                IndexPanel.Visible = true;
            }
            else
            {
                SearchPanel.Visible = true;
            }

            // Enable the Copy button if there is a selected picture
            CopySelectedButton.Visible = HasSelectedPicture;
            EditAlternatesButton.Visible = HasSelectedPicture;
            ReturnToSearchOnSave.Visible = ImageOutOfContext;
        }
        #endregion

        #region UIVisibility(bool visible)
        /// <summary>
        /// method returns the Visibility
        /// </summary>
        private void UIVisibility(bool visible)
        {
            Results1.Visible = visible;
            Results2.Visible = visible;
            Results3.Visible = visible;
            Results4.Visible = visible;
            Results5.Visible = visible;
            Results6.Visible = visible;
            Results7.Visible = visible;
            Results8.Visible = visible;
            Results9.Visible = visible;
            Results10.Visible = visible;

            // Reset Selected Also
            Results1.Selected = visible;
            Results2.Selected = visible;
            Results3.Selected = visible;
            Results4.Selected = visible;
            Results5.Selected = visible;
            Results6.Selected = visible;
            Results7.Selected = visible;
            Results8.Selected = visible;
            Results9.Selected = visible;
            Results10.Selected = visible;
        }
        #endregion

        #endregion

        #region Properties

        #region Admin
        /// <summary>
        /// This property gets or sets the value for 'Admin'.
        /// </summary>
        public Admin Admin
        {
            get { return admin; }
            set { admin = value; }
        }
        #endregion

        #region AllImages
        /// <summary>
        /// This property gets or sets the value for 'AllImages'.
        /// </summary>
        public List<Image> AllImages
        {
            get { return allImages; }
            set { allImages = value; }
        }
        #endregion

        #region AllImagesCount
        /// <summary>
        /// This read only property returns the value of AllImagesCount from the object AllImages.
        /// </summary>
        public int AllImagesCount
        {

            get
            {
                // initial value
                int allImagesCount = 0;

                // if AllImages exists
                if (HasAllImages)
                {
                    // set the return value
                    allImagesCount = AllImages.Count;
                }

                // return value
                return allImagesCount;
            }
        }
        #endregion

        #region CopyPath
        /// <summary>
        /// This property gets or sets the value for 'CopyPath'.
        /// This is used by the Copy timer to say 'Copied' then restore the path back.
        /// </summary>        
        public string CopyPath
        {
            get { return copyPath; }
            set { copyPath = value; }
        }
        #endregion

        #region CreateParams
        /// <summary>
        /// This property here is what did the trick to reduce the flickering.
        /// I also needed to make all of the controls Double Buffered, but
        /// this was the final touch. It is a little slow when you switch tabs
        /// but that is because the repainting is finishing before control is
        /// returned.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                // initial value
                CreateParams cp = base.CreateParams;

                // Apparently this interrupts Paint to finish before showing
                cp.ExStyle |= 0x02000000;

                // return value
                return cp;
            }
        }
        #endregion

        #region EditMode
        /// <summary>
        /// This property gets or sets the value for 'EditMode'.
        /// </summary>
        public EditTypeEnum EditMode
        {
            get { return editMode; }
            set { editMode = value; }
        }
        #endregion

        #region FirstActivationComplete
        /// <summary>
        /// This property gets or sets the value for 'FirstActivationComplete'.
        /// </summary>
        public bool FirstActivationComplete
        {
            get { return firstActivationComplete; }
            set { firstActivationComplete = value; }
        }
        #endregion

        #region HasAdmin
        /// <summary>
        /// This property returns true if this object has an 'Admin'.
        /// </summary>
        public bool HasAdmin
        {
            get
            {
                // initial value
                bool hasAdmin = (Admin != null);

                // return value
                return hasAdmin;
            }
        }
        #endregion

        #region HasAllImages
        /// <summary>
        /// This property returns true if this object has an 'AllImages'.
        /// </summary>
        public bool HasAllImages
        {
            get
            {
                // initial value
                bool hasAllImages = (AllImages != null);

                // return value
                return hasAllImages;
            }
        }
        #endregion

        #region HasSelectedAlternate
        /// <summary>
        /// This property returns true if this object has a 'SelectedAlternate'.
        /// </summary>
        public bool HasSelectedAlternate
        {
            get
            {
                // initial value
                bool hasSelectedAlternate = (SelectedAlternate != null);

                // return value
                return hasSelectedAlternate;
            }
        }
        #endregion

        #region HasSelectedImage
        /// <summary>
        /// This property returns true if this object has a 'SelectedImage'.
        /// </summary>
        public bool HasSelectedImage
        {
            get
            {
                // initial value
                bool hasSelectedImage = (SelectedImage != null);

                // return value
                return hasSelectedImage;
            }
        }
        #endregion

        #region HasSelectedPicture
        /// <summary>
        /// This property returns true if this object has a 'SelectedPicture'.
        /// </summary>
        public bool HasSelectedPicture
        {
            get
            {
                // initial value
                bool hasSelectedPicture = (SelectedPicture != null);

                // return value
                return hasSelectedPicture;
            }
        }
        #endregion

        #region HasUnindexedImages
        /// <summary>
        /// This property returns true if this object has an 'UnindexedImages'.
        /// </summary>
        public bool HasUnindexedImages
        {
            get
            {
                // initial value
                bool hasUnindexedImages = (UnindexedImages != null);

                // return value
                return hasUnindexedImages;
            }
        }
        #endregion

        #region ImageOutOfContext
        /// <summary>
        /// This property gets or sets the value for 'ImageOutOfContext'.
        /// </summary>
        public bool ImageOutOfContext
        {
            get { return imageOutOfContext; }
            set { imageOutOfContext = value; }
        }
        #endregion
        
        #region MemeFolder
        /// <summary>
        /// This read only property returns the value of MemeFolder from the object Admin.
        /// </summary>
        public string MemeFolder
        {

            get
            {
                // initial value
                string memeFolder = "";

                // if Admin exists
                if (HasAdmin)
                {
                    // set the return value
                    memeFolder = Admin.MemeFolder;
                }

                // return value
                return memeFolder;
            }
        }
        #endregion

        #region ScreenType
        /// <summary>
        /// This property gets or sets the value for 'ScreenType'.
        /// </summary>
        public ScreenTypeEnum ScreenType
        {
            get { return screenType; }
            set { screenType = value; }
        }
        #endregion

        #region SelectedAlternate
        /// <summary>
        /// This property gets or sets the value for 'SelectedAlternate'.
        /// </summary>
        public Alternate SelectedAlternate
        {
            get { return selectedAlternate; }
            set { selectedAlternate = value; }
        }
        #endregion

        #region SelectedImage
        /// <summary>
        /// This property gets or sets the value for 'SelectedImage'.
        /// </summary>
        public Image SelectedImage
        {
            get { return selectedImage; }
            set { selectedImage = value; }
        }
        #endregion

        #region SelectedImageHash
        /// <summary>
        /// This property gets or sets the value for 'SelectedImageHash'.
        /// </summary>
        public string SelectedImageHash
        {
            get { return selectedImageHash; }
            set { selectedImageHash = value; }
        }
        #endregion

        #region SelectedImageIndex
        /// <summary>
        /// This property gets or sets the value for 'SelectedImageIndex'.
        /// </summary>
        public int SelectedImageIndex
        {
            get { return selectedImageIndex; }
            set { selectedImageIndex = value; }
        }
        #endregion

        #region SelectedPicture
        /// <summary>
        /// This property gets or sets the value for 'SelectedPicture'.
        /// </summary>
        public PictureViewer SelectedPicture
        {
            get { return selectedPicture; }
            set { selectedPicture = value; }
        }
        #endregion

        #region UnindexedImages
        /// <summary>
        /// This read only property returns the value of UnindexedImages from the object AllImages.
        /// </summary>
        public List<Image> UnindexedImages
        {

            get
            {
                // initial value
                List<Image> unindexedImages = null;

                // if AllImages exists
                if (AllImages != null)
                {
                    // set the return value
                    unindexedImages = AllImages.Where(x => x.Indexed == false).ToList();
                }

                // return value
                return unindexedImages;
            }
        }
        #endregion

        #region UnindexedImagesCount
        /// <summary>
        /// This read only property returns the value of Count from the object UnindexedImages.
        /// </summary>
        public int UnindexedImagesCount
        {

            get
            {
                // initial value
                int unindexedImagesCount = 0;

                // if UnindexedImages exists
                if (HasUnindexedImages)
                {
                    // set the return value
                    unindexedImagesCount = UnindexedImages.Count;
                }

                // return value
                return unindexedImagesCount;
            }
        }
        #endregion

        #endregion

    }
    #endregion

}