using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies
{
    public interface IIsAdmin : IPolicy<IUtilisateurPolicyContext>
    {
    }
}
