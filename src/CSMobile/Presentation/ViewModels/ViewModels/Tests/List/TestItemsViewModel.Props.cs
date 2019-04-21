using System.Collections.Generic;

namespace CSMobile.Presentation.ViewModels.ViewModels.Tests.List
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