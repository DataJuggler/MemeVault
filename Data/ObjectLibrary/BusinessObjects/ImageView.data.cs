

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ImageView
    public partial class ImageView
    {

        #region Private Variables
        private int alternateId;
        private string alternateName;
        private int imageId;
        private bool indexed;
        private string name;
        private string path;
        #endregion

        #region Methods


        #endregion

        #region Properties

            #region int AlternateId
            public int AlternateId
            {
                get
                {
                    return alternateId;
                }
                set
                {
                    alternateId = value;
                }
            }
            #endregion

            #region string AlternateName
            public string AlternateName
            {
                get
                {
                    return alternateName;
                }
                set
                {
                    alternateName = value;
                }
            }
            #endregion

            #region int ImageId
            public int ImageId
            {
                get
                {
                    return imageId;
                }
                set
                {
                    imageId = value;
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

        #endregion

    }
    #endregion

}
