using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Client
{
    public partial class Form1 : Form
    {
        HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7151/api/") };
        int compteurVirement = 0;
        public Form1()
        {
            InitializeComponent();

        }
        private void bt_Start_Click(object sender, EventArgs e)
        {
            timerVirement.Start();
            bt_Start.Visible = false;
            bt_Stop.Visible = true;
        }

        private void bt_Stop_Click(object sender, EventArgs e)
        {
            timerVirement.Stop();
            bt_Start.Visible = true;
            bt_Stop.Visible = false;
        }

        private void timerVirement_Tick(object sender, EventArgs e)
        {
            compteurVirement++;
            Console.WriteLine("Virement générés n°" + compteurVirement);
            AddBankTransfer(compteurVirement);


        }
        public async Task AddBankTransfer(int compteurVirement)
        {
            Random random = new Random();
            BankTransfer newbankTransfer = new BankTransfer
            {
                ExpeditorAccountId = 44,
                ReceiverAccountId = random.Next(30, 40),
                Amount = 5,
                Communication = "Donation car je suis MrBeast N°"+compteurVirement,
                DateExpedition = DateTime.Now.ToLocalTime()
            };
              Console.WriteLine($"{newbankTransfer.ReceiverAccountId} | {newbankTransfer.ExpeditorAccountId}");
            var response = httpClient.PostAsJsonAsync("BankTransfer/create", newbankTransfer);
        }
      
    }

    internal class BankTransfer
    {
        public int ReceiverAccountId { get; set; }
        public int ExpeditorAccountId { get; set; }
        public string Communication { get; set; }
        [Required]
        public DateTime DateExpedition { get; set; }
        public int Amount { get; internal set; }
    }
}
