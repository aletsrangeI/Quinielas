namespace Quinielas.Domain.Entities
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Country
    {
        public string name { get; set; }
        public string code { get; set; }
        public string flag { get; set; }
    }

    public class Coverage
    {
        public Games games { get; set; }
        public Statistics statistics { get; set; }
        public bool players { get; set; }
        public bool injuries { get; set; }
        public bool standings { get; set; }
    }

    public class Games
    {
        public bool events { get; set; }
        public Statisitcs statisitcs { get; set; }
    }

    public class League
    {
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
    }

    public class Response
    {
        public League league { get; set; }
        public Country country { get; set; }
        public List<Season> seasons { get; set; }
    }

    public class ResponseLeaguesAF
    {
        public string get { get; set; }
        public List<object> parameters { get; set; }
        public List<object> errors { get; set; }
        public int results { get; set; }
        public List<Response> response { get; set; }
    }

    public class Season
    {
        public int year { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public bool current { get; set; }
        public Coverage coverage { get; set; }
    }

    public class Season2
    {
        public bool players { get; set; }
    }

    public class Statisitcs
    {
        public bool teams { get; set; }
        public bool players { get; set; }
    }

    public class Statistics
    {
        public Season season { get; set; }
    }
}

