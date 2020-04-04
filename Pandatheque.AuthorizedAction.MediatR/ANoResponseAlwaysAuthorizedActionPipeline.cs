using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Pipeline executing an always authorized action with no response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TParameters">The type of the action parameters.</typeparam>
    public abstract class ANoResponseAlwaysAuthorizedActionPipeline<TRequest, TAction, TParameters> : AAlwaysAuthorizedActionPipeline<TRequest, TAction, TParameters, Void>
        where TRequest : class, IRequest<Void>
        where TAction : class, IAuthorizedAction<TParameters, Void>
        where TParameters : class
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ANoResponseAlwaysAuthorizedActionPipeline{TRequest, TAction, TParameters}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected ANoResponseAlwaysAuthorizedActionPipeline(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Converts the request and the policy context to the unauthorized response.
        /// </summary>
        /// <param name="request">The request to convert.</param>
        /// <returns>The unauthorized response.</returns>
        protected override sealed Void ToUnauthorizedResponse(TRequest request)
        {
            return Void.Default;
        }

        #endregion // Methods
    }
}
