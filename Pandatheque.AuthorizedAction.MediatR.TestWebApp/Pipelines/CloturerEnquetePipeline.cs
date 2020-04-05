using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;
using System;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Pipelines
{
    public class CloturerEnquetePipeline : AAuthorizedActionPipeline<
        CloturerEnqueteRequest, // Request
        CloturerEnquetePolicyContext, // Policy context
        ICloturerEnquete, // Action
        (bool, Enquete)> // Action response
    {
        public CloturerEnquetePipeline(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public override CloturerEnquetePolicyContext BuildPolicyContext(CloturerEnqueteRequest request)
        {
            // Getting the objects from the database...
            CloturerEnquetePolicyContext context = new CloturerEnquetePolicyContext
            {
                Utilisateur = Utilisateur.CreateAdmin(),
                Enquete = Enquete.Create(request.EnqueteId)
            };

            return context;
        }

        public override (bool, Enquete) BuildUnauthorizedResponse(CloturerEnqueteRequest request, CloturerEnquetePolicyContext policyContext)
        {
            // Using Problem class...
            return (false, null);
        }
    }
}
