using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Base class for an authorized action with no response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TPolicyContext">The type of the context policy.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    public abstract class AVoidAuthorizedAction<TAction, TRequest, TPolicyContext> : AAuthorizedAction<TAction, TRequest, TPolicyContext, Void>, IVoidAuthorizedAction<TRequest, TPolicyContext>
        where TRequest : class, IRequest<Void>
        where TPolicyContext : class, IPolicyContext
        where TAction : class, IVoidAuthorizedAction<TRequest, TPolicyContext>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AVoidAuthorizedAction{TRequest, TPolicyContext, TAction}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AVoidAuthorizedAction(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Builds the the unauthorized response from the request and the policy context.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="policyContext">The policy context.</param>
        /// <returns>The unauthorized response.</returns>
        protected override sealed Void BuildUnauthorizedResponse(TRequest request, TPolicyContext policyContext)
        {
            return Void.Default;
        }

        #endregion // Methods
    }
}
