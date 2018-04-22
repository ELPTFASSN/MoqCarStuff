#region © 2017 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using Moq;
using CarStuff;

namespace SF_MSTest_Car_UT
{
    // ----------------------------------------------------
    /// <summary>
    ///     
    /// </summary>

    public class TestBase
    {
        protected int resp = 0;
        protected const int SPEED_UP = 1;
        protected const int SLOW_DOWN = -1;
        protected const int REMAIN_CONSTANT = 0;
        protected Mock<ICar> m_car = new Mock<ICar>();
    }
}
