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
    /// <typeparam name="TParameters">The type of the action parameters.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public abstract class AAuthorizedActionPipeline<TRequest, TPolicyContext, TAction, TParameters, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TPolicyContext: class, IPolicyContext
        where TAction : class, IAuthorizedAction<TParameters, TResponse>
        where TParameters: class
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
        /// Initializes a new instance of the <see cref="AAuthorizedActionPipeline{TRequest, TPolicyContext, TAction, TParameters, TResponse}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AAuthorizedActionPipeline(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            this.actionChecker = this.serviceProvider.GetService<IAuthorizedActionChecker<TPolicyContext, TAction>>();
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Converts the request to the policy context.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <returns>The policy context.</returns>
        public virtual TPolicyContext ToPolicyContext(TRequest request)
        {
            return request as TPolicyContext;
        }

        /// <summary>
        /// Converts the request and the policy context to the action parameters.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <returns>The action parameters.</returns>
        public virtual TParameters ToActionParameters(TRequest request, TPolicyContext policyContext)
        {
            return policyContext as TParameters;
        }

        /// <summary>
        /// Converts the request, the policy context and the action parameters to the unauthorized response.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <returns>The unauthorized response.</returns>
        public abstract TResponse ToUnauthorizedResponse(TRequest request, TPolicyContext policyContext);

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
            TPolicyContext context = this.ToPolicyContext(request);

            // Step 2: Checking the policies.
            IPolicyResult<TAction> result = this.actionChecker.CheckPolicies(context);
            if (result.Allowed)
            {
                // Step 3: Converting the request and the policy context to the action parameters.
                TParameters parameters = this.ToActionParameters(request, context);

                // Step 4: Executing the action.
                return await result.Action.ExecuteAsync(parameters, cancellationToken);
            }

            // Step 5: Action is unauthorized.
            return this.ToUnauthorizedResponse(request, context);
        }

        #endregion // Methods

        #endregion // IRequestHandler<TRequest, TResponse>
    }
}
