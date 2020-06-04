using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using counting;

public class cHotel
{
    public string base_name = " ";
    public string base_email = " ";
    public PasswordBox base_password = new PasswordBox();
    public string base_city = " ";
    public short base_people = 0;
    public int base_days = 0;
    public string base_quality = " ";
    public DateTime base_date = new DateTime();
    public decimal base_price = 0;
}

namespace Calendar
{

    public partial class LandingPage : UserControl
    {
        public LandingPage()
        {
            InitializeComponent();
            pictureHolder.Visibility = Visibility.Visible;
            SignInGrid.Visibility = Visibility.Collapsed;
            Grid2_IN.Visibility = Visibility.Collapsed;
            Grid1_UP.Visibility = Visibility.Collapsed;
            GridSlider.Visibility = Visibility.Collapsed;
            DestinationGrid.Visibility = Visibility.Collapsed;
            petPageGrid.Visibility = Visibility.Collapsed;
            bookGrid.Visibility = Visibility.Collapsed;
            popUpGrid.Visibility = Visibility.Collapsed;
            peopleCMB.ItemsSource = people_.ComboList;
            daysCMB.ItemsSource = days_.ComboList;
            qualityCMB.ItemsSource = quality_.ComboList;
            citiesCMB.ItemsSource = cities_.ComboList;
        }

        cQuality quality_ = new cQuality();
        cPeople people_ = new cPeople();
        cDays days_ = new cDays();
        cCities cities_ = new cCities();
        cHotel hotel = new cHotel();

        public double howmany_people()
        {
            double howpeople = 0.0;
            
            string tmp = peopleCMB.Text;
            object returnComboValue = peopleCMB.SelectedValue;
            string changeObject = Convert.ToString(returnComboValue);
            object returnComboIndex = peopleCMB.SelectedIndex;
            int index = Convert.ToInt32(returnComboIndex);

            if (index == 0){howpeople = 2.1;}
            if (index  == 1) {howpeople = 3.2;}
            if (index == 2) {howpeople = 4.3;}
            if (index == 3) {howpeople = 5.4;}

            hotel.base_people = (short) index;

            return howpeople;
        }

        public double howmany_days()
        {
            double howmany = 0.0;

            string tmp = daysCMB.Text;
            object returnComboValue = daysCMB.SelectedValue;
            string changeObject = Convert.ToString(returnComboValue);
            object returnComboIndex = daysCMB.SelectedIndex;
            int index = Convert.ToInt32(returnComboIndex);

            if (index == 0) { howmany = 8.5; }
            if (index == 1) { howmany = 6.2; }
            if (index == 2) { howmany = 5.5; }
            if (index == 3) { howmany = 4.2; }

            hotel.base_days = index;
            return howmany;
        }

        public double quality_type()
        {
            double price_quality = 0.0;

            string tmp = qualityCMB.Text;
            object returnComboValue = qualityCMB.SelectedValue;
            string changeObject = Convert.ToString(returnComboValue);
            object returnComboIndex = qualityCMB.SelectedIndex;
            int index = Convert.ToInt32(returnComboIndex);

            if (index == 0) { price_quality = 30.0; }
            if (index == 1) { price_quality = 20.0; }
            if (index == 2) { price_quality = 10.0; }
            if (index == 3) { price_quality = 5.0; }

            hotel.base_quality = changeObject;
            return price_quality;
        }

        public int which_town()
        {
            int town = 0;

            string tmp = citiesCMB.Text;
            object returnComboValue = citiesCMB.SelectedValue;
            string changeObject = Convert.ToString(returnComboValue);
            object returnComboIndex = citiesCMB.SelectedIndex;
            int index = Convert.ToInt32(returnComboIndex);

            if (index == 0) { town = 10; }
            if (index == 1) { town = 20; }
            if (index == 2) { town = 30; }
            if (index == 3) { town = 40; }
            if (index == 4) { town = 50; }

            hotel.base_city = changeObject;
            return town;
        }

        public static void InsertLogin(string name1, string email1, string password1)
        {
            using (DB context = new DB())
            {
                login dane = new login()
                {
                    name = name1,
                    email = email1,
                    password_ = password1
                };
                
                context.login.Add(dane);
                context.SaveChanges();
            }

            
        }


       
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void bookRoom_Click(object sender, RoutedEventArgs e)
        {
            DestinationGrid.Visibility = Visibility.Collapsed;
            petPageGrid.Visibility = Visibility.Collapsed;
            MemoGrid.Visibility = Visibility.Collapsed;
            bookGrid.Visibility = Visibility.Visible;
        }

