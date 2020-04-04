using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies
{
    public class IsAdmin : APolicy<IUtilisateurPolicyContext>, IIsAdmin
    {
        public override bool Check(IUtilisateurPolicyContext context)
        {
            return context.Utilisateur.Profile == Profile.Administrateur;
        }
    }
}
