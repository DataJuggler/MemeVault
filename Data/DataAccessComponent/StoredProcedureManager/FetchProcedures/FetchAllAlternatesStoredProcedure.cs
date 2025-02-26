

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllAlternatesStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Alternate' objects.
    /// </summary>
    public class FetchAllAlternatesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllAlternatesStoredProcedure' object.
        /// </summary>
        public FetchAllAlternatesStoredProcedure()
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
                this.ProcedureName = "Alternate_FetchAll";

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
