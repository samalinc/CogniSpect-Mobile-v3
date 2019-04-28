using System;
using System.Collections.Generic;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Enums;

namespace CSMobile.Domain.Services.WebApiIntegration.Dtos.Test
{
    public class TestSessionDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public IEnumerable<string> Routers { get; set; }
        
        public TestSessionStatusEnum TestSessionStatus { get; set; }
    }
}