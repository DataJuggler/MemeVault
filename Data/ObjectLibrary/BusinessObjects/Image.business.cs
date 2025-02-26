
#region using statements

using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Image
    [Serializable]
    public partial class Image
    {

        #region Private Variables
        private List<Alternate> alternates;
        private bool findByName;
        private bool loadBySearch;
        #endregion

        #region Constructor
        public Image()
        {
            // Create a new collection of 'Alternate' objects.
            Alternates = new List<Alternate>();
        }
        #endregion

        #region Methods

            #region Clone()
            public Image Clone()
            {
                // Create New Object
                Image newImage = (Image) this.MemberwiseClone();

                // Return Cloned Object
                return newImage;
            }
            #endregion

        #endregion

        #region Properties

            #region Alternates
            /// <summary>
            /// This property gets or sets the value for 'Alternates'.
            /// </summary>
            public List<Alternate> Alternates
            {
                get { return alternates; }
                set { alternates = value; }
            }
            #endregion
            
            #region FindByName
            /// <summary>
            /// This property gets or sets the value for 'FindByName'.
            /// </summary>
            public bool FindByName
            {
                get { return findByName; }
                set { findByName = value; }
            }
            #endregion
            
            #region HasAlternates
            /// <summary>
            /// This property returns true if this object has an 'Alternates'.
            /// </summary>
            public bool HasAlternates
            {
                get
                {
                    // initial value
                    bool hasAlternates = (Alternates != null);

                    // return value
                    return hasAlternates;
                }
            }
            #endregion
            
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
