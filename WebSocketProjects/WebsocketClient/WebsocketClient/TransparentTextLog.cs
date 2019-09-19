using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsocketClient
{
    class TransparentTextLog : TransparentRichTextField
    {
        protected override void OnDraw()
        {
            Font font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point); //TODO: make some static folder with all these fonts
            // Sets the text's font and style and draws it
            Point textPosition = new Point(0, 0);
            this.graphics.DrawString("TEXTTAS PIESIMUIADADADAFAFACVA", font, Brushes.Blue, textPosition);
            //TextRenderer.DrawText(this.graphics ,"http://www.broculos.net", "Microsoft Sans Serif", fontSize
            //   , FontStyle.Underline, Brushes.Blue, textPosition);
        }
    }
}
