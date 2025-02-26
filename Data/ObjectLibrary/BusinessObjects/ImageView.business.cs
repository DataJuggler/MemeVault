
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class ImageView
    [Serializable]
    public partial class ImageView
    {

        #region Private Variables
        private bool loadBySearch;
        #endregion

        #region Constructor
        public ImageView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ImageView Clone()
            {
                // Create New Object
                ImageView newImageView = (ImageView) this.MemberwiseClone();

                // Return Cloned Object
                return newImageView;
            }
            #endregion

        #endregion

        #region Properties

            #region LoadBySearch
            /// <summary>
            /// This property gets or sets the value for 'LoadBySearch'.
            /// </summary>
            public bool LoadBySearch
            {
                get { return loadBySearch; }
                set { loadBySearch = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
