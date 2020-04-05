using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions
{
    public class ListerEnquetes : AAlwaysAuthorizedAction<IListerEnquetes, ListerEnquetesRequest, (bool, ICollection<Enquete>)>, IListerEnquetes
    {
        private readonly IAuthorizedActionChecker<CloturerEnquetePolicyContext, ICloturerEnquete> cloturerEnqueteChecker;

        public ListerEnquetes(
            IServiceProvider serviceProvider,
            IAuthorizedActionChecker<CloturerEnquetePolicyContext, ICloturerEnquete> cloturerEnqueteChecker)
            : base(serviceProvider)
        {
            this.cloturerEnqueteChecker = cloturerEnqueteChecker;
        }

        protected override Task<(bool, ICollection<Enquete>)> ExecuteAsync(ListerEnquetesRequest request, CancellationToken cancellationToken)
        {
            ICollection<Enquete> enquetes = new List<Enquete>
            {
                new Enquete
                {
                    Id = 1,
                    DateOuverture = new DateTime(2020, 3, 1),
                    DateFermeture = new DateTime(2020, 4, 30)
                },
                new Enquete
                {
                    Id = 2,
                    DateOuverture = new DateTime(2020, 2, 1),
                    DateFermeture = new DateTime(2020, 2, 19)
                },
                new Enquete
                {
                    Id = 3,
                    DateOuverture = new DateTime(2020, 4, 1),
                    DateFermeture = new DateTime(2020, 4, 5)
                },
                new Enquete
                {
                    Id = 4,
                    DateOuverture = new DateTime(2020, 3, 1),
                    DateFermeture = new DateTime(2020, 3, 31)
                },
            };

            // Fills the authorizations.
            foreach (Enquete enquete in enquetes)
            {
                CloturerEnquetePolicyContext context = new CloturerEnquetePolicyContext
                {
                    Utilisateur = Utilisateur.CreateAdmin(),
                    Enquete = enquete
                };

                enquete.CanCloture = this.cloturerEnqueteChecker.CheckPolicies(context).Allowed;
            }

            return Task.FromResult((true, enquetes));
        }
    }
}
