using System;
using System.Drawing;
using PdfSharp.Drawing;

namespace jeza.Item.Tracker.Gui
{
    public class Renderer
    {
        /// <summary>
        /// Renders the content of the page.
        /// </summary>
        public void Render(XGraphics gfx)
        {
            double x = 50, y = 100;
            XFont fontH1 = new XFont("Times", 18, XFontStyle.Bold);
            XFont font = new XFont("Times", 12);
            XFont fontItalic = new XFont("Times", 12, XFontStyle.BoldItalic);
            double ls = font.GetHeight(gfx);

            // Draw some text
            gfx.DrawString("This is Header", fontH1, XBrushes.Black, x, x);
            y += ls;
            gfx.DrawString("This is normal.", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString("This is Italic.", fontItalic, XBrushes.Black, x, y);
            
            XGraphicsState state = gfx.Save();
            gfx.Restore(state);
        }
    }
}