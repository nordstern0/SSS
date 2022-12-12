using System;



namespace TextToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //Исходный текст числа
            string txtnum = "Seventy two million one hundred thirty four thousand two hundred seventy eight";
            Console.WriteLine("Text number: " + txtnum);
            //Форматирование для удобства
            txtnum = txtnum.ToLower();
            txtnum= txtnum.Trim();

            //Проверка наличия дублирующихся множителей
            string[] txtnumer = txtnum.Split(" ");
            int n = 0;
            int l = 0;
            foreach(string s in txtnumer)
            {
                if(s == "thousand")
                {
                    n++;
                    
                }
                if (s == "million")
                {
                    l++;
                }

            }
            if ((n > 1) || (l > 1)) 
            {
                Console.WriteLine("Incorrect number");
            }
            else
            {
                //Если в числе есть Миллионы и тысячи
                if ((txtnum.IndexOf("million") != -1) && (txtnum.IndexOf("thousand") != -1))
                {
                    //Отделение фрагмента с множителем миллиона
                    string el1 = txtnum.Substring(0, txtnum.IndexOf("million"));
                    el1 = JoinHundred(el1);//Слияние hundred и числа перед ним
                    el1.Trim();//Уборка лишних пробелов по краям
                    int num1 = TxtToNum(el1);//Преобразование в число
                    int num1m = num1 * 1000000;//Применение множителя
                    string el1temp = txtnum.Substring(txtnum.IndexOf("million"));//Промежуточная строка без выделенного элемента

                    //Отлеление фрагмента с тысячами
                    string el2 = el1temp.Substring(8, el1temp.IndexOf("thousand") - 8);
                    el2 = JoinHundred(el2);//Слияние hundred и числа перед ним
                    el2.Trim();//Уборка лишних пробелов по краям
                    int num2 = TxtToNum(el2);//Преобразование в число
                    int num2m = num2 * 1000;//Применение множителя
                    string el2temp = el1temp.Substring(el1temp.IndexOf("thousand"));//Промежуточная строка без выделенного элемента

                    //Отделения фрагмента без множителя
                    string el3 = el2temp.Substring(9);
                    el3 = JoinHundred(el3);//Слияние hundred и числа перед ним
                    el3.Trim();//Уборка лишних пробелов по краям
                    int num3 = TxtToNum(el3);//Преобразование в число

                    //Соеденение фрагментов и результат
                    int res = num1m + num2m + num3;
                    Console.WriteLine("Final number " + res);
                }

                //Если в числе нет миллионов, но есть тысячи
                else if (txtnum.IndexOf("thousand") != -1)
                {
                    //Отделение фрагмента с тысячей
                    string el1 = txtnum.Substring(0, txtnum.IndexOf("thousand"));
                    el1 = JoinHundred(el1);//Слияние hundred и числа перед ним
                    el1.Trim();//Уборка лишних пробелов по краям
                    int num1 = TxtToNum(el1);//Преобразование в число
                    int num1m = num1 * 1000;//Применение множителя
                    string el1temp = txtnum.Substring(txtnum.IndexOf("thousand"));//Промежуточная строка без выделенного элемента
                    //Отделение фрагмента без множителя
                    string el2 = el1temp.Substring(9);
                    el2 = JoinHundred(el2);//Уборка лишних пробелов по краям
                    el2.Trim();//Уборка лишних пробелов по краям
                    int num2 = TxtToNum(el2);//Преобразование в число

                    //Суммирование элементов
                    int res = num1m + num2;
                    Console.WriteLine("Final number " + res);
                }

                //Если в числе есть миллионы, но нет тысяч
                else if ((txtnum.IndexOf("million") != -1) && (txtnum.IndexOf("thousand") == -1))
                {
                    //Отделение фрагмента с миллионом
                    string el1 = txtnum.Substring(0, txtnum.IndexOf("million"));
                    el1 = JoinHundred(el1);
                    el1.Trim();
                    int num1 = TxtToNum(el1);
                    int num1m = num1 * 1000000;
                    string el1temp = txtnum.Substring(txtnum.IndexOf("million"));
                    //Отделение фрагмента без множителя
                    string el2 = el1temp.Substring(8);
                    el2 = JoinHundred(el2);
                    el2.Trim();
                    int num2 = TxtToNum(el2);

                    //Суммирование элемента
                    int res = num1m + num2;
                    Console.WriteLine("Final number " + res);
                }

                //Если нет ни тысяч ни миллионов
                else
                {
                    txtnum = JoinHundred(txtnum);
                    int res = TxtToNum(txtnum);

                    Console.WriteLine("Final number: " + res);
                }
            }
            
            



        }


        //Функция для слияния слова hundred с числом перед ним (one hundred -> onehundred)
        public static string JoinHundred(string str)
        {
            if(str.IndexOf("hundred") != -1)
            {
                string tmp1 = str.Substring(0, str.IndexOf("hundred") - 1);
                string tmp2 = str.Substring(str.IndexOf("hundred"));
                string res = string.Concat(tmp1, tmp2);
                return res;
            }
            else
            {
                return str;
            }
        }


        //Функция преобразования текста в число
        public static int TxtToNum (string str)
        {
            string[] txtstrs = str.Split(' ');
            int num = 0;
            foreach(string s in txtstrs)
            {
                switch (s)
                {
                    case "one":
                        num += 1;
                        break;
                    case "two":
                        num += 2;
                        break;
                    case "three":
                        num += 3;
                        break;
                    case "four":
                        num += 4;
                        break;
                    case "five":
                        num += 5;
                        break;
                    case "six":
                        num += 6;
                        break;
                    case "seven":
                        num += 7;
                        break;
                    case "eight":
                        num += 8;
                        break;
                    case "nine":
                        num += 9;
                        break;
                    case "ten":
                        num += 10;
                        break;
                    case "eleven":
                        num += 11;
                        break;
                    case "twelve":
                        num += 12;
                        break;
                    case "thirteen":
                        num += 13;
                        break;
                    case "fourteen":
                        num += 14;
                        break;
                    case "fifteen":
                        num += 15;
                        break;
                    case "sixteen":
                        num += 16;
                        break;
                    case "seventeen":
                        num += 17;
                        break;
                    case "eighteen":
                        num += 18;
                        break;
                    case "nineteen":
                        num += 19;
                        break;
                    case "twenty":
                        num += 20;
                        break;
                    case "thirty":
                        num += 30;
                        break;
                    case "forty":
                        num += 40;
                        break;
                    case "fifty":
                        num += 50;
                        break;
                    case "sixty":
                        num += 60;
                        break;
                    case "seventy":
                        num += 70;
                        break;
                    case "eighty":
                        num += 80;
                        break;
                    case "ninety":
                        num += 90;
                        break;
                    case "onehundred":
                        num += 100;
                        break;
                    case "twohundred":
                        num += 200;
                        break;
                    case "threehundred":
                        num += 300;
                        break;
                    case "fourhundred":
                        num += 400;
                        break;
                    case "fivehundred":
                        num += 500;
                        break;
                    case "sixhundred":
                        num += 600;
                        break;
                    case "sevenhundred":
                        num += 700;
                        break;
                    case "eighthundred":
                        num += 800;
                        break;
                    case "ninehundred":
                        num += 900;
                        break;
                    /*default:
                        Console.WriteLine("Incorrect value");
                        break;*/

                }
            }
            return num;
            

        }
    }
}
