using System.ComponentModel;
using CSMobile.Presentation.ViewModels.ViewModels.Statistics;
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
