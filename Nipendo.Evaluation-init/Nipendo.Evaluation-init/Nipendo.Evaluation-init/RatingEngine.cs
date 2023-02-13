using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Nipendo.Evaluation
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public sealed class RatingEngine
    {
        private RatingEngine() { }
        private static RatingEngine instance;
        private ApplicationNotifier notifier;
        public static RatingEngine GetInstance()
        {
            if (instance == null)
            {
                instance = new RatingEngine();
            }
            return instance;
        }
        public void SetNotifier(ApplicationNotifier notifier)
        {
            this.notifier = notifier;
        }
        private void NotifyApp(object message)
        {
            if(notifier != null)
                notifier.Notify(message);
        }
        public decimal Rate(Policy policy)
        {
            // log start rating
            decimal Rating = 0;
            const string Italy = "Italy";
           NotifyApp("Starting rate.");

            NotifyApp("Loading policy.");
            // add to another class 

            switch (policy.Type)
            {
                case PolicyType.Health:
                    NotifyApp("Rating HEALTH policy...");
                    if (policy.Gender == "Male")
                    {
                        if (policy.Deductible < 500)
                        {
                            Rating = 1000m;
                        }
                        Rating = 900m;
                    }
                    else
                    {
                        if (policy.Deductible < 800)
                        {
                            Rating = 1100m;
                        }
                        Rating = 1000m;
                    }
                    break;

                case PolicyType.Travel:
                    NotifyApp("Rating TRAVEL policy...");
                    NotifyApp("Validating policy.");
                    Rating = policy.Days * 2.5m;
                    if (policy.Country == Italy)
                    {
                        Rating *= 3;
                    }
                    break;

                case PolicyType.Life:
                    NotifyApp("Rating LIFE policy...");

                    // rerate this 
                    //      int age = DateTime.Today.Year - policy.DateOfBirth.Year;
                    var timeSpan = DateTime.Today - policy.DateOfBirth;
                    int age = new DateTime(timeSpan.Ticks).Year;

                    // //
                    decimal baseRate = policy.Amount * age / 200;
                    if (policy.IsSmoker)
                    {
                        Rating = baseRate * 2;
                        break;
                    }
                    Rating = baseRate;
                    break;

                default:
                    NotifyApp("Unknown policy type");
                    break;
            }
            NotifyApp("Rating completed.");
            return Rating;
        }
    }
}
