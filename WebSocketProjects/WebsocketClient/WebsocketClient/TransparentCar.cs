using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsocketClient
{
    public class TransparentCar : TransparentPanel
    {
        protected override void OnDraw()
        {
            // Gets the image from the global resources
            Image broculoImage = global::WebsocketClient.Properties.Resources.car_blue;

            // Sets the images' sizes and positions
            int width = broculoImage.Size.Width;
            int height = broculoImage.Size.Height;
            //Rectangle big = new Rectangle(0, 0, width, height);
            Rectangle small = new Rectangle(0, 0, (int)(0.1 * width),
                    (int)(0.1 * height));
            // TODO: add car image and size via methods for setuping
            // TODO: add method to resize car to the ratio of the window size pvz.: resize(double scale)

            // Draws the two images
            //this.graphics.DrawImage(broculoImage, big);
            //this.graphics.RotateTransform(45);
            this.graphics.DrawImage(broculoImage, small);
        }
    }
}
