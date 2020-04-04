using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Pipeline executing an action without neither parameter nor response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TPolicyContext">The type of the context policy.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    public abstract class AVoidAuthorizedActionPipeline<TRequest, TPolicyContext, TAction> : AAuthorizedActionPipeline<TRequest, TPolicyContext, TAction, Void, Void>
        where TRequest : class, IRequest<Void>
        where TPolicyContext : class, IPolicyContext
        where TAction : class, IAuthorizedAction<Void, Void>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AVoidAuthorizedActionPipeline{TRequest, TPolicyContext, TAction, TParameters}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AVoidAuthorizedActionPipeline(IServiceProvider serviceProvider)
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

        /// <summary>
        /// Converts the request, the policy context and the action parameters to the unauthorized response.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <returns>The unauthorized response.</returns>
        public override sealed Void ToUnauthorizedResponse(TRequest request, TPolicyContext policyContext)
        {
            return Void.Default;
        }

        #endregion // Methods
    }
}
