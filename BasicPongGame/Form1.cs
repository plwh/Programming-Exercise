﻿using System;
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

        Random setSpeed = new Random();
        int ballSpeedX = 6;
        int ballSpeedY = 6;
        int gameTimeInterval = 1;
        int playerPoints = 0;
        int computerPoints = 0;
        int aiSpeed = 0;
       
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
            picBoxPlayer.BackColor = Color.White;
            this.Controls.Add(picBoxPlayer);

            picBoxAI.Size = sizeAI;
            picBoxAI.Location = new Point(ClientSize.Width - (picBoxAI.Width + picBoxAI.Width / 2), ClientSize.Height / 2 - picBoxPlayer.Height / 2);
            picBoxAI.BackColor = Color.White;
            this.Controls.Add(picBoxAI);

            picBoxBall.Size = sizeBall;
            picBoxBall.Location = new Point(ClientSize.Width / 2 - picBoxBall.Width / 2, ClientSize.Height / 2 - picBoxBall.Height / 2);
            picBoxBall.BackColor = Color.White;
            this.Controls.Add(picBoxBall);
        }

        public void gameTime_Tick(object sender, EventArgs e)
        {
            picBoxBall.Location = new Point(picBoxBall.Location.X + ballSpeedX, picBoxBall.Location.Y + ballSpeedY);
            gameAreaCollisions();
            paddleCollision();
            playerMovement();
            aiMovement(aiSpeed);
        }

        private void updateScore()
        {
            if (picBoxBall.Location.X > ClientSize.Width)
            {
                playerPoints++;
                label1.Text = "score:" + playerPoints.ToString();
            }  
            else if (picBoxBall.Location.X < 0)
            {
                computerPoints++;
                label2.Text = "score:" + computerPoints.ToString();
            }       
        }

        public void restartGame()
        {
            playerPoints = 0;
            computerPoints = 0;
            label1.Text = "score:" + playerPoints.ToString();
            label2.Text = "score:" + computerPoints.ToString();
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = false;
            label3.Visible = false;
        }

        private void aiMovement(int currentSpeed)
        {
            if (ballSpeedX > 0)
            {
                picBoxAI.Location = new Point(ClientSize.Width - (picBoxAI.Width + picBoxAI.Width / 5), (picBoxBall.Location.Y - picBoxAI.Height / 2) + currentSpeed);
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
            if (picBoxBall.Bounds.IntersectsWith(picBoxAI.Bounds))
            {
                ballSpeedX = -ballSpeedX;
            }
            else if(picBoxBall.Bounds.IntersectsWith(picBoxPlayer.Bounds))
            {
                changeAISpeed();
                ballSpeedX = -ballSpeedX;          
            }
        }

        private void changeAISpeed()
        {
            aiSpeed = setSpeed.Next(60,66);
        }

        private void gameAreaCollisions()
        {
            if (picBoxBall.Location.Y > ClientSize.Height - picBoxBall.Height || picBoxBall.Location.Y < 0)
            {
                ballSpeedY = -ballSpeedY;
            }
            if ((picBoxBall.Location.X > ClientSize.Width || picBoxBall.Location.X < 0) && checkForWinner() != true)
            {
                updateScore();
                changeAISpeed();
                resetBall(true);
            }
        }

        private bool checkForWinner()
        {
            if (playerPoints == 9 || computerPoints == 9)
            { 
                label1.Visible = false;
                label2.Visible = false;
                lineShape1.Visible = false;
                textBox1.Visible = true;
                label3.Visible = true;
                aiSpeed = 0;
                resetBall(false);
                return true;
            }
            return false;
        }

        public void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space && checkForWinner() == true)
            {
                restartGame();
                resetBall(true);
            }
            else if (e.KeyChar == (char)Keys.Enter && checkForWinner() == true)
            {
                Application.Exit();
            }
        }

        private void resetBall(bool a)
        {
            if (a == true)
            {
                picBoxBall.Location = new Point(ClientSize.Width / 2 - picBoxBall.Width / 2, (ClientSize.Height-setSpeed.Next(10,550))  - picBoxBall.Height / 2);
                ballSpeedX = -ballSpeedX;
            }
        }  
    }
}