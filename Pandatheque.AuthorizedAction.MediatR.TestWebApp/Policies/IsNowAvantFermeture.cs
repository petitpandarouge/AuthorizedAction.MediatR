using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies
{
    public class IsNowAvantFermeture : APolicy<IEnquetePolicyContext>, IIsNowAvantFermeture
    {
        public override Task<bool> CheckAsync(IEnquetePolicyContext context)
        {
            return Task.FromResult(context.TimeStamp < context.Enquete.DateFermeture);
        }
    }
}
