﻿using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Actions;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests;
using System;
using System.Collections.Generic;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Pipelines
{
    public class ListerEnquetesPipeline : ANoParameterAlwaysAuthorizedActionPipeline<ListerEnquetesRequest, IListerEnquetes, (bool, ICollection<Enquete>)>
    {
        public ListerEnquetesPipeline(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        protected override (bool, ICollection<Enquete>) ToUnauthorizedResponse(ListerEnquetesRequest request)
        {
            // Using Problem class...
            return (false, null);
        }
    }
}