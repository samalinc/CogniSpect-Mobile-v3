using System;

namespace CSMobile.Domain.Services.WebApiIntegration.Dtos
{
    public class TestSessionDto
    {
        public Guid Id { get; set; }

        public TestSessionStatusEnum TestSessionStatus { get; set; }
        
        public string TestSessionName { get; set; }
    }
}