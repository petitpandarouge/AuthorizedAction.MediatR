using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions
{
    public abstract class ACloturerEnquete : ICloturerEnquete
    {
        public Task<(bool, Enquete)> ExecuteAsync(CloturerEnqueteRequest request, CloturerEnquetePolicyContext actionParams, CancellationToken cancellationToken)
        {
            actionParams.Enquete.Cloturer(actionParams.Utilisateur);
            return Task.FromResult((true, actionParams.Enquete));
        }
    }
}
