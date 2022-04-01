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
        byte[,] check2 = new byte[10, 10];//координаты вокруг кораблей
        Random rnd = new Random();
        string[] num = new string[100];
        string[] sd = new string[10];//координаты кораблей 
        int[] sd2 = new int[10];//направление кораблей
        int[] num2 = new int[100];//записаны все координаты
        int[] asd = new int[10];
        string[] asd2 = new string[10];
        bool[] fr = new bool[10];
        bool[] fr2 = new bool[10];
        bool a = true,hod= true,bot =true;
        int game = 0;//наш счёт      
        int lose = 0;//противника
        int a1 = 0;
        int b1 = 0;
        int[] br = new int[100];
        int r = 4, r1 = 3, r2 = 2, r3 = 1,bt = 0,n,n1;
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
        void checker2(int x, int y, int napravlenie, int ch)
        {
            if (napravlenie == 0)
            {
                for (int i = 0; i < ch; i++)
                {
                    if (y < 9) check2[x + i, y + 1] = 1;
                    if (y > 0) check2[x + i, y - 1] = 1;
                }
                if (x > 0)                check2[x - 1, y] = 1;
                if (x < 10 - ch)          check2[x + ch, y] = 1;
                if (x > 0 && y > 0)       check2[x - 1, y - 1] = 1;
                if (x > 0 && y < 9)       check2[x - 1, y + 1] = 1;
                if (x < 10 - ch && y < 9) check2[x + ch, y + 1] = 1;
                if (x < 10 - ch && y > 0) check2[x + ch, y - 1] = 1;
            }
            if (napravlenie == 1)
            {
                for (int i = 0; i < ch; i++)
                {
                    if (x < 9) check2[x + 1, y + i] = 1;
                    if (x > 0) check2[x - 1, y + i] = 1;
                }
                if (y > 0)                check2[x, y - 1] = 1;
                if (y < 10 - ch )         check2[x, y + ch] = 1;
                if (x > 0 && y > 0)       check2[x - 1, y - 1] = 1;
                if (x < 9 && y > 0)       check2[x + 1, y - 1] = 1;
                if (x < 9 && y < 10 - ch) check2[x + 1, y + ch] = 1;
                if (x > 0 && y < 10 - ch) check2[x - 1, y + ch] = 1;
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
                    but[i, j].BackColor = Color.White;
                    but[i, j].ForeColor = Color.Black;
                    but2[i, j].Tag = 0;
                    but2[i, j].BackColor = Color.White;
                    loc[i, j] = 0;
                    check[i, j] = 0;
                    check2[i, j] = 0;
                    label4.Visible = false;
                    bt = 0;
                }
                fr[i] = true;
                fr2[i] = true;
                asd[i] = 0;
                asd2[i] = "";
                game = 0;
                lose = 0;
            }
            bt = 0;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
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
                    but[i, j].Click += new EventHandler(cleeck_1);
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
        void cleeck_1(object sender, EventArgs e)//тут мы раставляем
        {
            var clk = (Button)sender;
            listBox3.Items.Clear();
            if (bt < 16 && checkBox1.Checked != true && prov(clk.Text))
            {          
                if (clk.BackColor == Color.White && bt < 20)//потом добавить проверку по кругу
                {
                    clk.BackColor = Color.Black;
                    bt++;
                }
                if (bt < 3) crash(clk.Text);//4 палубы 0               
                if (bt == 2) label3.Text = "поставьте две  3-х палубных корабя";
                if (bt > 2 && bt < 5) crash1(clk.Text, 1, 3, 4);//3 палубы 1
                if (bt > 4 && bt < 7) crash1(clk.Text, 2, 5, 6);//3 палубы 2                
                if (bt == 6)  label3.Text = "поставьте три  2-х палубных корабя";
                if (bt >6 && bt < 9) crash2(clk.Text , 3,7,8);//2 палубы 1
                if (bt > 8 && bt < 11) crash2(clk.Text, 4,9,10);//2 палубы 2
                if (bt > 10 && bt < 13) crash2(clk.Text, 5,11,12);//2 палубы 3
                if (bt == 12) label3.Text = "поставьте четыре  1-х палубных корабей";
                if (bt == 13)
                {
                     int st = Convert.ToInt32(clk.Text);
                     asd2[6] = st.ToString();
                }
                if (bt == 14)
                {
                    int st = Convert.ToInt32(clk.Text);
                    asd2[7] = st.ToString();
                }
                if (bt == 15)
                {
                    int st = Convert.ToInt32(clk.Text);
                    asd2[8] = st.ToString();
                }
                if (bt == 16)
                {
                    int st = Convert.ToInt32(clk.Text);
                    asd2[9] = st.ToString();
                }
                if (bt == 16) label3.Text = "подготовка завершена начните отаку";
            }
            else label3.Text = "подготовка завершена начните отаку";
            
            label1.Text = bt.ToString();
            for (int i = 0; i < 10; i++) listBox3.Items.Add(asd[i] + " : " + asd2[i]);
        }
        void cleeck_2(object sender, EventArgs e)//тут мы и бот атакуем
        {
            listBox3.Items.Clear();
            var clk = (Button)sender;
            if (lose < 10 && game < 10)
            {
                if (bt > 15 || checkBox1.Checked)
                {
                    if (hod && clk.BackColor != Color.Gray)
                    {
                        if (clk.BackColor == Color.Black || clk.Tag.ToString() == "1")
                        {
                            clk.BackColor = Color.Red;
                            if (fr[0]) it(0, sd[0], sd2[0]);//4 палубы
                            for (int i = 1; i < 3; i++) if (fr[i]) it1(i, sd[i], sd2[i]);//3 палубы
                            for (int i = 3; i < 6; i++) if (fr[i]) it3(i, sd[i], sd2[i]);// 2 палубы    
                            for (int i = 6; i < 10; i++) if (fr[i]) it6(i, sd[i], sd2[i]);//1 палуба          
                            for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) if (check[i, j] == 1) but2[i, j].BackColor = Color.Gray;//закраска вокруг корабля
                            if (game == 10) label4.Visible = true;
                            hod = true;
                        }
                        else
                        {
                            clk.BackColor = Color.Gray;
                            hod = false;
                        }
                    }
                    while (hod == false)//отака противника
                    {
                        bool w = true;
                       if (bot == true)
                       {
                            while (w)//если мы попали то ходим до тех пор пока не промажем
                            {
                                w = false;
                                int rn = rnd.Next(0, 100);
                                chec_num(rn.ToString());
                                if (but[a1, b1].BackColor == Color.Gray || but[a1, b1].BackColor == Color.Red) w = true;
                                if (lose == 10) w = false;
                                label1.Text = rn.ToString();
                            }
                        }
                        else nado();                    
                        if (but[a1, b1].BackColor == Color.Black)
                        {
                            but[a1, b1].BackColor = Color.Red;
                            bot = false;
                            //тута надобно вставить проверку
                            if (bot == false)
                            {
                                n = a1;
                                n1 = b1;
                            }
                            if (fr2[0]) it_2(0, asd2[0], asd[0]);//4 палубы
                            for (int i = 1; i < 3; i++) if (fr2[i]) it1_2(i, asd2[i], asd[i]);//3 палубы
                            for (int i = 3; i < 6; i++) if (fr2[i]) it3_2(i, asd2[i], asd[i]);//2 палубы  
                            for (int i = 6; i < 10; i++) if (fr2[i]) it6_2(i, asd2[i], asd[i]);//1 палуба  
                            hod = false;//нужна корректировка
                         
                        }
                        else
                        {
                            but[a1, b1].BackColor = Color.Gray;
                            hod = true;
                        }
                        if (lose == 10)
                        {
                            label4.Text = "you lose";
                            label4.Visible = true;
                        }
                       
                    }
                }
                if (lose == 10)
                {
                    label4.Text = "you lose";
                    label4.Visible = true;
                }
                if (game == 10) label4.Visible = true;
                for (int i = 0; i < 10; i++) listBox3.Items.Add(asd[i] + " : " + asd2[i] + " :: " + fr[i]);
                label5.Text = game.ToString();
                label6.Text = lose.ToString();
                label7.Text = bot.ToString();
            }
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
        }
        void it_2(int n, string kor, int nap)
        {
            chec_num(kor);
            if (nap == 0 && but[a1, b1].BackColor == Color.Red && but[a1 + 1, b1].BackColor == Color.Red && but[a1 + 2, b1].BackColor == Color.Red && but[a1 + 3, b1].BackColor == Color.Red)
            {
                checker2(a1, b1, 0, 4);//4 палубы по горизонтали
                label3.Text = "наш 4 палубный корабль уничтожен";
                fr2[n] = false;
                bot = true;
                lose++;
            }

            if (nap == 1 && but[a1, b1].BackColor == Color.Red && but[a1, b1 + 1].BackColor == Color.Red && but[a1, b1 + 2].BackColor == Color.Red && but[a1, b1 + 3].BackColor == Color.Red)
            {
                checker2(a1, b1, 1, 4);//4 палубы по горизонтали
                label3.Text = "наш 4 палубный корабль уничтожен";
                fr2[n] = false;
                lose++;
                bot = true;
            }

            for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) if (check2[i, j] == 1) but[i, j].BackColor = Color.Gray;   
        }
        void it1_2(int n, string kor, int nap)//1-3
        {
            int cor = Convert.ToInt32(kor);
            chec_num(cor.ToString());
            if (nap == 0 && but[a1, b1].BackColor == Color.Red && but[a1 + 1, b1].BackColor == Color.Red && but[a1 + 2, b1].BackColor == Color.Red)
            {
                checker2(a1, b1, 0, 3);//3 палубы по горизонтали
                label3.Text = "наш 3 палубный корабль уничтожен";
                fr2[n] = false;
                lose++;
                bot = true;
            }

            if (nap == 1 && but[a1, b1].BackColor == Color.Red && but[a1, b1 + 1].BackColor == Color.Red && but[a1, b1 + 2].BackColor == Color.Red)
            {
                checker2(a1, b1, 1, 3);//3 палубы по горизонтали
                label3.Text = "наш 3 палубный корабль уничтожен";
                fr2[n] = false;
                lose++;
                bot = true;
            }

            for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) if (check2[i, j] == 1) but[i, j].BackColor = Color.Gray;   
        }
        void it3_2(int n, string kor, int nap)//3 - 6
        {
            int cor = Convert.ToInt32(kor);
            chec_num(cor.ToString());
            if (nap == 0 && but[a1, b1].BackColor == Color.Red && but[a1 + 1, b1].BackColor == Color.Red)
            {
                checker2(a1, b1, 0, 2);//2 палубы по горизонтали
                label3.Text = "наш 2 палубный корабль уничтожен";
                fr2[n] = false;
                lose++;
                bot = true;
            }

            if (nap == 1 && but[a1, b1].BackColor == Color.Red && but[a1, b1 + 1].BackColor == Color.Red)
            {
                checker2(a1, b1, 1, 2);//2 палубы по горизонтали
                label3.Text = "наш 2 палубный корабль уничтожен";
                fr2[n] = false;
                lose++;
                bot = true;
            }

            for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) if (check2[i, j] == 1) but[i, j].BackColor = Color.Gray;   
        }
        void it6_2(int n, string kor, int nap)//от 6 до 10
        {
            
            chec_num(kor);
            if (but[a1, b1].BackColor == Color.Red)
            {
                checker2(a1, b1, 0, 1);//1 палубы по горизонтали
                label3.Text = "наш 1 палубный корабль уничтожен";
                fr2[n] = false;
                lose++;
                bot = true;
            }

            for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) if (check2[i, j] == 1) but[i, j].BackColor = Color.Gray;   
        }
        void crash(string st)//проверка для 4 палубного
        {
            int st1 = Convert.ToInt32(st);
            string str = st1.ToString();
            int x, y;
            if (bt == 1)
            {
                chec_num(str);
                asd2[0] = str;
            }
            if (bt == 2)
            {
                int e = 0, b = 0, m = 0;
                chec_num(str);
                x = a1;
                y = b1;
                chec_num(asd2[0]);
                if (a1 < x && a1 < 7)//по горизонтали вправо
                {
                    for (int i = 0; i < 4; i++)
                    {
                        but[a1 + i, b1].BackColor = Color.Black;
                        asd[0] = 0;
                    }
                }
                else if (a1 < x && a1 >= 7)//проверка по горизонтали чтобы не выходило за край
                {
                    for (int i = 0; i < 4; i++)
                    {
                        but[x - i, b1].BackColor = Color.Black;
                        e = x - i;
                        b = b1;
                    }
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd[0] = 0;
                    asd2[0] = str;
                }
                if (b1 < y && b1 < 7)// по вертикали вниз
                {
                    for (int i = 0; i < 4; i++)
                    {
                        but[a1, b1 + i].BackColor = Color.Black;
                        asd[0] = 1;
                    }
                }
                else if (b1 < y && b1 >= 7)//проверка по вертикали чтобы не выходило за край
                {
                    for (int i = 0; i < 4; i++)
                    {
                        but[a1 , y-i].BackColor = Color.Black;
                        e = x ;
                        b = (b1 - i)+1;
                    }
                    
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd[0] = 1;
                    asd2[0] = str;
                }
                //зеркало
                if (a1 > x && a1 > 2)//по горизонтали
                {
                    for (int i = 0; i < 4; i++)
                    {
                        but[a1 - i, b1].BackColor = Color.Black;
                        e = a1 - i;
                        b = b1;
                    }
                    asd[0] = 0;
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd2[0] = str;
                }
                else if (a1 > x && a1 <= 2)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        but[x + i, b1].BackColor = Color.Black;
                       
                    }
                    e = x;
                    b = b1;
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd[0] = 0;
                    asd2[0] = str;
                }

                if (b1 > y && b1 > 2)// по вертикали вверх
                {
                    for (int i = 0; i < 4; i++)
                    {
                        but[a1, b1 - i].BackColor = Color.Black;
                        
                        e = a1 ;                      
                    }
                    b = b1-3;
                    asd[0] = 1;
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd2[0] = str;
                }
                else if (b1 > y && b1 <= 2)//проверка по вертикали чтобы не выходило за край
                {
                    for (int i = 0; i < 4; i++)
                    {
                        but[a1, y + i].BackColor = Color.Black;
                        e = x;
                        b = y;
                    }

                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd[0] = 1;
                    asd2[0] = str;
                }
                label5.Text = x.ToString() + "" + y.ToString() + " : " + a1.ToString() + "" + b1.ToString();

            }

         //   listBox3.Items.Add(asd2[0] +" : " + asd[0]);
        }
        void crash1(string st , int n,int a,int b2)
        {
            int x, y;
            int st1 = Convert.ToInt32(st);
            string str = st1.ToString();
            if (bt == a)
            {
                chec_num(str);
                asd2[n] = str;
            }
            if (bt == b2)
            {
                int e = 0, b = 0, m = 0;
                chec_num(str);
                x = a1;
                y = b1;
                chec_num(asd2[n]);
                if (a1 < x && a1 < 8)//по горизонтали вправо
                {
                    for (int i = 0; i < 3; i++)
                    {
                        but[a1 + i, b1].BackColor = Color.Black;
                        asd[n] = 0;
                    }
                }
                else if (a1 < x && a1 >= 8)//проверка по горизонтали чтобы не выходило за край
                {
                    for (int i = 0; i < 3; i++)
                    {
                        but[x - i, b1].BackColor = Color.Black;
                        e = x - i;
                        b = b1;
                    }
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd[n] = 0;
                    asd2[n] = str;
                }
                if (b1 < y && b1 < 8)// по вертикали вниз
                {
                    for (int i = 0; i < 3; i++)
                    {
                        but[a1, b1 + i].BackColor = Color.Black;
                        asd[n] = 1;
                    }
                }
                else if (b1 < y && b1 >= 8)//проверка по вертикали чтобы не выходило за край
                {
                    for (int i = 0; i < 3; i++)
                    {
                        but[a1, y - i].BackColor = Color.Black;
                        e = x;
                        b = (b1 - i) + 1;
                    }

                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd[n] = 1;
                    asd2[n] = str;
                }
                //зеркало
                if (a1 > x && a1 > 1)//по горизонтали
                {
                    for (int i = 0; i < 3; i++)
                    {
                        but[a1 - i, b1].BackColor = Color.Black;
                        e = a1 - i;
                        b = b1;
                    }
                    asd[n] = 0;
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd2[n] = str;
                }
                else if (a1 > x && a1 <= 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        but[x + i, b1].BackColor = Color.Black;

                    }
                    e = x;
                    b = b1;
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd[n] = 0;
                    asd2[n] = str;
                }

                if (b1 > y && b1 > 1)// по вертикали вверх
                {
                    for (int i = 0; i < 3; i++)
                    {
                        but[a1, b1 - i].BackColor = Color.Black;

                        e = a1;
                    }
                    b = b1 - 2;
                    asd[n] = 1;
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd2[n] = str;
                }
                else if (b1 > y && b1 <= 1)//проверка по вертикали чтобы не выходило за край
                {
                    for (int i = 0; i < 3; i++)
                    {
                        but[a1, y + i].BackColor = Color.Black;
                        e = x;
                        b = y;
                    }

                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd[n] = 1;
                    asd2[n] = str;
                }
                label5.Text = x.ToString() + "" + y.ToString() + " : " + a1.ToString() + "" + b1.ToString();

            }
        }
        void crash2(string st, int n,int a,int b)
        {
            int e = 0, m = 0;
            int x, y;
            int st1 = Convert.ToInt32(st);
            string str = st1.ToString();
            if (bt == a)
            {
                chec_num(str);
                asd2[n] = str;
            }
            if (bt == b)
            {
                chec_num(str);
                x = a1;//второе нажатие
                y = b1;
                chec_num(asd2[n]);//первое нажатие
                if (a1 < x)
                {
                    asd[n] = 0;
                }
                else if (a1 > x)
                {
                    e = x;
                    b = b1;
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd2[n] = str;
                    asd[n] = 0;
                }
                if (b1 < y)
                {
                    asd[n] = 1;
                }
                else if (b1 > y)
                {
                    e = a1;
                    b = y;
                    str = e.ToString() + b.ToString();
                    m = Convert.ToInt32(str);
                    str = m.ToString();
                    asd2[n] = str;
                    asd[n] = 1;
                }
             
            }
        }
        bool prov(string kor)
        {
            bool ch = false;
            int cor = Convert.ToInt32(kor);
            int i = 0;
            chec_num(cor.ToString());
            if (a1 < 9 && b1 < 9) if (but[a1 + 1, b1 + 1].BackColor == Color.Black) i++; 

            if (a1 < 9 && b1 > 0) if (but[a1 + 1, b1 - 1].BackColor == Color.Black) i++;
            if (a1 > 0 && b1 < 9) if (but[a1 - 1, b1 + 1].BackColor == Color.Black) i++;
            if (a1 > 0 && b1 > 0) if (but[a1 - 1, b1 - 1].BackColor == Color.Black) i++;
            if (i == 0) ch = true;
            label7.Text = i.ToString() + " : " + ch.ToString();
            return ch;
        }
        void nado()
        {
            //int cor = Convert.ToInt32(kor);
            //chec_num(cor.ToString());
            bool right = true, left = true, top = true, bottom =true;
            int i = rnd.Next(0,3);
            if (n > 0  && but[n - 1, n1].BackColor == Color.Gray && but[n - 1, n1].BackColor == Color.Red) left   = false;
            if (n < 9  && but[n + 1, n1].BackColor == Color.Gray && but[n + 1, n1].BackColor == Color.Red) right  = false;
            if (n1 > 0 && but[n, n1 - 1].BackColor == Color.Gray && but[n, n1 - 1].BackColor == Color.Red) top    = false;
            if (n1 < 9 && but[n, n1 + 1].BackColor == Color.Gray && but[n, n1 + 1].BackColor == Color.Red) bottom = false;


            if (left)
            { 
                
            }
            else if (right)
            { 
            
            }
            else if (top)
            { 
            
            }
           else  if (bottom)
            { 
            
            }
            //if (but[a1 - 1, b1].BackColor == Color.Black)
            //{
            //    but[a1 - 1, b1].BackColor = Color.Red;
            //    hod = false;
            //    bot = false;
            //} 
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
            for (int i = 0; i < 10; i++)
            {
                int sy = 0;
                asd[i] = sd2[i];
                sy = Convert.ToInt32(sd[i]);
                asd2[i] =sy.ToString();
                listBox3.Items.Add(asd[i] + " : " + asd2[i]);
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
                       // but2[i, j].BackColor = Color.Black;
                        but2[i, j].Tag = 1;
                    }
            for (int i = 0; i < 10; i++)
            {
                listBox2.Items.Add(sd[i] + " " + sd2[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)//начало всего дерьма что происходит на поле
        {
            if (a) create_game_pole();
            clear();
            for (int i = 0; i < fr.Length; i++)fr[i] = true;
            if (checkBox1.Checked == true)
            {
                gamer1();
                label3.Visible = false;
            }
            else label3.Visible = true;
            gamer2();
            a = false;
            label3.Text = "поставьте первый 4 палубный корабль";
        }
    }
}//556 уменьшился до .... нихуя он не уменьшился, ААААААА 1017