        private void pricing_Click(object sender, RoutedEventArgs e)
        {
            DestinationGrid.Visibility = Visibility.Collapsed;
            petPageGrid.Visibility = Visibility.Collapsed;
            DestinationGrid.Visibility = Visibility.Collapsed;
            MemoGrid.Visibility = Visibility.Collapsed;

        }

        private void destinations_Click(object sender, RoutedEventArgs e)
        {
            MemoGrid.Visibility = Visibility.Visible;
            cityName.Visibility = Visibility.Collapsed;
            petPageGrid.Visibility = Visibility.Collapsed;
            DestinationGrid.Visibility = Visibility.Visible;

        }

        private void petFriendly_Click(object sender, RoutedEventArgs e)
        {
            petPageGrid.Visibility = Visibility.Visible;
            DestinationGrid.Visibility = Visibility.Collapsed;
            MemoGrid.Visibility = Visibility.Collapsed;
            MemoGrid.Visibility = Visibility.Collapsed;
        }

        private void signIn_Click(object sender, RoutedEventArgs e)
        {
         
                pictureHolder.Opacity = 30;
                SignInGrid.Visibility = Visibility.Visible;
                Grid2_IN.Visibility = Visibility.Visible;
                Grid1_UP.Visibility = Visibility.Visible;
                GridSlider.Visibility = Visibility.Visible;

        }

        private void closePopUp_Click(object sender, RoutedEventArgs e)
        {
            SignInGrid.Visibility = Visibility.Collapsed;
            Grid2_IN.Visibility = Visibility.Collapsed;
            Grid1_UP.Visibility = Visibility.Collapsed;
            GridSlider.Visibility = Visibility.Collapsed;
            pictureHolder.Visibility = Visibility.Visible;
        }


        private void closePopUp_2_Click(object sender, RoutedEventArgs e)
        {
            SignInGrid.Visibility = Visibility.Collapsed;
            Grid2_IN.Visibility = Visibility.Collapsed;
            Grid1_UP.Visibility = Visibility.Collapsed;
            GridSlider.Visibility = Visibility.Collapsed;
            pictureHolder.Visibility = Visibility.Visible;
        }

        private void signin_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void signup_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        public ImageBrush loadCzech()
        {
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(
                new Uri(
                   "C:/Users/gabri/Desktop/Aplikacja WPF/Calendar/Pictures/czech.png"));
            myBrush.ImageSource = image.Source;
            return myBrush;
        }

        public ImageBrush loadTokyo()
        {
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(
                new Uri(
                   "C:/Users/gabri/Desktop/Aplikacja WPF/Calendar/Pictures/tokyo.png"));
            myBrush.ImageSource = image.Source;
            return myBrush;
        }

        public ImageBrush loadFlorence()
        {
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(
                new Uri(
                   "C:/Users/gabri/Desktop/Aplikacja WPF/Calendar/Pictures/florence.png"));
            myBrush.ImageSource = image.Source;
            return myBrush;
        }

        public ImageBrush loadLondon()
        {
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(
                new Uri(
                   "C:/Users/gabri/Desktop/Aplikacja WPF/Calendar/Pictures/london.png"));
            myBrush.ImageSource = image.Source;
            return myBrush;
        }

        public ImageBrush loadMoscov()
        {
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(
                new Uri(
                   "C:/Users/gabri/Desktop/Aplikacja WPF/Calendar/Pictures/moscov.png"));
            myBrush.ImageSource = image.Source;
            return myBrush;
        }

        public ImageBrush loadParis()
        {
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(
                new Uri(
                   "C:/Users/gabri/Desktop/Aplikacja WPF/Calendar/Pictures/paris.png"));
            myBrush.ImageSource = image.Source;
            return myBrush;
        }

        private void Prague_Click(object sender, RoutedEventArgs e)
        {
            Tiles.Visibility = Visibility.Visible;
            MemoGrid.Visibility = Visibility.Collapsed;

            cityName.Content = "Czech Prague";
            cityName.Visibility = Visibility.Visible;

            ImageBrush Brush1 = new ImageBrush();
            ImageBrush Brush2 = new ImageBrush();
            ImageBrush Brush3 = new ImageBrush();
            ImageBrush Brush4 = new ImageBrush();
            ImageBrush Brush5 = new ImageBrush();
            ImageBrush Brush6 = new ImageBrush();


            Brush1 = loadCzech();
            mainCity.Background = Brush1;

            Brush2 = loadLondon();
            _2city.Background = Brush2;

            Brush3 = loadMoscov();
            _3city.Background = Brush3;

            Brush4 = loadTokyo();
            _4city.Background = Brush4;

            Brush5 = loadFlorence();
            _5city.Background = Brush5;

            Brush6 = loadParis();
            _6city.Background = Brush6;

        }

