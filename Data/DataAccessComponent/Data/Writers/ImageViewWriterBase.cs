

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

    #region class ImageViewWriterBase
    /// <summary>
    /// This class is used for converting a 'ImageView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ImageViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllImageViewsStoredProcedure(ImageView imageView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllImageViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ImageView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllImageViewsStoredProcedure' object.</returns>
            public static FetchAllImageViewsStoredProcedure CreateFetchAllImageViewsStoredProcedure(ImageView imageView)
            {
                // Initial value
                FetchAllImageViewsStoredProcedure fetchAllImageViewsStoredProcedure = new FetchAllImageViewsStoredProcedure();

                // return value
                return fetchAllImageViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
