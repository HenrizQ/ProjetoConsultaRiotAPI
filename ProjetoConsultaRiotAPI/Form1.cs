using System;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ProjetoConsultaRiotAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class JogadorResult
        {
            [JsonProperty(PropertyName = "id")]
            public string id { get; set; }

            [JsonProperty(PropertyName = "accountId")]
            public string accountId { get; set; }
            
            [JsonProperty(PropertyName = "puuid")]
            public string puuid { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string name { get; set; }

            [JsonProperty(PropertyName = "profileIconId")]
            public int profileIconId { get; set; }

            [JsonProperty(PropertyName = "revisionDate")]
            public long revisionDate { get; set; }

            [JsonProperty(PropertyName = "summonerLevel")]
            public int summonerLevel { get; set; }
            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if  (string.IsNullOrWhiteSpace(txtNick.Text))
            MessageBox.Show("Digite seu nick!", "Aviso!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            else
            {
                string ApiURL = string.Format("https://br1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{0}?api_key=RGAPI-7f721438-c2c5-4556-b800-d01b20fe7630", txtNick.Text.Trim());
                try
                {
                    using (HttpClient client = new HttpClient()) 
                    {
                        var response = client.GetAsync(ApiURL).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            JogadorResult res = JsonConvert.DeserializeObject<JogadorResult>(result);

                            txtNivel.Text = res.summonerLevel.ToString();
                            txtIconID.Text = res.profileIconId.ToString();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  
                }
            }

        }
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNick.Text = string.Empty;
            txtIconID.Text = string.Empty;
            txtNivel.Text = string.Empty;
        }
    }
}
