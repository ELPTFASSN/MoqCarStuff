#region © 2015 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

namespace CarStuff
{
    // ----------------------------------------------------

    public enum eTireSet
    {
        AllWeather,
        Performance,
        Winter
    }

    // ----------------------------------------------------
    /// <summary>
    /// 
    /// </summary>

    public class OptionsPackage
    {
        public ConsoleColor Color { set; get; }
        public bool SportsPackage { set; get; }
        public eTireSet Tires { set; get; }
    }
}
