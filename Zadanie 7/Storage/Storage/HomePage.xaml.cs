using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace Storage
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        IList<ImagesSource> arraySlider = new List<ImagesSource>()
            {
                new ImagesSource() { source="https://c4.wallpaperflare.com/wallpaper/831/327/581/ferrari-330-gtc-italian-cars-classic-cars-wallpaper-preview.jpg", description="Vehicle import from USA"},
                new ImagesSource() { source="https://di-uploads-pod17.dealerinspire.com/raycatenalandrovermarlboro/uploads/2018/11/Car-Financing-Handshake.png", description="Over 10 years of experience"},
                new ImagesSource() { source="https://cdn2.buyacar.co.uk/sites/buyacar/files/finance-contract-1.jpg", description="Leave the details to us"},
                new ImagesSource() { source="https://cdn2.buyacar.co.uk/sites/buyacar/files/styles/w860/public/car-and-money-1.jpg?itok=UcpVMcnx", description="We can find your dream car"},
                new ImagesSource() { source="https://media.consumeraffairs.com/files/cache/news/Shopping_or_buying_car_online_concept_gerenme_Getty_Images_large.jpg", description="Contact Us"},
            };

        int sliderIndex = 0;

        public HomePage()
        {
            InitializeComponent();
            CreateViewImageDynamically(sliderIndex);
            SelectedValue = sliderIndex;

        }



        private void CreateViewImageDynamically(int i)
        {


            if (sliderIndex == 3)
            {
                iconNextSlide.Foreground = System.Windows.Media.Brushes.OrangeRed;

            }
            else
            {
                iconNextSlide.Foreground = System.Windows.Media.Brushes.Black;
            }
            // Create Image and set its width and height
            System.Windows.Controls.Image dynamicImage = new System.Windows.Controls.Image();
            dynamicImage.Width = 715;
            dynamicImage.Height = 500;

            // Create a BitmapSource  
            string urlAdress = arraySlider[sliderIndex].source;


            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"" + urlAdress + "");
            Information.Text = arraySlider[sliderIndex].description;

            bitmap.EndInit();
            // Set Image.Source  
            dynamicImage.Source = bitmap;

            // Add Image to Window  
            LayoutRoot.Children.Add(dynamicImage);

        }

        //slider Button
        public int _selectedValue;

        public int SelectedValue
        {
            set
            {

                _selectedValue = value;
                sliderButtonChange();
            }
        }
        private void sliderButtonChange()
        {
            foreach (var e in SliderGrid.Children)
            {
                ((Button)e).Background = new SolidColorBrush(Colors.White);
            }
            
            ((Button)SliderGrid.Children[_selectedValue]).Background = new SolidColorBrush(Colors.Pink);
            sliderIndex = _selectedValue;
            CreateViewImageDynamically(sliderIndex);
        }

        private void sliderButtonValueChange(int value)
        {
            switch (value)
            {
                case 0:
                    if (_selectedValue < 1)
                    {
                        _selectedValue = arraySlider.Count() -1; 
                    }
                    else
                    {
                        _selectedValue--;
                    }
                    break;
                case 1:
                    if (_selectedValue == arraySlider.Count() - 1) 
                    {
                        _selectedValue = 0;

                    }
                    else
                    {
                        _selectedValue++;
                    }
                    break;
            }
            sliderButtonChange();


        }

        private void PreviousSlide_Click(object sender, RoutedEventArgs e)
        {
            if (sliderIndex <= 0)
            {
                sliderIndex = arraySlider.Count();

            }
            CreateViewImageDynamically(sliderIndex--);
            sliderButtonValueChange(0);
        }

        private void NextSlide_Click(object sender, RoutedEventArgs e)
        {
            if (sliderIndex == arraySlider.Count() - 1)
            {
                sliderIndex = 0;
                CreateViewImageDynamically(sliderIndex);
            }
            else
            {
                CreateViewImageDynamically(sliderIndex++);


            }
            sliderButtonValueChange(1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedValue = SliderGrid.Children.IndexOf((Button)sender);
        }
    }
}






