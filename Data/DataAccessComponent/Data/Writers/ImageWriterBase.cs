

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

    #region class ImageWriterBase
    /// <summary>
    /// This class is used for converting a 'Image' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ImageWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Image image)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='image'>The 'Image' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Image image)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (image != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", image.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteImageStoredProcedure(Image image)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteImage'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Image_Delete'.
            /// </summary>
            /// <param name="image">The 'Image' to Delete.</param>
            /// <returns>An instance of a 'DeleteImageStoredProcedure' object.</returns>
            public static DeleteImageStoredProcedure CreateDeleteImageStoredProcedure(Image image)
            {
                // Initial Value
                DeleteImageStoredProcedure deleteImageStoredProcedure = new DeleteImageStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteImageStoredProcedure.Parameters = CreatePrimaryKeyParameter(image);

                // return value
                return deleteImageStoredProcedure;
            }
            #endregion

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
            public static FindImageStoredProcedure CreateFindImageStoredProcedure(Image image)
            {
                // Initial Value
                FindImageStoredProcedure findImageStoredProcedure = null;

                // verify image exists
                if(image != null)
                {
                    // Instanciate findImageStoredProcedure
                    findImageStoredProcedure = new FindImageStoredProcedure();

                    // Now create parameters for this procedure
                    findImageStoredProcedure.Parameters = CreatePrimaryKeyParameter(image);
                }

                // return value
                return findImageStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Image image)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new image.
            /// </summary>
            /// <param name="image">The 'Image' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Image image)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify imageexists
                if(image != null)
                {
                    // Create [Indexed] parameter
                    param = new SqlParameter("@Indexed", image.Indexed);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", image.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Path] parameter
                    param = new SqlParameter("@Path", image.Path);

                    // set parameters[2]
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertImageStoredProcedure(Image image)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertImageStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Image_Insert'.
            /// </summary>
            /// <param name="image"The 'Image' object to insert</param>
            /// <returns>An instance of a 'InsertImageStoredProcedure' object.</returns>
            public static InsertImageStoredProcedure CreateInsertImageStoredProcedure(Image image)
            {
                // Initial Value
                InsertImageStoredProcedure insertImageStoredProcedure = null;

                // verify image exists
                if(image != null)
                {
                    // Instanciate insertImageStoredProcedure
                    insertImageStoredProcedure = new InsertImageStoredProcedure();

                    // Now create parameters for this procedure
                    insertImageStoredProcedure.Parameters = CreateInsertParameters(image);
                }

                // return value
                return insertImageStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Image image)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing image.
            /// </summary>
            /// <param name="image">The 'Image' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Image image)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify imageexists
                if(image != null)
                {
                    // Create parameter for [Indexed]
                    param = new SqlParameter("@Indexed", image.Indexed);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", image.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Path]
                    param = new SqlParameter("@Path", image.Path);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", image.Id);
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateImageStoredProcedure(Image image)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateImageStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Image_Update'.
            /// </summary>
            /// <param name="image"The 'Image' object to update</param>
            /// <returns>An instance of a 'UpdateImageStoredProcedure</returns>
            public static UpdateImageStoredProcedure CreateUpdateImageStoredProcedure(Image image)
            {
                // Initial Value
                UpdateImageStoredProcedure updateImageStoredProcedure = null;

                // verify image exists
                if(image != null)
                {
                    // Instanciate updateImageStoredProcedure
                    updateImageStoredProcedure = new UpdateImageStoredProcedure();

                    // Now create parameters for this procedure
                    updateImageStoredProcedure.Parameters = CreateUpdateParameters(image);
                }

                // return value
                return updateImageStoredProcedure;
            }
            #endregion

            #region CreateFetchAllImagesStoredProcedure(Image image)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllImagesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Image_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllImagesStoredProcedure' object.</returns>
            public static FetchAllImagesStoredProcedure CreateFetchAllImagesStoredProcedure(Image image)
            {
                // Initial value
                FetchAllImagesStoredProcedure fetchAllImagesStoredProcedure = new FetchAllImagesStoredProcedure();

                // return value
                return fetchAllImagesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
