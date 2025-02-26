

#region using statements

#endregion

namespace ObjectLibrary.Enumerations
{

    #region enum EditTypeEnum : int
    /// <summary>
    /// AddNew mode, Edit Mode or DisplayOnly
    /// </summary>
    public enum EditTypeEnum : int
    {
        DisplayOnly = 0,
        AddNewMode = 1,
        EditMode = 2
    }
    #endregion

    #region enum ScreenTypeEnum : int
    /// <summary>
    /// This is the mode the app currently is in
    /// </summary>
    public enum ScreenTypeEnum : int
    {
        Search = 0,
        Index = 1        
    }
    #endregion

    #region enum YesNoResponse : int
    /// <summary>
    /// Returns Yes or No basedd on a users answer.
    /// </summary>
    public enum YesNoResponse : int
    {
        No = 0,
        Yes = 1
    }
    #endregion

}
