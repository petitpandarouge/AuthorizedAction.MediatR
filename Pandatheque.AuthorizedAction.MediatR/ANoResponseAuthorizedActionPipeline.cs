using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Pipeline executing an action with no response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TPolicyContext">The type of the context policy.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TParameters">The type of the action parameters.</typeparam>
    public abstract class ANoResponseAuthorizedActionPipeline<TRequest, TPolicyContext, TAction, TParameters> : AAuthorizedActionPipeline<TRequest, TPolicyContext, TAction, TParameters, Void>
        where TRequest : class, IRequest<Void>
        where TPolicyContext : class, IPolicyContext
        where TAction : class, IAuthorizedAction<TParameters, Void>
        where TParameters : class
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ANoResponseAuthorizedActionPipeline{TRequest, TPolicyContext, TAction, TParameters}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected ANoResponseAuthorizedActionPipeline(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Converts the request and the policy context to the unauthorized response.
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
