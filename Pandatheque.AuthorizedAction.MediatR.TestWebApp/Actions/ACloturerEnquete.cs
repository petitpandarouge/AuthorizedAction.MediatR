using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions
{
    public abstract class ACloturerEnquete : AAuthorizedAction<ICloturerEnquete, CloturerEnqueteRequest, CloturerEnquetePolicyContext, (bool, Enquete)>, ICloturerEnquete
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ACloturerEnquete"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected ACloturerEnquete(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors

        #region Methods

        protected override CloturerEnquetePolicyContext BuildPolicyContext(CloturerEnqueteRequest request)
        {
            // Getting the objects from the database...
            CloturerEnquetePolicyContext context = new CloturerEnquetePolicyContext
            {
                Utilisateur = Utilisateur.CreateAdmin(),
                Enquete = Enquete.Create(request.EnqueteId)
            };

            return context;
        }

        protected override Task<(bool, Enquete)> ExecuteAsync(CloturerEnqueteRequest request, CloturerEnquetePolicyContext actionParams, CancellationToken cancellationToken)
        {
            actionParams.Enquete.Cloturer(actionParams.Utilisateur);
            return Task.FromResult((true, actionParams.Enquete));
        }

        protected override (bool, Enquete) BuildUnauthorizedResponse(CloturerEnqueteRequest request, CloturerEnquetePolicyContext policyContext)
        {
            // Using Problem class...
            return (false, null);
        }

        #endregion // Methods
    }
}
