using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Policies.Context
{
    public interface IEnquetePolicyContext : IPolicyContext
    {
        #region Properties

        Enquete Enquete { get; }

        #endregion // Properties
    }
}
