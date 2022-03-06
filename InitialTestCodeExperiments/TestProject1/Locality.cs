//using Newtonsoft.Json.JsonConvert;

namespace TestProject1
{
    public class Locality
    {
        public string category { get; set; }
        public int id { get; set; }
        public float latitude { get; set; }
        public string location { get; set; }
        public float longitude { get; set; }
        public int postcode { get; set; }
        public string state { get; set; }
    }

    /*{
        "localities": {
            "locality": {
                "category": "Delivery Area",
                "id": 12306,
                "latitude": -34.75705988,
                "location": "PARALOWIE",
                "longitude": 138.6081242,
                "postcode": 5108,
                "state": "SA"
            }
        }
    }*/
}
