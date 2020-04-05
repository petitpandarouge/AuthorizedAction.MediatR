using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR
{
    public abstract class AAction<TRequest, TResponse> : IAction<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        public Task<TResponse> ExecuteAsync(TRequest request, VoidPolicyContext context, CancellationToken cancellationToken)
        {
            return this.ExecuteAsync(request, cancellationToken);
        }

        protected abstract Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}
