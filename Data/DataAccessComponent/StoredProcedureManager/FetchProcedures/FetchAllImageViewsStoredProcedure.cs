

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllImageViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ImageView' objects.
    /// </summary>
    public class FetchAllImageViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllImageViewsStoredProcedure' object.
        /// </summary>
        public FetchAllImageViewsStoredProcedure()
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
                this.ProcedureName = "ImageView_FetchAll";

                // Set tableName
                this.TableName = "ImageView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
