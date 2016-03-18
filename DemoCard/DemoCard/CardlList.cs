using DemoCard.Styles;
using Xamarin.Forms;

namespace DemoCard.Views
{
    public class CardList : ContentView
    {
        public CardList()
        {
            BindingContext = App.MyDealsViewModel;
            var cards = new CardData();
            var cardstack = new StackLayout { BackgroundColor = Color.White.MultiplyAlpha(.8f), VerticalOptions = LayoutOptions.StartAndExpand };

            var mainView = new StackLayout { Orientation = StackOrientation.Vertical, Spacing = 15, BackgroundColor = Color.White.MultiplyAlpha(.8f), Padding = new Thickness(10), VerticalOptions = LayoutOptions.StartAndExpand, };
            //Define list in Stack Layout      
            foreach (var crd in cards)
            {
                cardstack.Children.Add(new ContentView() { Content = CardCell(crd) });
            }

            cardstack.SetBinding(ContentView.IsVisibleProperty, "ShowCardList");
            mainView.Children.Add(cardstack);

           
         

            this.Content = mainView;           
        }

        //Define cell as a Grid Structure for Daily deal
        private Grid CardCell(Card card)
        {
            var content = new ContentView();
            #region Define Grid Structure
            //Define structure of Grid Cell 
            Grid grid = new Grid
            {
                Padding = new Thickness(0, 1, 1, 1),
                RowSpacing = 1,
                ColumnSpacing = 1,
                BackgroundColor = StyleKit.CardBorderColor,
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (150, GridUnitType.Auto) },
					new RowDefinition { Height = new GridLength (40, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength (30, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength (30, GridUnitType.Absolute) }
				},
                ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (4, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength (50, GridUnitType.Absolute) }
				}
            };
            #endregion

            #region Add Content in Grid
            //Add Image Cell in Grid
            var titleimg = new CardTitleImage(card);
            grid.Children.Add(titleimg, 1, 4, 0, 1);

            //Add Title and Description cell in Grid
            var title = new CardDetailsView(card);
            grid.Children.Add(title, 1, 4, 1, 2);

            //Add Card Status cell as Bar in Grid
            grid.Children.Add(new CardStatusView(card), 0, 1, 0, 4);

            //New Text Area
            grid.Children.Add(new ContentView
            {
                Padding = new Thickness(10,0,0,0),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Content = new Label {VerticalOptions = LayoutOptions.CenterAndExpand , TextColor = Color.Gray,FontSize = 12, Text ="Rating : "+ card.RatingOfProduct+" and  250 Shares" }
            }, 1, 4, 2, 3);

            //Add Card Status Message and Action in Grid 
            grid.Children.Add(new RateView(card), 1, 3);

            grid.Children.Add(new Label() { FormattedText = card.Discount, FontSize = 12, FontFamily = "AvenirNextCondensed-Medium", TextColor = Color.FromHex("FF3300").MultiplyAlpha(35f), HorizontalOptions = LayoutOptions.CenterAndExpand, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center }, 2, 4, 1, 2);
            grid.Children.Add(new IconLabelView(card.ActionMessageFileSource, "Share",card), 2, 4, 3, 4);

