
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

    #region class ImageWriter
    /// <summary>
    /// This class is used for converting a 'Image' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ImageWriter : ImageWriterBase
    {

        #region Static Methods

            #region CreateFindImageStoredProcedure(Image image)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindImageStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Image_Find'.
            /// </summary>
            /// <param name="image">The 'Image' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindImageStoredProcedure CreateFindImageStoredProcedure(Image image)
            {
                // Initial Value
                FindImageStoredProcedure findImageStoredProcedure = null;

                // verify image exists
                if(image != null)
                {
                    // Instanciate findImageStoredProcedure
                    findImageStoredProcedure = new FindImageStoredProcedure();

                    // if image.FindByName is true
                    if (image.FindByName)
                    {
                            // Change the procedure name
                            findImageStoredProcedure.ProcedureName = "Image_FindByName";
                            
                            // Create the @Name parameter
                            findImageStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Name", image.Name);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findImageStoredProcedure.Parameters = CreatePrimaryKeyParameter(image);
                    }
                }

                // return value
                return findImageStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
