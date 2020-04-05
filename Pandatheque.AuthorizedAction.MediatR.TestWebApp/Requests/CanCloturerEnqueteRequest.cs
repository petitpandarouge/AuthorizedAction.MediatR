using MediatR;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests
{
    public class CanCloturerEnqueteRequest : ICanExecuteRequest
    {
        public int EnqueteId { get; set; }
    }
}
