using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        Button[,] but = new Button[10, 10];
        Button[,] but2 = new Button[10, 10];
        byte[,] loc = new byte[10, 10];//координаты кораблей
        byte[,] check = new byte[10, 10];//координаты вокруг кораблей
        Random rnd = new Random();
        string[] num = new string[100];
        string[] sd = new string[10];//координаты кораблей 
        int[] sd2 = new int[10];//направление кораблей
        int[] num2 = new int[100];//записаны все координаты
        string[] asd = new string[10];
        int[] asd2 = new int[10];
        bool[] fr = new bool[10];
        bool a = true,hod= true;
        int game = 0;
        int lose = 0;
        int a1 = 0;
        int b1 = 0;
        int r = 4, r1 = 3, r2 = 2, r3 = 1;
        public Form1()
        {
            InitializeComponent();
        }
        void sorte(int i)//спец сотировка не трогать
        {
            bool contains;
            int next;
            do
            {
                next = rnd.Next(0, 100);
                contains = false;
                for (int index = 0; index < i; index++)
                {
                    int n = num2[index];
                    if (n == next)
                    {
                        contains = true;
                        break;
                    }
                }
            } while (contains);
            num2[i] = next;
            num[i] = num2[i].ToString();
        }
         void chec_num(string e)//преобразователь чисел в координаты не трогать
        {
            string a = e;
            if (Convert.ToInt32(a) < 10)
            {
                a1 = 0;
                b1 = Convert.ToInt32(a[0].ToString());
            }
            else
            {
                a1 = Convert.ToInt32(a[0].ToString());
                b1 = Convert.ToInt32(a[1].ToString());
            }
        }
        void korabl1(int i)
        {
            int random = rnd.Next(0, 2);
            if (random == 0)
            {
                bool a = true;
                while (a)
                {
                    sorte(i);
                    chec_num(num[i]);
                    a = false;
                    if (a1 > 6) a = true;

                }
                for (int i1 = 0; i1 < r; i1++) loc[a1 + i1, b1] = 1;  
               // checker(a1,b1,0,r);//
                sd[i] = a1.ToString() + b1.ToString();
                sd2[i] = 0;

            }
            if (random == 1)
            {
                bool a = true;
                while (a)
                {
                    sorte(i);
                    chec_num(num[i]);
                    a = false;
                    if (b1 > 6) a = true;

                }
                for (int i1 = 0; i1 < r; i1++) loc[a1, b1 + i1] = 1;
                sd[i] = a1.ToString() + b1.ToString();
                sd2[i] = 1;
               // checker(a1, b1,1,r);
            }
            
            listBox1.Items.Add(a1 + ":" + b1 + " : " + num[i] + " :  4 мачты");
        }
        void checker(int x ,int y,int napravlenie,int ch)
        {
            if (napravlenie == 0)
            {
                for (int i = 0; i < ch; i++)
                {
                    if (y < 9) check[x + i, y + 1] = 1;
                    if (y > 0) check[x + i, y - 1] = 1;
                }
                if (x > 0) check[x - 1, y] = 1;
                if (x < 10-ch) check[x + ch, y] = 1;
                if (x > 0 && y > 0) check[x - 1, y - 1] = 1;
                if (x > 0 && y < 9) check[x - 1, y + 1] = 1;
                if (x < 10-ch && y < 9) check[x + ch, y + 1] = 1;
                if (x < 10-ch && y > 0) check[x + ch, y - 1] = 1;
            }
            if (napravlenie == 1)
            {
                for (int i = 0; i < ch; i++)
                {
                    if (x < 9) check[x + 1, y + i] = 1;
                    if (x > 0) check[x - 1, y + i] = 1;
                }
                if (y > 0) check[x , y-1] = 1;
                if (y < 10-ch) check[x , y+ch] = 1;
                if (x > 0 && y > 0) check[x - 1, y - 1] = 1;
                if (x < 9 && y >0) check[x + 1, y - 1] = 1;
                if (x < 9 && y < 10-ch) check[x + 1, y + ch] = 1;
                if (x >0 && y <  10-ch) check[x - 1, y + ch] = 1;
            }
            
        }
        void korabl2(int i)
        {
            int rand = rnd.Next(0, 2);
            int random = rand;
            if (random == 0)
            {
                bool a = true;
                while (a)
                {
                    sorte(i);
                    chec_num(num[i]);
                    a = false;
                    if (korabli_3math(a1, b1, r1, random)) a = true;
                }
                for (int i1 = 0; i1 < r1; i1++) loc[a1 + i1, b1] = 1;
               // checker(a1, b1, 0,r1);
                listBox1.Items.Add(a1 + ":" + b1 + " : " + num[i] + " :  3 мачты" + " " + random);
                sd[i] = a1.ToString() + b1.ToString();
                sd2[i] = 0;
            }
            else if (random == 1)
            {
                bool a = true;
                while (a)
                {
                    sorte(i);
                    chec_num(num[i]);
                    a = false;
                    if (korabli_3math(a1, b1, r1, random)) a = true;
                }
                for (int i1 = 0; i1 < r1; i1++) loc[a1, b1 + i1] = 1;
               // checker(a1, b1, 1,r1);
                listBox1.Items.Add(a1 + ":" + b1 + " : " + num[i] + " :  3 мачты" + " " + random);
                sd[i] = a1.ToString() + b1.ToString();
                sd2[i] = 1;
            }
            
        }
        void korabl3(int i)
        {
            int random = rnd.Next(0, 2);
            if (random == 0)
            {
                bool a = true;
                while (a)
                {
                    sorte(i);
                    chec_num(num[i]);
                    a = false;
                    if (korabli_2math(a1, b1, r2, random)) a = true;
                }
                for (int i1 = 0; i1 < r2; i1++) loc[a1 + i1, b1] = 1;
                //checker(a1, b1, 0,r2);
                listBox1.Items.Add(a1 + ":" + b1 + " : " + num[i] + " :  2 мачты");
                sd[i] = a1.ToString() + b1.ToString();
                sd2[i] = 0;
            }
            else if (random == 1)
            {
                bool a = true;
                while (a)
                {
                    sorte(i);
                    chec_num(num[i]);
                    a = false;
                    if (korabli_2math(a1, b1, r2, random)) a = true;
                }
                for (int i1 = 0; i1 < r2; i1++) loc[a1, b1 + i1] = 1;
                //checker(a1, b1, 1,r2);
                listBox1.Items.Add(a1 + ":" + b1 + " : " + num[i] + " :  2 мачты");
                sd[i] = a1.ToString() + b1.ToString();
                sd2[i] = 1;
            }
            
        }
        void korabl4(int i)
        {         
                bool a = true;
                while (a)
                {
                    sorte(i);
                    chec_num(num[i]);
                    a = false;
                    if (korabli_1math(a1, b1, r3)) a = true;
                }
                for (int i1 = 0; i1 < r3; i1++) loc[a1 + i1, b1] = 1;
               // checker(a1, b1, 0,r3);
                listBox1.Items.Add(a1 + ":" + b1 + " : " + num[i] + " :  1 мачта");
            
            sd[i] = a1.ToString() + b1.ToString();
        }

        bool korabli_3math(int x, int y, int r, int ran)
        {
            bool a = false;
            if (x < 8 && ran == 0)
            {
                for (int i = 0; i < r; i++)
                {
                    if (loc[x + i, y] == 1) a = true;
                    if (x > 0 && loc[x - 1, y] == 1) a = true;
                    if (x < 7 && loc[x + i + 1, y] == 1) a = true;
                    if (x < 7 && y<9 && loc[x + i + 1, y+1] == 1) a = true;
                    if (x < 7 && y >0 && loc[x + i + 1, y - 1] == 1) a = true;
                    if (y < 9 && loc[x + i, y + 1] == 1) a = true;
                    if (y > 0 && loc[x + i, y - 1] == 1) a = true;
                    if(x>0 && y<9 && loc[x-1,y+1]==1) a = true;
                    if (x > 0 && y > 0 && loc[x - 1, y - 1] == 1) a = true;
                }
            }
            else if (y < 8 && ran == 1)
            {
                for (int i = 0; i < r; i++)
                {
                    if (loc[x, y + i] == 1) a = true;
                    if (y > 0 && loc[x, y - 1] == 1) a = true;
                    if (y < 7 && loc[x, y + i + 1] == 1) a = true;
                    if (y < 7 && x<9 && loc[x+1, y + i + 1] == 1) a = true;
                    if (y < 7 && x >0 && loc[x - 1, y + i + 1] == 1) a = true;
                    if (x < 9 && loc[x + 1, y + i] == 1) a = true;
                    if (x > 0 && loc[x - 1, y + i] == 1) a = true;
                    if(x>0 && y > 0 && loc[x - 1, y - 1] == 1) a = true;
                    if (x <9 && y > 0 && loc[x + 1, y - 1] == 1) a = true;
                }
            }

            else a = true;
            return a;
        }

        bool korabli_2math(int x, int y, int r, int ran)
        {
            bool a = false;
            if (x < 9 && ran == 0)
            {
                for (int i = 0; i < r; i++)
                {

                    if (loc[x + i, y] == 1) a = true;
                    if (x > 0 && loc[x - 1, y] == 1) a = true;
                    if (x < 8 && loc[x + i + 1, y] == 1) a = true;
                    if (x < 8 && y<9 && loc[x + i + 1, y+1] == 1) a = true;
                    if (x < 8 && y >0 && loc[x + i + 1, y - 1] == 1) a = true;
                    if (y < 9 && loc[x + i, y + 1] == 1) a = true;
                    if (y > 0 && loc[x + i, y - 1] == 1) a = true;
                    if (x > 0 && y < 9 && loc[x - 1, y + 1] == 1) a = true;
                    if (x > 0 && y > 0 && loc[x - 1, y - 1] == 1) a = true;
                }
            }
            else if (y < 9 && ran == 1)
            {
                for (int i = 0; i < r; i++)
                {

                    if (loc[x, y + i] == 1) a = true;
                    if (y > 0 && loc[x, y - 1] == 1) a = true;
                    if (y < 8 && loc[x, y + i + 1] == 1) a = true;
                    if (y < 8 && x<9 && loc[x+1, y + i + 1] == 1) a = true;
                    if (y < 8 && x >0 && loc[x - 1, y + i + 1] == 1) a = true;
                    if (x < 9 && loc[x + 1, y + i] == 1) a = true;
                    if (x > 0 && loc[x - 1, y + i] == 1) a = true;
                    if (x > 0 && y > 0 && loc[x - 1, y - 1] == 1) a = true;
                    if (x < 9 && y > 0 && loc[x + 1, y - 1] == 1) a = true;
                }
            }
            else a = true;
            return a;
        }

        bool korabli_1math(int x, int y, int r)
        {
            bool a = false;
            int i = 1;
            if (x < 9 && loc[x + i, y] == 1) a = true;
            if (x > 0 && loc[x - i, y] == 1) a = true;
            if (y < 9 && loc[x, y + i] == 1) a = true;
            if (y > 0 && loc[x, y - i] == 1) a = true;
            if (x < 9 && y < 9 && loc[x + i, y + i] == 1) a = true;
            if (x > 0 && y > 0 && loc[x - i, y - i] == 1) a = true;
            if (x < 9 && y > 0 && loc[x + i, y - i] == 1) a = true;
            if (x > 0 && y < 9 && loc[x - i, y + i] == 1) a = true;
            return a;
        }

        void randomer(int i)//приоритет тоже не трогать
        {
            if (i < 1) korabl1(i);
            if (i > 0 && i < 3) korabl2(i);
            if (i > 2 && i < 6) korabl3(i);
            if (i > 5 && i < 10) korabl4(i);
        }

        void clear()// уже  используется не трогать
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    but[i, j].BackColor = Color.AntiqueWhite;
                    but[i, j].ForeColor = Color.Black;
                    but2[i, j].Tag = 0;
                    but2[i, j].BackColor = Color.White;
                    loc[i, j] = 0;
                    check[i, j] = 0;
                    label4.Visible = false;
                }
            }
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

      
        void create_game_pole()//создание поля не трогать
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    but[i, j] = new Button();
                    but[i, j].Size = new Size(40, 40);
                    but[i, j].Text = i.ToString() + j.ToString();
                    but[i, j].Tag = 0;
                    but[i, j].Location = new Point(10 + (i * 37), 12 + (j * 37));
                    groupBox1.Controls.Add(but[i, j]);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    but2[i, j] = new Button();
                    but2[i, j].Size = new Size(40, 40);
                    but2[i, j].Click += new EventHandler(cleeck_2);
                    but2[i, j].Text = i.ToString() + j.ToString();
                    but2[i, j].Location = new Point(10 + (i * 37), 12 + (j * 37));
                    groupBox2.Controls.Add(but2[i, j]);
                }
            }
        }
        void cleeck_2(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            var clk = (Button)sender;
            if (hod && clk.BackColor != Color.Gray )
            {
                
                if (clk.Tag.ToString() == "1")
                {
                    clk.BackColor = Color.Red;
                    if (fr[0]) it(0, sd[0], sd2[0]);//4 палубы
                    for (int i = 1; i < 3; i++) if (fr[i]) it1(i, sd[i], sd2[i]);//3 палубы
                    for (int i = 3; i < 6; i++) if (fr[i]) it3(i, sd[i], sd2[i]);// 2 палубы    
                    for (int i = 6; i < 10; i++) if (fr[i]) it6(i, sd[i], sd2[i]);//1 палуба          
                    for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) if (check[i, j] == 1) but2[i, j].BackColor = Color.Green;
                    if (game == 10) label4.Visible = true;
                    hod = true;
                }
                else
                {
                    clk.BackColor = Color.Gray;
                    hod = false;
                }
            }
            if (hod == false)
            {
               
                bool w = true;
                while(w)
                {
                    w=false;
                    int rn = rnd.Next(0, 100);
                    chec_num(rn.ToString());
                    if (but[a1, b1].Tag.ToString() == "1") w = true;
                }
                but[a1, b1].Tag=1;
                if (but[a1, b1].BackColor == Color.Black)
                {
                    but[a1, b1].BackColor = Color.Red;
                    lose++;
                    hod = false;

                }
                else
                {
                    but[a1, b1].BackColor = Color.Gray;
                    hod = true;
                }
            }
            if (lose == 20)
            {
                label4.Text = "you lose";
                label4.Visible = true;
            }
            label5.Text = game.ToString();
        }
        void it(int n , string kor , int nap)
        {
            int cor = Convert.ToInt32(kor);
            chec_num(cor.ToString());
            if (nap == 0 && but2[a1, b1].BackColor == Color.Red && but2[a1 + 1, b1].BackColor == Color.Red && but2[a1 + 2, b1].BackColor == Color.Red && but2[a1 + 3, b1].BackColor == Color.Red)
            {
                checker(a1, b1, 0, 4);//4 палубы по горизонтали
                label3.Text = "4 палубный корабль уничтожен";
                fr[n] = false;
                game++;
            }
            if (nap == 1 && but2[a1, b1].BackColor == Color.Red && but2[a1, b1 + 1].BackColor == Color.Red && but2[a1, b1 + 2].BackColor == Color.Red && but2[a1, b1 + 3].BackColor == Color.Red)
            {
                checker(a1, b1, 1, 4);//4 палубы по горизонтали
                label3.Text = "4 палубный корабль уничтожен";
                fr[n] = false;
                game++;
            }

            listBox3.Items.Add(fr[n] + " " + a1 + "" + b1 + "  " + kor + "  " + nap);
     
        }
        void it1(int n, string kor, int nap)//1-3
        {
            int cor = Convert.ToInt32(kor);
            chec_num(cor.ToString());
            if (nap == 0 && but2[a1, b1].BackColor == Color.Red && but2[a1 + 1, b1].BackColor == Color.Red && but2[a1 + 2, b1].BackColor == Color.Red )
            {
                checker(a1, b1, 0, 3);//3 палубы по горизонтали
                label3.Text = "3 палубный корабль уничтожен";
                fr[n] = false;
                game++;
            }
        
            if (nap == 1 && but2[a1, b1].BackColor == Color.Red && but2[a1, b1 + 1].BackColor == Color.Red && but2[a1, b1 + 2].BackColor == Color.Red)
            {
                checker(a1, b1, 1, 3);//3 палубы по горизонтали
                label3.Text = "3 палубный корабль уничтожен";
                fr[n] = false;
                game++;
            }

            listBox3.Items.Add(fr[n] + " " + a1 + "" + b1 + "  " + kor + "  " + nap);

        }
        void it3(int n, string kor, int nap)//3 - 6
        {
            int cor = Convert.ToInt32(kor);
            chec_num(cor.ToString());
            if (nap == 0 && but2[a1, b1].BackColor == Color.Red && but2[a1 + 1, b1].BackColor == Color.Red )
            {
                checker(a1, b1, 0, 2);//2 палубы по горизонтали
                label3.Text = "2 палубный корабль уничтожен";
                fr[n] = false;
                game++;
            }

            if (nap == 1 && but2[a1, b1].BackColor == Color.Red && but2[a1, b1 + 1].BackColor == Color.Red )
            {
                checker(a1, b1, 1, 2);//2 палубы по горизонтали
                label3.Text = "2 палубный корабль уничтожен";
                fr[n] = false;
                game++;
            }

            listBox3.Items.Add(fr[n] + " " + a1 + "" + b1 + "  " + kor + "  " + nap);
        }
        void it6(int n, string kor, int nap)//от 6 до 10
        {
            int cor = Convert.ToInt32(kor);
            chec_num(cor.ToString());
            if (but2[a1, b1].BackColor == Color.Red )
            {
                checker(a1, b1, 0, 1);//1 палубы по горизонтали
                label3.Text = "1 палубный корабль уничтожен";
                fr[n] = false;
                game++;
            }
            listBox3.Items.Add(fr[n] + " " + a1 + "" + b1 + "  " +kor + "  " + nap);
        }
        void gamer1()
        {
            int t = 1;            
            
            for (int i = 0; i < num.Length; i++) randomer(i);
            for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) if (loc[i, j] == 1)
                    {
                        label1.Text = t++.ToString();
                        but[i, j].BackColor = Color.Black;
                    }
           
           
        }
        void gamer2()
        {
        
            int t = 1;
            for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) loc[i, j] = 0;
            for (int i = 0; i < num.Length; i++) randomer(i);
            for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) if (loc[i, j] == 1)
                    {
                        label2.Text = t++.ToString();
                        but2[i, j].Tag = 1;
                      //  but2[i, j].BackColor = Color.Black;
                    }
            for (int i = 0; i < 10; i++)
            {
                listBox2.Items.Add(sd[i] + " " + sd2[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)//начало всего дерьма что происходит на поле
        {
            for (int i = 0; i < fr.Length; i++)fr[i] = true;
            if(a) create_game_pole();
            clear();
              gamer1();
              for (int i = 0; i < 10; i++)
              {
                  asd[i] = sd[i];
                  asd2[i] = sd2[i];
              }
              gamer2();
            a = false;      
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}//556 уменьшился до .... нихуя он не уменьшился
