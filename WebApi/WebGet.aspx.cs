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

            string htmlContent = "<table border='1'><tr><th>Movie ID</th><th>Title</th><th>Description</th></tr>";
            // duyệt json để lấy các thông tin 
            foreach (var movie in data)
            {
                htmlContent += $"<tr><td>{movie["MovieID"]}</td><td>{movie["Title"]}</td><td>{movie["description"]}</td></tr>";
            }
            htmlContent += "</table>";

            LiteralData.Text = htmlContent;

        }

    }
}