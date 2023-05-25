using MovieLibrary.Api;
using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MovieLibrary
{
    public partial class SearchForAMovie : Form
    {
        private readonly MovieApi _movieAppi = new MovieApi();
     
        public SearchForAMovie()
        {
            InitializeComponent();
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            string text = searchTextBox.Text;
            if(text == "")
            {
                return;
            }

            Task<MovieShort[]> movieTask = _movieAppi.GetMovies(text);
            await Task.WhenAll(movieTask);

            MovieShort[] movies = movieTask.Result;

            showMovies(movies);
        }

        private void showMovies(MovieShort[] movies)
        {
            int width = 150;
            Console.Write(movies.Length.ToString());
            foreach(MovieShort movie in movies)
            {
                Panel panel = new Panel();
                panel.Name = movie.Title;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Click += (object sender, EventArgs e) =>
                {
                    Console.Write(panel.Name);
                    MovieDetail m = new MovieDetail(panel.Name);
                    m.Show();
                };


                panel.Size = new Size(width, 250);

                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = movie.Poster;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(width, 150);
                pictureBox.Click += (object sender, EventArgs e) =>
                {
                    Console.Write(panel.Name);
                    MovieDetail m = new MovieDetail(panel.Name);
                    m.Show();
                };

                Label title = new Label();
                title.Text = movie.Title;
                title.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                title.AutoSize = true;
                title.MaximumSize = new Size(width, 0);
                title.Location = new Point(10, 155);
                title.Click += (object sender, EventArgs e) =>
                {
                    Console.Write(panel.Name);
                    MovieDetail m = new MovieDetail(panel.Name);
                    m.Show();
                };

                Label type = new Label();
                type.Text = movie.Type;
                type.AutoSize = true;
                type.MaximumSize = new Size(width, 0);
                type.Location = new Point(10, 195);

                Label year = new Label();
                year.Text = movie.Year;
                year.AutoSize = true;
                year.MaximumSize = new Size(width, 0);
                year.Location = new Point(10, 210);

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(title);
                panel.Controls.Add(type);
                panel.Controls.Add(year);



                flowLayoutPanel1.Controls.Add(panel);
            }
        }
    }
}
