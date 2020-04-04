using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using System.Collections.Generic;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions
{
    public interface IListerEnquetes : INoParameterAuthorizedAction<(bool, ICollection<Enquete>)>
    {
    }
}
