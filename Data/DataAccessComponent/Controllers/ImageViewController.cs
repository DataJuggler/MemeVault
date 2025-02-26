

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

    #region class ImageViewController
    /// <summary>
    /// This class controls a(n) 'ImageView' object.
    /// </summary>
    public class ImageViewController
    {

        #region Methods

            #region CreateImageViewParameter
            /// <summary>
            /// This method creates the parameter for a 'ImageView' data operation.
            /// </summary>
            /// <param name='imageview'>The 'ImageView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateImageViewParameter(ImageView imageView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = imageView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(ImageView tempImageView, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'ImageView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ImageView_FetchAll'.</summary>
            /// <param name='tempImageView'>A temporary ImageView for passing values.</param>
            /// <returns>A collection of 'ImageView' objects.</returns>
            public static List<ImageView> FetchAll(ImageView tempImageView, DataManager dataManager)
            {
                // Initial value
                List<ImageView> imageViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = ImageViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateImageViewParameter(tempImageView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ImageView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        imageViewList = (List<ImageView>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return imageViewList;
            }
            #endregion

        #endregion

    }
    #endregion

}
