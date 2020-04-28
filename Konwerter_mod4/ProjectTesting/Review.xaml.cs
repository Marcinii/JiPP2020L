using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project.Desktop
{
    /// <summary>
    /// Interaction logic for Review.xaml
    /// </summary>
    public partial class Review : Window
    {
        public Review()
        {
            InitializeComponent();
            it.Add(new items { id = 1, item = "item1" });
            it.Add(new items { id = 2, item = "item2" });
            it.Add(new items { id = 3, item = "item3" });
        }
        List<items> it = new List<items>();

        class items
        {
            public int id { get; set; }
            public string item { get; set; }
        }
    }
}
