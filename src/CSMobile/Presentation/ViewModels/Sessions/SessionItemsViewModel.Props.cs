using System.Collections.Generic;

namespace CSMobile.Presentation.ViewModels.Sessions
{
    public partial class SessionItemsViewModel
    {
        private IEnumerable<SessionListItemViewModel> _sessions;
        private bool _isRefreshing;
        
        public IEnumerable<SessionListItemViewModel> Sessions
        {
            get => _sessions;
            set => Set(nameof(Sessions), ref _sessions, value);
        }
        
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => Set(nameof(IsRefreshing), ref _isRefreshing, value);
        }
    }
}