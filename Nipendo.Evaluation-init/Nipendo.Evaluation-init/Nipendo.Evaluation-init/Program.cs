using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.IO;


namespace Nipendo.Evaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationNotifier Notifier = new ApplicationNotifier(NotifiersFactory.GetNotifiers());
            Notifier.Notify("Insurance Rating System Starting...");
            string policyJson = File.ReadAllText("policy.json");

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
            RatingEngine engine = RatingEngine.GetInstance();
            engine.SetNotifier(Notifier);
            var Rating = engine.Rate(policy);

            if (Rating > 0)
            {
                Notifier.Notify($"Rating: {Rating}");
                Console.ReadKey();
            }
            else
            {
                Notifier.Notify("No rating produced.");
            }

        }
    }
}
