using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SpotifyFront
{
    public partial class Form1 : Form
    {
        public string token;

        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            using (HttpClient client = new HttpClient())
            {

                    string url = "https://localhost:7122/account/login";

                    string body = "{\"Email\": \"" + textBox1.Text + "\", \"Senha\": \"" + textBox2.Text + "\"}";

                    var content = new StringContent(body, Encoding.UTF8, "application/json");

                    var reposta = await client.PostAsync(url, content);

                    var contReposta = await reposta.Content.ReadAsStringAsync();

                    Token Login = JsonConvert.DeserializeObject<Token>(contReposta);

                    token = Login.token;
               switch ((int)reposta.StatusCode)
                {
                    case 200: MessageBox.Show("Login Realizado");
                        break;
                        
                    case 400: MessageBox.Show("Dados Ausentes Ou Mal Informados");
                        break;

                    case 401: MessageBox.Show("Email Já Cadastrado");
                        break;


                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {

                string url = "https://localhost:7122/account/signup";

                string body = "{\"Email\": \"" + textBox3.Text + "\", \"Senha\": \"" + textBox4.Text + "\", \"Name\": \"" + textBox5.Text + "\"}";

                var content = new StringContent(body, Encoding.UTF8, "application/json");

                var reposta = await client.PostAsync(url, content);

                var contReposta = await reposta.Content.ReadAsStringAsync();

                Token Registro = JsonConvert.DeserializeObject<Token>(contReposta);

                switch ((int)reposta.StatusCode)
                {
                    case 200: MessageBox.Show("Cadastro Realizado");
                        break;
                        
                    case 400: MessageBox.Show("Dados Ausentes Ou Mal Informados");
                        break;

                    case 401: MessageBox.Show("Email Já Cadastrado");
                        break;


                    case 500: MessageBox.Show("Erro No Servidor");
                        break;

                }
            






            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    string url = "https://localhost:7122/artistas";

                    var reposta = await client.GetAsync(url);

                    var contReposta = await reposta.Content.ReadAsStringAsync();

                    dynamic Artistas = JsonConvert.DeserializeObject<dynamic>(contReposta);

                    listBox1.Items.Clear();
                    foreach (dynamic item in Artistas)
                    {
                        listBox1.Items.Add(item.ToString());
                    }



                }
                catch
                {
                    MessageBox.Show("Erro");
                }
            }

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
              
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    string nome = textBox6.Text;
                    string url = $"https://localhost:7122/artista/{nome}";

                    var reposta = await client.GetAsync(url);

                    var contReposta = await reposta.Content.ReadAsStringAsync();

                    dynamic Artistas = JsonConvert.DeserializeObject<dynamic>(contReposta);

                switch ((int)reposta.StatusCode)
                {
                    case 200:
                        listBox1.Items.Clear();
                        foreach (dynamic item in Artistas)
                        {

                            listBox1.Items.Add(item.ToString());

                        }
                        break;

                    case 404:
                        MessageBox.Show("Dados Não Encontrados");
                        break;

                    case 405:
                        MessageBox.Show("Dados Ausentes");
                        break;

                    case 500:
                        MessageBox.Show("Erro No Servidor");
                        break;

                }

            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    string nomeGenero = textBox7.Text;
                    string url = $"https://localhost:7122/artistass/{nomeGenero}";

                    var reposta = await client.GetAsync(url);

                    var contReposta = await reposta.Content.ReadAsStringAsync();

                    dynamic Artistas = JsonConvert.DeserializeObject<dynamic>(contReposta);

                switch ((int)reposta.StatusCode)
                {
                    case 200:
                        listBox1.Items.Clear();
                        foreach (dynamic item in Artistas)
                        {

                            listBox1.Items.Add(item.ToString());

                        }
                        break;

                    case 404:
                        MessageBox.Show("Dados Não Encontrados");
                        break;


                    case 500:
                        MessageBox.Show("Erro No Servidor");
                        break;

                }


            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    string url = "https://localhost:7122/generos";

                    var reposta = await client.GetAsync(url);

                    var contReposta = await reposta.Content.ReadAsStringAsync();

                    dynamic Generos = JsonConvert.DeserializeObject<dynamic>(contReposta);

                    listBox2.Items.Clear();
                    foreach (dynamic item in Generos)
                    {

                        listBox2.Items.Add(item.ToString());

                    }
                }

                catch
                {
                    MessageBox.Show("Erro");


                }
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button8_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {

           
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    string url = "https://localhost:7122/genero";

                    string body = "{\"Estilo\": \"" + textBox14.Text + "\"}";

                    var content = new StringContent(body, Encoding.UTF8, "application/json");

                    var reposta = await client.PostAsync(url, content);

                    var contReposta = await reposta.Content.ReadAsStringAsync();

                    dynamic genero = JsonConvert.DeserializeObject<dynamic>(contReposta);


                switch ((int)reposta.StatusCode)
                {
                    case 201:
                  
                        MessageBox.Show("Genero Cadastrado");
                        break;

                    case 400:
                        MessageBox.Show("Dados Ausentes");
                        break;
                    case 401:
                        MessageBox.Show("Genero Ja Cadastrado");
                        break;
                    case 403:
                        MessageBox.Show("ACESSO NEGADO");
                            break;
                    case 500:
                        MessageBox.Show("Erro No Servidor");
                        break;
                }

               
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {

                
                

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    string url = "https://localhost:7122/artista";

                    string body = "{\"Nome\": \"" + textBox8.Text + "\", \"Idade\": \"" + textBox9.Text + "\", \"Descricao\": \"" + textBox10.Text + "\", \"Ouvintes\": \"" + textBox11.Text + "\", \"MusicaMaisFamosa\": \"" + textBox12.Text + "\", \"GeneroId\": \"" + textBox13.Text + "\"}";

                    var content = new StringContent(body, Encoding.UTF8, "application/json");

                    var reposta = await client.PostAsync(url, content);

                    var contReposta = await reposta.Content.ReadAsStringAsync();

                    dynamic Artista = JsonConvert.DeserializeObject<dynamic>(contReposta);


                switch ((int)reposta.StatusCode)
                {
                    case 200:
                       
                        MessageBox.Show("Artista Cadastrado");
                        break;

                    case 400:
                        MessageBox.Show("Dados Ausentes");
                        break;
                    case 401:
                    MessageBox.Show("Artista Ja Cadastrado");
                        break;
                    case 403:
                        MessageBox.Show("ACESSO NEGADO");
                        break;
                    case 500:
                        MessageBox.Show("Erro No Servidor");
                        break;

                }

            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {


                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    
                    string nomeArtista = textBox8.Text;
                    string url = $"https://localhost:7122/artista/{nomeArtista}";

                    string body = "{\"Nome\": \"" + textBox8.Text + "\", \"Idade\": \"" + textBox9.Text + "\", \"Descricao\": \"" + textBox10.Text + "\", \"Ouvintes\": \"" + textBox11.Text + "\", \"MusicaMaisFamosa\": \"" + textBox12.Text + "\", \"GeneroId\": \"" + textBox13.Text + "\"}";

                    var content = new StringContent(body, Encoding.UTF8, "application/json");

                    var reposta = await client.PutAsync(url, content);

                    var contReposta = await reposta.Content.ReadAsStringAsync();

                    dynamic ArtistaAtualiza = JsonConvert.DeserializeObject<dynamic>(contReposta);


                    switch ((int)reposta.StatusCode)
                    {
                        case 200:
                           
                            MessageBox.Show("Artista Atualizado");
                        break;

                    case 400:
                            MessageBox.Show("Dados Errados");
                            break;
                    case 403:

                        MessageBox.Show("ACESSO NEGADO");
                        break;

                    case 404:
                        MessageBox.Show("Artista Não Encontrado");
                            break;

                    case 405:
                        MessageBox.Show("Dados Ausentes");
                            break;

                         case 500:
                            MessageBox.Show("Erro No Servidor");
                            break;

                    }
                }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {


                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    string nomeArtista = textBox8.Text;
                    string url = $"https://localhost:7122/artista/{nomeArtista}";

                    var reposta = await client.DeleteAsync(url);

                    var contReposta = await reposta.Content.ReadAsStringAsync();

                    dynamic ArtistaRemove = JsonConvert.DeserializeObject<dynamic>(contReposta);


                switch ((int)reposta.StatusCode)
                {
                    case 200:
                        
                        MessageBox.Show("Artista Removido");
                        break;
                    case 403:
                        MessageBox.Show("ACESSO NEGADO");
                        break;
                    case 404:
                        MessageBox.Show("Artista Não Encontrado");
                        break;
                    case 405:
                        MessageBox.Show("Dados Ausentes");
                        break;

                    case 500:
                        MessageBox.Show("Erro No Servidor");
                        break;

                }

            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}