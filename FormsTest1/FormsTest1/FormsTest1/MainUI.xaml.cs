using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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

        private async void Btn2_Clicked(object sender, EventArgs e)
        {
            var text = new TextModel();
            String p_texto;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                p_texto = textBox1.Text;


                //Intento de busqueda en wikipedia para el campo de texto

                IDictionary<string, string> lista = new Dictionary<string, string>();

                System.Net.HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://es.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro=&explaintext=&titles=" + WebUtility.UrlEncode(p_texto));
                webRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                webRequest.ContentType = "application/json; charset=utf-8";
                try
                {
                    HttpWebResponse webResponse = (HttpWebResponse)await webRequest.GetResponseAsync();
                    using (var reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        var strJSON = reader.ReadToEnd();
                        JObject JSON = JObject.Parse(strJSON);
                        if (!string.IsNullOrEmpty(JSON["query"]["pages"].First.First["extract"].ToString()))
                        {
                            lista.Add(new KeyValuePair<string, string>(JSON["query"]["pages"].First.First["title"].ToString(), JSON["query"]["pages"].First.First["extract"].ToString()));

                            text.Texto = lista[p_texto].ToString();
                            text.Titulo = p_texto;

                            var stop = 1;
                            

                        }
                    }

                }
                catch (Exception ex)
                {
                    
                    text.Texto = "No se encontro información en wikipedia sobre "+p_texto+".";
                    text.Titulo = "No se encontró el articulo";

                    // logger.DebugFormat("Error RelatedAditionalInfo: '{0}'", ex.Message);
                }



            }
            else
            {
                await DisplayAlert("Por favor ingrese un texto", "Se que no lo hiciste", "Ok");
            }
            await this.Navigation.PushModalAsync(new SecUI(text));

        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            String  texto = textBox1.Text;

            DisplayAlert("Funciona!!", "Usted escribio: "+texto, "Fuck yeah");
        }


    }
    
}
