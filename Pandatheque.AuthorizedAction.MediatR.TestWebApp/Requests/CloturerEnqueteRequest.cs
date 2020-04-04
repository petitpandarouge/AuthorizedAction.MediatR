using MediatR;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests
{
    public class CloturerEnqueteRequest : IRequest<(bool, Enquete)>
    {
        public int EnqueteId { get; set; }
    }
}
