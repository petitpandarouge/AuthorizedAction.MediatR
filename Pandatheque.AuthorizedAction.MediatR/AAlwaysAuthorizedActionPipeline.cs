using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Pipeline is responsible for linking the action execution steps and performing the action execution.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TParameters">The type of the action parameters.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public abstract class AAlwaysAuthorizedActionPipeline<TRequest, TAction, TParameters, TResponse> : AAuthorizedActionPipeline<TRequest, VoidPolicyContext, TAction, TParameters, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TAction : class, IAuthorizedAction<TParameters, TResponse>
        where TParameters : class
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AAlwaysAuthorizedActionPipeline{TRequest, TAction, TParameters, TResponse}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AAlwaysAuthorizedActionPipeline(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Converts the request to the policy context.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <returns>The policy context.</returns>
        public override sealed VoidPolicyContext ToPolicyContext(TRequest request)
        {
            return new VoidPolicyContext();
        }

        /// <summary>
        /// Converts the request and the policy context to the action parameters.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <returns>The action parameters.</returns>
        public override sealed TParameters ToActionParameters(TRequest request, VoidPolicyContext policyContext)
        {
            return this.ToActionParameters(request);
        }

        /// <summary>
        /// Converts the request to the action parameters.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <returns>The action parameters.</returns>
        protected virtual TParameters ToActionParameters(TRequest request)
        {
            return request as TParameters;
        }

        /// <summary>
        /// Converts the request and the policy context to the unauthorized response.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <returns>The unauthorized response.</returns>
        public override sealed TResponse ToUnauthorizedResponse(TRequest request, VoidPolicyContext policyContext)
        {
            return this.ToUnauthorizedResponse(request);
        }

        /// <summary>
        /// Converts the request to the unauthorized response.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <returns>The action parameters.</returns>
        protected abstract TResponse ToUnauthorizedResponse(TRequest request);

        #endregion // Methods
    }
}
