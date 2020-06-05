using Reviewer.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Common.Controls
{
    /// <summary>
    /// Interaction logic for MediaItem.xaml
    /// </summary>
    public partial class MediaItem : UserControl
    {
        public MediaItem()
        {
            InitializeComponent();
        }

        private static void OnTitleChanged(DependencyObject mediaControl, DependencyPropertyChangedEventArgs eventArgs)
        {
            ((MediaItem)mediaControl).TextTitle.Text = eventArgs.NewValue.ToString();
        }

        private static void OnDescChanged(DependencyObject mediaControl, DependencyPropertyChangedEventArgs eventArgs)
        {
            ((MediaItem)mediaControl).TextDesc.Text = eventArgs.NewValue.ToString();
        }

        private static void OnDateChanged(DependencyObject mediaControl, DependencyPropertyChangedEventArgs eventArgs)
        {
            ((MediaItem)mediaControl).TextDate.Text = eventArgs.NewValue.ToString();
        }

        private static void OnScoreChanged(DependencyObject mediaControl, DependencyPropertyChangedEventArgs eventArgs)
        {
            ((MediaItem)mediaControl).TextScore.Text = eventArgs.NewValue.ToString();
        }

        private static void OnTypeChanged(DependencyObject mediaControl, DependencyPropertyChangedEventArgs eventArgs)
        {
            string newType = eventArgs.NewValue.ToString();
            if (newType == "Book") ((MediaItem)mediaControl).TypeIcon.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(new Book().Color));
            else if (newType == "Movie") ((MediaItem)mediaControl).TypeIcon.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(new Movie().Color));
            else ((MediaItem)mediaControl).TypeIcon.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(new Game().Color));
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", 
            typeof(string), 
            typeof(MediaItem),
            new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender, OnTitleChanged));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
            "Description", 
            typeof(string),
            typeof(MediaItem), 
            new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender, OnDescChanged));
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty ReleaseDateProperty = DependencyProperty.Register(
            "ReleaseDate",
            typeof(string),
            typeof(MediaItem), 
            new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender, OnDateChanged));
        public string ReleaseDate
        {
            get { return (string)GetValue(ReleaseDateProperty); }
            set { SetValue(ReleaseDateProperty, value); }
        }

        public static readonly DependencyProperty ScoreProperty = DependencyProperty.Register(
            "Score", 
            typeof(string), 
            typeof(MediaItem), 
            new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender, OnScoreChanged));
        public string Score
        {
            get { return (string)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
            "Type",
            typeof(string), 
            typeof(MediaItem),
            new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender, OnTypeChanged));
        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }
    }
}