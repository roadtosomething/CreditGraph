using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Done_Click(object sender, EventArgs e)
        {
            double sC = Convert.ToDouble(this.sumCredit.Text);
            double percent = Convert.ToDouble(this.percentCredit.Text);
            int cMount = Convert.ToInt32(this.countMount.Text);
            double percStavka = percent / (100 * 12);
            double pe = sC * (percStavka + percStavka / (Math.Pow((1 + percStavka), cMount) - 1));
            int i = 0;
            string str = "Месяц | Ежемесячный платеж | Основной долг | Долг по процентам | Остаток основного долга\n";
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("Месяц");
            ds.Tables[0].Columns.Add("Ежемесячный платеж");
            ds.Tables[0].Columns.Add("Основной долг");
            ds.Tables[0].Columns.Add("Долг по процентам");
            ds.Tables[0].Columns.Add("Остаток основного долга");
            while (sC > 0)
            {
                double Ipe = sC * percStavka;
                double mainPe = pe - Ipe;
                sC -= mainPe;
                i += 1;
                str+=$"{i}|{pe}|{mainPe}|{Ipe}|{sC}";
                ds.Tables[0].Rows.Add(i,Math.Round(pe,2),Math.Round(mainPe,2),Math.Round(Ipe,2),Math.Round(sC,2));
            }
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
