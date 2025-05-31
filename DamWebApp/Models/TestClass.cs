using System.Runtime.InteropServices;

namespace DamWebApp.Models
{
    public class MyController
    {
        object viewdata;//store 

        public object ViewData
        {
            get { return viewdata; } 
            set {  viewdata = value; }
        }

        // another property wrap the same field viewdata
        public dynamic ViewBag
        {
            get { return viewdata; }
            set { viewdata = value; }
        }
    }



    public class TestClass
    {
        public void test(dynamic c)
        {
            MyController c1 = new MyController();
            c1.ViewData = "ahmed";
            Console.WriteLine();


            dynamic d1 = 1;
            dynamic d2 = "ahmed";
            dynamic d3 = new Student();

            d1 = d2 + d3; //compilation   ,detect type during runtime exception
        }
    }
}
