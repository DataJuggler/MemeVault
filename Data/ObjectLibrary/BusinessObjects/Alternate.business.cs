
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Alternate
    [Serializable]
    public partial class Alternate
    {

        #region Private Variables
        private bool loadByImageId;
        #endregion

        #region Constructor
        public Alternate()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Alternate Clone()
            {
                // Create New Object
                Alternate newAlternate = (Alternate) this.MemberwiseClone();

                // Return Cloned Object
                return newAlternate;
            }
        #endregion

            #region ToString()
            /// <summary>
            /// method returns the String
            /// </summary>
            public override string ToString()
            {
                return Name;
            }
            #endregion
            
        #endregion

        #region Properties

            #region LoadByImageId
            /// <summary>
            /// This property gets or sets the value for 'LoadByImageId'.
            /// </summary>
            public bool LoadByImageId
            {
                get { return loadByImageId; }
                set { loadByImageId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
