using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Base class for the always authorized action.
    /// </summary>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public abstract class AAlwaysAuthorizedAction<TAction, TRequest, TResponse> : AAuthorizedAction<TAction, TRequest, VoidPolicyContext, TResponse>, IAlwaysAuthorizedAction<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TAction : class, IAlwaysAuthorizedAction<TRequest, TResponse>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AAlwaysAuthorizedAction{TAction, TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AAlwaysAuthorizedAction(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Builds the policy context from the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The policy context.</returns>
        protected override sealed VoidPolicyContext BuildPolicyContext(TRequest request)
        {
            return new VoidPolicyContext();
        }

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="request">The initiale request.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        protected override sealed Task<TResponse> ExecuteAsync(TRequest request, VoidPolicyContext policyContext, CancellationToken cancellationToken)
        {
            return this.ExecuteAsync(request, cancellationToken);
        }

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="request">The initiale request.</param>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        protected abstract Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Builds the the unauthorized response from the request and the policy context.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The unauthorized response.</returns>
        protected override sealed TResponse BuildUnauthorizedResponse(TRequest request, VoidPolicyContext policyContext)
        {
            // Will never be called.
            return default;
        }

        #endregion // Methods
    }
}
