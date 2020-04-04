using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context
{
    public class CloturerEnquetePolicyContext : APolicyContext, IUtilisateurPolicyContext, IEnquetePolicyContext
    {
        #region Properties

        public Utilisateur Utilisateur { get; set; }

        public Enquete Enquete { get; set; }

        #endregion // Properties
    }
}
