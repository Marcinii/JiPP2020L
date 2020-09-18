using Storage.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Storage
{
    /// <summary>
    /// Interaction logic for AddToDatebasePage.xaml
    /// </summary>
    public partial class AddToDatebasePage : Page
    {
        public bool Sorted { get; set; }
        

        public AddToDatebasePage()
        {
            InitializeComponent();

            Type.ItemsSource = new InterfaceService().getTypes();

            /*            
            */

        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.ItemsSource = ((IStorageLogicApp)Type.SelectedItem).company;
            taxValue.Text = ((IStorageLogicApp)Type.SelectedItem).Tax.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                double value = Math.Round(((IStorageLogicApp)Type.SelectedItem).CountInsurance(((IStorageLogicApp)Type.SelectedItem).Tax, Convert.ToDouble(Capacity.Text), Convert.ToDouble(Value.Text)), 2);
                MessageBox.Show(value.ToString());
                AddToDataBase(value);
            

        }
        private void AddToDataBase(double valueType)
        {
            string typeValue = ((IStorageLogicApp)Type.SelectedItem).type;
            string brandValue = Model.SelectedItem.ToString();
            double capacity = double.Parse(Capacity.Text);
            byte QuantityValue = Convert.ToByte(sliderQuantity.Value);



            using (VehicleEntitiesData context = new VehicleEntitiesData())
            {
                Store store = new Store()
                {
                    Type = typeValue,
                    Brand = brandValue,
                    Capacity = capacity,
                    Value = valueType,
                    Quantity = QuantityValue,
                };
                context.Store.Add(store);
                context.SaveChanges();
            }


        }

        
    }

}
