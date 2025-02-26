

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

    #region class AlternateMethods
    /// <summary>
    /// This class contains methods for modifying a 'Alternate' object.
    /// </summary>
    public static class AlternateMethods
    {

        #region Methods

            #region DeleteAlternate(Alternate)
            /// <summary>
            /// This method deletes a 'Alternate' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Alternate' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteAlternate(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteAlternateStoredProcedure deleteAlternateProc = null;

                    // verify the first parameters is a(n) 'Alternate'.
                    if (parameters[0].ObjectValue as Alternate != null)
                    {
                        // Create Alternate
                        Alternate alternate = (Alternate) parameters[0].ObjectValue;

                        // verify alternate exists
                        if(alternate != null)
                        {
                            // Now create deleteAlternateProc from AlternateWriter
                            // The DataWriter converts the 'Alternate'
                            // to the SqlParameter[] array needed to delete a 'Alternate'.
                            deleteAlternateProc = AlternateWriter.CreateDeleteAlternateStoredProcedure(alternate);
                        }
                    }

                    // Verify deleteAlternateProc exists
                    if(deleteAlternateProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = AlternateManager.DeleteAlternate(deleteAlternateProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
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

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Alternate' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Alternate' to delete.
            /// <returns>A PolymorphicObject object with all  'Alternates' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Alternate> alternateListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllAlternatesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get AlternateParameter
                    // Declare Parameter
                    Alternate paramAlternate = null;

                    // verify the first parameters is a(n) 'Alternate'.
                    if (parameters[0].ObjectValue as Alternate != null)
                    {
                        // Get AlternateParameter
                        paramAlternate = (Alternate) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllAlternatesProc from AlternateWriter
                    fetchAllProc = AlternateWriter.CreateFetchAllAlternatesStoredProcedure(paramAlternate);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    alternateListCollection = AlternateManager.FetchAllAlternates(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(alternateListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = alternateListCollection;
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

            #region FindAlternate(Alternate)
            /// <summary>
            /// This method finds a 'Alternate' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Alternate' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindAlternate(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Alternate alternate = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindAlternateStoredProcedure findAlternateProc = null;

                    // verify the first parameters is a 'Alternate'.
                    if (parameters[0].ObjectValue as Alternate != null)
                    {
                        // Get AlternateParameter
                        Alternate paramAlternate = (Alternate) parameters[0].ObjectValue;

                        // verify paramAlternate exists
                        if(paramAlternate != null)
                        {
                            // Now create findAlternateProc from AlternateWriter
                            // The DataWriter converts the 'Alternate'
                            // to the SqlParameter[] array needed to find a 'Alternate'.
                            findAlternateProc = AlternateWriter.CreateFindAlternateStoredProcedure(paramAlternate);
                        }

                        // Verify findAlternateProc exists
                        if(findAlternateProc != null)
                        {
                            // Execute Find Stored Procedure
                            alternate = AlternateManager.FindAlternate(findAlternateProc, dataConnector);

                            // if dataObject exists
                            if(alternate != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = alternate;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertAlternate (Alternate)
            /// <summary>
            /// This method inserts a 'Alternate' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Alternate' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertAlternate(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Alternate alternate = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertAlternateStoredProcedure insertAlternateProc = null;

                    // verify the first parameters is a(n) 'Alternate'.
                    if (parameters[0].ObjectValue as Alternate != null)
                    {
                        // Create Alternate Parameter
                        alternate = (Alternate) parameters[0].ObjectValue;

                        // verify alternate exists
                        if(alternate != null)
                        {
                            // Now create insertAlternateProc from AlternateWriter
                            // The DataWriter converts the 'Alternate'
                            // to the SqlParameter[] array needed to insert a 'Alternate'.
                            insertAlternateProc = AlternateWriter.CreateInsertAlternateStoredProcedure(alternate);
                        }

                        // Verify insertAlternateProc exists
                        if(insertAlternateProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = AlternateManager.InsertAlternate(insertAlternateProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateAlternate (Alternate)
            /// <summary>
            /// This method updates a 'Alternate' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Alternate' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateAlternate(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Alternate alternate = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateAlternateStoredProcedure updateAlternateProc = null;

                    // verify the first parameters is a(n) 'Alternate'.
                    if (parameters[0].ObjectValue as Alternate != null)
                    {
                        // Create Alternate Parameter
                        alternate = (Alternate) parameters[0].ObjectValue;

                        // verify alternate exists
                        if(alternate != null)
                        {
                            // Now create updateAlternateProc from AlternateWriter
                            // The DataWriter converts the 'Alternate'
                            // to the SqlParameter[] array needed to update a 'Alternate'.
                            updateAlternateProc = AlternateWriter.CreateUpdateAlternateStoredProcedure(alternate);
                        }

                        // Verify updateAlternateProc exists
                        if(updateAlternateProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = AlternateManager.UpdateAlternate(updateAlternateProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

    }
    #endregion

}
