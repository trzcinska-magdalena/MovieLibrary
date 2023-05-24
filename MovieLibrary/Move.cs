using MovieLibrary.Api;
using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary
{
    public partial class Move : Form
    {
        private readonly MovieApi _movieAppi = new MovieApi();
     
        public Move()
        {
            InitializeComponent();
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            string title = searchTextBox.Text;
            Console.WriteLine(title);
            if(title == "")
            {
                return;
            }

            Task<Movie> movieTask = _movieAppi.GetMovie(title);
            await Task.WhenAll(movieTask);

            Movie movie = movieTask.Result;

            showData(movie);
        }

        private void showData(Movie movie)
        {
            panel1.Visible = true;

            if (movie.Poster != "")
            {
                pictureBox1.ImageLocation = movie.Poster;
            }

            titleLabel.Text = movie.Title;
            descLabel.Text = movie.Plot;
            scoreLabel.Text = movie.imdbRating + "/10";
            usersLabel.Text = movie.imdbVotes;
        }
    }
}
