

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateAlternateStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Alternate' object.
    /// </summary>
    public class UpdateAlternateStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateAlternateStoredProcedure' object.
        /// </summary>
        public UpdateAlternateStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "Alternate_Update";

                // Set tableName
                this.TableName = "Alternate";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
