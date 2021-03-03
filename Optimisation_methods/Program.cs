using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Optimisation_methods
{
    static class Const
    {
        public const double EPS = 1e-7;

        public static double Bine(int n)
        {
            return (Math.Pow((1 + Math.Sqrt(5)) / 2, n) - Math.Pow((1 - Math.Sqrt(5)) / 2, n)) / Math.Sqrt(5);
            
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            OneDimentionalSearch Minimizer = new OneDimentionalSearch(-2, 20, MinimizedFunction);
            double res = Minimizer.Dichotomy();
            
            Console.Write(res);
        }

        static double MinimizedFunction(double x)
        {
            return Math.Pow(x - 6, 2);
        }
    }
}
