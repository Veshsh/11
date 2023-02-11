using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _11
{
    class Board
    {
        public static bool[,] XO = new bool[3, 3];//true-крестик
        public static bool[,] XOClik = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };
        public static bool[,] XOHave = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };
    }
    public partial class Page3 : Page, InterfaceBack
    {
        private bool move = Page2.ChoseXO;
        private bool misclic = true;
        private bool Checstart;
        public Page3()
        {
            InitializeComponent();
            {
                InitializeOrNewGame();
            }
        }
        private void InitializeOrNewGame()
        {
            Dispatcher.Invoke(() => PrintBlock.Text = "");
            Board.XOHave = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };
            move = Page2.ChoseXO;
            if (!Page2.ChoseXO)
            {
                move = !move;
                Bot();
            }
            Print();
        }
        private void PrintWin()
        {
            if (Checstart)
            {
                Dispatcher.Invoke(() => Print());//Многопоточность.............................................
                if (!Win())
                    Board.XOHave = new bool[3, 3] { { true, true, true }, { true, true, true }, { true, true, true } };
            }
        }
        private void LogicOut()
        {
                        Checstart = !Chec();
                        User();
                        PrintWin();
                        if (Page2.Chose12 && !Chec() && misclic)
                        {
                            Checstart = !Chec();
                            Bot();
                            PrintWin();
                        misclic=true;
                    }
                    Board.XOClik = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };
        }
        private void WinX()
        {
            Dispatcher.Invoke(() => PrintBlock.Text = "Крестики победили");
        }
        private void WinO()
        {
            Dispatcher.Invoke(() => PrintBlock.Text = "Нолики победили");
        }
        private void WinXO()
        {
            Dispatcher.Invoke(() => PrintBlock.Text = "Ничья");
        }
        private bool Win()
        {
            for (int i = 0; i < 3; i++)
                if (Board.XOHave[0, i] && Board.XOHave[1, i] && Board.XOHave[2, i])
                {
                    if (Board.XO[0, i] && Board.XO[1, i] && Board.XO[2, i])
                    {
                        WinX();
                        return false;
                    }
                    if (!Board.XO[0, i] && !Board.XO[1, i] && !Board.XO[2, i])
                    {
                        WinO();
                        return false;
                    }
                }
            for (int i = 0; i < 3; i++)
                if (Board.XOHave[i, 0] && Board.XOHave[i, 1] && Board.XOHave[i, 2])
                {
                    if (Board.XO[i, 0] && Board.XO[i, 1] && Board.XO[i, 2])
                    {
                        WinX();
                        return false;
                    }
                    if (!Board.XO[i, 0] && !Board.XO[i, 1] && !Board.XO[i, 2])
                    {
                        WinO();
                        return false;
                    }
                }

            if (Board.XOHave[0, 0] && Board.XOHave[1, 1] && Board.XOHave[2, 2])
            {
                if (Board.XO[0, 0] && Board.XO[1, 1] && Board.XO[2, 2])
                {
                    WinX();
                    return false;
                }
                if (!Board.XO[0, 0] && !Board.XO[1, 1] && !Board.XO[2, 2])
                {
                    WinO();
                    return false;
                }
            }
            if (Board.XOHave[0, 2] && Board.XOHave[1, 1] && Board.XOHave[2, 0])
            {
                if (Board.XO[0, 2] && Board.XO[1, 1] && Board.XO[2, 0])
                {
                    WinX();
                    return false;
                }
                if (!Board.XO[0, 2] && !Board.XO[1, 1] && !Board.XO[2, 0])
                {
                    WinO();
                    return false;
                }
            }

            if (Chec())
            {
                WinXO();
                return false;
            }
            return true;
        }
        private bool Chec()
        {
            if (Board.XOHave[0,0] && Board.XOHave[1, 0] && Board.XOHave[2, 0] && Board.XOHave[0,1] && Board.XOHave[1, 1] && Board.XOHave[2, 1] && Board.XOHave[0, 2] && Board.XOHave[1, 2] && Board.XOHave[2, 2])
                return  true;
                return false;
        }
        private void Bot()
        {
            int i=1, l=1;
            Random random = new Random();
            while (Board.XOHave[i, l])
            {
                i = random.Next() % 3;
                l = random.Next() % 3;
            }
            Board.XOHave[i, l] = true;
            Board.XO[i, l] = move;
            move = !move;
        }
        private void User()
        {
            misclic = false;
            for (int i = 0; i < 3; i++)
                for (int l = 0; l < 3; l++)
                {
                    if (Board.XOClik[i, l] && !Board.XOHave[i, l])
                    {
                        Board.XOHave[i, l] = true;
                        Board.XO[i, l] = move;
                        Board.XOClik[i, l] = false;
                        move = !move;
                        misclic = true;
                    }
                }
        }
        private void Print()
        {
 
                    if (Board.XOHave[0, 0])
                        if (Board.XO[0, 0])
                            XOButton1.Content = "X";
                        else
                            XOButton1.Content = "O";
                    if (Board.XOHave[1, 0])
                        if (Board.XO[1, 0])
                            XOButton2.Content = 'X';
                        else
                            XOButton2.Content = 'O';
                    if (Board.XOHave[2, 0])
                        if (Board.XO[2, 0])
                            XOButton3.Content = 'X';
                        else
                            XOButton3.Content = 'O';
                    if (Board.XOHave[0, 1])
                        if (Board.XO[0, 1])
                            XOButton4.Content = "X";
                        else
                            XOButton4.Content = "O";
                    if (Board.XOHave[1, 1])
                        if (Board.XO[1, 1])
                            XOButton5.Content = 'X';
                        else
                            XOButton5.Content = 'O';
                    if (Board.XOHave[2, 1])
                        if (Board.XO[2, 1])
                            XOButton6.Content = 'X';
                        else
                            XOButton6.Content = 'O';
                    if (Board.XOHave[0, 2])
                        if (Board.XO[0, 2])
                            XOButton7.Content = "X";
                        else
                            XOButton7.Content = "O";
                    if (Board.XOHave[1, 2])
                        if (Board.XO[1, 2])
                            XOButton8.Content = 'X';
                        else
                            XOButton8.Content = 'O';
                    if (Board.XOHave[2, 2])
                        if (Board.XO[2, 2])
                            XOButton9.Content = 'X';
                        else
                            XOButton9.Content = 'O'; 
        }
        public void Back(object sender, RoutedEventArgs e)
        {
            Board.XOHave = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };
            NavigationService.Navigate(new Page1());
        }
        private void Again(object sender, RoutedEventArgs e)
        {
            XOButton1.Content = "";
            XOButton2.Content = "";
            XOButton3.Content = "";
            XOButton4.Content = "";
            XOButton5.Content = "";
            XOButton6.Content = "";
            XOButton7.Content = "";
            XOButton8.Content = "";
            XOButton9.Content = "";
            InitializeOrNewGame();
        }
        private void ButtonDo(int i,int l)
        {
            Board.XOClik[i, l] = true;
            LogicOut();
        }
        private void XO1(object sender, RoutedEventArgs e)
        {
            ButtonDo(0,0);
        }
        private void XO2(object sender, RoutedEventArgs e)
        {
            ButtonDo(1, 0);
        }
        private void XO3(object sender, RoutedEventArgs e)
        {
            ButtonDo(2, 0);
        }
        private void XO4(object sender, RoutedEventArgs e)
        {
            ButtonDo(0, 1);
        }
        private void XO5(object sender, RoutedEventArgs e)
        {
            ButtonDo(1, 1);
        }
        private void XO6(object sender, RoutedEventArgs e)
        {
            ButtonDo(2, 1);
        }
        private void XO7(object sender, RoutedEventArgs e)
        {
            ButtonDo(0, 2);
        }
        private void XO8(object sender, RoutedEventArgs e)
        {
            ButtonDo(1, 2);
        }
        private void XO9(object sender, RoutedEventArgs e)
        {
            ButtonDo(2, 2);
        }

    }
}
