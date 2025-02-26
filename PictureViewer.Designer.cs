namespace MemeVault
{
    partial class PictureViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LeftMargin = new DataJuggler.Win.Controls.Objects.PanelExtender();
            RightMargin = new DataJuggler.Win.Controls.Objects.PanelExtender();
            TopMargin = new DataJuggler.Win.Controls.Objects.PanelExtender();
            BottomMargin = new DataJuggler.Win.Controls.Objects.PanelExtender();
            Picture = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)Picture).BeginInit();
            SuspendLayout();
            // 
            // LeftMargin
            // 
            LeftMargin.Dock = DockStyle.Left;
            LeftMargin.Location = new Point(0, 0);
            LeftMargin.Name = "LeftMargin";
            LeftMargin.Size = new Size(2, 200);
            LeftMargin.TabIndex = 0;
            // 
            // RightMargin
            // 
            RightMargin.Dock = DockStyle.Right;
            RightMargin.Location = new Point(198, 0);
            RightMargin.Name = "RightMargin";
            RightMargin.Size = new Size(2, 200);
            RightMargin.TabIndex = 1;
            // 
            // TopMargin
            // 
            TopMargin.Dock = DockStyle.Top;
            TopMargin.Location = new Point(2, 0);
            TopMargin.Name = "TopMargin";
            TopMargin.Size = new Size(196, 2);
            TopMargin.TabIndex = 2;
            // 
            // BottomMargin
            // 
            BottomMargin.Dock = DockStyle.Bottom;
            BottomMargin.Location = new Point(2, 198);
            BottomMargin.Name = "BottomMargin";
            BottomMargin.Size = new Size(196, 2);
            BottomMargin.TabIndex = 3;
            // 
            // Picture
            // 
            Picture.BackgroundImageLayout = ImageLayout.Stretch;
            Picture.Dock = DockStyle.Fill;
            Picture.Location = new Point(2, 2);
            Picture.Name = "Picture";
            Picture.Size = new Size(196, 196);
            Picture.TabIndex = 4;
            Picture.TabStop = false;
            Picture.Click += Picture_Click;
            Picture.MouseEnter += Picture_MouseEnter;
            Picture.MouseLeave += Picture_MouseLeave;
            // 
            // PictureViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Picture);
            Controls.Add(BottomMargin);
            Controls.Add(TopMargin);
            Controls.Add(RightMargin);
            Controls.Add(LeftMargin);
            Name = "PictureViewer";
            Size = new Size(200, 200);
            ((System.ComponentModel.ISupportInitialize)Picture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataJuggler.Win.Controls.Objects.PanelExtender LeftMargin;
        private DataJuggler.Win.Controls.Objects.PanelExtender RightMargin;
        private DataJuggler.Win.Controls.Objects.PanelExtender TopMargin;
        private DataJuggler.Win.Controls.Objects.PanelExtender BottomMargin;
        private PictureBox Picture;
    }
}
