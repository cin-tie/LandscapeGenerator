using System;
using System.Drawing;
using System.Windows.Forms;

namespace LandscapeGenerator
{
    public partial class MainForm : Form
    {
        private int[,] heightMap;
        private int width = 512;
        private int height = 512;

        public MainForm()
        {
            InitializeComponent();
            GenerateHeightMap();
        }

        private void GenerateHeightMap()
        {
            heightMap = new int[width, height];
            Random random = new Random();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    heightMap[x, y] = random.Next(0, 256);
                }
            }

            SmoothHeightMap();
        }

        private void SmoothHeightMap()
        {
            for (int k = 0; k < 20; k++){
                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        heightMap[x, y] = (
                            heightMap[x - 1, y] +
                            heightMap[x + 1, y] +
                            heightMap[x, y - 1] +
                            heightMap[x, y + 1]) / 4;
                    }
                }
            }
            for (int i = 0; i < width; i++)
            {
                heightMap[0, i] = heightMap[1, i];
                heightMap[height - 1, i] = heightMap[height - 2, i];
            }

            for (int i = 0; i < height; i++)
            {
                heightMap[i, 0] = heightMap[i, 1];
                heightMap[i, width - 1] = heightMap[i, width - 2]; 
            }
        }

        private void DrawHeightMap()
        {
            Bitmap bitmap = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int heightValue = heightMap[x, y];
                    Color color = Color.FromArgb(heightValue, heightValue, heightValue);
                    bitmap.SetPixel(x, y, color);
                }
            }

            pictureBox1.Image = bitmap;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateHeightMap();
            DrawHeightMap();
        }
    }
}