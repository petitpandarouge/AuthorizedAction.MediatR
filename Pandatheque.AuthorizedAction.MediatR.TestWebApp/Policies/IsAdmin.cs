using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies
{
    public class IsAdmin : APolicy<IUtilisateurPolicyContext>, IIsAdmin
    {
        public override Task<bool> CheckAsync(IUtilisateurPolicyContext context)
        {
            return Task.FromResult(context.Utilisateur.Profile == Profile.Administrateur);
        }
    }
}
