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
    public abstract class AIsAllowedQuery<TAction, TRequest, TPolicyContext> : IRequestHandler<TRequest, bool>
        where TRequest : class, ICanExecuteRequest
        where TPolicyContext: class, IPolicyContext
        where TAction : class
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
        /// Initializes a new instance of the <see cref="AIsAllowedQuery{TAction, TRequest, TPolicyContext}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AIsAllowedQuery(IServiceProvider serviceProvider)
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

        #endregion // Methods

        #region IRequestHandler<TRequest, TResponse>

        #region Methods

        /// <summary>
        /// Handles the request by checking the policies.
        /// </summary>
        /// <param name="request">The request to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response.</returns>
        Task<bool> IRequestHandler<TRequest, bool>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            // Step 1: Converting the request to the policy context.
            TPolicyContext context = this.BuildPolicyContext(request);

            // Step 2: Checking the policies.
            IPolicyResult<TAction> result = this.actionChecker.CheckPolicies(context);

            // Step 3: Returning the result.
            return Task.FromResult(result.Allowed);
        }

        #endregion // Methods

        #endregion // IRequestHandler<TRequest, TResponse> 
    }
}
