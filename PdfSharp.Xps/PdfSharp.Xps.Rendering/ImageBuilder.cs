using System.Windows.Media;
using PdfSharp.Drawing;
using System;
using System.Windows.Media.Imaging;

namespace PdfSharp.Xps.Rendering
{
  class ImageBuilder : BuilderBase
  {
    ImageBuilder(DocumentRenderingContext context) :
      base(context)
    {
    }

    public static XImage FromImageBrush(DocumentRenderingContext context, 
      ImageBrush brush)
    {
      ImageBuilder ib = new ImageBuilder(context);
      XImage xpImage = ib.Build(brush);
      return xpImage;
    }

    private XImage Build(ImageBrush brush)
    {
      //FixedPage fpage = brush.GetParent<FixedPage>();
      //if (fpage == null)
      // Debug.Assert(false);

      //FixedPayload payload = fpage.Document.Payload;  // TODO: find better way to get FixedPayload
      //Debug.Assert(Object.Equals(payload, Context.

      // Get the font object.
      // Important: font.PdfFont is not yet defined here on the first call
      //string uriString = (brush.ImageSource as BitmapImage);
      //BitmapSource bitmapSource = payload.GetImage(uriString);
      //eztodo: cache the image....
      var filePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
      using (var outStream = System.IO.File.OpenWrite(filePath))
      {
        BitmapEncoder enc = new PngBitmapEncoder();
        enc.Frames.Add(BitmapFrame.Create(brush.ImageSource as BitmapSource));
        enc.Save(outStream);
      }

      XImage xpImage = XImage.FromFile(filePath);
      return xpImage;
    }
  }
}
