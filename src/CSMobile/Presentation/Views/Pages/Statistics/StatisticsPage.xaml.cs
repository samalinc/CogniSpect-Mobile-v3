using System.ComponentModel;
using CSMobile.Presentation.ViewModels.Statistics;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages.Statistics
{
    public class StatisticsPageBase : ViewPage<StatisticsViewModel> { }

    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }
    }
}
