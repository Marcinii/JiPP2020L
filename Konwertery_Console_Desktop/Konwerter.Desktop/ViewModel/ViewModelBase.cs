using Konwerter.Desktop.ViewModel.Commands;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Konwerter.Desktop.ViewModel
{
    public class ViewModelBase
    {
        public ConvertCommand convertCommand { get; set; }


        public ViewModelBase()
        {
            this.convertCommand = new ConvertCommand(this);
        }

        public void Convert()
        {
            
        }


    }
}
