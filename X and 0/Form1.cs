using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

namespace X_and_0
{
    public partial class Xsi0 : Form
    {
        private int scoruljucatorului = 0;
        private int pvc = 0;
        private int tur = 1;
        private int b1, b2, b3, b4, b5, b6, b7, b8, b9 = 0;
        private int mutare = 1;
        private int p = 1, a = 2;
        private int oscores, xscores = 0;
        private int selectat = 0;
        private string parolajucator;
        public string tura()
        {
            mutare = mutare + 1;
            if (tur == 1)
            {
                tur = 2;
                return "X";
            }
            else if (tur == 2)
            {
                tur = 1;
                return "O";
            }
            return "";
        }
        public void resetjoc()
        {
            info.Text = "JOC IN DESFASURARE";
            info.ForeColor = Color.SteelBlue;
            unu.Text = doi.Text = trei.Text = patru.Text = cinci.Text = sase.Text = sapte.Text = opt.Text = noua.Text = "";
            unu.Enabled = doi.Enabled = trei.Enabled = patru.Enabled = cinci.Enabled = sase.Enabled = sapte.Enabled = opt.Enabled = noua.Enabled = true;
            unu.ForeColor = doi.ForeColor = trei.ForeColor = patru.ForeColor = cinci.ForeColor = sase.ForeColor = sapte.ForeColor = opt.ForeColor = noua.ForeColor = Color.DimGray;
            unu.FlatAppearance.BorderSize = doi.FlatAppearance.BorderSize = trei.FlatAppearance.BorderSize = patru.FlatAppearance.BorderSize = cinci.FlatAppearance.BorderSize = sase.FlatAppearance.BorderSize = sapte.FlatAppearance.BorderSize = opt.FlatAppearance.BorderSize = noua.FlatAppearance.BorderSize = 1;
            tur = 1;
            b1 = b2 = b3 = b4 = b5 = b6 = b7 = b8 = b9 = 0;
            mutare = 1;
            strategie = 0;
            win = 0;
            primulplayer();
        }
        public void primulplayer()
        {
            if (selectat == 1)
            {
                p = 1;
                a = 2;
                selectat = 2;
            }
            else
            {
                p = 2;
                a = 1;
                selectat = 1;
            }
           
        }
        int linie = 0;
        public int verificare()
        {
            if (b1 == b2 && b2 == b3 && b1 == a)
            {
                linie = 1;
                return 1;
            }
            if (b4 == b5 && b5 == b6 && b5 == a)
            {
                linie = 2;
                return 1;
            }
            if (b7 == b8 && b8 == b9 && b7 == a)
            {
                linie = 3;
                return 1;
            }
            if (b7 == b4 && b4 == b1 && b1 == a)
            {
                linie = 4;
                return 1;
            }
            if (b8 == b5 && b5 == b2 && b8 == a)
            {
                linie = 5;
                return 1;
            }
            if (b9 == b6 && b6 == b3 && b9 == a)
            {
                linie = 6;
                return 1;
            }
            if (b9 == b5 && b5 == b1 && b1 == a)
            {
                linie = 7;
                return 1;
            }
            if (b7 == b5 && b5 == b3 && b7 == a)
            {
                linie = 8;
                return 1;
            }
            if (b1 == b2 && b2 == b3 && b1 == p)
            {
                linie = 1;
                return 2;
            }
            if (b4 == b5 && b5 == b6 && b5 == p)
            {
                linie = 2;
                return 2;
            }
            if (b7 == b8 && b8 == b9 && b7 == p)
            {
                linie = 3;
                return 2;
            }
            if (b7 == b4 && b4 == b1 && b1 == p)
            {
                linie = 4;
                return 2;
            }
            if (b8 == b5 && b5 == b2 && b8 == p)
            {
                linie = 5;
                return 2;
            }
            if (b9 == b6 && b6 == b3 && b9 == p)
            {
                linie = 6;
                return 2;
            }
            if (b9 == b5 && b5 == b1 && b1 == p)
            {
                linie = 7;
                return 2;
            }
            if (b7 == b5 && b5 == b3 && b7 == p)
            {
                linie = 8;
                return 2;
            }
            return 0;
        }
        public void deseneazalinia(Color culoare)
        {
            if (linie == 1)
            {
                unu.ForeColor = doi.ForeColor = trei.ForeColor = culoare;
                unu.FlatAppearance.BorderSize = doi.FlatAppearance.BorderSize = trei.FlatAppearance.BorderSize = 2;
            }
            if (linie == 2)
            {
                patru.ForeColor = cinci.ForeColor = sase.ForeColor = culoare;
                patru.FlatAppearance.BorderSize = cinci.FlatAppearance.BorderSize = sase.FlatAppearance.BorderSize = 2;
            }

            if (linie == 3)
            {
                sapte.ForeColor = opt.ForeColor = noua.ForeColor = culoare;
                sapte.FlatAppearance.BorderSize = opt.FlatAppearance.BorderSize = noua.FlatAppearance.BorderSize = 2;
            }
            if (linie == 4)
            {
                unu.ForeColor = patru.ForeColor = sapte.ForeColor = culoare;
                unu.FlatAppearance.BorderSize = patru.FlatAppearance.BorderSize = sapte.FlatAppearance.BorderSize = 2;
            }
            if (linie == 5)
            {
                doi.ForeColor = cinci.ForeColor = opt.ForeColor = culoare;
                doi.FlatAppearance.BorderSize = cinci.FlatAppearance.BorderSize = opt.FlatAppearance.BorderSize = 2;
            }
            if (linie == 6)
            {
                trei.ForeColor = sase.ForeColor = noua.ForeColor = culoare;
                trei.FlatAppearance.BorderSize = sase.FlatAppearance.BorderSize = noua.FlatAppearance.BorderSize = 2;
            }
            if (linie == 7)
            {
                unu.ForeColor = cinci.ForeColor = noua.ForeColor = culoare;
                unu.FlatAppearance.BorderSize = cinci.FlatAppearance.BorderSize = noua.FlatAppearance.BorderSize = 2;
            }
            if (linie == 8)
            {
                sapte.ForeColor = cinci.ForeColor = trei.ForeColor = culoare;
                sapte.FlatAppearance.BorderSize = cinci.FlatAppearance.BorderSize = trei.FlatAppearance.BorderSize = 2;
            }
        }
        public Xsi0()
        {
            InitializeComponent();
        }
        int win = 0;
        public void teste()
        {
            if (verificare() == p)
            {
                info.Text = "X A CASTIGAT";
                info.ForeColor = Color.Crimson;
                deseneazalinia(Color.Crimson);
                if (p == 1 || xlabel.Text == "X")
                {
                    xscores += 1;
                    xscore.Text = Convert.ToString(xscores);
                }
                else
                {
                    oscores += 1;
                    oscore.Text = Convert.ToString(oscores);
                }
                scoruljucatorului = xscores - oscores;
                if (pvc == 1)
                    button1.Text = "Salveaza Scorul de:" + scoruljucatorului.ToString() + " puncte";
                win = 1;
                unu.Enabled = doi.Enabled = trei.Enabled = patru.Enabled = cinci.Enabled = sase.Enabled = sapte.Enabled = opt.Enabled = noua.Enabled = false;
            }
            if (verificare() == a)
            {
                info.Text = "0 A CASTIGAT";
                info.ForeColor = Color.DodgerBlue;
                deseneazalinia(Color.DodgerBlue);
                unu.Enabled = doi.Enabled = trei.Enabled = patru.Enabled = cinci.Enabled = sase.Enabled = sapte.Enabled = opt.Enabled = noua.Enabled = false;
                win = 1;
                if (p != 2 || xlabel.Text == "X")
                {
                    oscores += 1;
                    oscore.Text = Convert.ToString(oscores);
                }
                else
                {
                    xscores += 1;
                    xscore.Text = Convert.ToString(xscores);
                }
                scoruljucatorului = xscores - oscores;
                if (pvc == 1)
                    button1.Text = "Salveaza Scorul de:" + scoruljucatorului.ToString() + " puncte";
            }
        }

