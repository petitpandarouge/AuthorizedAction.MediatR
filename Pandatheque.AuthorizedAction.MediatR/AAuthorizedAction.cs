using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Base class for the authorized action.
    /// </summary>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TPolicyContext">The type of the context policy.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public abstract class AAuthorizedAction<TAction, TRequest, TPolicyContext, TResponse> : IRequestHandler<TRequest, TResponse>, IAuthorizedAction<TRequest, TPolicyContext, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TPolicyContext: class, IPolicyContext
        where TAction : class, IAuthorizedAction<TRequest, TPolicyContext, TResponse>
    {
        #region Fields

        /// <summary>
        /// Stores the service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Stores the action checker.
        /// </summary>
        private readonly IAuthorizedActionChecker<TPolicyContext, TAction> actionChecker;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AAuthorizedAction{TAction, TRequest, TPolicyContext, TResponse}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AAuthorizedAction(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            this.actionChecker = this.serviceProvider.GetRequiredService<IAuthorizedActionChecker<TPolicyContext, TAction>>();
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Builds the policy context from the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The policy context.</returns>
        protected abstract TPolicyContext BuildPolicyContext(TRequest request);

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="request">The initiale request.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        protected abstract Task<TResponse> ExecuteAsync(TRequest request, TPolicyContext policyContext, CancellationToken cancellationToken);

        /// <summary>
        /// Builds the the unauthorized response from the request and the policy context.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <returns>The unauthorized response.</returns>
        protected abstract TResponse BuildUnauthorizedResponse(TRequest request, TPolicyContext policyContext);

        #endregion // Methods

        #region IRequestHandler<TRequest, TResponse>

        #region Methods

        /// <summary>
        /// Handles the request by checking the policies and executing the action.
        /// </summary>
        /// <param name="request">The request to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response.</returns>
        async Task<TResponse> IRequestHandler<TRequest, TResponse>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            // Step 1: Converting the request to the policy context.
            TPolicyContext context = this.BuildPolicyContext(request);

            // Step 2: Checking the policies.
            IPolicyResult<TAction> result = await this.actionChecker.CheckPoliciesAsync(context).ConfigureAwait(false);
            if (result.Allowed)
            {
                // Step 3: Executing the action.
                return await result.Action.ExecuteAsync(request, context, cancellationToken).ConfigureAwait(false);
            }

            // Step 4: Action is unauthorized.
            return this.BuildUnauthorizedResponse(request, context);
        }

        #endregion // Methods

        #endregion // IRequestHandler<TRequest, TResponse>

        #region IAuthorizedAction<TRequest, TPolicyContext, TResponse>

        #region Methods

        /// <summary>
        /// Executes the authorized action.
        /// </summary>
        /// <param name="request">The initiale request.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <param name="cancellationToken">The cancelation token.</param>
        /// <returns>The action response.</returns>
        Task<TResponse> IAuthorizedAction<TRequest, TPolicyContext, TResponse>.ExecuteAsync(TRequest request, TPolicyContext policyContext, CancellationToken cancellationToken)
        {
            return this.ExecuteAsync(request, policyContext, cancellationToken);
        }

        #endregion // Methods

        #endregion // IAuthorizedAction<TRequest, TPolicyContext, TResponse>
    }
}
