using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoCard.Services
{
    public class NavigationService : INavigationService
    {
        public INavigation Navi { get; internal set; }
        public NavigationPage NavPage { get; set; }

        public Task<bool> DisplayAlert(string title, string message, string accept = "ok", string cancel = "cancel")
        {
            return NavPage.DisplayAlert(title, message, accept, cancel);
        }

        public void InsertPageBefore(Page page, Page before)
        {
            Navi.InsertPageBefore(page, before);
        }

        public IReadOnlyList<Page> ModalStack
        {
            get { return Navi.ModalStack; }
        }

        public IReadOnlyList<Page> NavigationStack
        {
            get { return Navi.NavigationStack; }
        }

        public Task<Page> PopAsync(bool animated)
        {
            return NavPage.PopAsync(animated);
        }

        public Task<Page> PopAsync()
        {
            return NavPage.PopAsync();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            return Navi.PopModalAsync(animated);
        }

        public Task<Page> PopModalAsync()
        {
            return Navi.PopModalAsync();
        }

        public Task PopToRootAsync(bool animated)
        {
            return Navi.PopToRootAsync(animated);
        }

        public Task PopToRootAsync()
        {
            return Navi.PopToRootAsync();
        }

        public Task PushAsync(Page page, bool animated)
        {
            return NavPage.PushAsync(page, animated);
        }

        public Task PushAsync(Page page)
        {
            return NavPage.PushAsync(page);
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            return Navi.PushModalAsync(page,animated);
        }

        public Task PushModalAsync(Page page)
        {
            return Navi.PushModalAsync(page);
        }

        public void RemovePage(Page page)
        {
            Navi.RemovePage(page);
        }
    }
}