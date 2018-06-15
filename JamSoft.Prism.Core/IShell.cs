namespace JamSoft.Prism.Core
{
    /// <summary>
    /// The main application shell
    /// </summary>
    public interface IShell
    {
        /// <summary>
        /// Sets the main shell view model instance.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        object Model { set; }
    }
}