using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CSMobile.Application.ViewModels.ViewModels.Tests.List
{
    public partial class TestItemsViewModel
    {
        private IEnumerable<TestListItemViewModel> _tests;
        
        public IEnumerable<TestListItemViewModel> Tests
        {
            get => _tests;
            set => Set(nameof(Tests), ref _tests, value);
        }
    }
}