namespace LandscapeGenerator
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White; // Белый фон
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; // Рамка
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(80, 80, 80); // Цвет фона кнопки
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Плоский стиль
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point); // Шрифт
            this.btnGenerate.ForeColor = System.Drawing.Color.White; // Цвет текста
            this.btnGenerate.Location = new System.Drawing.Point(218, 530);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 40);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(130, 130, 130); // Цвет фона кнопки
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Плоский стиль
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point); // Шрифт
            this.btnSave.ForeColor = System.Drawing.Color.White; // Цвет текста
            this.btnSave.Location = new System.Drawing.Point(392, 535);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save to";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.SeveHeightMap);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(130, 130, 130); // Цвет фона кнопки
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Плоский стиль
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point); // Шрифт
            this.btnLoad.ForeColor = System.Drawing.Color.White; // Цвет текста
            this.btnLoad.Location = new System.Drawing.Point(464, 535);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(60, 30);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load from";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.LoadHeightMap);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(105, 105, 105); // Цвет фона формы
            this.ClientSize = new System.Drawing.Size(536, 582);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point); // Шрифт формы
            this.Name = "MainForm";
            this.Text = "Landscape Generator"; // Заголовок формы
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}