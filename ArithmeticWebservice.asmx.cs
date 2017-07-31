using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceDemo
{
    /// <summary>
    /// Summary description for ArithmeticWebservice
    /// </summary>
    [WebService(Namespace = "http://cwas.com/services")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ArithmeticWebservice : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true, Description="This Method add two numbers", CacheDuration= 20)]
        public int add(int first, int second)
        {
            List<string> calculations;

            if (Session["Calculations"] == null)
            {
                calculations = new List<string>();
            }
            else{
                calculations = (List<string>) Session["Calculations"];
            }

            string recentCalcul = first.ToString() + " + " + second.ToString() + " = " + (first + second).ToString();

            calculations.Add(recentCalcul);

            Session["Calculations"] = calculations;

            return first+second ;
        }

        [WebMethod]
        public double multiply(double first, double second)
        {
             return first * second;
        }

        [WebMethod(MessageName="multiplyInt")]
        public int multiply(int first, int second)
        {
            return first * second;
        }





        [WebMethod(EnableSession=true, Description="This method return all calculations")]
        public List<string> getCalcutions()
        {
            if (Session["Calculations"] == null)
            {
               List<string> calculations = new List<string>();
                calculations.Add("You have not perfomed any calculation");
               return calculations;
            }else{

                return (List<string>)Session["Calculations"];
            }

           
        }
    }
}
