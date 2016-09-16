using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsTest1
{
    public partial class SecUI : ContentPage
    {

        public SecUI(TextModel model)
        {
            InitializeComponent();
            //BindingContext = model;
            //lbl1.Text += model.Texto;
            lbl2.Text += model.Texto;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            btnVolver.Clicked += BtnVolver_Clicked;
        }

        private void BtnVolver_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushModalAsync(new MainUI());
            base.OnBackButtonPressed();
            //this.Navigation.RemovePage(this);
        }
    }
}
