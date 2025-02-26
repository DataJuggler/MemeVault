#region using statements

using MemeVault.Interfaces;
using ObjectLibrary.BusinessObjects;
using Image = System.Drawing.Image;

#endregion

namespace MemeVault
{

    #region class PictureViewer
    /// <summary>
    /// This class is used to display an image with a border when selected.
    /// </summary>
    public partial class PictureViewer : UserControl
    {

        #region Private Variables
        private bool selected;
        private Color borderColor;        
        private ImageLayout backgroundImageLayout;
        private IPictureViewerListener listener;
        private ImageView image;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'PictureViewer' object.
        /// </summary>
        public PictureViewer()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

        #region Picture_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'Picture' is clicked.
        /// </summary>
        private void Picture_Click(object sender, EventArgs e)
        {
            // Toggle
            Selected = !Selected;
        }
        #endregion

        #region Picture_MouseEnter(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Picture _ Mouse Enter
        /// </summary>
        private void Picture_MouseEnter(object sender, EventArgs e)
        {
            // Change the cursor to a hand
            Cursor = Cursors.Hand;
        }
        #endregion
        
        #region Picture_MouseLeave(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Picture _ Mouse Leave
        /// </summary>
        private void Picture_MouseLeave(object sender, EventArgs e)
        {
            // Change the cursor back to the default pointer
            Cursor = Cursors.Default;
        }
        #endregion
        
        #endregion

        #region Methods

        #region Init()
        /// <summary>
        ///  This method performs initializations for this object.
        /// </summary>
        public void Init()
        {
            // Ensure it stretches to fill
            BackgroundImageLayout = ImageLayout.Stretch;

            // Default to Black
            BorderColor = Color.Black;
        }
        #endregion

        #endregion

        #region Properties

        #region BackgroundImage
        /// <summary>
        /// This property gets or sets the value for 'BackgroundImage'.
        /// </summary>
        public new Image BackgroundImage
        {
            get
            {
                // return value
                return Picture.BackgroundImage; ;
            }
            set
            {
                // Set the value
                Picture.BackgroundImage = value;
            }
        }
        #endregion

        #region BackgroundImageLayout
        /// <summary>
        /// This property gets or sets the value for 'BackgroundImageLayout'.
        /// </summary>
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                // return value
                return Picture.BackgroundImageLayout;
            }
            set
            {
                // Set the value
                Picture.BackgroundImageLayout = value;
            }
        }
        #endregion

        #region BorderColor
        /// <summary>
        /// This property gets or sets the value for 'BorderColor'.
        /// </summary>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                // set the value
                borderColor = value;

                // Update the panels
                LeftMargin.BackColor = value;
                RightMargin.BackColor = value;
                TopMargin.BackColor = value;
                BottomMargin.BackColor = value;
            }
        }
        #endregion

        #region HasImage
        /// <summary>
        /// This property returns true if this object has an 'Image'.
        /// </summary>
        public bool HasImage
        {
            get
            {
                // initial value
                bool hasImage = (Image != null);

                // return value
                return hasImage;
            }
        }
        #endregion
        
        #region HasListener
        /// <summary>
        /// This property returns true if this object has a 'Listener'.
        /// </summary>
        public bool HasListener
        {
            get
            {
                // initial value
                bool hasListener = (Listener != null);

                // return value
                return hasListener;
            }
        }
        #endregion
        
        #region Image
        /// <summary>
        /// This property gets or sets the value for 'Image'.
        /// </summary>
        public ImageView Image
        {
            get { return image; }
            set { image = value; }
        }
        #endregion
      
        #region Listener
        /// <summary>
        /// This property gets or sets the value for 'Listener'.
        /// </summary>
        public IPictureViewerListener Listener
        {
            get { return listener; }
            set { listener = value; }
        }
        #endregion
        
        #region Path
        /// <summary>
        /// This read only property returns the value of Path from the object Image.
        /// </summary>
        public string Path
        {

            get
            {
                // initial value
                string path = null;

                // if Image exists
                if (Image != null)
                {
                    // set the return value
                    path = Image.Path;
                }

                // return value
                return path;
            }
        }
        #endregion

        #region Selected
        /// <summary>
        /// This property gets or sets the value for 'Selected'.
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set 
            {
                // set the value for selected
                selected = value;

                // if the value for Selected is true
                if (Selected)
                {
                    // Set to Yellow
                    BorderColor = Color.LemonChiffon;
                }
                else
                {
                    // Set to Black
                    BorderColor = Color.Black;
                }

                // if the value for HasListener is true
                if (HasListener)
                {
                    // Clear other selections
                    Listener.PictureViewerSelectionChanged(this);
                }
            }
        }
        #endregion

        #endregion

    }
    #endregion

}
