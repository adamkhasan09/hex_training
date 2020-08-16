using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public delegate void msg(string text);
    public delegate string getmsg();
    class Program
    {
        static Random rnd = new Random();
        static int hl;
        static int ll;
        static OutData _out = new OutData();
        static msg method_out = WriteText;
        static getData _get = new getData();
        static getmsg method_in = getText;
        static void Main(string[] args)
        {
            c_out("Добро пожаловать в приложение hex training");
            hl = 255;
            ll = 0;
            int choice = menuChoice(); 
        }
        static int menuChoice()
        {

            c_out("Выберете формат тренировки");
            c_out("1 - hex to int, 2 int to hex, 3 - настройка диапазона");
            c_out("LowLimit = " + ll + " HighLimit = " + hl);
            int typeTrain = int.Parse(c_get());
            if (typeTrain == 1)
                hexToInt();
            if (typeTrain == 2)
                intToHex();
            if (typeTrain == 3)
                ChangeLimits();
            return typeTrain;
        }
        static void c_out(string str)
        {
            _out.msg(str, method_out);
        }
        static string c_get()
        {
         return _get.getText(method_in);
        }
        static int hexToInt()
        {
            string str;
            int num;
            int returnMenu;
            do
            {
                num = rnd.Next(ll, hl);
                c_out("0x" + num.ToString("X"));
                str = c_get();
                c_out("Правильный ответ в int = " + num.ToString());
                c_out("0 чтобы закончить, 1 чтобы выйти в меню, enter чтобы продолжить");
                str = c_get();
                returnMenu = str == "1" ? 1 : 0;
            } while (str != "0" && str != "1");
            if (returnMenu == 1)
                menuChoice();
            return 0;
        }
        static int intToHex()
        {
            string str;
            int num;
            int returnMenu;
            do
            {
                num = rnd.Next(ll, hl);
                c_out("int = " + num);
                str = c_get();
                c_out("Правильный ответ в 0x" + num.ToString("X"));
                c_out("0 чтобы закончить, 1 чтобы выйти в меню, enter чтобы продолжить");
                str = c_get();
                returnMenu = str == "1" ? 1 : 0;
            } while (str != "0" && str != "1");
            if (returnMenu == 1)
                menuChoice();
            return 0;
        }
        static void ChangeLimits()
        {
            c_out("Введите нижний придел:");
            ll = int.Parse(c_get());
            c_out("Введите верхний придел:");
            hl = int.Parse(c_get());
            menuChoice();
        }
        static void WriteText(string text)
        //сигнатура данного метода должна совпадать с делегатом 
        {
            Console.WriteLine(text); //выбранный метод вывода
        }
        static string getText()
        //сигнатура данного метода должна совпадать с делегатом 
        {
            return Console.ReadLine();//выбранный метод ввода
        }

    }
    class OutData
    {
        public void msg(string text, msg method_out)
        {
            method_out(text);
        }
    }
    class getData
    {
        public string getText(getmsg method_in)
        {
            return method_in();
        }
    }
}
