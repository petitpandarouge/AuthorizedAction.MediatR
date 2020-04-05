using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Pipeline executing an always authorized action with no response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    public abstract class AVoidActionPipeline<TRequest, TAction> : AActionPipeline<TRequest, TAction, Void>
        where TRequest : class, IRequest<Void>
        where TAction : class, IVoidAction<TRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AVoidActionPipeline{TRequest, TAction}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AVoidActionPipeline(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Builds the the unauthorized response from the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The unauthorized response.</returns>
        protected override sealed Void BuildUnauthorizedResponse(TRequest request)
        {
            return Void.Default;
        }

        #endregion // Methods
    }
}
