using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsocketClient
{
    public abstract class TransparentPanel : Panel
    {
        /// <span class="code-SummaryComment"><summary></span>
        /// Drawing surface where graphics should be drawn.
        /// Use this member in the OnDraw method.
        /// <span class="code-SummaryComment"></summary></span>
        protected Graphics graphics;

        /// <span class="code-SummaryComment"><summary></span>
        /// Override this method in subclasses for drawing purposes.
        /// <span class="code-SummaryComment"></summary></span>
        abstract protected void OnDraw();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT

                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Don't paint background
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Update the private member so we can use it in the OnDraw method
            this.graphics = e.Graphics;

            // Set the best settings possible (quality-wise)
            this.graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.graphics.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.graphics.PixelOffsetMode =
                System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Calls the OnDraw subclass method
            OnDraw();
        }
    }
}