            //Set Tap Gesture in Grid Image and Title
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                App.Current.MainPage.Navigation.PushAsync(new CardDetailViewSingle(card));
            };
            titleimg.GestureRecognizers.Add(tapGestureRecognizer);
            title.GestureRecognizers.Add(tapGestureRecognizer);
            #endregion
            return grid;
        }
    }

    public class CardTitleImage : ContentView
    {
        public CardTitleImage(Card card)
        {
            this.BackgroundColor = StyleKit.BarBackgroundColor;
            //Set Grid Detail Image Height
            //this.HeightRequest = 120;
            this.Content = new Image()
            {
                Source = card.TitleSource,

                Aspect = Aspect.AspectFill
            };
        }
    }
    public class CardDetailsView : ContentView
    {
        public CardDetailsView(Card card)
        {
            BackgroundColor = Color.White;
            Label CompanyName = new Label() { FontFamily = "AvenirNext-DemiBold", FontAttributes = FontAttributes.Bold, FormattedText = card.CompanyName, FontSize = 18, TextColor = Color.FromHex("333333").MultiplyAlpha(.7f), YAlign = TextAlignment.Start };
          
            var stack = new StackLayout()
            {
                Spacing = 10,
                Padding = new Thickness(10, 8, 2, 2),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { CompanyName }
            };
            HorizontalOptions = LayoutOptions.FillAndExpand;
            Content = stack;
        }
    }
    public class CardStatusView : ContentView
    {
        public CardStatusView(Card card)
        {
            var statusBoxView = new BoxView
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill
            };

            //Add Card Status
            switch (card.Status)
            {
                case CardStatus.Alert:
                    statusBoxView.BackgroundColor = StyleKit.Status.AlertColor;
                    break;
                case CardStatus.Completed:
                    statusBoxView.BackgroundColor = StyleKit.Status.CompletedColor;
                    break;
                case CardStatus.Unresolved:
                    statusBoxView.BackgroundColor = StyleKit.Status.UnresolvedColor;
                    break;
                default:
                    statusBoxView.BackgroundColor = StyleKit.Status.UnresolvedColor;
                    break;
            };

            Content = statusBoxView;
        }
    }
    public class IconLabelView : ContentView
    {
        //Card Status View
        public IconLabelView(FileImageSource source, string text, Card card)
        {
            BackgroundColor = StyleKit.CardFooterBackgroundColor;

            var label = new Label()
            {
                Text = text,
                FontSize = 14,
                FontAttributes = FontAttributes.Bold,
                TextColor = StyleKit.LightTextColor
            };
            var icon = new Image()
            {
                Source = source,
                HeightRequest = 10,
                WidthRequest = 10,
            };

            Content = new StackLayout()
            {
                Padding = new Thickness(5),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Children = { icon, label }
            };          
            //label.GestureRecognizers.Add(tap);
            //icon.GestureRecognizers.Add(tap);
        }
    }

    public class RateView : ContentView
    {
        //Rete Content View for Every Crds
        public RateView(Card rate)
        {
            var label = new Label() { Text = "Ratings ", FontSize = 16, FontAttributes = FontAttributes.Bold, FontFamily = "AvenirNext-DemiBold", TextColor = Color.FromHex("333333").MultiplyAlpha(.5f), XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, HorizontalOptions = LayoutOptions.StartAndExpand };
            var stk = new StackLayout() { Spacing = 2, Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.StartAndExpand, HeightRequest = 18, Padding = new Thickness(10, 0, 0, 0) };
            stk.Children.Add(label);
            stk.Children.Add(new RateStar(rate));
            stk.BackgroundColor = StyleKit.CardFooterBackgroundColor;
            BackgroundColor = StyleKit.CardFooterBackgroundColor;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            Content = stk;
        }
    }

    public class RateStar : ContentView
    {
        //Rate Control
        public RateStar(Card card)
        {
            #region Rating Control
            var staroff1 = new Image() { Source = "staroff.png", HeightRequest = 16, WidthRequest = 16 };
            var staron1 = new Image() { Source = "staron.png", HeightRequest = 16, WidthRequest = 16, IsVisible = false };
            var staroff2 = new Image() { Source = "staroff.png", HeightRequest = 16, WidthRequest = 16 };
            var staron2 = new Image() { Source = "staron.png", HeightRequest = 16, WidthRequest = 16, IsVisible = false };
            var staroff3 = new Image() { Source = "staroff.png", HeightRequest = 16, WidthRequest = 16 };
            var staron3 = new Image() { Source = "staron.png", HeightRequest = 16, WidthRequest = 16, IsVisible = false };
            var staroff4 = new Image() { Source = "staroff.png", HeightRequest = 16, WidthRequest = 16 };
            var staron4 = new Image() { Source = "staron.png", HeightRequest = 16, WidthRequest = 16, IsVisible = false };
            var staroff5 = new Image() { Source = "staroff.png", HeightRequest = 16, WidthRequest = 16 };
            var staron5 = new Image() { Source = "staron.png", HeightRequest = 16, WidthRequest = 16, IsVisible = false };
            var grd1 = new Grid() { Children = { staroff1, staron1 } };
            var grd2 = new Grid() { Children = { staroff2, staron2 } };
            var grd3 = new Grid() { Children = { staroff3, staron3 } };
            var grd4 = new Grid() { Children = { staroff4, staron4 } };
            var grd5 = new Grid() { Children = { staroff5, staron5 } };

            //Set Tap Gesture in Rate Star
            var tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += (s, e) =>
            {
                staron1.IsVisible = true;
                card.RatingOfProduct = "1";
                staron5.IsVisible = staron4.IsVisible = staron3.IsVisible = staron2.IsVisible = (staron1.IsVisible) ? false : false;
            };
            grd1.GestureRecognizers.Add(tapGestureRecognizer1);

            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += (s, e) =>
            {
                staron2.IsVisible = true;
                card.RatingOfProduct = "2";
                staron1.IsVisible = !(staron3.IsVisible = staron4.IsVisible = staron5.IsVisible = (staron2.IsVisible) ? false : false);
            };
            grd2.GestureRecognizers.Add(tapGestureRecognizer2);

            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += (s, e) =>
            {
                staron3.IsVisible = true;
                card.RatingOfProduct = "3";
                staron1.IsVisible = staron2.IsVisible = !(staron4.IsVisible = staron5.IsVisible = (staron3.IsVisible) ? false : false);
            };
            grd3.GestureRecognizers.Add(tapGestureRecognizer3);

            var tapGestureRecognizer4 = new TapGestureRecognizer();
            tapGestureRecognizer4.Tapped += (s, e) =>
            {
                staron4.IsVisible = true;
                card.RatingOfProduct = "4";
                staron1.IsVisible = staron2.IsVisible = staron3.IsVisible = !(staron5.IsVisible = (staron4.IsVisible) ? false : false);
            };
            grd4.GestureRecognizers.Add(tapGestureRecognizer4);

            var tapGestureRecognizer5 = new TapGestureRecognizer();
            tapGestureRecognizer5.Tapped += (s, e) =>
            {
                staron5.IsVisible = true;
                card.RatingOfProduct = "5";
                staron4.IsVisible = staron3.IsVisible = staron2.IsVisible = staron1.IsVisible = true;
            };
            grd5.GestureRecognizers.Add(tapGestureRecognizer5);
            #endregion

            #region Setting Rate
            switch (card.RatingOfProduct)
            {
                case "1":
                    {
                        staron1.IsVisible = true;
                        staron5.IsVisible = staron4.IsVisible = staron3.IsVisible = staron2.IsVisible = false;
                        break;
                    }
                case "2":
                    {
                        staron2.IsVisible = staron1.IsVisible = true;
                        staron5.IsVisible = staron4.IsVisible = staron3.IsVisible = false;
                        break;
                    }
                case "3":
                    {
                        staron3.IsVisible = staron2.IsVisible = staron1.IsVisible = true;
                        staron5.IsVisible = staron4.IsVisible = false;
                        break;
                    }
                case "4":
                    {
                        staron4.IsVisible = staron3.IsVisible = staron2.IsVisible = staron1.IsVisible = true;
                        staron5.IsVisible = false;
                        break;
                    }
                case "5":
                    {
                        staron5.IsVisible = staron4.IsVisible = staron3.IsVisible = staron2.IsVisible = staron1.IsVisible = true;
                        break;
                    }
                default:
                    {
                        staron5.IsVisible = staron4.IsVisible = staron3.IsVisible = staron2.IsVisible = staron1.IsVisible = false;
                        break;
                    }
            }
            #endregion

            Content = new StackLayout { Spacing = 2, Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.FillAndExpand, Children = { grd1, grd2, grd3, grd4, grd5 } };
        }
    }
}