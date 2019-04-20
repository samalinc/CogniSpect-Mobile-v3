using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using CSMobile.Domain.Services.Tests;

namespace CSMobile.Application.ViewModels.ViewModels.Tests.List
{
    public partial class TestItemsViewModel : BasePageViewModel
    {
        private readonly ITestsService _testsService;
        private readonly IMapper _mapper;

        public ICommand OnRefreshTestsCommand { get; }
        
        public TestItemsViewModel(
            ITestsService testsService,
            IMapper mapper)
        {
            _testsService = testsService;
            _mapper = mapper;

            OnRefreshTestsCommand = Command(OnRefreshTests);
        }

        public override async Task OnAppearing()
        {
            await OnRefreshTests();
        }

        private async Task OnRefreshTests()
        {
            Tests = new List<TestListItemViewModel>(
                _mapper.Map<IEnumerable<TestListItemViewModel>>(await _testsService.GetAvailableTests()));
        }
    }
}