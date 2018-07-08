using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ImageRecognition
{
    public partial class Form1 : Form
    {
        public String pathToImg;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] answers = createMatrix();
            int[,] test = createMatrix();
           

            long[,] imgArray;
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.OK)
            {
                string FilePath = ofd.FileName;
                string path = FilePath;
                Bitmap img = new Bitmap(path, true);
                Bitmap imgOriginal = new Bitmap(path, true);
                pathToImg = path;
                pictureBox2.Image = imgOriginal;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                img = convertToGray(img);
               
                imgArray = new long[img.Height, img.Width];

                for (int x = 0; x < img.Height; x++)
                {
                    for (int y = 0; y < img.Width; y++)
                    {
                        Color clr = img.GetPixel(y, x);


                        if(Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30 )
                        {
                            imgArray[x,y] = 1;
                        }
                        else
                            imgArray[x, y] = 0;
                    }
                }
                for (int i = 0; i < img.Height; i++)
                {
                    for (int j = 0; j < img.Width; j++)
                    {
                        Console.Write(string.Format("{0}", imgArray[i, j]));
                    }
                    Console.Write(Environment.NewLine );
                }
                progressBar1.Value = 10;
                test = detectFigure(img, imgArray);
                progressBar1.Value = progressBar1.Value+50;
                getResults(answers,test);
                progressBar1.Value = 100;
                
                testType.Text = FilePath.Split('\\').Last();
                /*for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(string.Format("{0} ", test[i, j]));
                        
                    }
                    Console.Write(Environment.NewLine);
                }
                Console.Write(Environment.NewLine);
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(string.Format("{0} ", answers[i, j]));
                        
                    }
                    Console.Write(Environment.NewLine);
                }
                */
                // Console.ReadLine();
            }

        }
        private void getResults(int[,] answers,int[,] test)
        {
            int mark = 0;
            for(int i=0;i<7;i++)
            {
                for(int j=0;j<4;j++)
                {
                    if(answers[i,j] == 1 && test[i, j] == 1)
                    {
                        if (i == 0) { wrong1.Hide(); corect1.Show(); }
                        else if (i == 1) { wrong2.Hide(); corect2.Show(); }
                        else if (i == 2) { wrong3.Hide(); corect3.Show(); }
                        else if (i == 3) { wrong4.Hide(); corect4.Show(); }
                        else if (i == 4) { wrong5.Hide(); corect5.Show(); }
                        else if (i == 5) { wrong6.Hide(); corect6.Show(); }
                        else if (i == 6) { wrong7.Hide(); corect7.Show(); }
                        j = 0;
                        mark++;
                   //     MessageBox.Show(i + " " + j);
                        break;

                    }
                    else
                    {
                        if      (i == 0) wrong1.Show();
                        else if (i == 1) wrong2.Show();
                        else if (i == 2) wrong3.Show();
                        else if (i == 3) wrong4.Show();
                        else if (i == 4) wrong5.Show();
                        else if (i == 5) wrong6.Show();
                        else if (i == 6) wrong7.Show();
                    }
                }
               
            }
            markText.Text = "3+" + mark+" = "+(mark+3);
            
        }
        private int[,]  createMatrix()
        {
            int[,] matrix = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            // 1
            if (A1.Checked)
            {
                matrix[0, 0] = 1;
            }
            else if(B1.Checked)
            {
                matrix[0, 1] = 1;
            }
            else if (C1.Checked)
            {
                matrix[0, 2] = 1;
            }
            else 
            {
                matrix[0, 3] = 1;
            }
            // 2
            if (A2.Checked)
            {
                matrix[1, 0] = 1;
            }
            else if (B2.Checked)
            {
                matrix[1, 1] = 1;
            }
            else if (C2.Checked)
            {
                matrix[1, 2] = 1;
            }
            else
            {
                matrix[1, 3] = 1;
            }
            // 3
            if (A3.Checked)
            {
                matrix[2, 0] = 1;
            }
            else if (B3.Checked)
            {
                matrix[2, 1] = 1;
            }
            else if (C3.Checked)
            {
                matrix[2, 2] = 1;
            }
            else
            {
                matrix[2, 3] = 1;
            }

            //4
            if (A4.Checked)
            {
                matrix[3, 0] = 1;
            }
            else if (B4.Checked)
            {
                matrix[3, 1] = 1;
            }
            else if (C4.Checked)
            {
                matrix[3, 2] = 1;
            }
            else
            {
                matrix[3, 3] = 1;
            }
            // 5
            if (A5.Checked)
            {
                matrix[4, 0] = 1;
            }
            else if (B5.Checked)
            {
                matrix[4, 1] = 1;
            }
            else if (C5.Checked)
            {
                matrix[4, 2] = 1;
            }
            else
            {
                matrix[4, 3] = 1;
            }
            // 6
            if (A6.Checked)
            {
                matrix[5, 0] = 1;
            }
            else if (B6.Checked)
            {
                matrix[5, 1] = 1;
            }
            else if (C6.Checked)
            {
                matrix[5, 2] = 1;
            }
            else
            {
                matrix[5, 3] = 1;
            }
            // 7
            if (A7.Checked)
            {
                matrix[6, 0] = 1;
            }
            else if (B7.Checked)
            {
                matrix[6, 1] = 1;
            }
            else if (C1.Checked)
            {
                matrix[6, 2] = 1;
            }
            else
            {
                matrix[6, 3] = 1;
            }

            return matrix;
        }
        private int[,] detectFigure(Bitmap img,long [,]arr)
        {
            //top corner
            int[,] matrix = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            int[,] Top1,Top2;
            Top1 = new int[40, 160];
            Top2 = new int[50, 160];
            int Top1Fillment = 0;
            int Top1NoFill = 0;
            int Top2Fillment = 0;
            int Top2NoFill = 0;

          //  MessageBox.Show(img.Width.ToString()+" "+img.Height.ToString());
            //top corner 1 -_-
            for (int x = 37; x <= 57; x++)
            {
                for (int y = 38; y <= 110; y++)
                {

                    arr[x, y] = 2;
                    Color clr = img.GetPixel(x, y);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        Top1Fillment++;
                    }
                    else
                        Top1NoFill++;
                }
            }
            //top corner 2 | |
            for (int x = 57; x <= 125; x++)
            {
                for (int y = 38; y < 56; y++)
                {
                    arr[x, y] = 2;
                    Color clr = img.GetPixel(x, y);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        Top2Fillment++;
                    }
                    else
                        Top2NoFill++;
                }
            }
           // MessageBox.Show(Top1Fillment.ToString() + " " + Top1NoFill.ToString());
          //  MessageBox.Show(Top2Fillment.ToString() + " " + Top2NoFill.ToString());
           
            // BOTTOM =======================================
            int BottomLeft1Fill = 0;
            int BottomLeft1NoFill = 0;
            int BottomLeft2Fill = 0;
            int BottomLeft2NoFill = 0;
            
            for (int x = 519; x <= 585; x++)
            { 
                for (int y = 39; y < 57; y++)
                {
                    arr[x, y] = 3;
                    Color clr = img.GetPixel(y, x);
                     if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                      {
                         BottomLeft1Fill++;
                       }
                       else
                          BottomLeft1NoFill++;
                }
            }
            //bottom corner 2 | |
            
            for (int x = 586; x < 607; x++)
            { 
                for (int y = 39; y < 112; y++)
                {
                    arr[x, y] = 3;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        BottomLeft2Fill++;
                    }
                    else
                       BottomLeft2NoFill++;
                }
            }

            // RIGHT ---- -!! ! BOTTOM =======================================
            int BottomRight1Fill = 0;
            int BottomRight1NoFill = 0;
            int BottomRight2Fill = 0;
            int BottomRight2NoFill = 0;

            for (int x = 519; x <= 585; x++)
            {
                for (int y = 423; y < 442; y++)
                {
                    arr[x, y] = 4;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        BottomRight1Fill++;
                    }
                    else
                        BottomRight1NoFill++;
                }
            }
            //right corner 2 | |

            for (int x = 586; x < 607; x++)
            {
                for (int y = 369; y < 442; y++)
                {
                    arr[x, y] = 4;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        BottomRight2Fill++;
                    }
                    else
                        BottomRight2NoFill++;
                }
            }

            // RIGHT ---- -!! ! TOP =======================================
            int TopRight1Fill = 0;
            int TopRight1NoFill = 0;
            int TopRight2Fill = 0;
            int TopRight2NoFill = 0;

            for (int x = 37; x <= 57; x++)
            {
               
                for (int y = 369; y < 442; y++)
                    {
                    arr[x, y] = 5;
                    Color clr = img.GetPixel(x, y);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        TopRight1Fill++;
                    }
                    else
                        TopRight1NoFill++;
                }
            }
            //right corner 2 | |

            for (int x = 57; x <= 125; x++)
            {
                for (int y = 423; y < 442; y++)
                {
                    arr[x, y] = 5;
                    Color clr = img.GetPixel(x, y);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        TopRight2Fill++;
                    }
                    else
                        TopRight2NoFill++;
                }
            }

            //First Row
            //1.A 
            int ADiff = 0;
            int BDiff = 0;
            int CDiff = 0;
            int DDiff = 0;
            int fill = 0;
            int nofill = 0;
            for (int x = 91; x <= 124; x++)
            {
                for (int y = 92; y < 124; y++)
                {
                    arr[x, y] = 6;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            ADiff = fill - nofill;
            fill = 0; nofill = 0;
            //1.B
            for (int x = 91; x <= 124; x++)
            {
                for (int y = 182; y < 214; y++)
                {
                    arr[x, y] = 6;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            BDiff = fill - nofill;
            fill = 0; nofill = 0;
            //1.C
            for (int x = 91; x <= 124; x++)
            {
                for (int y = 272; y < 304; y++)
                {
                    arr[x, y] = 6;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            CDiff = fill - nofill;
            fill = 0; nofill = 0;
            //1.D
            for (int x = 91; x <= 124; x++)
            {
                for (int y = 362; y < 394; y++)
                {
                    arr[x, y] = 6;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            DDiff = fill - nofill;
            fill = 0; nofill = 0;
            if (ADiff > 100) matrix[0, 0] = 1;
            else if (BDiff > 100) matrix[0, 1] = 1;
            else if (CDiff > 100) matrix[0, 2] = 1;
            else if (DDiff > 100) matrix[0, 3] = 1;

            ADiff = 0; BDiff = 0; CDiff = 0; DDiff = 0;

            //SECOND ROW
            //2.A
            for (int x = 163; x <= 196; x++)
            {
                for (int y = 92; y < 124; y++)
                {
                    arr[x, y] = 7;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            ADiff = fill - nofill;
            fill = 0; nofill = 0;
            //2.B
            for (int x = 163; x <= 196; x++)
            {
                for (int y = 182; y < 214; y++)
                {
                    arr[x, y] = 7;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            BDiff = fill - nofill;
            fill = 0; nofill = 0;
            //2.C
            for (int x = 163; x <= 196; x++)
            {
                for (int y = 272; y < 304; y++)
                {
                    arr[x, y] = 7;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            CDiff = fill - nofill;
            fill = 0; nofill = 0;
            //2.D
            for (int x = 163; x <= 196; x++)
            {
                for (int y = 362; y < 394; y++)
                {
                    arr[x, y] = 7;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            DDiff = fill - nofill;
            fill = 0; nofill = 0;
            if (ADiff > 100) matrix[1, 0] = 1;
            else if (BDiff > 100) matrix[1, 1] = 1;
            else if (CDiff > 100) matrix[1, 2] = 1;
            else if (DDiff > 100) matrix[1, 3] = 1;

            ADiff = 0; BDiff = 0; CDiff = 0; DDiff = 0;

            //THIRD ROW
            //3.A
            for (int x = 235; x <= 268; x++)
            {
                for (int y = 92; y < 124; y++)
                {
                    arr[x, y] = 8;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            ADiff = fill - nofill;
            fill = 0; nofill = 0;
            //3.B
            for (int x = 235; x <= 268; x++)
            {
                for (int y = 182; y < 214; y++)
                {
                    arr[x, y] = 8;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            BDiff = fill - nofill;
            fill = 0; nofill = 0;
            //3.C
            for (int x = 235; x <= 268; x++)
            {
                for (int y = 272; y < 304; y++)
                {
                    arr[x, y] = 8;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            CDiff = fill - nofill;
            fill = 0; nofill = 0;
            //3.D
            for (int x = 235; x <= 268; x++)
            {
                for (int y = 362; y < 394; y++)
                {
                    arr[x, y] = 8;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            DDiff = fill - nofill;
            fill = 0; nofill = 0;
            if (ADiff > 100) matrix[2, 0] = 1;
            else if (BDiff > 100) matrix[2, 1] = 1;
            else if (CDiff > 100) matrix[2, 2] = 1;
            else if (DDiff > 100) matrix[2, 3] = 1;

            ADiff = 0; BDiff = 0; CDiff = 0; DDiff = 0;
            //FORTH ROW
            //4.A
            for (int x = 307; x <= 340; x++)
            {
                for (int y = 92; y < 124; y++)
                {
                    arr[x, y] = 9;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            ADiff = fill - nofill;
            fill = 0; nofill = 0;
            //4.B
            for (int x = 307; x <= 340; x++)
            {
                for (int y = 182; y < 214; y++)
                {
                    arr[x, y] = 9;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            BDiff = fill - nofill;
            fill = 0; nofill = 0;
            //4.C
            for (int x = 307; x <= 340; x++)
            {
                for (int y = 272; y < 304; y++)
                {
                    arr[x, y] = 9;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            CDiff = fill - nofill;
            fill = 0; nofill = 0;
            //4.D
            for (int x = 307; x <= 340; x++)
            {
                for (int y = 362; y < 394; y++)
                {
                    arr[x, y] = 9;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            DDiff = fill - nofill;
            fill = 0; nofill = 0;

            if (ADiff > 100) matrix[3, 0] = 1;
            else if (BDiff > 100) matrix[3, 1] = 1;
            else if (CDiff > 100) matrix[3, 2] = 1;
            else if (DDiff > 100) matrix[3, 3] = 1;

            ADiff = 0; BDiff = 0; CDiff = 0; DDiff = 0;
            //FIFTH ROW
            //5.A
            for (int x = 379; x <= 412; x++)
            {
                for (int y = 92; y < 124; y++)
                {
                    arr[x, y] = 5;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            ADiff = fill - nofill;
            fill = 0; nofill = 0;
            //5.B
            for (int x = 379; x <= 412; x++)
            {
                for (int y = 182; y < 214; y++)
                {
                    arr[x, y] = 5;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            BDiff = fill - nofill;
            fill = 0; nofill = 0;
            //5.C
            for (int x = 379; x <= 412; x++)
            {
                for (int y = 272; y < 304; y++)
                {
                    arr[x, y] = 5;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            CDiff = fill - nofill;
            fill = 0; nofill = 0;
            //5.D
            for (int x = 379; x <= 412; x++)
            {
                for (int y = 362; y < 394; y++)
                {
                    arr[x, y] = 5;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            DDiff = fill - nofill;
            fill = 0; nofill = 0;

            if (ADiff > 100) matrix[4, 0] = 1;
            else if (BDiff > 100) matrix[4, 1] = 1;
            else if (CDiff > 100) matrix[4, 2] = 1;
            else if (DDiff > 100) matrix[4, 3] = 1;

            ADiff = 0; BDiff = 0; CDiff = 0; DDiff = 0;
            //SiXTH ROW
            //6.A
            for (int x = 451; x <= 484; x++)
            {
                for (int y = 92; y < 124; y++)
                {
                    arr[x, y] = 6;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            ADiff = fill - nofill;
            fill = 0; nofill = 0;
            //6.B
            for (int x = 451; x <= 484; x++)
            {
                for (int y = 182; y < 214; y++)
                {
                    arr[x, y] = 6;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            BDiff = fill - nofill;
            fill = 0; nofill = 0;
            //6.C
            for (int x = 451; x <= 484; x++)
            {
                for (int y = 272; y < 304; y++)
                {
                    arr[x, y] = 6;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            CDiff = fill - nofill;
            fill = 0; nofill = 0;
            //6.D
            for (int x = 451; x <= 484; x++)
            {
                for (int y = 362; y < 394; y++)
                {
                    arr[x, y] = 6;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            DDiff = fill - nofill;
            fill = 0; nofill = 0;

            if (ADiff > 100) matrix[5, 0] = 1;
            else if (BDiff > 100) matrix[5, 1] = 1;
            else if (CDiff > 100) matrix[5, 2] = 1;
            else if (DDiff > 100) matrix[5, 3] = 1;

            ADiff = 0; BDiff = 0; CDiff = 0; DDiff = 0;
            //Seventh ROW
            //7.A
            for (int x = 523; x <= 556; x++)
            {
                for (int y = 92; y < 124; y++)
                {
                    arr[x, y] = 7;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            ADiff = fill - nofill;
            fill = 0; nofill = 0;
            //7.B
            for (int x = 523; x <= 556; x++)
            {
                for (int y = 182; y < 214; y++)
                {
                    arr[x, y] = 7;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            BDiff = fill - nofill;
            fill = 0; nofill = 0;
            //7.C
            for (int x = 523; x <= 556; x++)
            {
                for (int y = 272; y < 304; y++)
                {
                    arr[x, y] = 7;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            CDiff = fill - nofill;
            fill = 0; nofill = 0;
            //7.D
            for (int x = 523; x <= 556; x++)
            {
                for (int y = 362; y < 394; y++)
                {
                    arr[x, y] = 7;
                    Color clr = img.GetPixel(y, x);
                    if (Int32.Parse(clr.R.ToString()) < 30 && Int32.Parse(clr.G.ToString()) < 30 && Int32.Parse(clr.B.ToString()) < 30)
                    {
                        fill++;
                    }
                    else
                        nofill++;
                }
            }
            DDiff = fill - nofill;
            fill = 0; nofill = 0;

            if (ADiff > 100) matrix[6, 0] = 1;
            else if (BDiff > 100) matrix[6, 1] = 1;
            else if (CDiff > 100) matrix[6, 2] = 1;
            else if (DDiff > 100) matrix[6, 3] = 1;

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    Console.Write(string.Format("{0}", arr[i, j]));
                }
                Console.Write(Environment.NewLine);
            }

             // MessageBox.Show(BottomLeft1Fill.ToString()+" " + BottomLeft1NoFill.ToString());
             // MessageBox.Show(BottomLeft2Fill.ToString() + " " + BottomLeft2NoFill.ToString());

            return matrix;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            corect1.Hide(); wrong1.Hide();
            corect2.Hide(); wrong2.Hide();
            corect3.Hide(); wrong3.Hide();
            corect4.Hide(); wrong4.Hide();
            corect5.Hide(); wrong5.Hide();
            corect6.Hide(); wrong6.Hide();
            corect7.Hide(); wrong7.Hide();

        }
        private Bitmap convertToGray(Bitmap b)
        {
            Bitmap c = new Bitmap(b);
            for (int i = 0; i < b.Width; i++)
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);

                    int r1 = c1.R;
                    int g1 = c1.G;
                    int b1 = c1.B;

                    if (r1 + g1 + b1 <= 260)
                    {
                        b.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        c.SetPixel(i, j, Color.FromArgb(255, 0, 0));
                    }
                }
            pictureBox1.Image = c;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            return b;
        }
        private Bitmap convertToGray2(Bitmap b)
        {
            Bitmap c = new Bitmap(b);
            for (int i = 0; i < b.Width; i++)
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);

                    int r1 = c1.R;
                    int g1 = c1.G;
                    int b1 = c1.B;
                    int gray = (byte)(.299 * r1 + .587 * g1 + .144 * b1);
                    c.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            pictureBox1.Image = c;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            return b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)Image.FromFile(pathToImg);
            bmp = convertToGray2(bmp);
            pictureBox2.Image = bmp;
        }
    }
}
