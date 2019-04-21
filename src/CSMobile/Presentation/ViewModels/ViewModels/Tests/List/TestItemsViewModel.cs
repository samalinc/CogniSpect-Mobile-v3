using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using CSMobile.Domain.Services.Tests;
using CSMobile.Infrastructure.Mvvm;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Presentation.ViewModels.ViewModels.Tests.List
{
    public partial class TestItemsViewModel : BasePageViewModel
    {
        private readonly ITestsService _testsService;
        private readonly IMapper _mapper;
        private readonly IViewModelsFactory _viewModelsFactory;

        public ICommand OnRefreshTestsCommand { get; }

        public TestItemsViewModel(
            ITestsService testsService,
            IMapper mapper,
            IViewModelsFactory viewModelsFactory)
        {
            _testsService = testsService;
            _mapper = mapper;
            _viewModelsFactory = viewModelsFactory;

            OnRefreshTestsCommand = Command(OnRefreshTests);
        }

        public override async Task OnAppearing()
        {
            await OnRefreshTests();
        }

        private async Task OnRefreshTests()
        {
            SafeRemoveNestedViewModels(Tests);
            
            Tests = _viewModelsFactory.Create<TestListItemViewModel>(
                await _testsService.GetAvailableTests(), this);
        }
    }
}