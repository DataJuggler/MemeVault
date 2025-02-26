

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

    #region class AlternateManager
    /// <summary>
    /// This class is used to manage a 'Alternate' object.
    /// </summary>
    public class AlternateManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'AlternateManager' object.
        /// </summary>
        public AlternateManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteAlternate()
            /// <summary>
            /// This method deletes a 'Alternate' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteAlternate(DeleteAlternateStoredProcedure deleteAlternateProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteAlternateProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllAlternates()
            /// <summary>
            /// This method fetches a  'List<Alternate>' object.
            /// This method uses the 'Alternates_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Alternate>'</returns>
            /// </summary>
            public static List<Alternate> FetchAllAlternates(FetchAllAlternatesStoredProcedure fetchAllAlternatesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Alternate> alternateCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allAlternatesDataSet = DataHelper.LoadDataSet(fetchAllAlternatesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allAlternatesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allAlternatesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            alternateCollection = AlternateReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return alternateCollection;
            }
            #endregion

            #region FindAlternate()
            /// <summary>
            /// This method finds a  'Alternate' object.
            /// This method uses the 'Alternate_Find' procedure.
            /// </summary>
            /// <returns>A 'Alternate' object.</returns>
            /// </summary>
            public static Alternate FindAlternate(FindAlternateStoredProcedure findAlternateProc, DataConnector databaseConnector)
            {
                // Initial Value
                Alternate alternate = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet alternateDataSet = DataHelper.LoadDataSet(findAlternateProc, databaseConnector);

                    // Verify DataSet Exists
                    if(alternateDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(alternateDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Alternate
                            alternate = AlternateReader.Load(row);
                        }
                    }
                }

                // return value
                return alternate;
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

            #region InsertAlternate()
            /// <summary>
            /// This method inserts a 'Alternate' object.
            /// This method uses the 'Alternate_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertAlternate(InsertAlternateStoredProcedure insertAlternateProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertAlternateProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateAlternate()
            /// <summary>
            /// This method updates a 'Alternate'.
            /// This method uses the 'Alternate_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateAlternate(UpdateAlternateStoredProcedure updateAlternateProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateAlternateProc, databaseConnector);
                }

                // return value
                return saved;
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
