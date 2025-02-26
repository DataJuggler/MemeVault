

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

    #region class AlternateController
    /// <summary>
    /// This class controls a(n) 'Alternate' object.
    /// </summary>
    public class AlternateController
    {

        #region Methods

            #region CreateAlternateParameter
            /// <summary>
            /// This method creates the parameter for a 'Alternate' data operation.
            /// </summary>
            /// <param name='alternate'>The 'Alternate' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateAlternateParameter(Alternate alternate)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = alternate;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Alternate tempAlternate, DataManager dataManager)
            /// <summary>
            /// Deletes a 'Alternate' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'Alternate_Delete'.
            /// </summary>
            /// <param name='alternate'>The 'Alternate' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(Alternate tempAlternate, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteAlternate";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempalternate exists before attemptintg to delete
                    if (tempAlternate != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteAlternateMethod = AlternateMethods.DeleteAlternate;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAlternateParameter(tempAlternate);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteAlternateMethod, parameters, dataManager);

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

            #region FetchAll(Alternate tempAlternate, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'Alternate' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Alternate_FetchAll'.</summary>
            /// <param name='tempAlternate'>A temporary Alternate for passing values.</param>
            /// <returns>A collection of 'Alternate' objects.</returns>
            public static List<Alternate> FetchAll(Alternate tempAlternate, DataManager dataManager)
            {
                // Initial value
                List<Alternate> alternateList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = AlternateMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateAlternateParameter(tempAlternate);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Alternate> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        alternateList = (List<Alternate>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return alternateList;
            }
            #endregion

            #region Find(Alternate tempAlternate, DataManager dataManager)
            /// <summary>
            /// Finds a 'Alternate' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Alternate_Find'</param>
            /// </summary>
            /// <param name='tempAlternate'>A temporary Alternate for passing values.</param>
            /// <returns>A 'Alternate' object if found else a null 'Alternate'.</returns>
            public static Alternate Find(Alternate tempAlternate, DataManager dataManager)
            {
                // Initial values
                Alternate alternate = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempAlternate != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = AlternateMethods.FindAlternate;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAlternateParameter(tempAlternate);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Alternate != null))
                        {
                            // Get ReturnObject
                            alternate = (Alternate) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return alternate;
            }
            #endregion

            #region Insert(Alternate alternate, DataManager dataManager)
            /// <summary>
            /// Insert a 'Alternate' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Alternate_Insert'.</param>
            /// </summary>
            /// <param name='alternate'>The 'Alternate' object to insert.</param>
            /// <returns>The id (int) of the new  'Alternate' object that was inserted.</returns>
            public static int Insert(Alternate alternate, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Alternateexists
                    if (alternate != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = AlternateMethods.InsertAlternate;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAlternateParameter(alternate);

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

            #region Save(ref Alternate alternate, DataManager dataManager)
            /// <summary>
            /// Saves a 'Alternate' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='alternate'>The 'Alternate' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref Alternate alternate, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the alternate exists.
                if (alternate != null)
                {
                    // Is this a new Alternate
                    if (alternate.IsNew)
                    {
                        // Insert new Alternate
                        int newIdentity = Insert(alternate, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            alternate.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Alternate
                        saved = Update(alternate, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Alternate alternate, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'Alternate' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Alternate_Update'.</param>
            /// </summary>
            /// <param name='alternate'>The 'Alternate' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(Alternate alternate, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (alternate != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = AlternateMethods.UpdateAlternate;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAlternateParameter(alternate);
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
