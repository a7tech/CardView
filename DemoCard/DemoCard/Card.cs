using System;
using Xamarin.Forms;

namespace DemoCard
{
    public class Card
    {
        public ImageSource TitleSource { get; set; }
        public CardStatus Status { get; set; }

        public FileImageSource StatusMessageFileSource { get; set; }

        public string StatusMessage { get; set; }

        public FileImageSource ActionMessageFileSource { get; set; }

        public string ActionMessage { get; set; }

        public string CompanyName { get; set; }
        public string Discount { get; set; }

        public string Description { get; set; }

        public ContentView MessageView { get; set; }

        public ContentView ActionView { get; set; }

        public DateTime DueDate { get; set; }

        public int DirationInMinutes { get; set; }

        public string RatingOfProduct { get; set; }

        public string  ContactNo { get; set; }

        public string WebSiteURL { get; set; }
    }

    public enum CardStatus
    {
        Alert,
        Completed,
        Unresolved
    }
}
