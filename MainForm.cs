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
            
            heightMap[0, 0] = random.Next(-256, 256);

            for (int i = 1; i < width; i++)
            {
                heightMap[0, i] = heightMap[0, i - 1] + random.Next(-16, 16);
                heightMap[0, i] = Math.Clamp(heightMap[0, i], -256, 256);
            }

            for (int i = 1; i < height; i++)
            {
                heightMap[i, 0] = heightMap[i - 1, 0] + random.Next(-16, 16);
                heightMap[i, 0] = Math.Clamp(heightMap[i, 0], -256, 256);
            }

            for (int i = 1; i < width; i++)
            {
                heightMap[height - 1, i] = heightMap[height - 1, i - 1] + random.Next(-16, 16);
                heightMap[height - 1, i] = Math.Clamp(heightMap[height - 1, i], -256, 256);
            }

            for (int i = height - 2; i > 0; i--)
            {
                heightMap[i, width - 1] = heightMap[i + 1, width - 1] + random.Next(-16, 16);
                heightMap[i, width - 1] = Math.Clamp(heightMap[i, width - 1], -256, 256); 
            }

            heightMap[0, 0] = (heightMap[0, 1] + heightMap[1, 0]) / 2;

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    heightMap[x, y] = (
                        heightMap[x - 1, y] +
                        heightMap[x, y - 1] + 
                        heightMap[x - 1, y - 1]) / 3 + random.Next(-16, 16);
                    heightMap[x, y] = Math.Clamp(heightMap[x, y], -256, 256);
                }
            }

            //SmoothHeightMap();
        }

        private void SmoothHeightMap()
        {
            /*for (int k = 0; k < 5; k++){
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
            }*/
        }

        private static Color GenerateColor(int height){
            if(height < -128){
                return InterpolateColor(Color.DarkBlue, Color.Blue, height, -256, -128);
            }
            if(height < 0){
                return InterpolateColor(Color.Blue, Color.LightBlue, height, -128, 0);
            }
            if(height < 64){
                return InterpolateColor(Color.LightGreen, Color.Green, height, 0, 64);
            }
            if(height < 128){
                return InterpolateColor(Color.Green, Color.SaddleBrown, height, 64, 128);
            }
            if(height < 192){
                return InterpolateColor(Color.SaddleBrown, Color.Gray, height, 128, 192);
            }
            return InterpolateColor(Color.LightGray, Color.White, height, 192, 256);
        }

        private static Color InterpolateColor(Color color1, Color color2, int value, int min, int max){
            double ratio = (double)(value - min)/(max - min);
            int r = (int)(color1.R + (color2.R - color1.R) * ratio);
            int g = (int)(color1.G + (color2.G - color1.G) * ratio);
            int b = (int)(color1.B + (color2.B - color1.B) * ratio);
            return Color.FromArgb(r, g, b);
        }
        private void DrawHeightMap()
        {
            Bitmap bitmap = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int heightValue = heightMap[x, y];
                    Color color = GenerateColor(heightValue);
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

        private void SeveHeightMap(object sender, EventArgs e) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()){
                saveFileDialog.Filter = "JPG Image|*.jpg";
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void LoadHeightMap(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JPG Image|*.jpg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
    }
}   