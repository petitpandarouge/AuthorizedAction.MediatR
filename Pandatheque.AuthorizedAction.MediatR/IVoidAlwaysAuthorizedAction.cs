using MediatR;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Interface for always authorized command with no response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    public interface IVoidAlwaysAuthorizedAction<TRequest> : IAlwaysAuthorizedAction<TRequest, Void>
        where TRequest : class, IRequest<Void>
    {
    }
}
