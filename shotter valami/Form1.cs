using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace shotter_valami
{
    public partial class Form1 : Form
    {
        public Model p;
        public Form1()
        {
            InitializeComponent();
            p = new Model();
            Pers h = new Pers();
            Timer a = new Timer();
            PictureBox newgame = new PictureBox();
            PictureBox loadgame = new PictureBox();
            PictureBox exitgame = new PictureBox();
            PictureBox tutorial = new PictureBox();
            newgame.Image = new Bitmap("new game.jpg");
            loadgame.Image = new Bitmap("load game.jpg");
            exitgame.Image = new Bitmap("exit.jpg");
            tutorial.Image = new Bitmap("tutorial.jpg");
            newgame.SizeMode = PictureBoxSizeMode.StretchImage;
            loadgame.SizeMode = PictureBoxSizeMode.StretchImage;
            exitgame.SizeMode = PictureBoxSizeMode.StretchImage;
            tutorial.SizeMode = PictureBoxSizeMode.StretchImage;
            newgame.Location = new Point(Convert.ToInt32(this.Width * 0.4), Convert.ToInt32(this.Height * 0.05));
            loadgame.Location = new Point(Convert.ToInt32(this.Width * 0.4), Convert.ToInt32(this.Height * 0.30));
            exitgame.Location = new Point(Convert.ToInt32(this.Width * 0.4), Convert.ToInt32(this.Height * 0.55));
            tutorial.Location = new Point(Convert.ToInt32(this.Width * 0.05), Convert.ToInt32(this.Height * 0.05));
            newgame.Size = new Size(Convert.ToInt32(this.Width * 0.55), Convert.ToInt32(this.Height * 0.2));
            loadgame.Size = new Size(Convert.ToInt32(this.Width * 0.55), Convert.ToInt32(this.Height * 0.2));
            exitgame.Size = new Size(Convert.ToInt32(this.Width * 0.55), Convert.ToInt32(this.Height * 0.2));
            tutorial.Size = new Size(Convert.ToInt32(this.Width * 0.3), Convert.ToInt32(this.Height * 0.7));
            this.Controls.Add(newgame);
            this.Controls.Add(loadgame);
            this.Controls.Add(exitgame);
            this.Controls.Add(tutorial);
            PictureBox hatter = new PictureBox();
            Bitmap kep = new Bitmap("hattermenu2.jpg");
            hatter.Image = ((Image)(kep));
            hatter.Location = new Point(0 - Convert.ToInt32((this.Width - (Cursor.Position.X - this.Location.X)) * 0.2), 0 - Convert.ToInt32((this.Height - Cursor.Position.Y - this.Location.Y) * 0.2));
            hatter.Size = new Size(Convert.ToInt32(this.Width * 1.2), Convert.ToInt32(this.Height * 1.2));
            hatter.SizeMode = PictureBoxSizeMode.StretchImage;
            hatter.TabIndex = 0;
            hatter.TabStop = false;
            this.Controls.Add(hatter);
            a.Start();
            a.Interval = 15;
            a.Tick += (s, e) =>
                {
                    hatter.Location = new Point(0 - Convert.ToInt32((this.Width - (Cursor.Position.X - this.Location.X)) * 0.2), 0 - Convert.ToInt32((this.Height - Cursor.Position.Y - this.Location.Y) * 0.2));
                    hatter.Size = new Size(Convert.ToInt32(this.Width * 1.2), Convert.ToInt32(this.Height * 1.2));
                };
            this.SizeChanged += (s, e) =>
              {
                  newgame.Location = new Point(Convert.ToInt32(this.Width * 0.4), Convert.ToInt32(this.Height * 0.05));
                  loadgame.Location = new Point(Convert.ToInt32(this.Width * 0.4), Convert.ToInt32(this.Height * 0.30));
                  exitgame.Location = new Point(Convert.ToInt32(this.Width * 0.4), Convert.ToInt32(this.Height * 0.55));
                  tutorial.Location = new Point(Convert.ToInt32(this.Width * 0.05), Convert.ToInt32(this.Height * 0.05));
                  newgame.Size = new Size(Convert.ToInt32(this.Width * 0.55), Convert.ToInt32(this.Height * 0.2));
                  loadgame.Size = new Size(Convert.ToInt32(this.Width * 0.55), Convert.ToInt32(this.Height * 0.2));
                  exitgame.Size = new Size(Convert.ToInt32(this.Width * 0.55), Convert.ToInt32(this.Height * 0.2));
                  tutorial.Size = new Size(Convert.ToInt32(this.Width * 0.3), Convert.ToInt32(this.Height * 0.7));
              };
            exitgame.Click += (s, e) =>
              {
                  Application.Exit();
              };
            newgame.Click += (s, e) =>
              {
                  a.Stop();
                  p.Generate();
                  Game();
              };
            loadgame.Click += (s, e) =>
            {
                MessageBox.Show(h.Import() + " wave survived");
            };
        }
        public void Game()
        {
            int vawe = 0;
            bool first = false;
            this.Controls.Clear();
            this.BackColor = Color.DarkGray;
            Timer b = new Timer();
            b.Interval = 16;
            p.wsl = (this.Width - this.Height) / 2;
            List<PictureBox> map = new List<PictureBox>();
            for (int i = 0; i < p.mapp.Count(); i++)
            {
                PictureBox item = new PictureBox();
                map.Add(item);
                map[i].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (p.mapp[i][0] + p.pp[0])), Convert.ToInt32(this.Height * (p.mapp[i][1] + p.pp[1])));
                map[i].Size = new Size(Convert.ToInt32(this.Height * (p.maps[i][0])), Convert.ToInt32(this.Height * (p.maps[i][1])));
                map[i].BackColor = Color.White;
                this.Controls.Add(map[i]);
            }
            PictureBox[,] health = new PictureBox[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox hell = new PictureBox();
                    health[i, j] = hell;
                    health[i, j].Size = new Size(Convert.ToInt32(this.Height * 0.03), Convert.ToInt32(this.Height * 0.03));
                    health[i, j].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (0.44 + i * 0.028)), Convert.ToInt32(this.Height * (0.6 + j * 0.028)));
                    health[i, j].BackColor = Color.White;
                    this.Controls.Add(health[i, j]);
                }
            }
            List<PictureBox> Balls = new List<PictureBox>();
            PictureBox player = new PictureBox();
            player.Location = new Point(Convert.ToInt32(p.wsl + this.Height * 0.44), Convert.ToInt32(this.Height * 0.6));
            player.Size = new Size(Convert.ToInt32(this.Height * 4 * 0.028), Convert.ToInt32(this.Height * 4 * 0.028));
            player.BackColor = Color.Black;
            this.Controls.Add(player);
            List<PictureBox> Enemies = new List<PictureBox>();

            this.Resize += (s, e) =>
              {
                  p.wsl = (this.Width - this.Height) / 2;
                  for (int i = 0; i < 4; i++)
                  {
                      for (int j = 0; j < 4; j++)
                      {
                          health[i, j].Size = new Size(Convert.ToInt32(this.Height * 0.03), Convert.ToInt32(this.Height * 0.03));
                          health[i, j].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (0.44 + i * 0.028)), Convert.ToInt32(this.Height * (0.6 + j * 0.028)));
                      }
                  }
                  player.Location = new Point(Convert.ToInt32(p.wsl + this.Height * 0.44), Convert.ToInt32(this.Height * 0.6));
                  player.Size = new Size(Convert.ToInt32(this.Height * 4 * 0.028), Convert.ToInt32(this.Height * 4 * 0.028));
                  for (int i = 0; i < p.mapp.Count(); i++)
                  {
                      map[i].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (p.mapp[i][0] + p.pp[0])), Convert.ToInt32(this.Height * (p.mapp[i][1] + p.pp[1])));
                      map[i].Size = new Size(Convert.ToInt32(this.Height * (p.maps[i][0])), Convert.ToInt32(this.Height * (p.maps[i][1])));
                  }
                  for (int i = 0; i < Balls.Count(); i++)
                  {
                      Balls[Balls.Count() - 1].Size = new Size(Convert.ToInt32(this.Height * 0.03), Convert.ToInt32(this.Height * 0.03));
                      Balls[Balls.Count() - 1].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (p.myballs[i][0] + p.pp[0])), Convert.ToInt32(this.Height * (p.myballs[i][1] + p.pp[1])));
                  }
                  for (int i = 0; i < Enemies.Count(); i++)
                  {
                      GraphicsPath gp = new GraphicsPath();
                      gp.AddEllipse(new Rectangle(0, 0, Enemies[i].Width - 1, Enemies[i].Height - 1));
                      Enemies[i].Region = new Region(gp);
                      Enemies[i].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (p.enemiesp[i][0] + p.pp[0])), Convert.ToInt32(this.Height * (p.enemiesp[Enemies.Count() - 1][1] + p.pp[1])));
                      Enemies[i].Size = new Size(player.Width, player.Height);
                  }
              };
            int fstrike = 0;
            KeyDown += (s, e) =>
              {
                  if (first == false)
                  {
                      b.Start();
                      FRM();
                      PictureBox bov = new PictureBox();
                      PictureBox bov2 = new PictureBox();
                      map.Add(bov);
                      map.Add(bov2);
                      map[map.Count() - 1].BackColor = Color.White;
                      map[map.Count() - 2].BackColor = Color.White;
                      map[map.Count() - 1].Location = new Point(-10, -10);
                      map[map.Count() - 2].Location = new Point(-10, -10);
                      map[map.Count() - 2].Size = new Size(1, 1);
                      map[map.Count() - 1].Size = new Size(1, 1);
                      this.Controls.Add(map[map.Count() - 1]);
                      this.Controls.Add(map[map.Count() - 2]);
                      first = true;
                  }
              };
            bool szun = false;
            MouseClick += (s, e) =>
              {
                  if(szun==false)
                  {
                  PictureBox ball = new PictureBox();
                  double[] balp = new double[2] { player.Location.X / this.Height - p.pp[0] + 0.47, player.Location.Y / this.Height - p.pp[1] + 0.6 };
                  double[] vect = new double[2] { (Cursor.Position.X - balp[0] - this.Location.X - this.Width / 2) / this.Width / 4, (Cursor.Position.Y - this.Location.Y - balp[1] - this.Height / 2) / this.Height / 4 };
                  p.lifetime.Add(0);
                  p.myballv.Add(vect);
                  p.myballs.Add(balp);
                  Balls.Add(ball);
                  Balls[Balls.Count() - 1].Size = new Size(Convert.ToInt32(this.Height * 0.03), Convert.ToInt32(this.Height * 0.03));
                  Balls[Balls.Count() - 1].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (p.myballs[Balls.Count() - 1][0] + p.pp[0])), Convert.ToInt32(this.Height * (p.myballs[Balls.Count() - 1][1] + p.pp[1])));
                  Balls[Balls.Count() - 1].BackColor = Color.White;
                  this.Controls.Add(Balls[Balls.Count() - 1]);
                  Random rand = new Random();
                  int szam = rand.Next(0, p.lifeh.Count() - 1);
                  health[Convert.ToInt32(p.lifeh[szam] / 10), p.lifeh[szam] % 10].BackColor = Color.LightGray;
                  p.lifeh.Remove(p.lifeh[szam]);
                  if (p.lifeh.Count() == 0)
                  {
                      b.Stop();
                      MessageBox.Show("Game over");
                      Pers h = new Pers();
                      h.Export(vawe);
                      Application.Restart();
                  }
                  }
              };
            bool up = false;
            bool lef = false;
            bool righ = false;
            bool djump = false;
            bool down = false;
            KeyDown += (s, e) =>
              {
                  if (e.KeyCode == Keys.A)
                  {
                      lef = true;
                  }
              };
            KeyDown += (s, e) =>
              {
                  if (e.KeyCode == Keys.W)
                  {
                      up = true;
                  }
              };
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.S)
                {
                    down = true;
                }
            };
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.W && djump == true)
                {
                    djump = false;
                    p.ip[1] += 0.015;
                }
            };
            KeyDown += (s, e) =>
              {
                  if (e.KeyCode == Keys.Escape)
                  {
                      if(szun==false)
                      {
                          b.Stop();
                          szun = true;
                          this.BackColor = Color.Black;
                      }
                      else
                      {
                          b.Start();
                          szun = false;
                          this.BackColor = Color.DarkGray;
                      }
                  }
              };
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.D)
                {
                    righ = true;
                }
            };
            KeyUp += (s, e) =>
              {
                  if (e.KeyCode == Keys.W)
                  {
                      up = false;
                  }
                  if (e.KeyCode == Keys.A)
                  {
                      lef = false;
                  }
                  if (e.KeyCode == Keys.D)
                  {
                      righ = false;
                  }
                  if(e.KeyCode==Keys.S)
                  {
                      down = false;
                  }
              };
            b.Tick += (s, e) =>
              {
                  if(first==true)
                  {
                      fstrike++;
                  }
                  if (Enemies.Count()==0 && fstrike>150)
                  {
                      FRM();
                      PictureBox bov = new PictureBox();
                      PictureBox bov2 = new PictureBox();
                      map.Add(bov);
                      map.Add(bov2);
                      map[map.Count() - 1].BackColor = Color.White;
                      map[map.Count() - 2].BackColor = Color.White;
                      map[map.Count() - 1].Location = new Point(-10, -10);
                      map[map.Count() - 2].Location = new Point(-10, -10);
                      map[map.Count() - 2].Size = new Size(1, 1);
                      map[map.Count() - 1].Size = new Size(1, 1);
                      this.Controls.Add(map[map.Count() - 1]);
                      this.Controls.Add(map[map.Count() - 2]);
                      for (int i = 0; i < vawe*7; i++)
                      {
                          PictureBox Enemy = new PictureBox();
                          Enemies.Add(Enemy);
                          p.GenEnemies();
                          Enemies[Enemies.Count() - 1].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (p.enemiesp[Enemies.Count() - 1][0] + p.pp[0])), Convert.ToInt32(this.Height * (p.enemiesp[Enemies.Count() - 1][1] + p.pp[1])));
                          Enemies[Enemies.Count() - 1].Size = new Size(player.Width, player.Height);
                          Enemies[Enemies.Count() - 1].BackColor = Color.White;
                          GraphicsPath gp = new GraphicsPath();
                          gp.AddEllipse(new Rectangle(0, 0, Enemies[Enemies.Count() - 1].Width - 1, Enemies[Enemies.Count() - 1].Height - 1));
                          Enemies[Enemies.Count() - 1].Region = new Region(gp);
                          this.Controls.Add(Enemies[Enemies.Count() - 1]);
                      }
                      vawe++;
                      fstrike = 0;
                  }
                  for (int j = 0; j < Enemies.Count(); j++)
                  {
                      p.enemiesi[j][1] -= 0.001;
                      if (player.Location.X > Enemies[j].Location.X)
                      {
                          p.enemiesi[j][0] = vawe*-0.007;
                      }
                      if (player.Location.X < Enemies[j].Location.X)
                      {
                          p.enemiesi[j][0] = vawe * 0.007;
                      }
                      if (Enemies[j].Bounds.IntersectsWith(player.Bounds))
                      {
                          Random rand = new Random();
                          int szam = rand.Next(0, p.lifeh.Count() - 1);
                          health[Convert.ToInt32(p.lifeh[szam] / 10), p.lifeh[szam] % 10].BackColor = Color.LightGray;
                          p.lifeh.Remove(p.lifeh[szam]);
                          if (p.lifeh.Count() == 0)
                          {
                              b.Stop();
                              MessageBox.Show("Game over");
                              Application.Restart();
                          }
                          this.Controls.Remove(Enemies[j]);
                          Enemies.Remove(Enemies[j]);
                          p.enemiesi.Remove(p.enemiesi[j]);
                          p.enemiesp.Remove(p.enemiesp[j]);
                      }
                  }
                  p.ip[1] += -0.001;
                  for (int j = 0; j < Balls.Count(); j++)
                  {
                      p.myballv[j][1] += 0.001;
                      p.myballs[j][0] += p.myballv[j][0];
                      p.myballs[j][1] += p.myballv[j][1];
                      Balls[j].Size = new Size(Convert.ToInt32(this.Height * 0.03), Convert.ToInt32(this.Height * 0.03));
                      Balls[j].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (p.myballs[j][0] + p.pp[0])), Convert.ToInt32(this.Height * (p.myballs[j][1] + p.pp[1])));
                      for (int i = 0; i < p.mapp.Count(); i++)
                      {
                          if (map[i].Bounds.IntersectsWith(Balls[j].Bounds))
                          {
                              if (map[i].Location.X + Balls[j].Height * 3 < Balls[j].Location.X + Balls[j].Width && map[i].Location.X + map[i].Width - Balls[j].Height * 3 > Balls[j].Location.X && map[i].Location.Y - Balls[j].Height * 3 < Balls[j].Location.Y + Balls[j].Height)
                              {
                                  p.myballv[j][1] = -p.myballv[j][0] / 2;
                                  p.myballv[j][0] = p.myballv[j][0] * 0.9;
                              }
                              else if (map[i].Location.X + Balls[j].Width * 3 > Balls[j].Location.X + Balls[j].Width && map[i].Location.Y < Balls[j].Location.Y + Balls[j].Height && map[i].Location.Y + map[i].Height > Balls[j].Location.Y)
                              {
                                  p.myballv[j][0] = -p.myballv[j][1] / 2;
                              }
                              else if (map[i].Location.X + map[i].Width - Balls[j].Width * 3 < Balls[j].Location.X && map[i].Location.Y < Balls[j].Location.Y + Balls[j].Height && map[i].Location.Y + map[i].Height > Balls[j].Location.Y)
                              {
                                  p.myballv[j][0] = -p.myballv[j][1] / 2;
                              }
                              else
                              {
                                  p.myballv[j][1] = -p.myballv[j][0] / 2;
                                  p.myballv[j][0] = p.myballv[j][0] * 0.9;
                              }
                          }
                      }
                      if (player.Bounds.IntersectsWith(Balls[j].Bounds) && p.lifetime[j] > 20)
                      {
                          bool log = false;
                          for (int k = 0; k < 4; k++)
                          {
                              for (int l = 0; l < 4; l++)
                              {
                                  if (health[k, l].BackColor == Color.LightGray && log == false)
                                  {
                                      log = true;
                                      health[k, l].BackColor = Color.White;
                                      p.lifeh.Add(k * 10 + l);
                                  }
                              }
                          }
                          p.lifetime[j] = 1000;
                      }

                      for (int i = 0; i < Enemies.Count(); i++)
                      {
                          if (Enemies[i].Bounds.IntersectsWith(Balls[j].Bounds))
                          {
                              this.Controls.Remove(Enemies[i]);
                              Enemies.Remove(Enemies[i]);
                              p.enemiesi.Remove(p.enemiesi[i]);
                              p.enemiesp.Remove(p.enemiesp[i]);
                              bool log = false;
                              bool log2 = false;
                              for (int k = 0; k < 4; k++)
                              {
                                  for (int l = 0; l < 4; l++)
                                  {
                                      if (health[k, l].BackColor == Color.LightGray && (log == false||log2==false))
                                      {
                                          health[k, l].BackColor = Color.White;
                                          p.lifeh.Add(k * 10 + l);
                                          if(log==true)
                                          {
                                              log2 = true;
                                          }
                                          log = true;
                                      }
                                  }
                              }
                              p.lifetime[j] = 1000;
                          }
                      }
                      if (p.lifetime[j] == 1000)
                      {
                          this.Controls.Remove(Balls[j]);
                          Balls.Remove(Balls[j]);
                          p.myballs.Remove(p.myballs[j]);
                          p.myballv.Remove(p.myballv[j]);
                          p.lifetime.Remove(p.lifetime[j]);
                      }
                      else
                      {
                          p.lifetime[j]++;
                      }
                  }
                  if (lef == true)
                  {
                      p.ip[0] = 0.03;
                  }
                  else if (righ == true)
                  {
                      p.ip[0] = -0.03;
                  }
                  else
                  {
                      p.ip[0] = 0;
                  }
                  for (int i = 0; i < p.mapp.Count(); i++)
                  {
                      map[i].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (p.mapp[i][0] + p.pp[0])), Convert.ToInt32(this.Height * (p.mapp[i][1] + p.pp[1])));
                      map[i].Size = new Size(Convert.ToInt32(this.Height * (p.maps[i][0])), Convert.ToInt32(this.Height * (p.maps[i][1])));
                      if (map[i].Bounds.IntersectsWith(player.Bounds))
                      {
                          if (map[i].Location.X + player.Height * 0.2 < player.Location.X + player.Width && map[i].Location.X + map[i].Width - player.Height * 0.2 > player.Location.X)
                          {
                              if (up == true)
                              {
                                  p.ip[1] = 0.02;
                                  djump = true;
                              }
                              if (p.ip[1] < 0)
                              {
                                  p.ip[1] = 0;
                              }
                              if(down==true&&map[0].Location.Y>player.Location.Y+player.Height&&i!=3)
                              {
                                  p.ip[1] = -0.01;
                              }
                          }
                          else if (map[i].Location.X + player.Width * 0.3 > player.Location.X + player.Width && map[i].Location.Y < player.Location.Y + player.Height && map[i].Location.Y + map[i].Height > player.Location.Y)
                          {
                              if (p.ip[0] < 0)
                              {
                                  p.ip[0] = 0;
                              }
                              if (p.ip[1] < 0)
                              {
                                  p.ip[1] = p.ip[1] / 3 * 2;
                              }

                          }
                          else if (map[i].Location.X + map[i].Width - player.Width * 0.3 < player.Location.X && map[i].Location.Y < player.Location.Y + player.Height && map[i].Location.Y + map[i].Height > player.Location.Y)
                          {
                              if (p.ip[1] < 0)
                              {
                                  p.ip[1] = p.ip[1] / 3 * 2;
                              }
                              if (p.ip[0] > 0)
                              {
                                  p.ip[0] = 0;
                              }
                          }
                      }
                      for (int j = 0; j < Enemies.Count(); j++)
                      {
                          if (map[i].Bounds.IntersectsWith(Enemies[j].Bounds))
                          {
                              if (map[i].Location.X + Enemies[j].Height * 0.2 < Enemies[j].Location.X + Enemies[j].Width && map[i].Location.X + map[i].Width - Enemies[j].Height * 0.2 > Enemies[j].Location.X)
                              {
                                  if (player.Location.Y + player.Height / 2 < Enemies[j].Location.Y)
                                  {
                                      p.enemiesi[j][1] += 0.005;
                                  }
                                  if (p.enemiesi[j][1] < 0)
                                  {
                                      p.enemiesi[j][1] = 0;
                                  }
                                  if (player.Location.Y>Enemies[j].Location.Y && map[0].Location.Y > Enemies[j].Location.Y + Enemies[j].Height && i != 3)
                                  {
                                      p.enemiesi[j][1]  = -0.01;
                                  }
                              }
                              else if (map[i].Location.X + Enemies[j].Width * 0.3 > Enemies[j].Location.X + Enemies[j].Width && map[i].Location.Y < Enemies[j].Location.Y + Enemies[j].Height && map[i].Location.Y + map[i].Height > Enemies[j].Location.Y)
                              {
                                  if (p.enemiesi[j][0] < 0)
                                  {
                                      p.enemiesi[j][0] = 0;
                                  }
                                  if (p.enemiesi[j][1] < 0)
                                  {
                                      p.enemiesi[j][1] = p.enemiesi[j][1] / 3 * 2;
                                  }

                              }
                              else if (map[i].Location.X + map[i].Width - Enemies[j].Width * 0.3 < Enemies[j].Location.X && map[i].Location.Y < Enemies[j].Location.Y + Enemies[j].Height && map[i].Location.Y + map[i].Height > Enemies[j].Location.Y)
                              {
                                  if (p.enemiesi[j][1] < 0)
                                  {
                                      p.enemiesi[j][1] = p.enemiesi[j][1] / 3 * 2;
                                  }
                                  if (p.enemiesi[j][0] > 0)
                                  {
                                      p.enemiesi[j][0] = 0;
                                  }
                              }
                          }
                          if(Enemies[j].Location.Y>3*this.Height)
                          {
                              this.Controls.Remove(Enemies[j]);
                              Enemies.Remove(Enemies[j]);
                              p.enemiesi.Remove(p.enemiesi[j]);
                              p.enemiesp.Remove(p.enemiesp[j]);
                          }
                      }
                  }
                  for (int i = 0; i < Enemies.Count(); i++)
                  {
                      Enemies[i].Location = new Point(Convert.ToInt32(p.wsl + this.Height * (p.enemiesp[i][0] + p.pp[0])), Convert.ToInt32(this.Height * (p.enemiesp[i][1] + p.pp[1])));
                      Enemies[i].Size = new Size(player.Width, player.Height);
                  }
                  p.pp[0] += p.ip[0];
                  p.pp[1] += p.ip[1];
                  for (int j = 0; j < Enemies.Count(); j++)
                  {
                      p.enemiesp[j][0] -= p.enemiesi[j][0];
                      p.enemiesp[j][1] -= p.enemiesi[j][1];
                  }
              };
        }
        public void FRM()
        {
            Random rsza = new Random();
            Timer f = new Timer();
            f.Interval = 16;
            f.Start();
            int time = 0;
            f.Tick += (s, e) =>
              {
                  if (time < 100)
                  {
                      p.mapp[0][0] -= 0.02;
                      p.maps[0][0] += 0.04;
                      p.mapp[1][0] -= 0.02;
                      p.mapp[2][0] += 0.02;
                  }
                  else
                  {
                      f.Stop();
                      double szam1 = rsza.Next(17, 60);
                      double szam2 = rsza.Next(17, 60);
                      double[] tomb = new double[2] { p.mapp[1][0] + p.maps[1][0], szam1 / 100 };
                      double[] tombs = new double[2] { 1.8, 0.12 };
                      double[] tom = new double[2] { p.mapp[2][0] - 1.8, szam2 / 100 };
                      p.mapp.Add(tomb);
                      p.mapp.Add(tom);
                      p.maps.Add(tombs);
                      p.maps.Add(tombs);
                  }
                  time++;
              };
        }
    }
}