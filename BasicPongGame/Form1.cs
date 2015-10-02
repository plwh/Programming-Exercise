using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicPongGame
{
    public partial class Form1 : Form
    {
        PictureBox picBoxPlayer, picBoxAI,picBoxBall;
        Timer gameTime;

        const int ScreenWidth = 800;
        const int ScreenHeight = 600;

        Size sizePlayer = new Size(25, 100);
        Size sizeAI = new Size(25, 100);
        Size sizeBall = new Size(20, 20);

        int ballSpeedX = 6;
        int ballSpeedY = 6;
        int gameTimeInterval = 1;

        public Form1()
        {
            InitializeComponent();

            picBoxPlayer = new PictureBox();
            picBoxAI = new PictureBox();
            picBoxBall = new PictureBox();

            gameTime = new Timer();

            gameTime.Enabled = true;
            gameTime.Interval = gameTimeInterval;

            gameTime.Tick += new EventHandler(gameTime_Tick);

            this.Width = ScreenWidth;
            this.Height = ScreenHeight;
            this.StartPosition = FormStartPosition.CenterScreen;

            picBoxPlayer.Size = sizePlayer;
            picBoxPlayer.Location = new Point(picBoxPlayer.Width / 2, ClientSize.Height / 2 - picBoxPlayer.Height / 2);
            picBoxPlayer.BackColor = Color.Blue;
            this.Controls.Add(picBoxPlayer);

            picBoxAI.Size = sizeAI;
            picBoxAI.Location = new Point(ClientSize.Width - (picBoxAI.Width + picBoxAI.Width / 2), ClientSize.Height / 2 - picBoxPlayer.Height / 2);
            picBoxAI.BackColor = Color.Red;
            this.Controls.Add(picBoxAI);

            picBoxBall.Size = sizeBall;
            picBoxBall.Location = new Point(ClientSize.Width / 2 - picBoxBall.Width / 2, ClientSize.Height / 2 - picBoxBall.Height / 2);
            picBoxBall.BackColor = Color.Green;
            this.Controls.Add(picBoxBall);
        }

        private void gameTime_Tick(object sender, EventArgs e)
        {
            picBoxBall.Location = new Point(picBoxBall.Location.X + ballSpeedX, picBoxBall.Location.Y + ballSpeedY);
            gameAreaCollisions();
            paddleCollision();
            playerMovement();
            aiMovement();
        }

        private void aiMovement()
        {
            if (ballSpeedX > 0)
            {
                picBoxAI.Location = new Point(ClientSize.Width - (picBoxAI.Width + picBoxAI.Width / 2), picBoxBall.Location.Y - picBoxAI.Height / 2);
            }
        }

        private void playerMovement()
        {
            if (this.PointToClient(MousePosition).Y >= picBoxPlayer.Height / 2 && this.PointToClient(MousePosition).Y <= ClientSize.Height - picBoxPlayer.Height / 2)
            {
                int playerX = picBoxPlayer.Width / 2;
                int playerY = this.PointToClient(MousePosition).Y - picBoxPlayer.Height / 2;

                picBoxPlayer.Location = new Point(playerX, playerY);
            }
        }

        private void paddleCollision()
        {
            if (picBoxBall.Bounds.IntersectsWith(picBoxAI.Bounds) || picBoxBall.Bounds.IntersectsWith(picBoxPlayer.Bounds))
            {
                ballSpeedX = -ballSpeedX;
            }
        }

        private void gameAreaCollisions()
        {
            if (picBoxBall.Location.Y > ClientSize.Height - picBoxBall.Height || picBoxBall.Location.Y < 0)
            {
                ballSpeedY = -ballSpeedY;
            }
            else if (picBoxBall.Location.X > ClientSize.Width)
            {
                resetBall();
            }
            else if (picBoxBall.Location.X < 0)
            {
                resetBall();
            }
        }

        private void resetBall()
        {
            picBoxBall.Location = new Point(ClientSize.Width / 2 - picBoxBall.Width / 2, ClientSize.Height / 2 - picBoxBall.Height / 2);
        }

        
    }
}
