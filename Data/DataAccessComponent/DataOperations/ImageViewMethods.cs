

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.DataBridge;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class ImageViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'ImageView' object.
    /// </summary>
    public static class ImageViewMethods
    {

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'ImageView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ImageView' to delete.
            /// <returns>A PolymorphicObject object with all  'ImageViews' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ImageView> imageViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllImageViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ImageViewParameter
                    // Declare Parameter
                    ImageView paramImageView = null;

                    // verify the first parameters is a(n) 'ImageView'.
                    if (parameters[0].ObjectValue as ImageView != null)
                    {
                        // Get ImageViewParameter
                        paramImageView = (ImageView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllImageViewsProc from ImageViewWriter
                    fetchAllProc = ImageViewWriter.CreateFetchAllImageViewsStoredProcedure(paramImageView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    imageViewListCollection = ImageViewManager.FetchAllImageViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(imageViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = imageViewListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

    }
    #endregion

}
