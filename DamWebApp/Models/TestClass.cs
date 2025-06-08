using System.Runtime.InteropServices;

namespace DamWebApp.Models
{
    //DIP (IOC) 
    interface ISort
    {
        void Sort(int[] arr);
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //sort arr using BubbleSort Alg
        }
    }
    //extend
    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {

        }
    }

    class ChristSort : ISort
    {
        public void Sort(int[] arr)
        {
            
        }
    }
    //Befor
    // High Level Class (MyList) depened Low Level Class (bubbleSort)
    // Tigh Couple Depend
    //After
    // DIP : high level depend on abstract class  ,interface
    // Lossly Couple
    class MyList
    {
        int[] arr;
        ISort sortAlg;//depend 
        public MyList(ISort sortAlg)//inject Constructor
        {
            arr = new int[10];
            //sortAlg = new BubbleSort();//
            this.sortAlg = sortAlg;
        }

        public void SortList()// Inject at MEthod Scoper
        {
            sortAlg.Sort(arr);//sort arr BubbleSort
        }
    }





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

            MyList l1 = new MyList(new BubbleSort());
            MyList l2 = new MyList(new SelectionSort());
            MyList l3 = new MyList(new ChristSort());

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
