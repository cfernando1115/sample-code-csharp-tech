using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodeTech
{
    public class Customer:Person
    {
        private string _rewardStatus;
        public Customer(ILogger logger)
            : base(logger)
        {
        }

        public void CalculateRewardStatus()
        {
            if (Age <= 28)
            {
                _rewardStatus = "bronze";
            }
            if (Age >= 29 && Age <= 38)
            {
                _rewardStatus = "silver";
            }
            if (Age >= 39)
            {
                _rewardStatus = "gold";
            }
            Logger.Log("Congratulations! Your Customer reward status is " + _rewardStatus);
        }
    }
}
