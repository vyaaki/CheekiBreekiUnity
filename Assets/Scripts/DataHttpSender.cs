using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;


namespace Network
{
    public class LeaderBoard
    {
        public LeaderBoard(double time, int score)
        {
            Time = time;
            Score = score;
        }

        public double Time { get; set; }
        public int Score { get; set; }
    }
    class DataHttpSender
    {
        public static void CreateUserScore(LeaderBoard leaderBoard)
        {
            var json = JsonConvert.SerializeObject(leaderBoard);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44311/api/leaderboard");
            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Close();
            }
            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
            {
                response.Close();
            }
        }

        public static List<LeaderBoard> GetLeaderBoard()
        {
            WebRequest webRequest = WebRequest.Create("https://localhost:44311/api/leaderboard");
            WebResponse webResponse = webRequest.GetResponse();
            string responseFromServer;
            using (Stream dataStream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }


            return JsonConvert.DeserializeObject<List<LeaderBoard>>(responseFromServer);
        }


    }
}
