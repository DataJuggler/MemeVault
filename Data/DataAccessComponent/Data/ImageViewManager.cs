

#region using statements

using DataAccessComponent.Data.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data
{

    #region class ImageViewManager
    /// <summary>
    /// This class is used to manage a 'ImageView' object.
    /// </summary>
    public class ImageViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ImageViewManager' object.
        /// </summary>
        public ImageViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllImageViews()
            /// <summary>
            /// This method fetches a  'List<ImageView>' object.
            /// This method uses the 'ImageViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ImageView>'</returns>
            /// </summary>
            public static List<ImageView> FetchAllImageViews(FetchAllImageViewsStoredProcedure fetchAllImageViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ImageView> imageViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allImageViewsDataSet = DataHelper.LoadDataSet(fetchAllImageViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allImageViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allImageViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            imageViewCollection = ImageViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return imageViewCollection;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
