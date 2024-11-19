using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApi
{
    public partial class WebGet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://localhost:44373/WebApi.aspx";
            JArray data = GetApi.GetDataFromApi(url);

            List<Movie> movies = new List<Movie>();

            foreach (var movie in data)
            {
                movies.Add(new Movie
                {
                    MovieID = movie["MovieID"].ToString(),
                    Title = movie["Title"].ToString(),
                    Description = movie["description"].ToString()
                });
            }

            RepeaterMovies.DataSource = movies;
            RepeaterMovies.DataBind();

        }
        // Tạo lớp movie để lưu những thông tin muốn xuất hiện trên page
        public class Movie
        {
            public string MovieID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}