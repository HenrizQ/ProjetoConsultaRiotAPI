using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoConsultaRiotAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Jogador
        {
            public string id { get; set; }
            public string accountId { get; set; }
            public string puuid { get; set; }
            public string name { get; set; }
            public int profileIconId { get; set; }
            public long revisionDate { get; set; }
            public int summonerLevel { get; set; }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNick.Text)) ;
            MessageBox.Show("Digite seu nick","Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
