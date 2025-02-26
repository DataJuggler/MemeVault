

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Writers
{

    #region class AlternateWriterBase
    /// <summary>
    /// This class is used for converting a 'Alternate' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class AlternateWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Alternate alternate)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='alternate'>The 'Alternate' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Alternate alternate)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (alternate != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", alternate.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteAlternateStoredProcedure(Alternate alternate)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteAlternate'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Alternate_Delete'.
            /// </summary>
            /// <param name="alternate">The 'Alternate' to Delete.</param>
            /// <returns>An instance of a 'DeleteAlternateStoredProcedure' object.</returns>
            public static DeleteAlternateStoredProcedure CreateDeleteAlternateStoredProcedure(Alternate alternate)
            {
                // Initial Value
                DeleteAlternateStoredProcedure deleteAlternateStoredProcedure = new DeleteAlternateStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteAlternateStoredProcedure.Parameters = CreatePrimaryKeyParameter(alternate);

                // return value
                return deleteAlternateStoredProcedure;
            }
            #endregion

            #region CreateFindAlternateStoredProcedure(Alternate alternate)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindAlternateStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Alternate_Find'.
            /// </summary>
            /// <param name="alternate">The 'Alternate' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindAlternateStoredProcedure CreateFindAlternateStoredProcedure(Alternate alternate)
            {
                // Initial Value
                FindAlternateStoredProcedure findAlternateStoredProcedure = null;

                // verify alternate exists
                if(alternate != null)
                {
                    // Instanciate findAlternateStoredProcedure
                    findAlternateStoredProcedure = new FindAlternateStoredProcedure();

                    // Now create parameters for this procedure
                    findAlternateStoredProcedure.Parameters = CreatePrimaryKeyParameter(alternate);
                }

                // return value
                return findAlternateStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Alternate alternate)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new alternate.
            /// </summary>
            /// <param name="alternate">The 'Alternate' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Alternate alternate)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify alternateexists
                if(alternate != null)
                {
                    // Create [ImageId] parameter
                    param = new SqlParameter("@ImageId", alternate.ImageId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", alternate.Name);

                    // set parameters[1]
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertAlternateStoredProcedure(Alternate alternate)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertAlternateStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Alternate_Insert'.
            /// </summary>
            /// <param name="alternate"The 'Alternate' object to insert</param>
            /// <returns>An instance of a 'InsertAlternateStoredProcedure' object.</returns>
            public static InsertAlternateStoredProcedure CreateInsertAlternateStoredProcedure(Alternate alternate)
            {
                // Initial Value
                InsertAlternateStoredProcedure insertAlternateStoredProcedure = null;

                // verify alternate exists
                if(alternate != null)
                {
                    // Instanciate insertAlternateStoredProcedure
                    insertAlternateStoredProcedure = new InsertAlternateStoredProcedure();

                    // Now create parameters for this procedure
                    insertAlternateStoredProcedure.Parameters = CreateInsertParameters(alternate);
                }

                // return value
                return insertAlternateStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Alternate alternate)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing alternate.
            /// </summary>
            /// <param name="alternate">The 'Alternate' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Alternate alternate)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify alternateexists
                if(alternate != null)
                {
                    // Create parameter for [ImageId]
                    param = new SqlParameter("@ImageId", alternate.ImageId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", alternate.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", alternate.Id);
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateAlternateStoredProcedure(Alternate alternate)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateAlternateStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Alternate_Update'.
            /// </summary>
            /// <param name="alternate"The 'Alternate' object to update</param>
            /// <returns>An instance of a 'UpdateAlternateStoredProcedure</returns>
            public static UpdateAlternateStoredProcedure CreateUpdateAlternateStoredProcedure(Alternate alternate)
            {
                // Initial Value
                UpdateAlternateStoredProcedure updateAlternateStoredProcedure = null;

                // verify alternate exists
                if(alternate != null)
                {
                    // Instanciate updateAlternateStoredProcedure
                    updateAlternateStoredProcedure = new UpdateAlternateStoredProcedure();

                    // Now create parameters for this procedure
                    updateAlternateStoredProcedure.Parameters = CreateUpdateParameters(alternate);
                }

                // return value
                return updateAlternateStoredProcedure;
            }
            #endregion

            #region CreateFetchAllAlternatesStoredProcedure(Alternate alternate)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllAlternatesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Alternate_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllAlternatesStoredProcedure' object.</returns>
            public static FetchAllAlternatesStoredProcedure CreateFetchAllAlternatesStoredProcedure(Alternate alternate)
            {
                // Initial value
                FetchAllAlternatesStoredProcedure fetchAllAlternatesStoredProcedure = new FetchAllAlternatesStoredProcedure();

                // return value
                return fetchAllAlternatesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
