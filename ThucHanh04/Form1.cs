using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ThucHanh04
{
    public partial class Form1 : Form
    {
        List<string> lst = new List<string>();

        public Form1()
        {
            InitializeComponent();
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

        int ly, lm, ld, d, m;

        void getAL(DateTime d)
        {
            VietnameseCalendar.FromDateTime(d, out ly, out lm, out ld);
            lblNgayAm.Text = ld.ToString();

            string t = lm.ToString();
            if (t == "1") t = "Giêng";
            else if (t == "12") t = "Chạp";
            lblThangAm.Text = "Tháng " + t;

            string y = VietnameseCalendar.GetYearName(ly).ToString();
            lblNamAm.Text = "Năm " + y;
        }

        void readData()
        {
            string path = Application.StartupPath + @"\quotes.txt";
            string line;
            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                lst.Add(line);
            }
            file.Close();
        }

        void update(DateTime current)
        {
            lblNgay.Text = current.ToString("dd");
            lblThang.Text = "Tháng " + current.ToString("MM");
            lblNam.Text = current.ToString("yyyy");
            DayOfWeek thu = current.DayOfWeek;
            string sthu = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(thu);
            lblThu.Text = sthu;
            d = current.Day;
            m = current.Month;
            
            
        }

        void updanhngon()
        {
            //Random rand = new Random();
            //lbldanhngon.Text = lst[rand.Next(lst.Count)];
            Random ran = new Random();
            int so = ran.Next(0,310);
            lbldanhngon.Text = lst[so];
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            update(dateTimePicker1.Value);
            getAL(dateTimePicker1.Value);
            updanhngon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
            button1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readData();
            update(DateTime.Now);
            getAL(DateTime.Now);
            updanhngon();
        }

         

       

        
    }
}
