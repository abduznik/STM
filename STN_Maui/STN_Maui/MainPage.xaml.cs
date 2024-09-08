using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using System;

namespace STN_Maui
{
    public partial class MainPage : ContentPage
    {
        // Arrays of image URLs for each button
        private readonly string[] _buttonOneImages =
        {
            "https://example.com/image1a.png",
            "https://example.com/image1b.png",
            "https://example.com/image1c.png"
        };

        private readonly string[] _buttonTwoImages =
        {
            "https://example.com/image2a.png",
            "https://example.com/image2b.png",
            "https://example.com/image2c.png"
        };

        private readonly string[] _buttonThreeImages =
        {
            "https://user-images.githubusercontent.com/12956286/30039757-19613790-91de-11e7-8f4c-52f7e8aafb39.png",
            "https://example.com/image3b.png",
            "https://example.com/image3c.png"
        };

        public MainPage()
        {
            InitializeComponent();
        }

        // Event handler for Button One
        private void OnButtonOneClicked(object sender, EventArgs e)
        {
            ShowRandomImagePopup(_buttonOneImages);
        }

        // Event handler for Button Two
        private void OnButtonTwoClicked(object sender, EventArgs e)
        {
            ShowRandomImagePopup(_buttonTwoImages);
        }

        // Event handler for Button Three
        private void OnButtonThreeClicked(object sender, EventArgs e)
        {
            ShowRandomImagePopup(_buttonThreeImages);
        }

        // Method to show a random image in a popup
        private void ShowRandomImagePopup(string[] imageUrls)
        {
            var random = new Random();
            var randomIndex = random.Next(imageUrls.Length);
            var randomImageUrl = imageUrls[randomIndex];

            var popup = new ImagePopup(randomImageUrl, true);
            this.ShowPopup(popup);
        }
    }

    // Custom Popup class
    public class ImagePopup : Popup
    {
        public ImagePopup(string imagePath, bool isUri = false)
        {
            var image = new Image();

            if (isUri)
            {
                image.Source = ImageSource.FromUri(new Uri(imagePath));
            }
            else
            {
                image.Source = ImageSource.FromFile(imagePath);
            }

            Content = new VerticalStackLayout
            {
                Children = { image }
            };

            //CloseWhenBackgroundIsClicked = true;  // Allows closing the popup when clicking outside
        }
    }
}