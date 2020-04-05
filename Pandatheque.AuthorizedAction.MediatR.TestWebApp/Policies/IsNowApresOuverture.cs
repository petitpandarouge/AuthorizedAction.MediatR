using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies
{
    public class IsNowApresOuverture : APolicy<IEnquetePolicyContext>, IIsNowApresOuverture
    {
        public override Task<bool> CheckAsync(IEnquetePolicyContext context)
        {
            return Task.FromResult(context.Enquete.DateOuverture <= context.TimeStamp);
        }
    }
}
