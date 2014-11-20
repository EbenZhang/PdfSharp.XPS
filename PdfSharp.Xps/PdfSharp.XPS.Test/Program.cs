using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfSharp.Xps.Test
{
  class Program
  {
    static void Main(string[] args)
    {
      var dir = Path.GetDirectoryName(Process.GetCurrentProcess().ProcessName);
      var sampleDir = Path.Combine(dir, "SampleXpsDocs");
      var targetDir = Path.Combine(dir, "ConvertedDocs");
      Directory.CreateDirectory(targetDir);
      var xpsFiles = Directory.GetFiles(sampleDir, "*.xps", SearchOption.TopDirectoryOnly);
      foreach (var xps in xpsFiles)
      {
        var targetFile = Path.Combine(targetDir, Path.GetFileNameWithoutExtension(xps) + ".pdf");
        if (!xps.EndsWith("SharedResource.xps"))
        {
          PdfSharp.Xps.XpsConverter.Convert(xps, targetFile, 0);
        }
      }
      Process.Start(targetDir);
    }
  }
}
