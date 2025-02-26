
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

    #region class AlternateWriter
    /// <summary>
    /// This class is used for converting a 'Alternate' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class AlternateWriter : AlternateWriterBase
    {

        #region Static Methods

            #region CreateFetchAllAlternatesStoredProcedure(Alternate alternate)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllAlternatesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Alternate_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllAlternatesStoredProcedure' object.</returns>
            public static new FetchAllAlternatesStoredProcedure CreateFetchAllAlternatesStoredProcedure(Alternate alternate)
            {
                // Initial value
                FetchAllAlternatesStoredProcedure fetchAllAlternatesStoredProcedure = new FetchAllAlternatesStoredProcedure();

                // if the alternate object exists
                if (alternate != null)
                {
                    // if LoadByImageId is true
                    if (alternate.LoadByImageId)
                    {
                        // Change the procedure name
                        fetchAllAlternatesStoredProcedure.ProcedureName = "Alternate_FetchAllForImageId";
                        
                        // Create the @ImageId parameter
                        fetchAllAlternatesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ImageId", alternate.ImageId);
                    }
                }
                
                // return value
                return fetchAllAlternatesStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