        private void Florence_Click(object sender, RoutedEventArgs e)
        {
            Tiles.Visibility = Visibility.Visible;
            MemoGrid.Visibility = Visibility.Collapsed;

            cityName.Content = "Florence";
            cityName.Visibility = Visibility.Visible;

            ImageBrush Brush1 = new ImageBrush();
            ImageBrush Brush2 = new ImageBrush();
            ImageBrush Brush3 = new ImageBrush();
            ImageBrush Brush4 = new ImageBrush();
            ImageBrush Brush5 = new ImageBrush();
            ImageBrush Brush6 = new ImageBrush();

            Brush1 = loadFlorence();
            mainCity.Background = Brush1;

            Brush2 = loadMoscov();
            _2city.Background = Brush2;

            Brush3 = loadTokyo();
            _3city.Background = Brush3;

            Brush4 = loadParis();
            _4city.Background = Brush4;

            Brush5 = loadLondon();
            _5city.Background = Brush5;

            Brush6 = loadCzech();
            _6city.Background = Brush6;
        }

        private void London_Click(object sender, RoutedEventArgs e)
        {
            Tiles.Visibility = Visibility.Visible;
            MemoGrid.Visibility = Visibility.Collapsed;

            cityName.Content = "London";
            cityName.Visibility = Visibility.Visible;

            ImageBrush Brush1 = new ImageBrush();
            ImageBrush Brush2 = new ImageBrush();
            ImageBrush Brush3 = new ImageBrush();
            ImageBrush Brush4 = new ImageBrush();
            ImageBrush Brush5 = new ImageBrush();
            ImageBrush Brush6 = new ImageBrush();

            Brush1 = loadLondon();
            mainCity.Background = Brush1;

            Brush2 = loadMoscov();
            _2city.Background = Brush2;

            Brush3 = loadParis();
            _3city.Background = Brush3;

            Brush4 = loadCzech();
            _4city.Background = Brush4;

            Brush5 = loadTokyo();
            _5city.Background = Brush5;

            Brush6 = loadFlorence();
            _6city.Background = Brush6;

        }

        private void Moscow_Click(object sender, RoutedEventArgs e)
        {
            Tiles.Visibility = Visibility.Visible;
            MemoGrid.Visibility = Visibility.Collapsed;

            cityName.Content = "Moscov";
            cityName.Visibility = Visibility.Visible;

            ImageBrush Brush1 = new ImageBrush();
            ImageBrush Brush2 = new ImageBrush();
            ImageBrush Brush3 = new ImageBrush();
            ImageBrush Brush4 = new ImageBrush();
            ImageBrush Brush5 = new ImageBrush();
            ImageBrush Brush6 = new ImageBrush();

            Brush1 = loadMoscov();
            mainCity.Background = Brush1;

            Brush2 = loadFlorence();
            _2city.Background = Brush2;

            Brush3 = loadCzech();
            _3city.Background = Brush3;

            Brush4 = loadLondon();
            _4city.Background = Brush4;

            Brush5 = loadTokyo();
            _5city.Background = Brush5;

            Brush6 = loadParis();
            _6city.Background = Brush6;
        }

        private void Paris_Click(object sender, RoutedEventArgs e)
        {
            Tiles.Visibility = Visibility.Visible;
            MemoGrid.Visibility = Visibility.Collapsed;

            cityName.Content = "Paris";
            cityName.Visibility = Visibility.Visible;

            ImageBrush Brush1 = new ImageBrush();
            ImageBrush Brush2 = new ImageBrush();
            ImageBrush Brush3 = new ImageBrush();
            ImageBrush Brush4 = new ImageBrush();
            ImageBrush Brush5 = new ImageBrush();
            ImageBrush Brush6 = new ImageBrush();

            Brush1 = loadParis();
            mainCity.Background = Brush1;

            Brush2 = loadTokyo();
            _2city.Background = Brush2;

            Brush3 = loadLondon();
            _3city.Background = Brush3;

            Brush4 = loadCzech();
            _4city.Background = Brush4;

            Brush5 = loadFlorence();
            _5city.Background = Brush5;

            Brush6 = loadMoscov();
            _6city.Background = Brush6;
        }

