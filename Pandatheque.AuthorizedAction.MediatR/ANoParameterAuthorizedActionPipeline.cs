using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Pipeline executing an action with no parameter.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TPolicyContext">The type of the context policy.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public abstract class ANoParameterAuthorizedActionPipeline<TRequest, TPolicyContext, TAction, TResponse> : AAuthorizedActionPipeline<TRequest, TPolicyContext, TAction, Void, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TPolicyContext : class, IPolicyContext
        where TAction : class, IAuthorizedAction<Void, TResponse>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ANoParameterAuthorizedActionPipeline{TRequest, TPolicyContext, TAction, TResponse}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected ANoParameterAuthorizedActionPipeline(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Converts the request and the policy context to the action parameters.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <returns>The action parameters.</returns>
        public override sealed Void ToActionParameters(TRequest request, TPolicyContext policyContext)
        {
            return Void.Default;
        }

        #endregion // Methods
    }
}