        public int nucastiga()
        {
            if (b1 == 0)
            {
                b1 = p;
                if (verificare() == 2)
                {
                    b1 = 0;
                    return 1;
                }
                else b1 = 0;
            }
            if (b2 == 0)
            {
                b2 = p;
                if (verificare() == 2)
                {
                    b2 = 0;
                    return 2;
                }
                else b2 = 0;
            }
            if (b3 == 0)
            {
                b3 = p;
                if (verificare() == 2)
                {
                    b3 = 0;
                    return 3;
                }
                else b3 = 0;
            }
            if (b4 == 0)
            {
                b4 = p;
                if (verificare() == 2)
                {
                    b4 = 0;
                    return 4;
                }
                else b4 = 0;
            }
            if (b5 == 0)
            {
                b5 = p;
                if (verificare() == 2)
                {
                    b5 = 0;
                    return 5;
                }
                else b5 = 0;
            }
            if (b6 == 0)
            {
                b6 = p;
                if (verificare() == 2)
                {
                    b6 = 0;
                    return 6;
                }
                else b6 = 0;
            }
            if (b7 == 0)
            {
                b7 = p;
                if (verificare() == 2)
                {
                    b7 = 0;
                    return 7;
                }
                else b7 = 0;
            }
            if (b8 == 0)
            {
                b8 = p;
                if (verificare() == 2)
                {
                    b8 = 0;
                    return 8;
                }
                else b8 = 0;
            }
            if (b9 == 0)
            {
                b9 = p;
                if (verificare() == 2)
                {
                    b9 = 0;
                    return 9;
                }
                else b9 = 0;
            }
            return 0;
        }
        int strategie = 0;
        public int gandireo()
        {
            if (mutare == 1)
            {
                return 5;
            }
            if (mutare == 4)
            {
                if (b2 == 1) { strategie = 2; return 9; }
                if (b4 == 1) { strategie = 4; return 9; }
                if (b6 == 1) { strategie = 6; return 1; }
                if (b8 == 1) { strategie = 8; return 1; }
                if (b1 == 1 || b3 == 1 || b7 == 1 || b9 == 1) { strategie = 1; }
            }
            if (strategie == 1)
            {

                if (nucastiga() == 0)
                {
                    if (b1 == a)
                    {
                        if (b1 == b7 && b4 == 0) return 4;
                        if (b1 == b4 && b7 == 0) return 7;
                        if (b1 == b3 && b2 == 0) return 2;
                        if (b1 == b2 && b3 == 0) return 3;
                        if (b1 == b9 && b5 == 0) return 5;
                        if (b1 == b5 && b9 == 0) return 9;
                    }
                    if (b2 == a)
                    {
                        if (b2 == b8 && b5 == 0) return 5;
                        if (b2 == b5 && b8 == 0) return 8;
                        if (b2 == b1 && b3 == 0) return 3;
                        if (b2 == b3 && b1 == 0) return 1;
                    }
                    if (b3 == a)
                    {
                        if (b3 == b1 && b2 == 0) return 2;
                        if (b3 == b2 && b1 == 0) return 1;
                        if (b3 == b9 && b6 == 0) return 6;
                        if (b3 == b6 && b9 == 0) return 9;
                        if (b3 == b7 && b5 == 0) return 5;
                        if (b3 == b5 && b7 == 0) return 7;
                    }
                    if (b4 == a)
                    {
                        if (b4 == b7 && b1 == 0) return 1;
                        if (b4 == b1 && b7 == 0) return 7;
                        if (b4 == b6 && b5 == 0) return 5;
                        if (b4 == b5 && b6 == 0) return 6;
                    }
                    if (b5 == a)
                    {
                        if (b5 == b4 && b6 == 0) return 6;
                        if (b5 == b6 && b4 == 0) return 4;
                        if (b5 == b8 && b2 == 0) return 2;
                        if (b5 == b2 && b8 == 0) return 8;
                        if (b5 == b1 && b9 == 0) return 9;
                        if (b5 == b9 && b1 == 0) return 1;
                        if (b5 == b3 && b7 == 0) return 7;
                        if (b5 == b7 && b3 == 0) return 3;
                    }
                    if (b6 == a)
                    {
                        if (b6 == b5 && b4 == 0) return 4;
                        if (b6 == b4 && b5 == 0) return 5;
                        if (b6 == b9 && b3 == 0) return 3;
                        if (b6 == b3 && b9 == 0) return 9;
                    }
                    if (b7 == a)
                    {
                        if (b7 == b5 && b3 == 0) return 3;
                        if (b7 == b3 && b5 == 0) return 5;
                        if (b7 == b1 && b4 == 0) return 4;
                        if (b7 == b4 && b1 == 0) return 1;
                        if (b7 == b8 && b9 == 0) return 9;
                        if (b7 == b9 && b8 == 0) return 8;
                    }
                    if (b8 == a)
                    {
                        if (b8 == b2 && b5 == 0) return 5;
                        if (b8 == b5 && b2 == 0) return 2;
                        if (b8 == b7 && b9 == 0) return 9;
                        if (b8 == b9 && b7 == 0) return 7;
                    }
                    if (b9 == a)
                    {
                        if (b9 == b7 && b8 == 0) return 8;
                        if (b9 == b8 && b7 == 0) return 7;
                        if (b9 == b3 && b6 == 0) return 6;
                        if (b9 == b6 && b3 == 0) return 3;
                        if (b9 == b5 && b1 == 0) return 1;
                        if (b9 == b1 && b5 == 0) return 5;
                    }
                    bool gasit = false;
                    int random = 0;
                    do
                    {
                        var rand = new System.Random();
                        random = rand.Next(1, 10);
                        if (random == 1 && b1 == 0) gasit = true;
                        if (random == 2 && b2 == 0) gasit = true;
                        if (random == 3 && b3 == 0) gasit = true;
                        if (random == 4 && b4 == 0) gasit = true;
                        if (random == 5 && b5 == 0) gasit = true;
                        if (random == 6 && b6 == 0) gasit = true;
                        if (random == 7 && b7 == 0) gasit = true;
                        if (random == 8 && b8 == 0) gasit = true;
                        if (random == 9 && b9 == 0) gasit = true;

                    } while (gasit == false);
                    mutare = mutare - 2;
                    return random;
                }
                else return nucastiga();
            }
            if (strategie == 2)
            {
                if (b1 == 0) return 1;
                if (b3 == 0) return 3;
                else
                {
                    if (b7 == 0) return 7;
                    else return 6;
                }
            }
            if (strategie == 4)
            {
                if (b1 == 0) return 1;
                if (b7 == 0) return 7;
                else
                {
                    if (b3 == 0) return 3;
                    else return 8;
                }
            }
            if (strategie == 6)
            {
                if (b9 == 0) return 9;
                if (b3 == 0) return 3;
                else
                {
                    if (b2 == 0) return 2;
                    else return 7;
                }
            }
            if (strategie == 8)
            {
                if (b9 == 0) return 9;
                if (b7 == 0) return 7;
                else
                {
                    if (b4 == 0) return 4;
                    else return 3;
                }
            }
            if (strategie == 1)
            {

            }
            return 0;
        }
        public int gandire()
        {
            if (mutare == 2)
            {
                if (b5 == 0) return 5;
                else
                {
                    int random;
                    var rand = new System.Random();
                    do
                    {
                        random = rand.Next(1, 9);
                    } while (random == 5);
                    return random;
                }
            }
            else
            {
                if (nucastiga() == 0)
                {
                    if (b1 == a)
                    {
                        if (b1 == b7 && b4 == 0) return 4;
                        if (b1 == b4 && b7 == 0) return 7;
                        if (b1 == b3 && b2 == 0) return 2;
                        if (b1 == b2 && b3 == 0) return 3;
                        if (b1 == b9 && b5 == 0) return 5;
                        if (b1 == b5 && b9 == 0) return 9;
                    }
                    if (b2 == a)
                    {
                        if (b2 == b8 && b5 == 0) return 5;
                        if (b2 == b5 && b8 == 0) return 8;
                        if (b2 == b1 && b3 == 0) return 3;
                        if (b2 == b3 && b1 == 0) return 1;
                    }
                    if (b3 == a)
                    {
                        if (b3 == b1 && b2 == 0) return 2;
                        if (b3 == b2 && b1 == 0) return 1;
                        if (b3 == b9 && b6 == 0) return 6;
                        if (b3 == b6 && b9 == 0) return 9;
                        if (b3 == b7 && b5 == 0) return 5;
                        if (b3 == b5 && b7 == 0) return 7;
                    }
                    if (b4 == a)
                    {
                        if (b4 == b7 && b1 == 0) return 1;
                        if (b4 == b1 && b7 == 0) return 7;
                        if (b4 == b6 && b5 == 0) return 5;
                        if (b4 == b5 && b6 == 0) return 6;
                    }
                    if (b5 == a)
                    {
                        if (b5 == b4 && b6 == 0) return 6;
                        if (b5 == b6 && b4 == 0) return 4;
                        if (b5 == b8 && b2 == 0) return 2;
                        if (b5 == b2 && b8 == 0) return 8;
                        if (b5 == b1 && b9 == 0) return 9;
                        if (b5 == b9 && b1 == 0) return 1;
                        if (b5 == b3 && b7 == 0) return 7;
                        if (b5 == b7 && b3 == 0) return 3;
                    }
                    if (b6 == a)
                    {
                        if (b6 == b5 && b4 == 0) return 4;
                        if (b6 == b4 && b5 == 0) return 5;
                        if (b6 == b9 && b3 == 0) return 3;
                        if (b6 == b3 && b9 == 0) return 9;
                    }
                    if (b7 == a)
                    {
                        if (b7 == b5 && b3 == 0) return 3;
                        if (b7 == b3 && b5 == 0) return 5;
                        if (b7 == b1 && b4 == 0) return 4;
                        if (b7 == b4 && b1 == 0) return 1;
                        if (b7 == b8 && b9 == 0) return 9;
                        if (b7 == b9 && b8 == 0) return 8;
                    }
                    if (b8 == a)
                    {
                        if (b8 == b2 && b5 == 0) return 5;
                        if (b8 == b5 && b2 == 0) return 2;
                        if (b8 == b7 && b9 == 0) return 9;
                        if (b8 == b9 && b7 == 0) return 7;
                    }
                    if (b9 == a)
                    {
                        if (b9 == b7 && b8 == 0) return 8;
                        if (b9 == b8 && b7 == 0) return 7;
                        if (b9 == b3 && b6 == 0) return 6;
                        if (b9 == b6 && b3 == 0) return 3;
                        if (b9 == b5 && b1 == 0) return 1;
                        if (b9 == b1 && b5 == 0) return 5;
                    }
                    bool gasit = false;
                    int random;
                    do
                    {
                        var rand = new System.Random();
                        random = rand.Next(1, 9);
                        if (random == 1 && b1 == 0) gasit = true;
                        if (random == 2 && b2 == 0) gasit = true;
                        if (random == 3 && b3 == 0) gasit = true;
                        if (random == 4 && b4 == 0) gasit = true;
                        if (random == 5 && b5 == 0) gasit = true;
                        if (random == 6 && b6 == 0) gasit = true;
                        if (random == 7 && b7 == 0) gasit = true;
                        if (random == 8 && b8 == 0) gasit = true;
                        if (random == 9 && b9 == 0) gasit = true;

                    } while (gasit == false);
                    return random;
                }
                else
                {
                    return nucastiga();
                }

            }
        }
        public void miscare()
        {
            int x;
            if (p == 1)
            {
                x = gandire();
            }
            else
            {
                x = gandireo();
            }
            mutare = mutare + 1;
            if (x == 1)
            {
                unu.Enabled = false;
                unu.Text = tura();
                b1 = tur;
            }
            if (x == 2)
            {
                doi.Enabled = false;
                doi.Text = tura();
                b2 = tur;
            }
            if (x == 3)
            {
                trei.Enabled = false;
                trei.Text = tura();
                b3 = tur;
            }
            if (x == 4)
            {
                patru.Enabled = false;
                patru.Text = tura();
                b4 = tur;
            }
            if (x == 5)
            {
                cinci.Enabled = false;
                cinci.Text = tura();
                b5 = tur;
            }
            if (x == 6)
            {
                sase.Enabled = false;
                sase.Text = tura();
                b6 = tur;
            }
            if (x == 7)
            {
                sapte.Enabled = false;
                sapte.Text = tura();
                b7 = tur;
            }
            if (x == 8)
            {
                opt.Enabled = false;
                opt.Text = tura();
                b8 = tur;
            }
            if (x == 9)
            {
                noua.Enabled = false;
                noua.Text = tura();
                b9 = tur;
            }
        }
        public void mutareAI()
        {
            miscare();
            teste();
        }
        public void remizasaumutare()
        {
            teste();
            if (tur == a && mutare < 13 && win == 0 && pvc == 1)
            {
                System.Threading.Thread.Sleep(250);
                mutareAI();
            }
            if (mutare > 13 || (mutare > 10 && p == 2 && win == 0) || (mutare > 9 && pvc == 0 && win == 0))
            {
                info.Text = "REMIZA";
                info.ForeColor = Color.SeaGreen;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            unu.Text = tura();
            unu.Enabled = false;
            b1 = tur;
            remizasaumutare();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doi.Text = tura();
            doi.Enabled = false;
            b2 = tur;
            remizasaumutare();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            jocnou.Enabled = true;
            jocnou.Height = 75;
            selectat = 1;
            a = 2;
            p = 1;
            initializarepentrumeniu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            jocnou.Enabled = true;
            jocnou.Height = 75;
            selectat = 2;
            a = 1;
            p = 2;
            initializarepentrumeniu();
        }
        public void initializarepentrumeniu()
        {
            unu.Text = doi.Text = trei.Text = patru.Text = cinci.Text = sase.Text = sapte.Text = opt.Text = noua.Text = "";
            unu.Enabled = doi.Enabled = trei.Enabled = patru.Enabled = cinci.Enabled = sase.Enabled = sapte.Enabled = opt.Enabled = noua.Enabled = false;
            unu.ForeColor = doi.ForeColor = trei.ForeColor = patru.ForeColor = cinci.ForeColor = sase.ForeColor = sapte.ForeColor = opt.ForeColor = noua.ForeColor = Color.DimGray;
            unu.FlatAppearance.BorderSize = doi.FlatAppearance.BorderSize = trei.FlatAppearance.BorderSize = patru.FlatAppearance.BorderSize = cinci.FlatAppearance.BorderSize = sase.FlatAppearance.BorderSize = sapte.FlatAppearance.BorderSize = opt.FlatAppearance.BorderSize = noua.FlatAppearance.BorderSize = 1;
            info.ForeColor = Color.SteelBlue;
        }
        private void jucatorContraCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scoruljucatorului = 0;
            numelejucator = numejucator.Text;
            labelnume.Show();
            numejucator.Show();
            parola.Show();
            labelparola.Show();
            trimitenume.Show();
            pictureBox1.Show();
            resetscor();
            xlabel.Text = "P";
            olabel.Text = "C";
            pvc = 1;
            jocnou.Enabled = false;
            initializarepentrumeniu();
            info.Text = "ALEGE-TI ROLUL";
            pvm.Text = "Alege alt cont";
            numejucator.Text = "";
            parola.Text = "";
        }
        public void resetscor()
        {
            xscores = 0;
            oscores = 0;
            xscore.Text = "0";
            oscore.Text = "0";
            scoruljucatorului = 0;
            button1.Text = "Salveaza Scorul";
        }
        private void jucatorContraJucatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetscor();
            xlabel.Text = "X";
            olabel.Text = "0";
            button1.Enabled = false;
            pvc = 0;
            jocnou.Enabled = true;
            initializarepentrumeniu();
            info.Text = "PORNESTE JOCUL";
            pvm.Text = "Jucator contra Calculator";
            labelnume.Hide();
            numejucator.Hide();
            parola.Hide();
            labelparola.Hide();
            trimitenume.Hide();
            pictureBox1.Hide();
        }

