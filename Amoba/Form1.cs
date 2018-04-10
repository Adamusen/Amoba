using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Amoba
{
    public partial class Form1 : Form
    {
        public bool ingame=false; //fut-e épp játék.
        public int zoom; //A zoomolási tényező
        public int mx,my; // egér x,y koordinátáinak helye.
        public int spx, spy; // A pálya közepének helye az ablak széléhez képest.
        public int spxk, spyk; // A pálya közepének helye a jobb egérgombos mozgatás kezdetekor.
        public const int range = 100; // A pálya mérete minden irányban.
        public bool [ , ] player1 = new bool[range*2,range*2]; //Az első játékos tömbje (hol van bábúja, hol nincs)
        public bool [ , ] player2 = new bool[range*2,range*2]; //A második játékos tömbje (hol van bábúja, hol nincs)
        public bool player1turn; //Ez a változó tárolja el, hogy épp az első játékos lép-e.
        public Point startPoint; //Az egér kezdeti helye mozgatás elkezdése esetén (jobb egérgomb)
        public Point endPoint; //Az egér végső helye mozgatás végén vagy közben.
        public Point ptCursor; //Az egér x,y koordinátinak helye a form1-en belül.
        public bool isDrag = false; //Logikai változó arra, hogy épp mozgatjuk-e a pályát.
        public bool origo = true; //Pálya Origoját jelezzem-e ki információt tároló változó.
        public bool keret = true; //Pálya keretét jelezzem-e ki információt tároló változó.
        public bool boton = false; //Gépi játékos be illetve kikapcsolt állapotát tároló változó.
        string FajlNev = "Save.txt"; //Ebbe a fájlba ment a játék.
        
        public Form1()
        {
            InitializeComponent(); 
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseWheel += new MouseEventHandler(Form1_MouseMove);
            //Egér görgőjének kezelét tölti be ez a két sor a programba (netről néztem)
        }

        private void újJátékToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoom = 30; spx = 200; spy = 200; //Alapadatok megadása parametrikus kijelzéshez.
            for(int i = 0; i < range*2; i++) //Bábuk meglétét tároló változók nullázása
                for (int j = 0; j < range*2; j++)
                {
                    player1[i, j] = false;
                    player2[i, j] = false;
                }
            player1turn = true; //Első játékos kezd, igen!
            ingame = true; //Játékon belül vagyunk, igen!
            Alap(spx,spy,zoom); //átugrás a mindent kiábrázoló voidba.
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (ingame == true) Alap(spx, spy, zoom); //Event arra, ha átméretezzük az ablakot, rajzolja újra a dolgokat.
        }

        private void Alap(int spx1, int spy1, int z1)
        {
            Refresh();
            Graphics g = this.CreateGraphics(); //Grafika betöltése
            mx = Form1.MousePosition.X;
            my = Form1.MousePosition.Y; //Egér koordinátáinak lementése
            
            Pen p = new Pen(Color.Green, 2);
            Point p1, p2;
            for (int i = -range; i <= range; i++) //A zöld rács kirajzolása
            {
                p1 = new Point(spx + i * z1, spy - range * z1);
                p2 = new Point(spx + i * z1, spy + range * z1);
                g.DrawLine(p, p1, p2);
                p1 = new Point(spx - range * z1, spy + i * z1);
                p2 = new Point(spx + range * z1, spy + i * z1);
                g.DrawLine(p, p1, p2);
            }

            if (keret == true) //A keret kirajzolása
            {
                p = new Pen(Color.Yellow, 3);
                p1 = new Point(spx - (range - 4) * z1, spy - (range - 4) * z1);
                p2 = new Point(spx + (range - 4) * z1, spy - (range - 4) * z1);
                g.DrawLine(p, p1, p2);
                p1 = new Point(spx - (range - 4) * z1, spy + (range - 4) * z1);
                p2 = new Point(spx + (range - 4) * z1, spy + (range - 4) * z1);
                g.DrawLine(p, p1, p2);
                p1 = new Point(spx - (range - 4) * z1, spy - (range - 4) * z1);
                p2 = new Point(spx - (range - 4) * z1, spy + (range - 4) * z1);
                g.DrawLine(p, p1, p2);
                p1 = new Point(spx + (range - 4) * z1, spy - (range - 4) * z1);
                p2 = new Point(spx + (range - 4) * z1, spy + (range - 4) * z1);
                g.DrawLine(p, p1, p2);
            }

            if (origo == true) //Az origo kirajzolása
            {
                p = new Pen(Color.Yellow, 2);
                p1 = new Point(spx - 5, spy);
                p2 = new Point(spx + 5, spy);
                g.DrawLine(p, p1, p2);
                p1 = new Point(spx, spy - 5);
                p2 = new Point(spx, spy + 5);
                g.DrawLine(p, p1, p2);
            }

            for (int i = 0; i < range * 2; i++) //Az egyes játékosok bábuinak kiábrázolása.
                for (int j = 0; j < range * 2; j++)
                {
                    if (player1[i, j] == true) DrawX(i - range, j - range);
                    if (player2[i, j] == true) DrawY(i - range, j - range);
                }

        }

        private void DrawX(int i, int j) //X rajzolása a pálya i. sor, j. oszlopába. 
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Red, 2);
            Point p1, p2;
            p1 = new Point (spx + 2 + zoom*i, spy + 2 + zoom*j);
            p2 = new Point (spx - 2 + zoom*(i+1), spy - 2 + zoom*(j+1));
            g.DrawLine(p,p1,p2);
            p1 = new Point (spx + 2 + zoom*i, spy - 2 + zoom*(j+1));
            p2 = new Point (spx - 2 + zoom*(i+1), spy + 2 + zoom*j);
            g.DrawLine(p, p1, p2);
        }

        private void DrawY(int i, int j) //O rajzolása a pálya i. sor, j. oszlopába. 
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Blue, 2);
            int x, y, sz, m;
            x = spx + 2 + zoom * i;
            y = spy + 2 + zoom * j;
            sz = zoom - 4;
            m = zoom - 4;
            Rectangle t = new Rectangle(new Point(x, y), new Size(sz, m));
            g.DrawEllipse(p, t);
        }

        private void Helymeghatarozas() //Meghatározza, hogy a kurzor a pálya melyik pontjára mutat éppen.
        {
            double dhx, dhy;
            int x, y, h1x, h1y;
            ptCursor.X = Form1.MousePosition.X;
            ptCursor.Y = Form1.MousePosition.Y;
            ptCursor = PointToClient(ptCursor);
            x = ptCursor.X - spx - zoom / 2;
            y = ptCursor.Y - spy - zoom / 2;
            
            dhx = Convert.ToDouble(x) / Convert.ToDouble(zoom) + range;
            dhy = Convert.ToDouble(y) / Convert.ToDouble(zoom) + range;
            h1x = Convert.ToInt32(dhx);
            h1y = Convert.ToInt32(dhy);

            Lerakas(h1x,h1y); //A hely meghatározása után jön is a bábuk lerakása.
        }

        private void Lerakas(int hx, int hy) //Leellenőrzi ki lép éppen, és a helymeghatározás void által visszadott helyre bábut tesz.
        {
            if (hx >= 4 && hy >= 4 && hx <= 2 * range - 5 && hy <= 2 * range - 5)
            {
                if (player1turn == true && player1[hx, hy] == false && player2[hx, hy] == false)
                {
                    player1[hx, hy] = true;
                    DrawX(hx - range, hy - range);
                    wincheck(hx, hy);
                    player1turn = false;
                }
                else if (player1[hx, hy] == false && player2[hx, hy] == false)
                {
                    player2[hx, hy] = true;
                    DrawY(hx - range, hy - range);
                    wincheck(hx, hy);
                    player1turn = true;
                }
            }
        }

        private bool CM(int x, int y) //Check myself, leellenőrzi x,y helyén a pályának van e bábúja az aktális játékosnak.
        {
            if (player1turn == true)
                return player1[x, y];
            else return player2[x, y];
        }

        private bool CE(int x, int y) //Check enemy, leellenőrzi x,y helyén a pályának van e bábúja az aktális játékos ellenfelének.
        {
            if (player1turn == false)
                return player1[x, y];
            else return player2[x, y];
        }
        
        //Az előző két függvényt a gépi játékos lépésének meghatározásához írtam.

        private void BotlepesSzamitas() //Ez a void adja (adná) meg mit lépjen a gép.
        {
            int rx, ry;

            do //A gép alapból randomot lépjen, ha nem dob ki semmit az "esze" :D
            {
                Random m = new Random();
                rx = m.Next(95, 105);
                ry = m.Next(95, 105);
            } while (player1[rx,ry] == true || player2[rx,ry] == true);

            /*for (int x = 5; x <= 2 * range - 4; x++) 
                for (int y = 5; y <= 2 * range - 4; y++)
                {
                    int k = 0;
                    for (int i = x - 4; i <= x + 4; i++)
                        if (CM[i, y] == true)
                        {
                            k++;
                            if (k == 5) win(true, 1, i - x, x, y);
                        }
                        else k = 0;
                }*/ //Gyenge próbálkozás, kudarc jelei :)

            Lerakas(rx, ry); //A gép tesz, vagyis a lerakás meghívása a kidobott rx, ry helyre.
        }

        private void wincheck(int x, int y) //Itt ellenőrzi le a program, hogy valaki nyert-e
        {
            int k;
            if (player1turn == true) //Játékos1 nyert-e ellenőrzése:
            {
                k = 0;
                for (int i = x - 4; i <= x + 4; i++) //Vízszintesen kijött-e az 5 bábú
                    if (player1[i, y] == true)
                    {
                        k++;
                        if (k == 5) win(true, 1, i - x, x, y);
                    }
                    else k = 0;
                
                k = 0;
                for (int j = y - 4; j <= y + 4; j++) //Függőlegesen kijött-e az 5 bábú
                    if (player1[x, j] == true)
                    {
                        k++;
                        if (k == 5) win(true, 2, j - y, x, y);
                    }
                    else k = 0;

                k = 0;
                for (int i = x - 4; i <= x + 4; i++) //Balra-le keresztbe kijött-e az 5 bábú
                    if (player1[i, y + (i - x)] == true)
                    {
                        k++;
                        if (k == 5) win(true, 3, i - x, x, y);
                    }
                    else k = 0;

                k = 0;
                for (int j = y - 4; j <= y + 4; j++) //Jobbra-fel keresztbe kijött-e az 5 bábú
                    if (player1[x - (j - y), j] == true)
                    {
                        k++;
                        if (k == 5) win(true, 4, j - y, x, y);
                    }
                    else k = 0;
            }
            else //Játékos2 nyert-e ellenőrzése:
            {
                k = 0;
                for (int i = x - 4; i <= x + 4; i++) //Vízszintesen kijött-e az 5 bábú
                    if (player2[i, y] == true)
                    {
                        k++;
                        if (k == 5) win(false, 1, i - x, x, y);
                    }
                    else k = 0;

                k = 0;
                for (int j = y - 4; j <= y + 4; j++) //Függőlegesen kijött-e az 5 bábú
                    if (player2[x, j] == true)
                    {
                        k++;
                        if (k == 5) win(false, 2, j - y, x, y);
                    }
                    else k = 0;

                k = 0;
                for (int i = x - 4; i <= x + 4; i++) //Balra-le keresztbe kijött-e az 5 bábú
                    if (player2[i, y + (i - x)] == true)
                    {
                        k++;
                        if (k == 5) win(false, 3, i - x, x, y);
                    }
                    else k = 0;

                k = 0;
                for (int j = y - 4; j <= y + 4; j++) //Jobbra-fel keresztbe kijött-e az 5 bábú
                    if (player2[x - (j - y), j] == true)
                    {
                        k++;
                        if (k == 5) win(false, 4, j - y, x, y);
                    }
                    else k = 0;
            }
        }

        private void win(bool p1w,int ut, int poz, int x, int y) //Győzelem esetén a győztes bábuk áthúzása, melyek helyét az előző voidból (wincheck) kapja meg a void.
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Yellow, 8);
            if (p1w==true) p = new Pen(Color.Red, 8);
            if (p1w==false) p = new Pen(Color.Blue, 8);
            Point h1 = new Point(0,0), h2 = new Point(0,0);

            if (ut == 1)
            {
                h1.X = x + poz;
                h1.Y = y;
                h2.X = x + poz - 4;
                h2.Y = y;
            }
            if (ut == 2)
            {
                h1.X = x;
                h1.Y = y + poz;
                h2.X = x;
                h2.Y = y + poz - 4;
            }
            if (ut == 3)
            {
                h1.X = x + poz;
                h1.Y = y + poz;
                h2.X = x + poz - 4;
                h2.Y = y + poz - 4;
            }
            if (ut == 4)
            {
                h1.X = x - poz;
                h1.Y = y + poz;
                h2.X = x - poz + 4;
                h2.Y = y + poz - 4;
            }

            Point p1 = new Point(spx + zoom * (h1.X - range) + zoom / 2, spy + zoom * (h1.Y - range) + zoom / 2);
            Point p2 = new Point(spx + zoom * (h2.X - range) + zoom / 2, spy + zoom * (h2.Y - range) + zoom / 2);
            g.DrawLine(p, p1, p2);

            ingame = false; //Fut-e épp játék változó hamissá tétele.
        }
        
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoom = zoom + 10;
            if (zoom > 100) zoom = 100;
            if (ingame == true) Alap(spx, spy, zoom);
            // Új zoom paramét megadása + újrarajzolás.
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoom = zoom - 10;
            if (zoom < 10) zoom = 10;
            if (ingame == true) Alap(spx, spy, zoom);
            // Új zoom paraméter megadása + újrarajzolás.
        }

        private void alapZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoom = 30; spx = 200; spy = 200;
            if (ingame == true) Alap(spx, spy, zoom);
            // Alap zoom paraméter megadása + újrarajzolás.
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ingame == true)
                {
                    bool player1wasturn; //Elmenti ki lépett legutóbb.
                    player1wasturn = player1turn;
                    
                    Helymeghatarozas(); //Bal egérklikk esetén bábu lerakásának voidsorozatainak behívása.

                    if (boton == true && player1wasturn != player1turn) //Ha a gép be van kapcsolva + az emberi játékos lépett legutóbb meghívjuk a voidját:)
                    {
                        BotlepesSzamitas();
                    }
                }      
            }

            if (e.Button == MouseButtons.Right) //Jobb klikk esetén a mozgatási procedúra beindítása
            {
                isDrag = true;
                ptCursor.X = Form1.MousePosition.X;
                ptCursor.Y = Form1.MousePosition.Y;
                ptCursor = PointToClient(ptCursor);
                startPoint.X = ptCursor.X;
                startPoint.Y = ptCursor.Y;
                spxk = spx; spyk = spy;
                if (ingame == true) timer1.Enabled = true;
            }
        }
        
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrag == true) //Egér felengedése esetén, mozgatás és a vele járó folyamatos újrarajzolás kikapcsolása.
            {
                if (ingame == true) Alap(spx, spy, zoom);
                isDrag = false;
                timer1.Enabled = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0 && ingame == true) //Görgőzés esetén új zoomolási paraméter megadása + újrarajzolás.
            {
                zoom += e.Delta / 10;
                if (zoom < 10 ) zoom = 10;
                if (zoom > 100) zoom = 100;
                Alap(spx, spy, zoom);
            }
        }

        private void origoKijelzéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            origo = !origo;
            if (ingame == true) Alap(spx, spy, zoom); //Origo kijelzésének ki be kapcsolása
        }

        private void határkeretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keret = !keret;
            if (ingame == true) Alap(spx, spy, zoom); //Keret kijelzésének ki be kapcsolása
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Kilépés :)
        }

        private void timer1_Tick(object sender, EventArgs e) //Az állandó újrarajzolásért felelős timer mozgatás esetén.
        {
            ptCursor.X = Form1.MousePosition.X;
            ptCursor.Y = Form1.MousePosition.Y;
            ptCursor = PointToClient(ptCursor);
            endPoint.X = ptCursor.X;
            endPoint.Y = ptCursor.Y;
            spx = spxk - (startPoint.X - endPoint.X);
            spy = spyk - (startPoint.Y - endPoint.Y);
            // Elmozdulás kiszámítása és új origo helyének megadása

            if (ingame == true) Alap(spx, spy, zoom);
        }

        private void pveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boton = true; //Gépi játékos be
        }

        private void pvpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boton = false; //Gépi játékos ki
        }

        private void mentésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Játékállás mentése
            FileStream fout = new FileStream(FajlNev, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fout);
            for (int i=0;i<2*range;i++)
                for (int j = 0; j < 2 * range; j++)
                {
                    if (player1[i, j] == true)
                        bw.Write("X");
                    else if (player2[i, j] == true)
                        bw.Write("O");
                    else bw.Write(" ");
                }
            bw.Flush();
            bw.Close();
        }

        private void betöltésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Játékállás betöltése
            FileStream fin = new FileStream(FajlNev, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fin);
            string sz;
            int p1l=0, p2l=0;
            for (int i = 0; i < 2 * range; i++)
                for (int j = 0; j < 2 * range; j++)
                {
                    sz = br.ReadString();
                    if (sz == "X")
                    {
                        player1[i, j] = true;
                        p1l++;
                    }
                    else if (sz == "O")
                    {
                        player2[i, j] = true;
                        p2l++;
                    }
                    else
                    {
                        player1[i, j] = false;
                        player2[i, j] = false;
                    }
                }
            br.Close();
            ingame = true;
            zoom = 30; spx = 200; spy = 200;
            if (p1l > p2l)
                player1turn = false;
            else player1turn = true;
            Alap(spx, spy, zoom);
        }
  
    }
}