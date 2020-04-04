using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Base class for no parameter action.
    /// </summary>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public abstract class ANoParameterAuthorizedAction<TResponse> : INoParameterAuthorizedAction<TResponse>
    {
        #region Methods

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="actionParams">The action parameters.</param>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        async Task<TResponse> IAuthorizedAction<Void, TResponse>.ExecuteAsync(Void actionParams, CancellationToken cancellationToken)
        {
            return await this.ExecuteAsync(cancellationToken);
        }

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        protected abstract Task<TResponse> ExecuteAsync(CancellationToken cancellationToken);

        #endregion // Methods
    }
}
