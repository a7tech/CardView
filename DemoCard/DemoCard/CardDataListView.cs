using Xamarin.Forms;

namespace DemoCard.Views
{
    public class CardDataListView : ContentPage
    {
        //Define list of products
        public CardDataListView()
        {
            var scl = new ScrollView() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var list = new ListView() { VerticalOptions = LayoutOptions.StartAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand,RowHeight = 65 };
            var itm = new DataTemplate(typeof(CustomCell));
            list.ItemTemplate = itm;
            var cardlist = new CardData();
            list.ItemsSource = cardlist; 
            Content = scl.Content = list;
            //Set list item tapped event
            list.ItemTapped += (s, e) =>
            {
                App.Current.MainPage.Navigation.PushAsync(new CardDetailViewSingle((Card)e.Item));
            };
        }
    }

    //Define the custom cell of list
    public class CustomCell : ViewCell
    {
        public CustomCell()
        {
            var image = new Image() { HeightRequest = 70,WidthRequest =90};
            StackLayout cell = new StackLayout() { Orientation = StackOrientation.Horizontal, Padding = new Thickness(0,3) };
            StackLayout horizontalLayout = new StackLayout() { Orientation = StackOrientation.Vertical };

            Label title = new Label() { FontSize = 18, TextColor = Color.FromHex("333333").MultiplyAlpha(.7f), HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            Label discount = new Label() { FontSize = 12,TextColor = Color.Red.MultiplyAlpha(.8f), FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand,YAlign = TextAlignment.Center };         
          
            //set bindings
            title.SetBinding(Label.TextProperty, "CompanyName");
            discount.SetBinding(Label.TextProperty, "Discount");
            image.SetBinding(Image.SourceProperty, "TitleSource");
            
            //add views to the view hierarchy 
            horizontalLayout.Children.Add(title);
            horizontalLayout.Children.Add(discount);

            //Add View to cell of list
            cell.Children.Add(image);
            cell.Children.Add(horizontalLayout);
            View = cell;
        }
    }
}