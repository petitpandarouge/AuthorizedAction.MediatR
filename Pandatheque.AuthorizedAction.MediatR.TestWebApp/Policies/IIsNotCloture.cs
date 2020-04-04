using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies
{
    public interface IIsNotCloture : IPolicy<IEnquetePolicyContext>
    {
    }
}
