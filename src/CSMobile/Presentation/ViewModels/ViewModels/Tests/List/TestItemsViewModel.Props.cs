using System.Collections.ObjectModel;
using CSMobile.Domain.Services.Tests;

namespace CSMobile.Application.ViewModels.ViewModels.Tests.List
{
    public partial class TestItemsViewModel
    {
        private ObservableCollection<TestListItem> _tests;
        
        public ObservableCollection<TestListItem> Tests
        {
            get => _tests;
            set => Set(nameof(Tests), ref _tests, value);
        }
    }
}