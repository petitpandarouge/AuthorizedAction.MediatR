using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Pipeline executing an always authorized action with no parameter.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public abstract class ANoParameterAlwaysAuthorizedActionPipeline<TRequest, TAction, TResponse> : AAlwaysAuthorizedActionPipeline<TRequest, TAction, Void, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TAction : class, IAuthorizedAction<Void, TResponse>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ANoParameterAlwaysAuthorizedActionPipeline{TRequest, TAction, TResponse}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected ANoParameterAlwaysAuthorizedActionPipeline(IServiceProvider serviceProvider)
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

        #endregion // Methods
    }
}
