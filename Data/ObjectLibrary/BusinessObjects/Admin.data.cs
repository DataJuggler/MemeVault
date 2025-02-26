

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Admin
    public partial class Admin
    {

        #region Private Variables
        private int id;
        private bool indexOnSave;
        private string memeFolder;
        private bool suppressDeletePrompt;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.id = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region bool IndexOnSave
            public bool IndexOnSave
            {
                get
                {
                    return indexOnSave;
                }
                set
                {
                    indexOnSave = value;
                }
            }
            #endregion

            #region string MemeFolder
            public string MemeFolder
            {
                get
                {
                    return memeFolder;
                }
                set
                {
                    memeFolder = value;
                }
            }
            #endregion

            #region bool SuppressDeletePrompt
            public bool SuppressDeletePrompt
            {
                get
                {
                    return suppressDeletePrompt;
                }
                set
                {
                    suppressDeletePrompt = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
