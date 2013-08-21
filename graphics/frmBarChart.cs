/* 
 * Name: Alexander D. Martinez
 * Date: 11/24/09
 * Purpose: Learn to use form graphics capabilities. 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace graphics
{
    public partial class frmBarChart : Form
    {
        //
        // init area
        //

        int x1 = 0;
        int y1 = 0;
        int w1 = 0;
        int h1 = 0;

        int x2 = 0;
        int y2 = 0;
        int w2 = 0;
        int h2 = 0;

        int x3 = 0;
        int y3 = 0;
        int w3 = 0;
        int h3 = 0;

        int x4 = 0;
        int y4 = 0;
        int w4 = 0;
        int h4 = 0;

        private Color p1Color = Color.Red;
        private Color p2Color = Color.Blue;
        private Color p3Color = Color.Green;
        private Color p4Color = Color.Goldenrod;

        public frmBarChart()
        {
            InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grObj = pnlDrawArea.CreateGraphics();

            Pen linePen = new Pen(Color.Black, 3);
            SolidBrush numBrush = new SolidBrush(Color.Black);
            SolidBrush p1Brush = new SolidBrush(p1Color);
            SolidBrush p2Brush = new SolidBrush(p2Color);
            SolidBrush p3Brush = new SolidBrush(p3Color);
            SolidBrush p4Brush = new SolidBrush(p4Color);
            
            
            FontStyle fStyle = FontStyle.Regular;
            Font sansSerif = new Font("Microsoft Sans Serif", 8, fStyle);

            grObj.Clear(frmBarChart.DefaultBackColor);

            //draw bar chart
            grObj.FillRectangle(p1Brush, x1, y1, w1, h1);
            grObj.FillRectangle(p2Brush, x2, y2, w2, h2);
            grObj.FillRectangle(p3Brush, x3, y3, w3, h3);
            grObj.FillRectangle(p4Brush, x4, y4, w4, h4);

            //draw grid
            grObj.DrawLine(linePen, 0, 0, 0, 500);
            grObj.DrawLine(linePen, 0, 0, 10, 0);
            grObj.DrawLine(linePen, 0, 100, 10, 100);
            grObj.DrawLine(linePen, 0, 200, 10, 200);
            grObj.DrawLine(linePen, 0, 300, 10, 300);
            grObj.DrawLine(linePen, 0, 400, 10, 400);
            grObj.DrawString("500", sansSerif, numBrush, 11, 0);
            grObj.DrawString("400", sansSerif, numBrush, 11, 100);
            grObj.DrawString("300", sansSerif, numBrush, 11, 200);
            grObj.DrawString("200", sansSerif, numBrush, 11, 300);
            grObj.DrawString("100", sansSerif, numBrush, 11, 400);
            
        }
        //
        // init area
        //
        //-----------------------------------------------------------------------
        //
        // Draw button execute
        //
        private void btnDrawChart_Click(object sender, EventArgs e)
        {
            int score1;
            int score2;
            int score3;
            int score4;

            if (checkNumber(textBox1.Text))
            {
                score1 = Convert.ToInt32(textBox1.Text);
                makeBarChart(1, score1);
            }
            else
            {
                MessageBox.Show("Score must be >= 0 and <= 500", "Player 1 out of range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (checkNumber(textBox2.Text))
            {
                score2 = Convert.ToInt32(textBox2.Text);
                makeBarChart(2, score2); 
            }
            else
            {
                MessageBox.Show("Score must be >= 0 and <= 500", "Player 2 out of range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (checkNumber(textBox3.Text))
            {
                score3 = Convert.ToInt32(textBox3.Text);
                makeBarChart(3, score3); 
            }
            else
            {
                MessageBox.Show("Score must be >= 0 and <= 500", "Player 3 out of range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (checkNumber(textBox4.Text))
            {
                score4 = Convert.ToInt32(textBox4.Text);
                makeBarChart(4, score4); 
            }
            else
            {
                MessageBox.Show("Score must be >= 0 and <= 500", "Player 4 out of range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Invalidate();
        }
        //
        // Draw button execute
        //
        //----------------------------------------------------------------------
        //
        // clear display
        //        
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            x1 = 0;
            y1 = 0;
            w1 = 0;
            h1 = 0;

            x2 = 0;
            y2 = 0;
            w2 = 0;
            h2 = 0;

            x3 = 0;
            y3 = 0;
            w3 = 0;
            h3 = 0;

            x4 = 0;
            y4 = 0;
            w4 = 0;
            h4 = 0;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            Invalidate();
        }
        //
        // clear display
        //
        //----------------------------------------------------------------------
        //
        // change colors
        //
        private void btnBarColor1_Click(object sender, EventArgs e)
        {
            DialogResult result = myColorPicker.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            textBox1.ForeColor = myColorPicker.Color;
            p1Color = myColorPicker.Color;
            Invalidate();
        }

        private void btnBarColor2_Click(object sender, EventArgs e)
        {
            DialogResult result = myColorPicker.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            textBox2.ForeColor = myColorPicker.Color;
            p2Color = myColorPicker.Color;
            Invalidate();
        }

        private void btnBarColor3_Click(object sender, EventArgs e)
        {
            DialogResult result = myColorPicker.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            textBox3.ForeColor = myColorPicker.Color;
            p3Color = myColorPicker.Color;
            Invalidate();
        }

        private void btnBarColor4_Click(object sender, EventArgs e)
        {
            DialogResult result = myColorPicker.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            textBox4.ForeColor = myColorPicker.Color;
            p4Color = myColorPicker.Color;
            Invalidate();
        }
        //
        // change colors
        //
        //----------------------------------------------------------------------------
        //
        // Methods
        //
        // Creates the chart
        private void makeBarChart(int player, int height)
        {
            if (player == 1)
            {
                x1 = 50;
                y1 = 500 - height;
                w1 = 70;
                h1 = height; 
            }

            if (player == 2)
            {
                x2 = 140;
                y2 = 500 - height;
                w2 = 70;
                h2 = height;
            }

            if (player == 3)
            {
                x3 = 230;
                y3 = 500 - height;
                w3 = 70;
                h3 = height;
            }

            if (player == 4)
            {
                x4 = 320;
                y4 = 500 - height;
                w4 = 70;
                h4 = height;
            }
        }

        // verifies input
        private bool checkNumber(string input)
        {
            int number = Convert.ToInt32(input);
            bool result = false;

            if (number >= 0 && number <= 500)
            {
                result = true;
            }

            return result;
        }

    }
}
