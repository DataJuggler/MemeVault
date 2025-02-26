

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Image
    public partial class Image
    {

        #region Private Variables
        private int id;
        private bool indexed;
        private string name;
        private string path;
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

            #region bool Indexed
            public bool Indexed
            {
                get
                {
                    return indexed;
                }
                set
                {
                    indexed = value;
                }
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            #endregion

            #region string Path
            public string Path
            {
                get
                {
                    return path;
                }
                set
                {
                    path = value;
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
