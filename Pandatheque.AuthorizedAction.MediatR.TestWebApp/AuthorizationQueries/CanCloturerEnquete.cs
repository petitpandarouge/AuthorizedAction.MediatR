using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests;
using System;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.AuthorizationQueries
{
    public class CanCloturerEnquete : AIsAllowedQuery<ICloturerEnquete, CanCloturerEnqueteRequest, CloturerEnquetePolicyContext>
    {
        public CanCloturerEnquete(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        protected override CloturerEnquetePolicyContext BuildPolicyContext(CanCloturerEnqueteRequest request)
        {
            // Getting the objects from the database...
            CloturerEnquetePolicyContext context = new CloturerEnquetePolicyContext
            {
                Utilisateur = Utilisateur.CreateAdmin(),
                Enquete = Enquete.Create(request.EnqueteId)
            };

            return context;
        }
    }
}
