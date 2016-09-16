using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsTest1
{
    public partial class MainUI : ContentPage
    {
        public MainUI()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            btn1.Clicked += Btn1_Clicked;
            btn2.Clicked += Btn2_Clicked;
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                String texto = textBox1.Text;
                var text = new TextModel{ Texto = textBox1.Text };
                this.Navigation.PushModalAsync(new SecUI(text));
            }
            else
            {
                DisplayAlert("Por favor ingrese un texto", "Se que no lo hiciste", "Ok");
            }
            
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            String  texto = textBox1.Text;

            DisplayAlert("Funciona!!", "Usted escribio: "+texto, "Fuck yeah");
        }


    }
    
}
