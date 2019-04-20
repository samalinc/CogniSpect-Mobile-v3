using CSMobile.Application.ViewModels.ViewModels;
using System.ComponentModel;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages
{
    public class StatisticsPageBase : ViewPage<StatisticsViewModel> { }

    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : StatisticsPageBase
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }
    }
}
