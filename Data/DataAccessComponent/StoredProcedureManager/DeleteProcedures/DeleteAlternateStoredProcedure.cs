

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteAlternateStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Alternate' object.
    /// </summary>
    public class DeleteAlternateStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteAlternateStoredProcedure' object.
        /// </summary>
        public DeleteAlternateStoredProcedure()
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
                this.ProcedureName = "Alternate_Delete";

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
