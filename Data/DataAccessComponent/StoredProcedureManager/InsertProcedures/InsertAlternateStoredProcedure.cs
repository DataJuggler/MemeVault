

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertAlternateStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Alternate' object.
    /// </summary>
    public class InsertAlternateStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertAlternateStoredProcedure' object.
        /// </summary>
        public InsertAlternateStoredProcedure()
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
                this.ProcedureName = "Alternate_Insert";

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
