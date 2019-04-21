using System.Collections.Generic;

namespace CSMobile.Presentation.ViewModels.Sessions
{
    public partial class SessionItemsViewModel
    {
        private IEnumerable<SessionListItemViewModel> _sessions;
        
        public IEnumerable<SessionListItemViewModel> Sessions
        {
            get => _sessions;
            set => Set(nameof(Sessions), ref _sessions, value);
        }
    }
}