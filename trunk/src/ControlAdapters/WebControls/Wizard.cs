using System;

namespace ControlAdapters.WebControls
{
    /// <summary>
    /// Subclass of the default <see cref="System.Web.UI.WebControls.Wizard"/> control.
    /// No functionality is changed; this class is functionally equivalent to its ancestor.
    /// </summary>
    /// <remarks>
    /// The class exists to allow you to apply the control adapters functionality to this class
    /// instead of the default control, allowing you to have both default and adapted functionality
    /// based on the control used.
    /// </remarks>
    public class Wizard : System.Web.UI.WebControls.Wizard
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Wizard()
            : base()
        {
        }
    }
}
