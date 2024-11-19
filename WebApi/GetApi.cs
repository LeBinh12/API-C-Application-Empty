using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApi
{
    public class GetApi
    {
        // Hàm của người khác
        public static JArray GetDataFromApi(string apiUrl)
        {
            try
            {
                // Gửi yêu cầu GET tới API
                var request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "GET";  // Hoặc "POST" nếu API yêu cầu

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string jsonResponse = reader.ReadToEnd();

                        // Phân tích dữ liệu JSON và trả về phần "data" dưới dạng JArray
                        JObject jobject = JObject.Parse(jsonResponse);
                        return (JArray)jobject["data"];
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về một JArray rỗng trong trường hợp gặp lỗi
                Console.WriteLine($"Error: {ex.Message}");
                return new JArray();  // Hoặc có thể trả về null, tùy vào yêu cầu
            }
        }

    }
}