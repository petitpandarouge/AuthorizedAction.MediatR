using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions
{
    public interface ICloturerEnquete : IAuthorizedAction<CloturerEnqueteRequest, CloturerEnquetePolicyContext, (bool, Enquete)>
    {
    }
}
