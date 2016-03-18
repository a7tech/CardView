using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoCard.Services
{
    public interface INavigationService : INavigation
    {
        Task<bool> DisplayAlert(string title, string message, string accept = "ok", string cancel = "cancel");
    }
}