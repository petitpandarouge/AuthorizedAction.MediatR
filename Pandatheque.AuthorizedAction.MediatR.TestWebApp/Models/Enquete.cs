using System;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models
{
    public class Enquete
    {
        public int Id { get; set; }

        public DateTime DateOuverture { get; set; }

        public DateTime? DateCloture { get; set; }

        public DateTime DateFermeture { get; set; }

        public Utilisateur UtilisateurModification { get; set; }

        public static Enquete Create(int id)
        {
            return new Enquete
            {
                Id = id,
                DateOuverture = new DateTime(2020, 3, 1),
                DateFermeture = new DateTime(2020, 4, 30)
            };
        }

        public void Cloturer(Utilisateur utilisateur)
        {
            this.DateCloture = DateTime.Now;
            this.UtilisateurModification = utilisateur;
        }
    }
}
