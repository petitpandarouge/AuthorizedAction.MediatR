using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies
{
    public class IsNowApresOuverture : APolicy<IEnquetePolicyContext>, IIsNowApresOuverture
    {
        public override bool Check(IEnquetePolicyContext context)
        {
            return context.Enquete.DateOuverture <= context.TimeStamp;
        }
    }
}
