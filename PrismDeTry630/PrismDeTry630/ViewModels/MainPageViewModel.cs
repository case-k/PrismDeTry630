using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismDeTry630.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;

        public ICommand GoNextPageCommand { get; }


        public MainPageViewModel(INavigationService navigationService)
        {
            System.Diagnostics.Debug.WriteLine("■MainPageViewModel.コンストラクタ");

            _navigationService = navigationService;

            GoNextPageCommand = new DelegateCommand(GoNextPage);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("■MainPageViewModel.OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("■MainPageViewModel.OnNavigatedTo");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("■MainPageViewModel.OnNavigatingTo");
        }


        async private void GoNextPage()
        {
            await _navigationService.NavigateAsync("SubPage");
        }
    }
}
