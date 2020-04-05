using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Pipeline is responsible for linking the action execution steps and performing the action execution.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TPolicyContext">The type of the context policy.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public abstract class AAuthorizedActionPipeline<TRequest, TPolicyContext, TAction, TResponse> : IRequestHandler<TRequest, TResponse>
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
        /// Initializes a new instance of the <see cref="AAuthorizedAction{TRequest, TPolicyContext, TAction, TParameters, TResponse}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AAuthorizedActionPipeline(IServiceProvider serviceProvider)
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
        public virtual TPolicyContext BuildPolicyContext(TRequest request)
        {
            return request as TPolicyContext;
        }

        /// <summary>
        /// Builds the the unauthorized response from the request and the policy context.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <returns>The unauthorized response.</returns>
        public abstract TResponse BuildUnauthorizedResponse(TRequest request, TPolicyContext policyContext);

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
            IPolicyResult<TAction> result = this.actionChecker.CheckPolicies(context);
            if (result.Allowed)
            {
                // Step 3: Executing the action.
                return await result.Action.ExecuteAsync(request, context, cancellationToken);
            }

            // Step 4: Action is unauthorized.
            return this.BuildUnauthorizedResponse(request, context);
        }

        #endregion // Methods

        #endregion // IRequestHandler<TRequest, TResponse>
    }
}
