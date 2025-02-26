

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class ImageController
    /// <summary>
    /// This class controls a(n) 'Image' object.
    /// </summary>
    public class ImageController
    {

        #region Methods

            #region CreateImageParameter
            /// <summary>
            /// This method creates the parameter for a 'Image' data operation.
            /// </summary>
            /// <param name='image'>The 'Image' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateImageParameter(Image image)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = image;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Image tempImage, DataManager dataManager)
            /// <summary>
            /// Deletes a 'Image' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'Image_Delete'.
            /// </summary>
            /// <param name='image'>The 'Image' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(Image tempImage, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteImage";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempimage exists before attemptintg to delete
                    if (tempImage != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteImageMethod = ImageMethods.DeleteImage;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateImageParameter(tempImage);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteImageMethod, parameters, dataManager);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(Image tempImage, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'Image' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Image_FetchAll'.</summary>
            /// <param name='tempImage'>A temporary Image for passing values.</param>
            /// <returns>A collection of 'Image' objects.</returns>
            public static List<Image> FetchAll(Image tempImage, DataManager dataManager)
            {
                // Initial value
                List<Image> imageList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = ImageMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateImageParameter(tempImage);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Image> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        imageList = (List<Image>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return imageList;
            }
            #endregion

            #region Find(Image tempImage, DataManager dataManager)
            /// <summary>
            /// Finds a 'Image' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Image_Find'</param>
            /// </summary>
            /// <param name='tempImage'>A temporary Image for passing values.</param>
            /// <returns>A 'Image' object if found else a null 'Image'.</returns>
            public static Image Find(Image tempImage, DataManager dataManager)
            {
                // Initial values
                Image image = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempImage != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = ImageMethods.FindImage;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateImageParameter(tempImage);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Image != null))
                        {
                            // Get ReturnObject
                            image = (Image) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return image;
            }
            #endregion

            #region Insert(Image image, DataManager dataManager)
            /// <summary>
            /// Insert a 'Image' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Image_Insert'.</param>
            /// </summary>
            /// <param name='image'>The 'Image' object to insert.</param>
            /// <returns>The id (int) of the new  'Image' object that was inserted.</returns>
            public static int Insert(Image image, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Imageexists
                    if (image != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = ImageMethods.InsertImage;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateImageParameter(image);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, insertMethod , parameters, dataManager);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref Image image, DataManager dataManager)
            /// <summary>
            /// Saves a 'Image' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='image'>The 'Image' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref Image image, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the image exists.
                if (image != null)
                {
                    // Is this a new Image
                    if (image.IsNew)
                    {
                        // Insert new Image
                        int newIdentity = Insert(image, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            image.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Image
                        saved = Update(image, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Image image, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'Image' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Image_Update'.</param>
            /// </summary>
            /// <param name='image'>The 'Image' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(Image image, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (image != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = ImageMethods.UpdateImage;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateImageParameter(image);
                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, updateMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

    }
    #endregion

}
