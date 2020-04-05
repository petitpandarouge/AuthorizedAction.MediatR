using MediatR;
using System;

namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Base class for the always authorized action with no response.
    /// </summary>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    public abstract class AVoidAlwaysAuthorizedAction<TAction, TRequest> : AAlwaysAuthorizedAction<TAction, TRequest, Void>, IVoidAlwaysAuthorizedAction<TRequest>
        where TRequest : class, IRequest<Void>
        where TAction : class, IVoidAlwaysAuthorizedAction<TRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AVoidAlwaysAuthorizedAction{TAction, TRequest}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected AVoidAlwaysAuthorizedAction(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion // Constructors
    }
}
