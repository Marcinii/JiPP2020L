using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Modul_3.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DateTime DoDate;
        string format = "dddd, dd MMMM yyyy";
        int i = 0;
        DateTime OdDate;
       
        public Window1()
        {
            InitializeComponent();
            converterCombobox.ItemsSource = new ConverterService().GetConverter();
            using (JIPPEntities context = new JIPPEntities())
            {
                List<Stata> statas = context.Statas
             .OrderBy(a => a.ID)
             .Skip(i * 10)
             .Take(10)
             .ToList();
                Baza.ItemsSource = statas;
                Topka.ItemsSource = context.Statas
             .GroupBy(a => new { a.Rodzaj_Konwertera,a.Wybrana_jednostka})
             .Select(a=>new { a.Key.Rodzaj_Konwertera,a.Key.Wybrana_jednostka, Suma=a.Count()})
             .OrderByDescending(a=>a.Suma)
             .Take(3)
             .ToList();
            }
        }

        private void Poprzedni_Click(object sender, RoutedEventArgs e)
        {
            using (JIPPEntities context = new JIPPEntities())
            {
                if (OdKal.SelectedDate == null)
                    OdDate = new DateTime(2000, 01, 01);
                if(i>0)i--;
                if (converterCombobox.SelectedIndex.ToString() == null)
                {
                    List<Stata> statas = context.Statas
                    .Where(a => a.Rodzaj_Konwertera == ((Ikonwerter)converterCombobox.SelectedValue).nazwa)
               .Where(a => a.Data_Konwersji >= OdDate)
                               .Where(a => a.Data_Konwersji <= DoDate)
                   .OrderBy(a => a.ID)
                   .Skip(i * 10)
                   .Take(10)
                   .ToList();
                    Baza.ItemsSource = statas;
                }
                else
                {

                    List<Stata> statas = context.Statas
                    .Where(a => a.Data_Konwersji >= OdDate)
                               .Where(a => a.Data_Konwersji <= DoDate)
                   .OrderBy(a => a.ID)
                   .Skip(i * 10)
                   .Take(10)
                   .ToList();
                    Baza.ItemsSource = statas;
                }
            }
        }

        private void Nastepny_Click(object sender, RoutedEventArgs e)
        {
            using (JIPPEntities context = new JIPPEntities())
            {
                i++;
                if (OdKal.SelectedDate == null)
                    OdDate = new DateTime(2000, 01, 01);
                if (DoKal.SelectedDate == null)
                    DoDate = DateTime.Now;
                if (converterCombobox.SelectedIndex.ToString() == null)
                {
                    List<Stata> statas = context.Statas
               .Where(a => a.Rodzaj_Konwertera == ((Ikonwerter)converterCombobox.SelectedValue).nazwa)
               .Where(a => a.Data_Konwersji >= OdDate)
                               .Where(a => a.Data_Konwersji <= DoDate)
               .OrderBy(a => a.ID)
               .Skip(i * 10)
               .Take(10)
               .ToList();
                    Baza.ItemsSource = statas;
                }
                else
                {
                    List<Stata> statas = context.Statas
                               .Where(a => a.Data_Konwersji >= OdDate)
                               .Where(a => a.Data_Konwersji <= DoDate)
                               .OrderBy(a => a.ID)
                               .Skip(i * 10)
                               .Take(10)
                               .ToList();
                    Baza.ItemsSource = statas;
                }
            }
        }

        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }

        private void OdKal_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            
            OdDate = OdKal.SelectedDate.Value;
            OdButton.Text = OdDate.ToString(format);
        }

        private void DoKal_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DoDate = DoKal.SelectedDate.Value;
            DoButton.Text = DoDate.ToString(format);
        }

        private void Pokaz_Click(object sender, RoutedEventArgs e)
        {
            using (JIPPEntities context = new JIPPEntities())
            {
                if (OdKal.SelectedDate == null)
                    OdDate = new DateTime(2000, 01, 01);
                if (DoKal.SelectedDate == null)
                    DoDate = DateTime.Now;
                List<Stata> statas = context.Statas
              .Where(a=>a.Rodzaj_Konwertera== ((Ikonwerter)converterCombobox.SelectedValue).nazwa)
              .Where(a => a.Data_Konwersji >= OdKal.SelectedDate)
              .Where(a => a.Data_Konwersji <= DoKal.SelectedDate)
                  .OrderBy(a => a.ID)
                    .Skip(i * 10)
                .Take(10)
              .ToList();
                Baza.ItemsSource = statas;
                Topka.ItemsSource = context.Statas
                     .Where(a => a.Rodzaj_Konwertera == ((Ikonwerter)converterCombobox.SelectedValue).nazwa)
                     .Where(a => a.Data_Konwersji >= OdKal.SelectedDate)
                     .Where(a => a.Data_Konwersji <= DoKal.SelectedDate)
                    .GroupBy(a => new { a.Rodzaj_Konwertera, a.Wybrana_jednostka })
                    .Select(a => new { a.Key.Rodzaj_Konwertera, a.Key.Wybrana_jednostka, Suma = a.Count() })
                    .OrderByDescending(a => a.Suma)
                     .Take(3)
                     .ToList();
            }
        }
    }
    


}
