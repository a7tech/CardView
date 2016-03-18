using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCard.Services;

namespace DemoCard.ViewModels
{
   public class CardViewModel:BaseViewModel
    {
        INavigationService navigationService;
        public CardViewModel(INavigationService navService)
        {
            navigationService = navService;
            ShowCardList = true;
        }
        public bool HideCardList
        {
            get { return GetValue<bool>(); }
            set 
            {
                SetValue<bool>(value); 
            }
        }

        public bool ShowCardList
        {
            get { return GetValue<bool>(); }
            set
            {
                HideCardList = !value;
                SetValue<bool>(value);
            }
        }
    }
}
