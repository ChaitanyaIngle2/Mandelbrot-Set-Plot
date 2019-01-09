// Chaitanya Ingle
// 2000475661
// CS 480
// Mandelbrot Set with Zoom

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mandelbrotSet
{
    public partial class mandelbrot : Form

    {   //*****************************************************************************************************
        //*****************************************************************************************************
        // PUBLIC CLASS VARIABLES

        // Initialize user Bounds for canvas
        double x_min = -2;
        double y_min = -2;
        double x_max = 2;
        double y_max = 2;

        // Variables to iterate through canvas
        double c1, c2;

        // Rate at which canvas is iterated through
        double delta_X, delta_Y;

        // To store what coordinate is clicked
        double click_X, click_Y;

        // Zoom input and total factor
        double zoom_input = 0.2;
        double zoom_factor;

        // Bitmap to write image to
        private Bitmap bm;

        //*****************************************************************************************************
        //*****************************************************************************************************
        // INITIALIZER
        public mandelbrot()
        {
            InitializeComponent();

            // Overload event handlers
            mandelbrotBox.Paint += new PaintEventHandler(mandelbrotBox_Paint);
            mandelbrotBox.MouseClick += new MouseEventHandler(mandelbrotBox_MouseClick);

            // Initalize zoom value
            zoomBox1.Text = "2";
        }

        //*****************************************************************************************************        
        //*****************************************************************************************************
        // CLASS FUNCTIONS

        // Function to draw mandelbrot set to canvas based on current class variables
        private void mandelbrotBox_Paint(object sender, PaintEventArgs e)
        {
            // Create bitmap to be written to

            bm = new Bitmap(mandelbrotBox.Width, mandelbrotBox.Height);

            // Set delta_X and delta_Y 

            delta_X = (x_max - x_min) / (mandelbrotBox.Width);
            delta_Y = (y_max - y_min) / (mandelbrotBox.Height);

            double curr_X;
            double curr_Y;
            double next_X, next_Y, curr_Z;
            int n = 0;
            bool div = false;
            // Main Double Loop to determine if a pixel diverges or not

            for (int i = 0; i < mandelbrotBox.Width; i++)
            {
                c1 = x_min + (delta_X * i);
                for (int j = 0; j < mandelbrotBox.Height; j++)
                {
                    c2 = y_min + (delta_Y * j);

                    curr_X = 0;
                    curr_Y = 0;
                    n = 0;
                    div = false;

                    while (n < 1024)
                    {
                        next_X = curr_X * curr_X - curr_Y * curr_Y + c1;
                        next_Y = 2 * curr_X * curr_Y + c2;
                        curr_Z = next_X * next_X + next_Y * next_Y;

                        if (curr_Z > 20)
                        {
                            div = true;
                            break;
                        }

                        curr_X = next_X;
                        curr_Y = next_Y;
                        n ++;
                    }

                    // Paint pixel based on convergence/divergence
                    if (div == true)
                        bm.SetPixel(i, j, compute_Color(n)); // If diverges, need to calculate shade
                    else
                        bm.SetPixel(i, j, Color.Black);
                }

            }

            // Draw bitmap on canvas
            e.Graphics.DrawImage(bm, 0, 0, bm.Width, bm.Height);
        }


        private void mandelbrotBox_Click(object sender, EventArgs e)
        {

        }

        //*****************************************************************************************************
        // Function to draw rectangle on mosue click
        private void mandelbrotBox_MouseClick(object sender, MouseEventArgs e)
        {

            // Retrieve real mouse click coordinates and compute usable values
            click_X = x_min + (e.X * ((x_max - x_min) / (mandelbrotBox.Width)));
            click_Y = y_min + (e.Y * ((y_max - y_min) / (mandelbrotBox.Height)));

            // Calculate zoom factor based on current zoom_input
            zoom_factor = (((x_max - x_min) * (double)zoom_input) / 2);

            // Compute rectangle vertices (top left and bottom right gives whole thing)

            double temp;

            // Top Left Vertex
            temp = click_X - zoom_factor;
            double TL_X = x_min + ((temp - x_min) * (mandelbrotBox.Width)) / (x_max - x_min);

            temp = click_Y - zoom_factor;
            double TL_Y = y_min + ((temp - y_min) * (mandelbrotBox.Height)) / (y_max - y_min);

            // Bottom Right Vertex
            temp = click_X + zoom_factor;
            double BR_X = x_min + ((temp - x_min) * (mandelbrotBox.Width)) / (x_max - x_min);

            temp = click_Y + zoom_factor;
            double BR_Y = y_min + ((temp - y_min) * (mandelbrotBox.Height)) / (y_max - y_min);

            // Draw Rectangle
            using (Graphics g = mandelbrotBox.CreateGraphics())
            {
                Pen pen = new Pen(Color.Green);

                g.DrawImage(bm, 0, 0, bm.Width, bm.Height);
                g.DrawRectangle(pen, (int)TL_X, (int)TL_Y, (int)(BR_X - TL_X), (int)(BR_Y - TL_Y));
            }
        }

        private void zoomLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //*****************************************************************************************************
        // Function for pressing "Reset" button. Clears and reinitalizes mandelbrot set
        private void resetButton_Click(object sender, EventArgs e)
        {

            // Reinitialize variables 
            x_min = -2;
            x_max = 2;
            y_min = -2;
            y_max = 2;

            // Clear and redraw canvas
            mandelbrotBox.Invalidate();
        }

        //*****************************************************************************************************
        // Function to update class variable if different zoom_input is chosen
        private void zoomBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void zoomBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Convert String to actual zoom value
            switch (zoomBox1.Text)
            {
                case "2":
                    zoom_input = 1.0 / 2.0;
                    break;
                case "3":
                    zoom_input = 1.0 / 3.0;
                    break;
                case "4":
                    zoom_input = 1.0 / 4.0;
                    break;
                case "5":
                    zoom_input = 1.0 / 5.0;
                    break;
                case "10":
                    zoom_input = 1.0 / 10.0;
                    break;
            }
        }

        //*****************************************************************************************************
        // Function for when "Zoom!" button is clicked. Zooms in on canvas.
        private void zoomButton_Click(object sender, EventArgs e)
        {
            // Get zoom factor based on zoom_input
            zoom_factor = (x_max - x_min) * zoom_input;

            // Center view around the rectangle
            x_min = click_X - (zoom_factor/2);
            x_max = click_X + (zoom_factor/2);
            y_min = click_Y - (zoom_factor/2);
            y_max = click_Y + (zoom_factor/2);

            // Clears and redraaws canvas
            mandelbrotBox.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //*****************************************************************************************************
        //*****************************************************************************************************
        // HELPER FUNCTIONS

        //*****************************************************************************************************
        // Function to determine color of mandelbrot pixel based on degree of divergence
        Color compute_Color(int n)
        {
            if (n <= 1)
                return Color.FromArgb(255, 35, 0, 0);
            else if (n == 2)
                return Color.FromArgb(255, 50, 0, 0);
            else if (n == 3)
                return Color.FromArgb(255, 100, 0, 0);
            else if (n == 4)
                return Color.FromArgb(255, 150, 0, 0);
            else if (n == 5)
                return Color.FromArgb(255, 200, 0, 0);
            else
                return Color.FromArgb(255, 255, 0, 0);
        }
    }
}
