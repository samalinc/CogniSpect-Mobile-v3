using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonServiceLocator;
using CSMobile.Application.ViewModels.Navigation;
using CSMobile.Application.ViewModels.ViewModels;
using Xamarin.Forms;

namespace CSMobile.Presentation.Views
{
    internal class NavigationService : INavigationService
    {
        private readonly object _sync = new object();
        private readonly Dictionary<Type, Type> _pagesByKey = new Dictionary<Type, Type>();

        private readonly Stack<NavigationPage> _navigationPageStack =
            new Stack<NavigationPage>();

        private NavigationPage CurrentNavigationPage => _navigationPageStack.Peek();

        public void Configure<TViewModel, TViewPage>() where TViewModel : BasePageViewModel
        {
            lock (_sync)
            {
                var viewModelType = typeof(TViewModel);
                if (_pagesByKey.ContainsKey(viewModelType))
                {
                    _pagesByKey[viewModelType] = typeof(TViewPage);
                }
                else
                {
                    _pagesByKey.Add(viewModelType, typeof(TViewPage));
                }
            }
        }

        public Page SetRootPage<TViewModel>() where TViewModel : BasePageViewModel
        {
            Page rootPage = GetPage(typeof(TViewModel));
            _navigationPageStack.Clear();
            var mainPage = new NavigationPage(rootPage);
            _navigationPageStack.Push(mainPage);
            return mainPage;
        }

        public Type CurrentPageViewModel
        {
            get
            {
                lock (_sync)
                {
                    if (CurrentNavigationPage?.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = CurrentNavigationPage.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                        ? _pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        public async Task GoToRoot()
        {
            if (CurrentNavigationPage.NavigationProxy.NavigationStack.Count > 0)
            {
                await CurrentNavigationPage.Navigation.PopToRootAsync();                
            }
        }

        public async Task GoBack()
        {
            if (CurrentNavigationPage.Navigation.NavigationStack.Count > 1)
            {
                await CurrentNavigationPage.Navigation.PopAsync();
                return;
            }

            if (_navigationPageStack.Count > 1)
            {
                _navigationPageStack.Pop();
                await CurrentNavigationPage.Navigation.PopModalAsync();
                return;
            }

            await CurrentNavigationPage.PopAsync();
        }

        public async Task NavigateModalAsync<TViewModel>(bool animated = false) where TViewModel : BasePageViewModel
        {
            await NavigateModalAsync<TViewModel>(null, animated);
        }

        public async Task NavigateModalAsync<TViewModel>(object parameter, bool animated = false) where TViewModel : BasePageViewModel
        {
            var page = GetPage(typeof(TViewModel), parameter);
            NavigationPage.SetHasNavigationBar(page, false);
            var modalNavigationPage = new NavigationPage(page);
            await CurrentNavigationPage.Navigation.PushModalAsync(modalNavigationPage, animated);
            _navigationPageStack.Push(modalNavigationPage);
        }

        public async Task NavigateAsync<TViewModel>(bool animated = true) where TViewModel : BasePageViewModel
        {
            await NavigateAsync<TViewModel>(null, animated);
        }

        public async Task NavigateAsync<TViewModel>(object parameter, bool animated = false) where TViewModel : BasePageViewModel
        {
            var page = GetPage(typeof(TViewModel), parameter);
            await CurrentNavigationPage.Navigation.PushAsync(page, animated);
        }

        private Page GetPage(Type viewModelType, object parameter = null)
        {

            lock (_sync)
            {
                if (!_pagesByKey.ContainsKey(viewModelType))
                {
                    throw new ArgumentException(
                        $"No such page for viewmodel: {viewModelType}. Did you forget to call NavigationService.Configure?");
                }

                return (Page)ServiceLocator.Current.GetInstance(_pagesByKey[viewModelType]);
            }
        }
    }
}