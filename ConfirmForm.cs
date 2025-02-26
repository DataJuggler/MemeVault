#region using statements

#endregion

using DataAccessComponent.DataGateway;
using DataAccessComponent.Connection;
using ObjectLibrary.Enumerations;
using ObjectLibrary.BusinessObjects;
using DataJuggler.UltimateHelper;

namespace MemeVault
{

    #region class ConfirmForm
    /// <summary>
    /// This class is used to get a users response
    /// </summary>
    public partial class ConfirmForm : Form
    {

        #region Private Variables
        private YesNoResponse response;
        private bool deleteSuppressed;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ConfirmForm' object.
        /// </summary>
        public ConfirmForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Events

        #region NoButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'NoButton' is clicked.
        /// </summary>
        private void NoButton_Click(object sender, EventArgs e)
        {
            // Set to No
            Response = YesNoResponse.No;

            // if checked
            if (DoNotShowAgainCheckBox.Checked)
            {
                // Save Admin.SuppressDeletePrompt
                DoNotShowAgain();
            }

            // Close this form
            Close();
        }
        #endregion
        
        #region YesButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'YesButton' is clicked.
        /// </summary>
        private void YesButton_Click(object sender, EventArgs e)
        {
            // Set to Yes
            Response = YesNoResponse.Yes;

            // if checked
            if (DoNotShowAgainCheckBox.Checked)
            {
                // Save Admin.SuppressDeletePrompt
                DoNotShowAgain();
            }

            // Close this form
            Close();
        }
        #endregion
        
        #endregion

        #region Methods

        #region DoNotShowAgain()
        /// <summary>
        /// Do Not Show Again
        /// </summary>
        public void DoNotShowAgain()
        {
            // Create a new instance of a 'Gateway' object.
            Gateway gateway = new Gateway(ConnectionConstants.Name);

            // Load the Admin object
            Admin admin = gateway.LoadAdmins().FirstOrDefault();

            // If the admin object exists
            if (NullHelper.Exists(admin))
            {
                // Set to true
                admin.SuppressDeletePrompt = true;

                // Save
                bool saved = gateway.SaveAdmin(ref admin);

                // if the value for saved is true
                if (saved)
                {
                    // Set this so the MainForm can update
                    DeleteSuppressed = true;
                }
            }
        }
        #endregion
        
        #region Setup(string prompt)
        /// <summary>
        /// Setup
        /// </summary>
        public void Setup(string prompt)
        {
            // Set the text to show
            StatusLabel.Text = prompt;
        }
        #endregion

        #endregion

        #region Properties

        #region DeleteSuppressed
        /// <summary>
        /// This property gets or sets the value for 'DeleteSuppressed'.
        /// </summary>
        public bool DeleteSuppressed
        {
            get { return deleteSuppressed; }
            set { deleteSuppressed = value; }
        }
        #endregion
        
        #region Response
        /// <summary>
        /// This property gets or sets the value for 'Response'.
        /// </summary>
        public YesNoResponse Response
        {
            get { return response; }
            set { response = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
