﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RxXamarinTest.ViewModels
{
	public class ClosePopupPageViewModel : ViewModelBase
	{
        public ClosePopupPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
