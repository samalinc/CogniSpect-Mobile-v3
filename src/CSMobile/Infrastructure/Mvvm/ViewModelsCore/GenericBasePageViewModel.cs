using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Mvvm.ViewModelsCore
{
    public abstract class BasePageViewModel<TArgument> : BasePageViewModel
    {
        /// <summary>
        /// Will be called when navigated to page
        /// </summary>
        /// <param name="argument">Type of argument</param>
        /// <returns><see cref="Task"/></returns>
        public abstract Task RetrieveArgument(TArgument argument);
    }
}