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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Konwerter.Desktop.Repository;

namespace Konwerter.Desktop
{
    public partial class Ocena : UserControl
    {
        GRADES ocena = new GRADES();

        public Ocena()
        {
            InitializeComponent();
            getLastGrade();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ocena.grade = Convert.ToInt32(gradeSlider.Value);
            gradeLabel.Content = ocena.grade;
        }

        private void sendGradeBtn_Click(object sender, RoutedEventArgs e)
        {
            DatabaseModule.insertGrade(ocena);
            gradeLabel.Content = "Wysłano";
            ocena = new GRADES();
            getLastGrade();
        }

        private void getLastGrade()
        {
            lastGradeLbl.Content = DatabaseModule.getGrade()[0].grade.ToString();
        }
    }
}
