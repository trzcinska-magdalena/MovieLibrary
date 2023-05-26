using MovieLibrary.Api;
using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary
{
    public partial class MovieDetail : Form
    {
        private readonly MovieApi _movieAppi = new MovieApi();
        public MovieDetail(string title)
        {
            InitializeComponent();
            getMovie(title);
        }

        private async void getMovie(string title)
        {
            Task<Movie> movieTask = _movieAppi.GetMovie(title);
            await Task.WhenAll(movieTask);

            Movie movie = movieTask.Result;

            showData(movie);
            this.Show();
        }

        private void showData(Movie movie)
        {
            panel1.Visible = true;

            if (movie.Poster != "")
            {
                pictureBox1.ImageLocation = movie.Poster;
            }

            scoreLabel.Text = movie.imdbRating + "/10";
            usersLabel.Text = movie.imdbVotes;

            titleLabel.Text = movie.Title;
            descLabel.Text = movie.Plot;
            
            genreValue.Text = movie.Genre;
            countryValue.Text = movie.Country;
            runtimeValue.Text = movie.Runtime;
            languageValue.Text = movie.Language;
            directorValue.Text = movie.Director;

            string[] actors = movie.Actors.Split(',');
            actor1Value.Text = actors[0].Trim();
            actor2Value.Text = actors[1].Trim();
            actor3Value.Text = actors[2].Trim();

            dvdValue.Text = movie.DVD;
            releasedValue.Text = movie.Released;

            //awardsValue.Text = movie.Awards.Substring();
 
        }
    }
}
