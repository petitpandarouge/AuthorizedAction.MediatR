using System;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions
{
    public class CloturerEnqueteAdmin : ACloturerEnquete
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloturerEnqueteAdmin"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public CloturerEnqueteAdmin(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors
    }
}
