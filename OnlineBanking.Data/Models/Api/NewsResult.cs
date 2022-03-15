namespace OnlineBanking.Data.Models.Api
{
    public class Rootobject
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public NewsResult[] results { get; set; }
        public int nextPage { get; set; }
    }

    public class NewsResult
    {
        public string title { get; set; }
        public string link { get; set; }
        public string[] keywords { get; set; }
        public string[] creator { get; set; }
        public object video_url { get; set; }
        public string description { get; set; }
        public object content { get; set; }
        public string pubDate { get; set; }
        public string full_description { get; set; }
        public string image_url { get; set; }
        public string source_id { get; set; }
        public string[] country { get; set; }
        public string[] category { get; set; }
        public string language { get; set; }
    }

}
