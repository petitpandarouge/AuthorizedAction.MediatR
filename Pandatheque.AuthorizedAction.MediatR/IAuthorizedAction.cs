using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Interface for an authorized action handled via the MadiatR pipeline.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TPolicyContext">The type of the context policy.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public interface IAuthorizedAction<TRequest, TPolicyContext, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TPolicyContext : class, IPolicyContext
    {
        #region Methods

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="request">The initiale request.</param>
        /// <param name="context">The policy context.</param>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        Task<TResponse> ExecuteAsync(TRequest request, TPolicyContext context, CancellationToken cancellationToken);

        #endregion // Methods
    }
}
