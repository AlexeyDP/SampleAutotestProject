using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atest.Suites.TestCaseSources
{
    public class UserLoginData
    {
        /// <summary>
        /// In this demo project separated class with DTO is used only for demonstration NUnit functionalities 
        /// </summary>
     
        private static string incorrectLoginAlertText = "Invalid Email or Password";

        public static IEnumerable PositiveLogins
        {
            get
            {
                yield return new TestCaseData("user@phptravels.com", "demouser");
            }
        }

        public static IEnumerable NegativeLogins
        {
            get
            {
                yield return new TestCaseData("admin@phptravels.com", "demoadmin").Returns(incorrectLoginAlertText);
                yield return new TestCaseData("supplier@phptravels.com", "demosupplier").Returns(incorrectLoginAlertText);
            }
        }


    }
}
