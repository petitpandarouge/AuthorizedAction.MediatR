using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests;
using System.Collections.Generic;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions
{
    public interface IListerEnquetes : IAlwaysAuthorizedAction<ListerEnquetesRequest, (bool, ICollection<Enquete>)>
    {
    }
}