        private void Tokyo_Click(object sender, RoutedEventArgs e)
        {
            Tiles.Visibility = Visibility.Visible;
            MemoGrid.Visibility = Visibility.Collapsed;

            cityName.Content = "Tokyo";
            cityName.Visibility = Visibility.Visible;

            ImageBrush Brush1 = new ImageBrush();
            ImageBrush Brush2 = new ImageBrush();
            ImageBrush Brush3 = new ImageBrush();
            ImageBrush Brush4 = new ImageBrush();
            ImageBrush Brush5 = new ImageBrush();
            ImageBrush Brush6 = new ImageBrush();

            Brush1 = loadTokyo();
            mainCity.Background = Brush1;

            Brush2 = loadCzech();
            _2city.Background = Brush2;

            Brush3 = loadFlorence();
            _3city.Background = Brush3;

            Brush4 = loadLondon();
            _4city.Background = Brush4;

            Brush5 = loadMoscov();
            _5city.Background = Brush5;

            Brush6 = loadParis();
            _6city.Background = Brush6;
        }

        private void sign_in__Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            SqlCommand cmd = new SqlCommand("select * from login where email like @email and password_ = @password;");
            cmd.Parameters.AddWithValue("@email", email_in.Text);
            cmd.Parameters.AddWithValue("@password", password_in.Password);
            cmd.Parameters.AddWithValue("@name", name_up.Text);
            cmd.Connection = conn;
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Close();
            
            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            if (loginSuccessful)
            {
                string username_ = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
                userHello.Content = ("Hello "  + username_ +  " !");
         
                userHello.Visibility = Visibility.Visible;
                SignInGrid.Visibility = Visibility.Collapsed;
                Grid2_IN.Visibility = Visibility.Collapsed;
                Grid1_UP.Visibility = Visibility.Collapsed;
                GridSlider.Visibility = Visibility.Collapsed;
                pictureHolder.Visibility = Visibility.Visible;
                signIn.Visibility = Visibility.Collapsed;
                signout.Visibility = Visibility.Visible;
            }
            else
            {
                popUpGrid.Visibility = Visibility.Visible;
                popup_lbl.Content = "Invalid username or password";
            }
        }
  
        private void createAccount_Click(object sender, RoutedEventArgs e)
        {
            string name = name_up.Text;
            string email = email_up.Text;
            string password = password_up.Password.ToString();

            InsertLogin(name,email,password);
        }

        private void userHello_Click(object sender, RoutedEventArgs e)
        {

        }

        private void signout_Click(object sender, RoutedEventArgs e)
        {
            userHello.Visibility = Visibility.Collapsed;
            signIn.Visibility = Visibility.Visible;
            signout.Visibility = Visibility.Collapsed;

        }

        private void checkPrice_Click(object sender, RoutedEventArgs e)
        {
            loadingGrid.Visibility = Visibility.Visible;
            user1();


            double a = howmany_days();
            double b = howmany_people();
            double c = quality_type();
            double d = which_town();

            double finalprice = a * b * c * d;
            finalprice = Math.Round(finalprice, 2);
            finalprice_lbl.Content = finalprice;

            hotel.base_price = (decimal) finalprice;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void exitBooking_Click(object sender, RoutedEventArgs e)
        {
            bookGrid.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void closeDestination_Click(object sender, RoutedEventArgs e)
        {
            DestinationGrid.Visibility = Visibility.Collapsed;
            Tiles.Visibility = Visibility.Collapsed;
            infoDestGrid.Visibility = Visibility.Collapsed;
            MemoGrid.Visibility = Visibility.Collapsed;
        }

        private void closePetPage_Click(object sender, RoutedEventArgs e)
        {
            petPageGrid.Visibility = Visibility.Collapsed;
        }

        private void closeLoginPopUp_Click(object sender, RoutedEventArgs e)
        {
            popUpGrid.Visibility = Visibility.Collapsed;

        }

        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bookNow_Click(object sender, RoutedEventArgs e)
        {
           

        }

        // --------------------------------------------
        CancellationTokenSource tokenSource1;

        public void user1()
        {
            tokenSource1 = new CancellationTokenSource();
            Task t1 = new Task(() => r_1(tokenSource1.Token), tokenSource1.Token);
            t1.Start();
            loadprogressbar1();
        }
        public void r_1(CancellationToken ct)
        {
            if (ct.IsCancellationRequested) { ct.ThrowIfCancellationRequested(); }
            Thread.Sleep(3000);
            Dispatcher.Invoke(() =>
            loadingGrid.Visibility = Visibility.Hidden
            );
        }

        public void loadprogressbar1()
        {
            Duration duration_1 = new Duration(TimeSpan.FromSeconds(30));
            DoubleAnimation doubler1 = new DoubleAnimation(1000.0, duration_1);
            Dispatcher.Invoke(() => progressBar1.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, doubler1));
        }

        private void btnX_Click(object sender, RoutedEventArgs e)
        {
            tokenSource1.Cancel();
            loadingGrid.Visibility = Visibility.Collapsed;
        }
    }
}

