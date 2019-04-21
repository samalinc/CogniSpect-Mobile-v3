using System;

namespace CSMobile.Domain.Services.WebApiIntegration.Dtos
{
    public class AccountDto
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }
    }
}