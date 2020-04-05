using MediatR;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Interface defining a request checking if an action can be executed.
    /// </summary>
    public interface ICanExecuteRequest : IRequest<bool>
    {
    }
}
