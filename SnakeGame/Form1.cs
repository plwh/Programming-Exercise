using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gameTimer.Interval = 1000 / 60;
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();
        }

        int square_x = 0;
        int square_y = 0;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        public void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Update(object sender, EventArgs e)
        {
            if (Input.Pressed(Keys.Right))
                square_x += 4;
            if (Input.Pressed(Keys.Left))
                square_x -= 4;
            if (Input.Pressed(Keys.Up))
                square_y -= 4;
            if (Input.Pressed(Keys.Down))
                square_y += 4;
            pbCanvas.Invalidate();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            canvas.FillRectangle(Brushes.Red, new Rectangle(square_x, square_y, 16, 16));
        }

    }
 }

