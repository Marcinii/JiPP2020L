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
                new ImagesSource() { source="https://cdn.pixabay.com/photo/2016/11/21/13/20/business-1845350_1280.jpg", description="Professional service"},
                new ImagesSource() { source="https://cdn.pixabay.com/photo/2015/08/27/09/06/bike-909690_1280.jpg", description="Over 40 years on the market"},
                new ImagesSource() { source="https://cdn.pixabay.com/photo/2017/12/28/23/41/car-3046424_1280.jpg", description="We take care about every details"},
                new ImagesSource() { source="https://cdn.pixabay.com/photo/2014/06/28/17/09/us-army-379036_1280.jpg", description="Always on time"},
                new ImagesSource() { source="https://www.trucks.com.pl/wp-content/uploads/2019/08/www_Ford-01-1024x682.jpg", description="Reliability"},
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






