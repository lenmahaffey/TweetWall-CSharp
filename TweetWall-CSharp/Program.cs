using System;
namespace HTTPGetRequest
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            TwitterHttpGetRequest twitter = new TwitterHttpGetRequest("9CpDRPiRoQS4Kd97aCNr30Xzu", "N2G1AKjTbTufjDmfxxj9MFyTu2SG2NGLMZ8HZreVP0Gk9LG0b4");
            var tweets = await twitter.GetTweetsAsync();
        }
    }
}
