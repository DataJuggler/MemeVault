

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindAlternateStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Alternate' object.
    /// </summary>
    public class FindAlternateStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindAlternateStoredProcedure' object.
        /// </summary>
        public FindAlternateStoredProcedure()
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
                this.ProcedureName = "Alternate_Find";

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
