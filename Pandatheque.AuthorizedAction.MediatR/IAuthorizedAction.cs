using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Interface for an action handled via the MadiatR pipeline.
    /// </summary>
    /// <typeparam name="TParameters">The type of the action parameters.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public interface IAuthorizedAction<TParameters, TResponse>
        where TParameters : class
    {
        #region Methods

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="actionParams">The action parameters.</param>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        Task<TResponse> ExecuteAsync(TParameters actionParams, CancellationToken cancellationToken);

        #endregion // Methods
    }
}
