using System;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Infrastructure.Mvvm.Navigation
{
    /// <summary>
    /// Provides basic navigation functional
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Navigates to root page
        /// </summary>
        /// <returns><see cref="Task"/></returns>
        Task GoToRoot();
        
        /// <summary>
        /// Register specified view model for related view page
        /// </summary>
        /// <typeparam name="TViewModel">View model</typeparam>
        /// <typeparam name="TViewPage">View page</typeparam>
        void Configure<TViewModel, TViewPage>() 
            where TViewModel : BasePageViewModel
            where TViewPage : IViewPage<TViewModel>;
        
        /// <summary>
        /// Navigates to previous page
        /// </summary>
        /// <returns><see cref="Task"/></returns>
        Task GoBack();
        
        /// <summary>
        /// Navigates to modal page
        /// </summary>
        /// <param name="animated">Should the animation show</param>
        /// <typeparam name="TViewModel">Navigate to modal page with corresponded view model</typeparam>
        /// <exception cref="ArgumentException">Will be thrown if no page is found for the corresponding model</exception>
        /// <returns><see cref="Task"/></returns>
        Task NavigateModal<TViewModel>(bool animated = false) where TViewModel : BasePageViewModel;
        
        /// <summary>
        /// Navigates to page
        /// </summary>
        /// <param name="animated">Should the animation show</param>
        /// <typeparam name="TViewModel">Navigate to page with corresponded view model</typeparam>
        /// <exception cref="ArgumentException">Will be thrown if no page is found for the corresponding model</exception>
        /// <returns><see cref="Task"/></returns>
        Task Navigate<TViewModel>(bool animated = false) where TViewModel : BasePageViewModel;
        
        /// <summary>
        /// Navigates to page with specific argument
        /// </summary>
        /// <param name="argument">Argument which will be provided</param>
        /// <param name="animated">Should the animation show</param>
        /// <typeparam name="TViewModel">Navigate to page with corresponded view model</typeparam>
        /// <typeparam name="TArgument">Type of argument</typeparam>
        /// <exception cref="ArgumentException">Will be thrown if no page is found for the corresponding model</exception>
        /// <returns><see cref="Task"/></returns>
        Task Navigate<TViewModel, TArgument>(TArgument argument, bool animated = false)
            where TViewModel : BasePageViewModel<TArgument>;
    }
}