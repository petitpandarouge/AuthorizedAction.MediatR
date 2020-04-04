using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Base class for neither parameter nor response action.
    /// </summary>
    public abstract class AVoidAuthorizedAction : IVoidAuthorizedAction
    {
        #region Methods

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="actionParams">The action parameters.</param>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        async Task<Void> IAuthorizedAction<Void, Void>.ExecuteAsync(Void actionParams, CancellationToken cancellationToken)
        {
            await this.ExecuteAsync(cancellationToken);
            return Void.Default;
        }

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        protected abstract Task ExecuteAsync(CancellationToken cancellationToken);

        #endregion // Methods
    }
}
