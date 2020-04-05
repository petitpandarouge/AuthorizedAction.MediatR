using System;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions
{
    public class CloturerEnqueteModification : ACloturerEnquete
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloturerEnqueteModification"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public CloturerEnqueteModification(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors
    }
}
