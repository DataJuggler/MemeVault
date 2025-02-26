

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class ImageViewReader
    /// <summary>
    /// This class loads a single 'ImageView' object or a list of type <ImageView>.
    /// </summary>
    public class ImageViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ImageView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ImageView' DataObject.</returns>
            public static ImageView Load(DataRow dataRow)
            {
                // Initial Value
                ImageView imageView = new ImageView();

                // Create field Integers
                int alternateIdfield = 0;
                int alternateNamefield = 1;
                int imageIdfield = 2;
                int indexedfield = 3;
                int namefield = 4;
                int pathfield = 5;

                try
                {
                    // Load Each field
                    imageView.AlternateId = DataHelper.ParseInteger(dataRow.ItemArray[alternateIdfield], 0);
                    imageView.AlternateName = DataHelper.ParseString(dataRow.ItemArray[alternateNamefield]);
                    imageView.ImageId = DataHelper.ParseInteger(dataRow.ItemArray[imageIdfield], 0);
                    imageView.Indexed = DataHelper.ParseBoolean(dataRow.ItemArray[indexedfield], false);
                    imageView.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    imageView.Path = DataHelper.ParseString(dataRow.ItemArray[pathfield]);
                }
                catch
                {
                }

                // return value
                return imageView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ImageView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ImageView Collection.</returns>
            public static List<ImageView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ImageView> imageViews = new List<ImageView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ImageView' from rows
                        ImageView imageView = Load(row);

                        // Add this object to collection
                        imageViews.Add(imageView);
                    }
                }
                catch
                {
                }

                // return value
                return imageViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
