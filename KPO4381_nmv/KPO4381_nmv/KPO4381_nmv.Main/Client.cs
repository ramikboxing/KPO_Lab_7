using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KPO4381_nmv.Main
{
    public partial class Client : FrmMain
    {
        //Метод для передачи в качестве делегата
        public void OnAfterRowRead(string[] cerrentRow)
        {
            ActiveForm.Text = "Загрузка из файла.";
            Thread.Sleep(180);
            ActiveForm.Text = "Загрузка из файла.";
            Thread.Sleep(180);
            ActiveForm.Text = "Загрузка из файла.";
            Thread.Sleep(180);
            ActiveForm.Text = "Чтение завершено.";
            

        }
       /* public Client()
        {
            InitializeComponent();
        }*/
      /*  private void InitializeComponent()
        {
            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(452, 248);
            this.Name = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }*/

        private void Client_Load(object sender, EventArgs e)
        {

        }
    }
}
