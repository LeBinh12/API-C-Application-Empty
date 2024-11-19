using System;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebApi
{
    public partial class WebApi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/json"; // thiết lập web thành kiểu json

            try
            {
                if (Request.HttpMethod == "GET" || Request.HttpMethod == "POST") // cho phép client có thể get hoặc post về máy chủ
                {
                    using (var context = new DataClasses1DataContext())
                    {
                        var movies = context.Movies.Select(m => new
                        {
                            m.MovieID,
                            m.Title,
                            m.description
                        }).ToList();

                        var json = new JavaScriptSerializer().Serialize(new
                        {
                            status = "success",
                            data = movies
                        }); // ??? chứa biết hàm này, lấy trên mạng
                        Response.Write(json);
                    }
                }
                else
                {
                    // Trả về lỗi nếu phương thức không được hỗ trợ
                    Response.StatusCode = 405; 
                    Response.Write("{\"status\":\"error\",\"message\":\"Method not allowed\"}");
                }
            }
            catch (Exception ex)
            {
                var errorJson = new JavaScriptSerializer().Serialize(new
                {
                    status = "error",
                    message = ex.Message
                });
                Response.Write(errorJson);
            }
            Response.End();
        }
    }
}
