using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningWindowForm_24_06_2017
{
    public partial class frmRandomFood : Form
    {
        static Boolean isStart = true;
       
        ArrayList menuList = new ArrayList();
        static int count = 0;

        public frmRandomFood()
        {
            InitializeComponent();
            menuList.Add("กะเพราหมูกรอบ");
            menuList.Add("กะเพราหมูไก่");
            menuList.Add("สุกี้แห้ง");
            menuList.Add("ผัดมาม่า");
            menuList.Add("ราดหน้า");
            menuList.Add("สุกี้น้ำ");
            menuList.Add("ก๋วยเตี๋ยวเส้นหมี่");
            menuList.Add("ส้มตำ");
            menuList.Add("ขนมจีน");
            menuList.Add("ก๋วยเตี๋ยวเส้นมาม่า");
            menuList.Add("ก๋วยจั๊บ");
            menuList.Add("ข้าวราดแกง");
            menuList.Add("KFC");
            menuList.Add("ต้มยำทะเล");
            menuList.Add("ลูกชิ้น");
            menuList.Add("มาม่า");
            menuList.Add("ไม่กิน");
            menuList.Add("ซาลาเปา");
            menuList.Add("ผัดเผ็ด");
            menuList.Add("ข้าวขาหมู");
            menuList.Add("ผัดไท");
            menuList.Add("กะเพราหมูกรอบ");

        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txbRandomFood.Text = menuList[count].ToString();
            count += 1;
            
            if(count == menuList.Count)
            {
                count = 0;
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
