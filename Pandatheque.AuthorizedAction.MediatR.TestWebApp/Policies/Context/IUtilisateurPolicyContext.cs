using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context
{
    public interface IUtilisateurPolicyContext : IPolicyContext
    {
        #region Properties

        Utilisateur Utilisateur { get; }

        #endregion // Properties
    }
}
