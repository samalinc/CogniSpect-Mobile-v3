using System;
using System.Collections.Generic;

namespace CSMobile.Presentation.ViewModels.Sessions
{
    public partial class SessionListItemViewModel
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public IEnumerable<string> SecurityPoints { get; set; }
    }
}
