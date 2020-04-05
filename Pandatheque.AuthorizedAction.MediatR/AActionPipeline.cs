using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Pipeline is responsible for linking the action execution steps and performing the action execution.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public abstract class AActionPipeline<TRequest, TAction, TResponse> : AAuthorizedActionPipeline<TRequest, VoidPolicyContext, TAction, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TAction : class, IAction<TRequest, TResponse>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AActionPipeline{TRequest, TAction, TResponse}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AActionPipeline(IServiceProvider serviceProvider)
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
        public override VoidPolicyContext BuildPolicyContext(TRequest request)
        {
            return new VoidPolicyContext();
        }

        /// <summary>
        /// Builds the the unauthorized response from the request and the policy context.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The unauthorized response.</returns>
        public override sealed TResponse BuildUnauthorizedResponse(TRequest request, VoidPolicyContext policyContext)
        {
            return this.BuildUnauthorizedResponse(request);
        }

        /// <summary>
        /// Builds the the unauthorized response from the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The action parameters.</returns>
        protected abstract TResponse BuildUnauthorizedResponse(TRequest request);

        #endregion // Methods
    }
}
