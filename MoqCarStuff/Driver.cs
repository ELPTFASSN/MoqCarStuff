#region © 2015 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

namespace CarStuff
{
    // ----------------------------------------------------
    /// <summary>
    /// 
    /// </summary>

    public class Driver : IDriver
    {
        private ICar Car { set; get; }
        private int MaxSpeed { set; get; }

        // ------------------------------------------------

        public Driver(ICar car, int maxSpeed)
        {
            Car = car;
            MaxSpeed = maxSpeed;
        }

        // ------------------------------------------------
        
        public int Drive()
        {
            int retVal = 0;
            int speed = Car.GetSpeed();

            if(speed > MaxSpeed)
            {
                retVal = -1;
            }
            else if(speed < MaxSpeed)
            {
                retVal = 1;
            }

            return retVal;
        }

        // ------------------------------------------------

        public bool PurchasedSportsPackage
        {
            get
            {
                return Car.Options.SportsPackage;
            }
        }

        // ------------------------------------------------

        public string CarColor
        {
            get
            {
                return Car.Options.Color.ToString();
            }
        }

        // ------------------------------------------------

        public string TireOption
        {
            get
            {
                return Car.Options.Tires.ToString();
            }
        }
    }
}
