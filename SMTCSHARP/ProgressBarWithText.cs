using System.Drawing;
using System.Windows.Forms;

namespace SMTCSHARP
{
    internal class ProgressBarWithText : ProgressBar
    {
        public ProgressBarWithText()
        {
            this.SetStyle(ControlStyles.UserPaint |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = this.ClientRectangle;

            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-3, -3);
            if (this.Value > 0)
            {
                Rectangle clip = new Rectangle(rect.X, rect.Y,
                    (int)((float)rect.Width * ((float)this.Value / this.Maximum)), rect.Height);
                g.FillRectangle(Brushes.LightBlue, clip);
            }

            // Gambar teks di tengah
            string text = this.Value.ToString() + "%";
            using (Font f = new Font("Arial", 10, FontStyle.Bold))
            {
                SizeF len = g.MeasureString(text, f);
                Point location = new Point((int)((rect.Width - len.Width) / 2), (int)((rect.Height - len.Height) / 2));
                g.DrawString(text, f, Brushes.Black, location);
            }
        }
    }
}
