using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions
{
    public interface ICloturerEnquete : IAuthorizedAction<CloturerEnquetePolicyContext, (bool, Enquete)>
    {
    }
}
