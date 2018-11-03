using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RxXamarinTest.ViewModels
{
	public class MyNavigationPageViewModel : ViewModelBase
	{
        public MyNavigationPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
