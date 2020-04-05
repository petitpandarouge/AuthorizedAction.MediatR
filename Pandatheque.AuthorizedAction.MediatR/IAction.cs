using MediatR;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Interface for always authorized command.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public interface IAction<TRequest, TResponse> : IAuthorizedAction<TRequest, VoidPolicyContext, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
    }
}
