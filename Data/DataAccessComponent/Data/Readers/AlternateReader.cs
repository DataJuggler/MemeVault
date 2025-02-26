

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class AlternateReader
    /// <summary>
    /// This class loads a single 'Alternate' object or a list of type <Alternate>.
    /// </summary>
    public class AlternateReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Alternate' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Alternate' DataObject.</returns>
            public static Alternate Load(DataRow dataRow)
            {
                // Initial Value
                Alternate alternate = new Alternate();

                // Create field Integers
                int idfield = 0;
                int imageIdfield = 1;
                int namefield = 2;

                try
                {
                    // Load Each field
                    alternate.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    alternate.ImageId = DataHelper.ParseInteger(dataRow.ItemArray[imageIdfield], 0);
                    alternate.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                }
                catch
                {
                }

                // return value
                return alternate;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Alternate' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Alternate Collection.</returns>
            public static List<Alternate> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Alternate> alternates = new List<Alternate>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Alternate' from rows
                        Alternate alternate = Load(row);

                        // Add this object to collection
                        alternates.Add(alternate);
                    }
                }
                catch
                {
                }

                // return value
                return alternates;
            }
            #endregion

        #endregion

    }
    #endregion

}
