using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using Prism.Services;

namespace PrismDeTry630.ViewModels
{
    public class SubPageViewModel : BindableBase, INavigationAware, IDestructible, IConfirmNavigationAsync
    {
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;

        public ICommand GoPrevPageCommand { get; }


        public SubPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            System.Diagnostics.Debug.WriteLine("●SubPageViewModel.コンストラクタ");

            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            GoPrevPageCommand = new DelegateCommand(GoPrevPage);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("●SubPageViewModel.OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("●SubPageViewModel.OnNavigatedTo");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("●SubPageViewModel.OnNavigatingTo");
        }

        public void Destroy()
        {
            System.Diagnostics.Debug.WriteLine("●SubPageViewModel.デストラクタ");
        }

        public Task<bool> CanNavigateAsync(NavigationParameters parameters)
        {
            return _pageDialogService.DisplayAlertAsync("確認", "前のページに戻ってよい？", "はい", "いいえ");
        }


        async private void GoPrevPage()
        {
            await _navigationService.GoBackAsync();
        }

    }
}
