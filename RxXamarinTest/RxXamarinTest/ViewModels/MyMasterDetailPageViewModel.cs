using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Services;

namespace RxXamarinTest.ViewModels
{
	public class MyMasterDetailPageViewModel : ViewModelBase
	{
	    private IPageDialogService _pageDialogService;

        public MyMasterDetailPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService) {
            _pageDialogService = pageDialogService;
        }

	    public async Task<bool> ShowDialog() {
	        var result = await _pageDialogService.DisplayAlertAsync("Exit App?" , "do you wanna Exit?" , "Exit" , "No");

	        return result;
	    }
    }
}
