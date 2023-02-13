using System;

namespace Nipendo.Evaluation
{

    public class Policy
    {
        private string gender;

        private int days;

        private decimal amount;

        private DateTime dateOfBirth;

        private string country;
        public PolicyType Type { get; set; }

        #region General Policy Prop
        public string FullName { get; set; }
        public DateTime DateOfBirth { get { return dateOfBirth; } set
            {
                if(value == DateTime.MinValue)
                {
                    throw new Exception("Life policy must include Date of Birth.");
                }
                if(value < DateTime.Today.AddYears(-100))
                {
                    throw new Exception("\"Max eligible age for coverage is 100 years.");
                }
                dateOfBirth = value;
            }
        }
        #endregion

        #region Life Insurance
        public bool IsSmoker { get; set; }
        
        public decimal Amount { get { return amount; } set
            {
                if (value == 0)
                {
                    throw new Exception("Life policy must include an Amount.");
                }
                amount = value;
            }
        }
        #endregion

        #region Travel
        public string Country { get { return country; } set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Travel policy must specify country.");
                }
                    country = value;
            }
        }
        public int Days { get { return days; } set
            {
                if (value <= 0)
                {
                    throw new Exception("Travel policy must specify Days.");
                }
                else if (value > 180)
                {
                    throw new Exception("the Values shoud be Male or Female");
                }
                days = value;
            }
        }
        #endregion

        #region Health
        public string Gender { get { return gender; } set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Health policy must specify Gender");
                }
                if(value != "Male" && value != "Female")
                {
                    throw new Exception("the Values shoud be Male or Female");
                }
                gender = value;
            } }
        public decimal Deductible { get; set; }
        #endregion

    }
}
