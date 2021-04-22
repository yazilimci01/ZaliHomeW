using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZaliHomeW
{
    public partial class Form1 : Form
    {
        //int[,] GameBoardB = new int[8, 32];
        //int[,] GameBoardY = new int[8, 32];
        GameBoard[,] gameBoard = new GameBoard[8, 32];
        int sira = 1;

        int board1 = 1;
        int board2 = 1;
        int board3 = 1;
        int board4 = 1;
        int board5 = 1;
        int board6 = 1;
        int board7 = 1;
        int board8 = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sira > 64)
            {
                MessageBox.Show("Oyun Berabere Bitti");
                return;//Boncuklar bitti eşleşme yok , her şeyi 0 la yada böyle kalabilir 
            }


            Random random = new Random();
            int randomNumber = random.Next(1, 9);


            int boardsira = 0;
            if (randomNumber == 1)
                boardsira = board1;
            else if (randomNumber == 2)
                boardsira = board2;
            else if (randomNumber == 3)
                boardsira = board3;
            else if (randomNumber == 4)
                boardsira = board4;
            else if (randomNumber == 5)
                boardsira = board5;
            else if (randomNumber == 6)
                boardsira = board6;
            else if (randomNumber == 7)
                boardsira = board7;
            else if (randomNumber == 8)
                boardsira = board8;

            var item = new GameBoard();

            if (sira % 2 == 0)
                item.IsGreen = true;
            else
                item.IsWhite = true;

            gameBoard[randomNumber - 1, boardsira - 1] = item; //boncuk yerleştirildi

            string controlName = "";
            controlName = "b" + (randomNumber - 1).ToString() + "" + (boardsira - 1).ToString();

            if (sira % 2 == 0)
                ((Button)this.Controls.Find(controlName, true)[0]).BackColor = Color.Green;
            else
                ((Button)this.Controls.Find(controlName, true)[0]).BackColor = Color.White;




            if (sira % 2 == 0)//yeşil için kontrol
            {
                int kontrolY = 0; // x ekseninde kontrol
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        if (gameBoard[i, j] != null && gameBoard[i, j].IsGreen)
                            kontrolY++;
                        else
                            kontrolY = 0;

                        if (kontrolY == 4)
                        {
                            MessageBox.Show("Tebrikler Yeşil Oyuncu Kazandı");
                            return;//yeşil kazandı mesaj verdir

                        }

                    }
                }

                kontrolY = 0;//Y ekseninde de kontrol yap

                for (int i = 0; i < 32; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (gameBoard[j, i] != null && gameBoard[j, i].IsGreen)
                            kontrolY++;
                        else
                            kontrolY = 0;

                        if (kontrolY == 4)
                        {
                            MessageBox.Show("Tebrikler Yeşil Oyuncu Kazandı");
                            return;//yeşil kazandı mesaj verdir

                        }

                    }
                }
            }
            else
            {//beyaz için kontrol
                int kontrolB = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        if (gameBoard[i, j] != null && gameBoard[i, j].IsWhite)
                            kontrolB++;
                        else
                            kontrolB = 0;

                        if (kontrolB == 4)
                        {
                            MessageBox.Show("Tebrikler Beyaz Oyuncu Kazandı");
                            return;//beyaz kazandı mesaj verdir

                        }

                    }
                }

                kontrolB = 0;
                for (int i = 0; i < 32; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (gameBoard[j, i] != null && gameBoard[j, i].IsWhite)
                            kontrolB++;
                        else
                            kontrolB = 0;

                        if (kontrolB == 4)
                        {
                            MessageBox.Show("Tebrikler Beyaz Oyuncu Kazandı");
                            return;//beyaz kazandı mesaj verdir
                        }

                    }
                }

            }

            if (randomNumber == 1)
                board1++;
            else if (randomNumber == 2)
                board2++;
            else if (randomNumber == 3)
                board3++;
            else if (randomNumber == 4)
                board4++;
            else if (randomNumber == 5)
                board5++;
            else if (randomNumber == 6)
                board6++;
            else if (randomNumber == 7)
                board7++;
            else if (randomNumber == 8)
                board8++;

            sira++;


            MessageBox.Show("İşlem Bitti");//Butona ne zaman basmam gerek anlamak için koydum



        }
    }
    public class GameBoard
    {
        public bool IsWhite { get; set; }
        public bool IsGreen { get; set; }

    }




}
