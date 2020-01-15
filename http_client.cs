var url = "http://localhost/crisis-response-plan/web/api/crp?_format=json";
HttpMessageHandler handler = new HttpClientHandler(){ };

var httpClient = new HttpClient(handler)
{
    BaseAddress = new Uri(url),
    Timeout = new TimeSpan(0, 2, 0)
};

httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

    
var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("iom:diphoromis");
    string val = System.Convert.ToBase64String(plainTextBytes);
    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

var method = new HttpMethod("GET");

    HttpResponseMessage response = httpClient.GetAsync(url).Result;
    string content = string.Empty;

using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, System.Text.Encoding.GetEncoding("UTF8")))
{
        content = stream.ReadToEnd();
}

//AT THIS POINT ---- CONTENT WILL BE THE JSON RESPONSE