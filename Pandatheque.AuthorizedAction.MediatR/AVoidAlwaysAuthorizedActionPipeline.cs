using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Pipeline executing an always authorized action without neither parameter nor response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    public abstract class AVoidAlwaysAuthorizedActionPipeline<TRequest, TAction> : AAlwaysAuthorizedActionPipeline<TRequest, TAction, Void, Void>
        where TRequest : class, IRequest<Void>
        where TAction : class, IAuthorizedAction<Void, Void>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AVoidAlwaysAuthorizedActionPipeline{TRequest, TAction}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AVoidAlwaysAuthorizedActionPipeline(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Converts the request to the action parameters.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <returns>The action parameters.</returns>
        protected override sealed Void ToActionParameters(TRequest request)
        {
            return Void.Default;
        }

        /// <summary>
        /// Converts the request to the unauthorized response.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <returns>The action parameters.</returns>
        protected override sealed Void ToUnauthorizedResponse(TRequest request)
        {
            return Void.Default;
        }

        #endregion // Methods
    }
}
