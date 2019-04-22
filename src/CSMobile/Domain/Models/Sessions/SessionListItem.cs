using System;
using System.Collections.Generic;

namespace CSMobile.Domain.Models.Sessions
{
    public class SessionListItem
    {
        public Guid Id { get; set; }

        public SessionStatus Status { get; set; }
        
        public string Name { get; set; }

        public IEnumerable<string> SecurityPoints { get; set; }
    }
}