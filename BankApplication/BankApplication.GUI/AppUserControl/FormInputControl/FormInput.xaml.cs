using BankApplication.Library.ValidatorUtil;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BankApplication.GUI.AppUserControl.FormInputControl
{
    /// <summary>
    /// Interaction logic for FormInput.xaml
    /// </summary>
    /// <param name="valid">Pole przechowujące informacje, czy wprowadzona wartość pola jest prawidłowa</param>
    /// <param name="onChange">Zdarzenie, które będzie wywoływane w trakcie dokonywania zmian wartości kontrolki</param>
    /// <param name="labelText">Tekst, który będzie się wyświetlać jako etykietka nad polem</param>
    /// <param name="type">Rodzaj pola</param>
    /// <param name="errorMessage">Wiadomość, która będzie wyśwetlana w momencie wprowadzania nieprawidłwych wartości</param>
    /// <param name="value">Wartość pola</param>
    /// <param name="focused">
    ///     Pole, przechowujące informacje o tym, czy dana kontrolka ma być aktywna po uruchomieniu aplikacji.
    ///     Ważną rzeczą jest to, że TYLKO jedna kontrolka w formularzu może mieć ustawioną wartość na true.
    ///     W przeciwnym wypadku ustawianie wartości na true będzie nieskuteczne, ponieważ tylko jedna kontrolka
    ///     będzie aktywna.
    /// </param>
    /// <see cref="FormInputType"/>
    public partial class FormInput : UserControl
    {
        private Control control;
        
        public bool valid { get; private set; }
        public event FormInputEventHandler onChange;


        public string labelText
        {
            get { return (string)GetValue(labelTextProperty); }
            set { SetValue(labelTextProperty, value); }
        }

        public static readonly DependencyProperty labelTextProperty =
            DependencyProperty.Register("labelText", typeof(string), typeof(FormInput), new PropertyMetadata("Default value"));




        public FormInputType type
        {
            get { return (FormInputType)GetValue(typeProperty); }
            set { SetValue(typeProperty, value); }
        }

        public static readonly DependencyProperty typeProperty =
            DependencyProperty.Register("type", typeof(FormInputType), typeof(FormInput), new PropertyMetadata(FormInputType.TEXT));





        public string errorMessage
        {
            get { return (string)GetValue(errorMessageProperty); }
            set { SetValue(errorMessageProperty, value); }
        }

        public static readonly DependencyProperty errorMessageProperty =
            DependencyProperty.Register("errorMessage", typeof(string), typeof(FormInput), new PropertyMetadata(""));




        public string value
        {
            get { return (string)GetValue(valueProperty); }
            set { SetValue(valueProperty, value); }
        }

        public static readonly DependencyProperty valueProperty =
            DependencyProperty.Register("value", typeof(string), typeof(FormInput), new PropertyMetadata(""));





        public bool focused
        {
            get { return (bool)GetValue(focusedProperty); }
            set { SetValue(focusedProperty, value); }
        }

        public static readonly DependencyProperty focusedProperty =
            DependencyProperty.Register("focused", typeof(bool), typeof(FormInput), new PropertyMetadata(false));





        public FormInput()
        {
            InitializeComponent();
            this.DataContext = this;
            this.valid = true;
        }





        public override void OnApplyTemplate()
        {
            switch (this.type)
            {
                case FormInputType.TEXT:
                case FormInputType.NUMBER:
                    control = new TextBox();
                    ((TextBox)control).TextChanged += changeListener;
                    ((TextBox)control).Text = this.value;
                    break;
                case FormInputType.PASSWORD:
                    control = new PasswordBox();
                    ((PasswordBox)control).PasswordChanged += changeListener;
                    ((PasswordBox)control).Password = this.value;
                    break;
                case FormInputType.DATE:
                    control = new DatePicker();
                    ((DatePicker)control).SelectedDateChanged += changeListener;
                    if(this.value != "")
                        ((DatePicker)control).SelectedDate = DateTime.Parse(this.value);
                    break;
            }

            this.inputContentGrid.Children.Add(control);

            if(this.focused)
                this.control.Focus();
        }




        /// <summary>
        /// Metoda ma za zadanie wyczyścić wprowadzoną wartość w pole
        /// </summary>
        public void clear()
        {
            this.value = "";
            switch (this.type)
            {
                case FormInputType.TEXT:
                    ((TextBox)control).Clear();
                    break;
                case FormInputType.PASSWORD:
                    ((PasswordBox)control).Clear();
                    break;
                case FormInputType.DATE:
                    ((DatePicker)control).SelectedDate = null;
                    break;
            }
        }

       

        /// <summary>
        /// Metoda sprawdza, czy dana kontrolka została wypełniona
        /// </summary>
        /// <returns>Zwraza true, jeżeli kontrolka jest wypełniona. W przeciwnym wypadku - false.</returns>
        public bool isEmpty() => this.value == "";



        /// <summary>
        /// Metoda ustawia status kontrolki jako nieprawidłową. Można ją wykorzystać do walidacji wprowadzanej wartości i 
        /// wywietleniu stosownego komunikatu
        /// </summary>
        public void setToInvalid()
        {
            this.valid = false;
            this.validationLabel.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// Metoda zmienia status poprawności wartości kontrolki na prawidłową.
        /// </summary>
        public void setToValid()
        {
            this.valid = true;
            this.validationLabel.Visibility = Visibility.Collapsed;
            this.errorMessage = "";
        }



        /// <summary>
        /// Metoda ma za zadanie zmienić stan kontrolki na aktywną (nie trzeba będzie klikać myszką, by ją aktywować)
        /// </summary>
        public void focus() => this.control.Focus();



        /// <summary>
        /// Metoda będzie wywoływana w momencie dokonywania zmiany wartości kontrolki.
        /// Metoda ta ustawia wartość parametru <see cref="value"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeListener(object sender, EventArgs e)
        {
            switch (this.type)
            {
                case FormInputType.TEXT:
                    this.value = ((TextBox)control).Text;
                    break;
                case FormInputType.PASSWORD:
                    this.value = ((PasswordBox)control).Password;
                    break;
                case FormInputType.DATE:
                    this.value = ((DatePicker)control).SelectedDate.ToString();
                    break;
                case FormInputType.NUMBER:
                    IValidator validator = new NumberValidator();
                    if (!validator.validate(((TextBox)control).Text) && ((TextBox)control).Text != "")
                    {
                        this.errorMessage = "Podana wartość nie jest prawidłową liczbą";
                        this.setToInvalid();
                    }
                    else
                    {
                        this.value = ((TextBox)control).Text.Replace('.', ',');
                        this.setToValid();
                    }
                    break;
            }

            this.onChange?.Invoke(sender, new FormInputEventArgs(this.value));
        }
    }
}
