

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class AdminReader
    /// <summary>
    /// This class loads a single 'Admin' object or a list of type <Admin>.
    /// </summary>
    public class AdminReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Admin' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Admin' DataObject.</returns>
            public static Admin Load(DataRow dataRow)
            {
                // Initial Value
                Admin admin = new Admin();

                // Create field Integers
                int idfield = 0;
                int indexOnSavefield = 1;
                int memeFolderfield = 2;
                int suppressDeletePromptfield = 3;

                try
                {
                    // Load Each field
                    admin.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    admin.IndexOnSave = DataHelper.ParseBoolean(dataRow.ItemArray[indexOnSavefield], false);
                    admin.MemeFolder = DataHelper.ParseString(dataRow.ItemArray[memeFolderfield]);
                    admin.SuppressDeletePrompt = DataHelper.ParseBoolean(dataRow.ItemArray[suppressDeletePromptfield], false);
                }
                catch
                {
                }

                // return value
                return admin;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Admin' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Admin Collection.</returns>
            public static List<Admin> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Admin> admins = new List<Admin>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Admin' from rows
                        Admin admin = Load(row);

                        // Add this object to collection
                        admins.Add(admin);
                    }
                }
                catch
                {
                }

                // return value
                return admins;
            }
            #endregion

        #endregion

    }
    #endregion

}
