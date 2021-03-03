using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation_methods
{

    delegate double F(double x);

    class OneDimentionalSearch
    {

        public double a = 0;
        public double b = 1;
        public F MinimizedFunction = null;  

        //создание объекта класса "одномерный поиск" по функции и отрезку
        public OneDimentionalSearch(double a, double b, F EnteredFunction) {
            this.a = a;
            this.b = b;
            MinimizedFunction = EnteredFunction;
        }

        public OneDimentionalSearch() { }

        public OneDimentionalSearch(F EnteredFunction) {
            MinimizedFunction = EnteredFunction;
        }

        public double Dichotomy()
        {
            //если отрезок задан наоборот, меняем концы местами
            if (b < a)
            {
                double temp = a;
                a = b;
                b = temp;
            }

            double delta = Const.EPS/10;
            double a_new = a;
            double b_new = b;
            double length;
            double x1, x2;
            int i = 0;
            Console.WriteLine("| i | X1             | Y1             | X2             | Y2             | a               | b              | b - a         | len1/len2");
            do
            {
                length = b_new - a_new;
                x1 = (a_new + b_new - delta) / 2;
                x2 = (a_new + b_new + delta) / 2;

                //вычисляем значения функции в полученных точках
                double y1 = MinimizedFunction(x1);
                double y2 = MinimizedFunction(x2);

                if (y1 > y2) { a_new = x2; }

                else if(y1 < y2) { b_new = x1; }
                
                else
                {   a_new = x1;
                    b_new = x2;
                }

                i++;

                Console.WriteLine("____________________________________________________________________________________________________________________________________________");
                Console.WriteLine("| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8}|", i, x1.ToString("E7"), MinimizedFunction(x1).ToString("E7"),
                    x2.ToString("E7"), MinimizedFunction(x2).ToString("E7"), a_new.ToString("E7"), b_new.ToString("E7"), (b_new - a_new).ToString("E7"),
                    (length / (b_new - a_new)).ToString("E7"));

            }
            while (b_new - a_new > Const.EPS);
            //возвращаем середину полученного отрезка
            return (x2+x1)/2;
        }

        public double Golden_ratio()
        {

            //если отрезок задан наоборот, меняем концы местами
            if (b < a)
            {
                double temp = a;
                a = b;
                b = temp;
            }

            double a_new = a;
            double b_new = b;
            double length = b - a;
            double x1 = a_new + (3 - Math.Sqrt(5)) * (b_new - a_new)/2;
            double x2 = a_new + (-1 + Math.Sqrt(5)) * (b_new - a_new)/2;
            double y1 = MinimizedFunction(x1);
            double y2 = MinimizedFunction(x2);
            int i = 1;
            
            do
            {
                length = b_new - a_new;
                //случай 1
                if (y1 < y2)
                {
             
                    b_new = x2;
                    x2 = x1;
                    y2 = y1;
                    x1 = a_new + (3 - Math.Sqrt(5)) * (b_new - a_new)/2;
                    y1 = MinimizedFunction(x1);

                }
                //случай 2
                else
                {
                    a_new = x1;
                    x1 = x2;
                    y1 = y2;
                    x2 = a_new + (-1 + Math.Sqrt(5)) * (b_new - a_new)/2;
                    y2 = MinimizedFunction(x2);
                }

                
                i++;
            }
            while (Math.Abs(a_new - b_new) > Const.EPS);

            //возвращаем середину полученного отрезка
            return (x1 + x2) / 2;
        }

        public double Fibonacci()
        {

            //если отрезок задан наоборот, меняем концы местами
            if (b < a)
            {
                double temp = a;
                a = b;
                b = temp;
            }

            double a_new = a;
            double b_new = b;
            double length = b - a;
            int n = 1;
            //определяем начальное n
            while (Const.Bine(n+2) < length/Const.EPS)
            {
                n++;
            }


            double x1 = a_new + Const.Bine(n) * (b_new - a_new) / Const.Bine(n+2);
            double x2 = a_new + b_new - x1;
            double y1 = MinimizedFunction(x1);
            double y2 = MinimizedFunction(x2);
            int i = 1;
            Console.WriteLine("| i | X1             | Y1             | X2             | Y2             | a               | b              | b - a         | len1/len2");
            do
            {
                length = b_new - a_new;
                //случай 1
                if (y1 < y2)
                {

                    b_new = x2;
                    x2 = x1;
                    y2 = y1;
                    x1 = a_new + Const.Bine(n - i + 1) * (b_new - a_new) / Const.Bine(n - i + 3);
                    y1 = MinimizedFunction(x1);

                }
                //случай 2
                else
                {
                    a_new = x1;
                    x1 = x2;
                    y1 = y2;
                    x2 = a_new + Const.Bine(n - i + 2) * (b_new - a_new) / Const.Bine(n - i + 3);
                    y2 = MinimizedFunction(x2);
                }

                Console.WriteLine("____________________________________________________________________________________________________________________________________________");
                Console.WriteLine("| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8}|", i, x1.ToString("E7"), MinimizedFunction(x1).ToString("E7"),
                    x2.ToString("E7"), MinimizedFunction(x2).ToString("E7"), a_new.ToString("E7"), b_new.ToString("E7"), (b_new - a_new).ToString("E7"),
                    (length / (b_new - a_new)).ToString("E7"));
                i++;

            }
            while (i<=1+n);
            Console.WriteLine("{0}\t {1}", i -1, Math.Log10(Const.EPS));
            
            //Console.WriteLine("____________________________________________________________________________________________________________________________________________");
            //возвращаем середину полученного отрезка
            return (x1 + x2) / 2;
        }

        public void Count_Interval()
        {
            double delta = 0.5;
            double x = 50;
            double y1 = MinimizedFunction(x);
            double h = delta;
            int i = 1;
            if (y1 > MinimizedFunction(x + delta))
            {
                x += delta;   
            }
            else 
            if (y1 > MinimizedFunction(x - delta))
            {
                x -= delta;
                h = -h;
            }

            while (MinimizedFunction(x) > MinimizedFunction(x + h))
            {
                h *= 2;
                x += h;
                Console.WriteLine("{0}\t {1}", x, MinimizedFunction(x));
                i++;
            }

            a = x - h;
            b = x;
            
            if (b < a)
            {
                double temp = a;
                a = b;
                b = temp;
            }

        }
    


    }
}
