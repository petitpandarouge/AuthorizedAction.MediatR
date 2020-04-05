using MediatR;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Interface for no response authorized command with no response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TPolicyContext">The type of the context policy.</typeparam>
    public interface IVoidAuthorizedAction<TRequest, TPolicyContext> : IAuthorizedAction<TRequest, TPolicyContext, Void>
        where TRequest : class, IRequest<Void>
        where TPolicyContext : class, IPolicyContext
    {
    }
}
