using MediatR;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using System.Collections.Generic;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests
{
    public class ListerEnquetesRequest : IRequest<(bool, ICollection<Enquete>)>
    {
    }
}
