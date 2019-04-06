using CSMobile.Application.ViewModels.ViewModels;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages
{
    public class StatisticsPageBase : ViewPage<StatisticsPageViewModel> { }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : StatisticsPageBase
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }
    }
}
