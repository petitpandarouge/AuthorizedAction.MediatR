using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Base class for no response action.
    /// </summary>
    /// <typeparam name="TParameters">The type of the action parameters.</typeparam>
    public abstract class AVoidAuthorizedAction<TRequest, TPolicyContext> : IVoidAuthorizedAction<TRequest, TPolicyContext>
        where TRequest : class, IRequest<Void>
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
        async Task<Void> IAuthorizedAction<TRequest, TPolicyContext, Void>.ExecuteAsync(TRequest request, TPolicyContext context, CancellationToken cancellationToken)
        {
            await this.ExecuteAsync(request, context, cancellationToken);
            return Void.Default;
        }

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="request">The initiale request.</param>
        /// <param name="context">The policy context.</param>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        protected abstract Task ExecuteAsync(TRequest request, TPolicyContext context, CancellationToken cancellationToken);

        #endregion // Methods
    }
}
