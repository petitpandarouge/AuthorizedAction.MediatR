using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Base class for no response action.
    /// </summary>
    /// <typeparam name="TParameters">The type of the action parameters.</typeparam>
    public abstract class ANoResponseAuthorizedAction<TParameters> : INoResponseAuthorizedAction<TParameters>
        where TParameters : class
    {
        #region Methods

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="actionParams">The action parameters.</param>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        async Task<Void> IAuthorizedAction<TParameters, Void>.ExecuteAsync(TParameters actionParams, CancellationToken cancellationToken)
        {
            await this.ExecuteAsync(actionParams, cancellationToken);
            return Void.Default;
        }

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        protected abstract Task ExecuteAsync(TParameters actionParams, CancellationToken cancellationToken);

        #endregion // Methods
    }
}
