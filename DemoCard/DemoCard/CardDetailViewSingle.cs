
using Xamarin.Forms;

namespace DemoCard.Views
{
    public class CardDetailViewSingle : ContentPage
    {
        public CardDetailViewSingle(Card card)
        {
            AbsoluteLayout peakLayout = new AbsoluteLayout { HeightRequest = 250, BackgroundColor = Color.Black }; 

            //Set Detail View Title
            var title = new Label
            {
                Text = card.CompanyName.ToString(),
                FontSize = 24,
                FontFamily = "Verdana",
                TextColor = Color.White,
            };

            //Set Detail View Title Description
            var discount = new Label
            {
                Text = card.Discount.ToString(),
                BackgroundColor = Color.Red.MultiplyAlpha(.25f),
                TextColor = Color.FromHex("#ddd"),
                FontFamily = "AvenirNextCondensed-Medium"
            };

            //Set Contact no
            var contactno = new Label
            {
                FontSize = 15,
                Text ="Call- "+ card.ContactNo,
                TextColor = Color.FromHex("#ddd"),
                FontFamily = "Tahoma"
            };
			

            //Set Website
            var website = new Label
            {
                FontSize = 14,
                Text ="visit us on: " + card.WebSiteURL,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                FontFamily = "AvenirNextCondensed-Medium"
            }; 
            var tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) =>
            {
				Device.OpenUri(new System.Uri("http://xamarin.com"));
				//await App.Current.MainPage.Navigation.PushAsync((NavigationPage)new System.Uri("http://xamarin.com"));
            };
            website.GestureRecognizers.Add(tap);


            //Set Detail View Title Image
            var image = new Image()
            {
                Source = card.TitleSource,
                Aspect = Aspect.AspectFill,
            };

            var overlay = new BoxView()
            {
                Color = Color.Black.MultiplyAlpha(.5f)
            };

            //Set Description Frame and Text
            var description = new Frame()
            {
                Padding = new Thickness(10, 5),
                HasShadow = false,
                BackgroundColor = Color.Transparent,
                Content = new Label()
                {
                    FontSize = 14,
                    TextColor = Color.FromHex("#ddd"),
                    Text = "With close to 17,000 acres, South Mountain Park is the world's largest city park. It's one of the Phoenix icons like \"Camelback Mountain\" and \"Superstition Mountain\". From a distance, South Mountain looks like one big dead mountain, but those that hike it realize that it features some gorgeous scenery and great horizon views in all directions. South Mountain features some of the most popular urban hiking and biking trails in the city and also very enjoyable horseback riding. The mountain is 11 miles across and is home to more than 150 animal species and two mountain ranges including \"Ma Ha Range\" and \"Guadalupe Range\"."
                }
            };

            var btnRedeem = new Button { Text = "Redeem", VerticalOptions = LayoutOptions.End,HorizontalOptions = LayoutOptions.FillAndExpand };

            //Add controls into Layout
            AbsoluteLayout.SetLayoutFlags(overlay, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(overlay, new Rectangle(0, 1, 1, 0.3));

            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0f, 0f, 1f, 1f));

            AbsoluteLayout.SetLayoutFlags(title, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(title, new Rectangle(0.1, 0.80, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(discount, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(discount, new Rectangle(0.1, 0.92, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(contactno, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(contactno, new Rectangle(0.99, 0.90, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(website, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(website, new Rectangle(0.99, 0.99, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            //Add  all controls into Main Layout
            peakLayout.Children.Add(image);
            peakLayout.Children.Add(overlay);
            peakLayout.Children.Add(title);
            peakLayout.Children.Add(discount);
            peakLayout.Children.Add(contactno);
            peakLayout.Children.Add(website);

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#333"),
                Children = { peakLayout, description, btnRedeem }
            };
        }
    }
}
