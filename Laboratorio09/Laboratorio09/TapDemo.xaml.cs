using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratorio09
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TapDemo : ContentPage
    {
        private int _tapCount;
        private readonly Label _label;
        public TapDemo()
        {
            InitializeComponent();
            var image = new Image
            {
                Source = "javascript.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.NumberOfTapsRequired = 2;
            tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
            image.GestureRecognizers.Add(tapGestureRecognizer);

            _label = new Label
            {
                Text = "tap the photo!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout()
            {
                Padding = new Thickness(20,100),
                Children = { image,_label}
            };

        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            _tapCount++;
            _label.Text = String.Format("{0} tap{1} so far!", _tapCount, _tapCount == 1 ? "" :"S");
            var imageSender = (Image) sender;
            if (_tapCount % 2 == 0)
            {
                imageSender.Source = "javascript.png";
            }
            else
            {
                imageSender.Source = "java.jpg";
            }
        }
    }
}