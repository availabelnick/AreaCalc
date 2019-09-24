using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalc
{
    class Class1
    {
        public static string err = "Вы можете рассчитать площадь круга или треугольника. Для получения дополнительной информации введите help";

        public static string Calc(string s) //Входящая строка
        {
            if (s == "help")
            {
                return "Для расчета площади круга введите 'circle r', где r-радиус круга \n" +
                      "Для расчета площади треугольника введите 'triangle a b c', где a b c - длины сторон треугольника \n" +
                      "Вы также можете получить площадь указав только значения\n" +
                      "Для выхода введите exit";                     ;
            }
            else if (s.Length > 0)
            {
                string[] m = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//Разбиваем полученную строку на слова (если написаны через запятую)
                double res;

                if (double.TryParse(m[0], out res))//Если первое слова возможно конвертировать в double
                {
                    double[] a = new double[m.Length];//Объявляем массив double для хранения полученных значений
                    int i = 0;

                    foreach (string c in m)
                    {
                        if (double.TryParse(c, out res))//Если все значения в строке будут числовыми, то записываем в массив, иначе выходим
                        {
                            a[i] = double.Parse(c);
                            i++;
                        }
                        else
                        {
                            return CalcMe("null", 0);
                        }
                    }
                    return CalcMe(a);
                }
                else//Если первое значение не число
                {
                    int i = 0;
                    double[] a = new double[m.Length - 1];//Уменьшаем размер массива, т.к. первый элемент строка

                    foreach (string c in m)
                    {
                        if (double.TryParse(c, out res))//Записываем только числа
                        {

                            a[i] = double.Parse(c);
                            i++;
                        }
                    }

                    return CalcMe(m[0], a);
                }
            }
            else
            {
                return CalcMe("null", 0);
            }
        }

        public static string CalcMe(string s, params double[] a)//Расчет площади с указанием фигуры
        {

            switch (s)
            {
                case "circle":
                    if (a.Length == 1)
                    {
                        return "Площадь круга равна " + (Math.PI * Math.Pow(a[0], 2)).ToString();
                    }
                    else
                    {
                        return "Для вычисления площади круга введите радиус";
                    }
                case "triangle":
                    if (a.Length == 3)
                    {
                        double p = (a[0] + a[1] + a[2]) / 2;
                        if ((Math.Pow(a[0], 2) == Math.Pow(a[1], 2) + Math.Pow(a[2], 2)) ||
                           (Math.Pow(a[1], 2) == Math.Pow(a[0], 2) + Math.Pow(a[2], 2)) ||
                           (Math.Pow(a[2], 2) == Math.Pow(a[0], 2) + Math.Pow(a[1], 2)))
                        {
                            return "Площадь прямоугольного треугольника равна " + (Math.Sqrt(p * (p - a[0]) * (p - a[1]) * (p - a[2]))).ToString();
                        }
                        else if (a[0] == a[1] && a[1] == a[2])
                        {
                            return "Площадь равностроннего треугольника равна " + (Math.Sqrt(p * (p - a[0]) * (p - a[1]) * (p - a[2]))).ToString();
                        }
                        else
                        {
                            return "Площадь треугольника равна " + (Math.Sqrt(p * (p - a[0]) * (p - a[1]) * (p - a[2]))).ToString();
                        }
                    }
                    else
                    {
                        return "Для вычисления площади треугольника введите длины трех его сторон";
                    }
                default:
                    return err;
            }
        }


        public static string CalcMe(params double[] a) //Расчет площади без указания фигуры
        {
            if (a.Length == 1)
            {
                return CalcMe("circle", a);
            }
            else if (a.Length == 3)
            {
                return CalcMe("triangle", a);
            }
            else
            {
                return err;
            }
        }
    }
}
