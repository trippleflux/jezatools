using System;
using System.Drawing;
using System.IO;
using PdfSharp.Drawing;

namespace jeza.Item.Tracker.Gui
{
    public class Renderer
    {
        private readonly Item item;

        public Renderer()
        {
        }

        public Renderer(Item item)
        {
            this.item = item;
        }

        /// <summary>
        /// Renders the content of the page.
        /// </summary>
        public void Render(XGraphics xGraphics)
        {
            const double textPossitionX = 50;
            double textPossitionY = 100;
            const string fontFamilyName = "Times";
            const int fontSizeHeader = 18;
            const int fontSizeText = 12;

            XFont fontHeader = new XFont(fontFamilyName, fontSizeHeader, XFontStyle.Bold);
            XFont fontText = new XFont(fontFamilyName, fontSizeText);
            XFont fontItalic = new XFont(fontFamilyName, fontSizeText, XFontStyle.BoldItalic);
            double lineSpacing = fontText.GetHeight(xGraphics);

            xGraphics.DrawString("This is Header", fontHeader, XBrushes.Black, textPossitionX, textPossitionX);
            textPossitionY += lineSpacing;
            xGraphics.DrawString("This is normal.", fontText, XBrushes.Black, textPossitionX, textPossitionY);
            textPossitionY += lineSpacing;
            xGraphics.DrawString("This is Italic.", fontItalic, XBrushes.Black, textPossitionX, textPossitionY);

            textPossitionY += lineSpacing*3;

            //Bitmap bitmap = (Bitmap)Image.FromFile(@"E:\temp\klicaj.jpeg");
            XImage xImage = null;
            if (item != null)
            {
                if (item.Image != null)
                {
                    MemoryStream memoryStream = new MemoryStream(item.Image);
                    Bitmap bitmap = (Bitmap) Image.FromStream(memoryStream, true, true);
                    xImage = XImage.FromGdiPlusImage(bitmap);
                }
            }

            if (xImage != null)
            {
                XRect rcImage = new XRect(100, textPossitionY, 100, 100*Math.Sqrt(2));
                xGraphics.DrawImage(xImage, rcImage);
            }

            XGraphicsState state = xGraphics.Save();
            xGraphics.Restore(state);
        }
    }
}