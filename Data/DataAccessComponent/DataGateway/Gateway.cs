
#region using statements

using DataAccessComponent.Controllers;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Data;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

#endregion

namespace DataAccessComponent.DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method either create an override or
    /// add or set properties to the temp object that is passed in.
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        private string connectionName;        
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Gateway object.
        /// </summary>
        public Gateway(string connectionName)
        {
            // store the ConnectionName
            ConnectionName = connectionName;

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods
        
            #region DeleteAdmin(int id, Admin tempAdmin = null)
            /// <summary>
            /// This method is used to delete Admin objects.
            /// </summary>
            /// <param name="id">Delete the Admin with this id</param>
            /// <param name="tempAdmin">Pass in a tempAdmin to perform a custom delete.</param>
            public bool DeleteAdmin(int id, Admin tempAdmin = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempAdmin does not exist
                    if (tempAdmin == null)
                    {
                        // create a temp Admin
                        tempAdmin = new Admin();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempAdmin.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = AdminController.Delete(tempAdmin, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteAlternate(int id, Alternate tempAlternate = null)
            /// <summary>
            /// This method is used to delete Alternate objects.
            /// </summary>
            /// <param name="id">Delete the Alternate with this id</param>
            /// <param name="tempAlternate">Pass in a tempAlternate to perform a custom delete.</param>
            public bool DeleteAlternate(int id, Alternate tempAlternate = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempAlternate does not exist
                    if (tempAlternate == null)
                    {
                        // create a temp Alternate
                        tempAlternate = new Alternate();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempAlternate.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = AlternateController.Delete(tempAlternate, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteImage(int id, Image tempImage = null)
            /// <summary>
            /// This method is used to delete Image objects.
            /// </summary>
            /// <param name="id">Delete the Image with this id</param>
            /// <param name="tempImage">Pass in a tempImage to perform a custom delete.</param>
            public bool DeleteImage(int id, Image tempImage = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempImage does not exist
                    if (tempImage == null)
                    {
                        // create a temp Image
                        tempImage = new Image();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempImage.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = ImageController.Delete(tempImage, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.Data.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindAdmin(int id, Admin tempAdmin = null)
            /// <summary>
            /// This method is used to find 'Admin' objects.
            /// </summary>
            /// <param name="id">Find the Admin with this id</param>
            /// <param name="tempAdmin">Pass in a tempAdmin to perform a custom find.</param>
            public Admin FindAdmin(int id, Admin tempAdmin = null)
            {
                // initial value
                Admin admin = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempAdmin does not exist
                    if (tempAdmin == null)
                    {
                        // create a temp Admin
                        tempAdmin = new Admin();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempAdmin.UpdateIdentity(id);
                    }

                    // perform the find
                    admin = AdminController.Find(tempAdmin, DataManager);
                }

                // return value
                return admin;
            }
            #endregion

            #region FindAlternate(int id, Alternate tempAlternate = null)
            /// <summary>
            /// This method is used to find 'Alternate' objects.
            /// </summary>
            /// <param name="id">Find the Alternate with this id</param>
            /// <param name="tempAlternate">Pass in a tempAlternate to perform a custom find.</param>
            public Alternate FindAlternate(int id, Alternate tempAlternate = null)
            {
                // initial value
                Alternate alternate = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempAlternate does not exist
                    if (tempAlternate == null)
                    {
                        // create a temp Alternate
                        tempAlternate = new Alternate();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempAlternate.UpdateIdentity(id);
                    }

                    // perform the find
                    alternate = AlternateController.Find(tempAlternate, DataManager);
                }

                // return value
                return alternate;
            }
            #endregion

            #region FindImage(int id, Image tempImage = null)
            /// <summary>
            /// This method is used to find 'Image' objects.
            /// </summary>
            /// <param name="id">Find the Image with this id</param>
            /// <param name="tempImage">Pass in a tempImage to perform a custom find.</param>
            public Image FindImage(int id, Image tempImage = null)
            {
                // initial value
                Image image = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempImage does not exist
                    if (tempImage == null)
                    {
                        // create a temp Image
                        tempImage = new Image();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempImage.UpdateIdentity(id);
                    }

                    // perform the find
                    image = ImageController.Find(tempImage, DataManager);
                }

                // return value
                return image;
            }
            #endregion

            #region FindImageByName(string name)
            /// <summary>
            /// This method is used to find 'Image' objects for the Name given.
            /// </summary>
            public Image FindImageByName(string name)
            {
                // initial value
                Image image = null;
                
                // Create a temp Image object
                Image tempImage = new Image();
                
                // Set the value for FindByName to true
                tempImage.FindByName = true;
                
                // Set the value for Name
                tempImage.Name = name;
                
                // Perform the find
                image = FindImage(0, tempImage);
                
                // return value
                return image;
            }
            #endregion
            
            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists.
            /// Always test for null before refeferencing the Exception returned as it will be null 
            /// if no errors were encountered.
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // If the AppController object exists
                if (HasAppController)
                {
                    // return the Exception from the AppController
                    exception = AppController.Exception;

                    // Set to null after the exception is retrieved so it does not return again
                    AppController.Exception = null;
                }

                // return value
                return exception;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                AppController = new ApplicationController(ConnectionName);
            }
            #endregion

            #region LoadAdmins(Admin tempAdmin = null)
            /// <summary>
            /// This method loads a collection of 'Admin' objects.
            /// </summary>
            public List<Admin> LoadAdmins(Admin tempAdmin = null)
            {
                // initial value
                List<Admin> admins = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    admins = AdminController.FetchAll(tempAdmin, DataManager);
                }

                // return value
                return admins;
            }
            #endregion

            #region LoadAlternates(Alternate tempAlternate = null)
            /// <summary>
            /// This method loads a collection of 'Alternate' objects.
            /// </summary>
            public List<Alternate> LoadAlternates(Alternate tempAlternate = null)
            {
                // initial value
                List<Alternate> alternates = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    alternates = AlternateController.FetchAll(tempAlternate, DataManager);
                }

                // return value
                return alternates;
            }
            #endregion

            #region LoadAlternatesForImageId(int imageId)
            /// <summary>
            /// This method is used to load 'Alternate' objects for the ImageId given.
            /// </summary>
            public List<Alternate> LoadAlternatesForImageId(int imageId)
            {
                // initial value
                List<Alternate> alternates = null;
                
                // Create a temp Alternate object
                Alternate tempAlternate = new Alternate();
                
                // Set the value for LoadByImageId to true
                tempAlternate.LoadByImageId = true;
                
                // Set the value for ImageId
                tempAlternate.ImageId = imageId;
                
                // Perform the load
                alternates = LoadAlternates(tempAlternate);
                
                // return value
                return alternates;
            }
            #endregion
            
            #region LoadImages(Image tempImage = null)
            /// <summary>
            /// This method loads a collection of 'Image' objects.
            /// </summary>
            public List<Image> LoadImages(Image tempImage = null)
            {
                // initial value
                List<Image> images = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    images = ImageController.FetchAll(tempImage, DataManager);
                }

                // return value
                return images;
            }
            #endregion

            #region LoadImageViews(ImageView tempImageView = null)
            /// <summary>
            /// This method loads a collection of 'ImageView' objects.
            /// </summary>
            public List<ImageView> LoadImageViews(ImageView tempImageView = null)
            {
                // initial value
                List<ImageView> imageViews = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    imageViews = ImageViewController.FetchAll(tempImageView, DataManager);
                }

                // return value
                return imageViews;
            }
            #endregion

            #region LoadImageViewsForSearch(string searchText)
            /// <summary>
            /// This method is used to load 'ImageView' objects for the Name given.
            /// </summary>
            public List<ImageView> LoadImageViewsForSearch(string searchText)
            {
                // initial value
                List<ImageView> imageViews = null;
                
                // Create a temp ImageView object
                ImageView tempImageView = new ImageView();
                
                // Set the value for LoadBySearch to true
                tempImageView.LoadForSearch = true;
                
                // Set the value for Name
                tempImageView.Name = searchText;
                
                // Perform the load
                imageViews = LoadImageViews(tempImageView);
                
                // return value
                return imageViews;
            }
            #endregion
            
            #region SaveAdmin(ref Admin admin)
            /// <summary>
            /// This method is used to save 'Admin' objects.
            /// </summary>
            /// <param name="admin">The Admin to save.</param>
            public bool SaveAdmin(ref Admin admin)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = AdminController.Save(ref admin, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveAlternate(ref Alternate alternate)
            /// <summary>
            /// This method is used to save 'Alternate' objects.
            /// </summary>
            /// <param name="alternate">The Alternate to save.</param>
            public bool SaveAlternate(ref Alternate alternate)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = AlternateController.Save(ref alternate, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveImage(ref Image image)
            /// <summary>
            /// This method is used to save 'Image' objects.
            /// </summary>
            /// <param name="image">The Image to save.</param>
            public bool SaveImage(ref Image image)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = ImageController.Save(ref image, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            /// <summary>
            /// This property gets or sets the value for 'AppController'.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ConnectionName
            /// <summary>
            /// This property gets or sets the value for 'ConnectionName'.
            /// </summary>
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion
            
            #region DataManager
            /// <summary>
            /// This read only property returns the value of DataManager from the object AppController.
            /// </summary>
            public DataManager DataManager
            {

                get
                {
                    // initial value
                    DataManager dataManager = null;

                    // if AppController exists
                    if (HasAppController)
                    {
                        // set the return value
                        dataManager = AppController.DataManager;
                    }

                    // return value
                    return dataManager;
                }
            }
            #endregion

            #region HasAppController
            /// <summary>
            /// This property returns true if this object has an 'AppController'.
            /// </summary>
            public bool HasAppController
            {
                get
                {
                    // initial value
                    bool hasAppController = (this.AppController != null);

                    // return value
                    return hasAppController;
                }
            }
            #endregion

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
                    // return value
                    return hasConnectionName;
                }
            }
            #endregion
            
            #region HasDataManager
            /// <summary>
            /// This property returns true if this object has a 'DataManager'.
            /// </summary>
            public bool HasDataManager
            {
                get
                {
                    // initial value
                    bool hasDataManager = (DataManager != null);

                    // return value
                    return hasDataManager;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}