        private void informatiiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Acest joc foloseste inteligenta artificiala . Aceasta consta in 3 etape de gandire . Gandirea agresiva , Gandirea defensiva si Gandirea pasiva." + Environment.NewLine + "Jocul foloseste si o baza de date online realizata printr-un database engine numit MYSQL folosind website-ul www.freemysqlhosting.net si limbajul SQL.");
        }

        private void top10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
        string numelejucator;
        private void trimitenume_Click(object sender, EventArgs e)
        {
            parolainfo.Visible = false;
            jocnou.Height = 35;
            //Conectarea la baza de date
            string server, database, uid, password;
            server = "sql8.freemysqlhosting.net";
            database = "sql8172470";
            uid = "sql8172470";
            password = "vZRDwsEz8J";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            //Conectarea la baza de date

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand command = con.CreateCommand();
            command.CommandText = " SELECT COUNT(*) from Top15 where Nume like '"+ numejucator.Text.Trim() +"'";
            con.Open();
            MySqlCommand selectData;
            selectData = con.CreateCommand();
            selectData.CommandText = "SELECT Parola FROM Top15 Where Nume='" + numejucator.Text.Trim() + "'";
            MySqlDataReader rdr = selectData.ExecuteReader();
            string Parola;
            if (rdr.Read())
            {
                Parola = rdr["Parola"].ToString(); 
            } 
            else
            {
                Parola = "23Sxefr3o9%$@d";
            }
            rdr.Close();
            int userCount = Convert.ToInt32(command.ExecuteScalar());

            if (numejucator.Text.Trim() != "")
            {
                if (userCount>0)
                {
                    if (Parola == parola.Text.Trim())
                    {
                        MessageBox.Show("Ai accesat cu succes acest nume !");
                        button1.Enabled = true;
                        numelejucator = numejucator.Text.Trim();
                        labelnume.Hide();
                        numejucator.Hide();
                        trimitenume.Hide();
                        pictureBox1.Hide();
                        labelparola.Hide();
                        parola.Hide();
                    }
                    else
                        MessageBox.Show("Ai gresit parola!");
                }
                else
                {
                    button1.Enabled = true;
                    numelejucator = numejucator.Text.Trim();
                    labelnume.Hide();
                    numejucator.Hide();
                    trimitenume.Hide();
                    pictureBox1.Hide();
                    labelparola.Hide();
                    parola.Hide();
                    parolajucator = parola.Text.Trim();
                    MessageBox.Show("Contul a fost creat cu succes!");
                }
            }
            else MessageBox.Show("Ai nevoie de un nume daca vrei sa joci !");
        }
        private void Xsi0_Load(object sender, EventArgs e)
        {
            numelejucator = numejucator.Text;
            labelnume.Hide();
            numejucator.Hide();
            trimitenume.Hide();
            pictureBox1.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (scoruljucatorului > 0)
            {
                //Conectarea la baza de date
                string server, database, uid, password;
                server = "sql8.freemysqlhosting.net";
                database = "sql8172470";
                uid = "sql8172470";
                password = "vZRDwsEz8J";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                //Conectarea la baza de date

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand command = con.CreateCommand();
                con.Open();
                command.CommandText = " SELECT COUNT(*) from Top15 where Nume like '" + numelejucator + "'";
                int userCount = Convert.ToInt32(command.ExecuteScalar());

                if (userCount > 0)
                {
                    MySqlCommand selectData;
                    selectData = con.CreateCommand();
                    selectData.CommandText = "SELECT Scor FROM Top15 Where Nume='" + numelejucator + "'";
                    MySqlDataReader rdr = selectData.ExecuteReader();
                    rdr.Read();
                    int Scor = Convert.ToInt32(rdr["Scor"]);
                    rdr.Close();
                    if (Scor <= scoruljucatorului) {
                        MessageBox.Show("Scorul a fost schimbat");
                        command.CommandText = "UPDATE Top15 SET Scor=" + scoruljucatorului + " WHERE Nume='" + numelejucator + "'";
                        command.ExecuteNonQuery();
                    }
                    else MessageBox.Show("Ai deja un scor mai bun!");
                }
                else
                {
                    MessageBox.Show("Scorul a fost adaugat");
                    command.CommandText = "INSERT INTO Top15 (Nume,Scor,Parola) VALUES ('" + numelejucator + "'," + scoruljucatorului.ToString() + ",'" + parolajucator + "')";
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
            else MessageBox.Show("Nu ai un scor destul de bun!");
        }

        private void parola_MouseClick(object sender, MouseEventArgs e)
        {
            parolainfo.Visible = true;
        }

        private void parola_TextChanged(object sender, EventArgs e)
        {
            parolainfo.Visible = false;
        }

        private void parolainfo_Click(object sender, EventArgs e)
        {
            parolainfo.Visible = false;
        }

        private void Optiuni_Click(object sender, EventArgs e)
        {

        }

        private void resetarescor_Click(object sender, EventArgs e)
        {
            resetscor();
        }

        private void jocnou_Click(object sender, EventArgs e)
        {
            resetjoc();
            if (p == 2 && pvc == 1)
            {
                mutareAI();
            }
        }
        private void info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scopul meu este sa arat statusul jocului");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trei.Text = tura();
            trei.Enabled = false;
            b3 = tur;
            remizasaumutare();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            patru.Text = tura();
            patru.Enabled = false;
            b4 = tur;
            remizasaumutare();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cinci.Text = tura();
            cinci.Enabled = false;
            b5 = tur;
            remizasaumutare();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sase.Text = tura();
            sase.Enabled = false;
            b6 = tur;
            remizasaumutare();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sapte.Text = tura();
            sapte.Enabled = false;
            b7 = tur;
            remizasaumutare();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            opt.Text = tura();
            opt.Enabled = false;
            b8 = tur;
            remizasaumutare();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            noua.Text = tura();
            noua.Enabled = false;
            b9 = tur;
            remizasaumutare();
        }

    }
}
