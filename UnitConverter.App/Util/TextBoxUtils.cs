using System.Windows.Controls;
using System.Windows.Media;

namespace UnitConverter.App.Util
{
    public class TextBoxUtils
    {
        public TextBox textBox { get; private set; }
        public bool valid { get; private set; }

        public TextBoxUtils(TextBox textBox)
        {
            this.textBox = textBox;
        }

        public void setToInvalid()
        {
            this.valid = false;
            this.textBox.Background = Brushes.Red;
        }

        public void setToValid()
        {
            this.valid = true;
            this.textBox.Background = Brushes.White;
        }
    }
}
