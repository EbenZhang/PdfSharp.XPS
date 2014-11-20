using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using PdfSharp.Internal;
using PdfSharp.Drawing;

namespace PdfSharp.Xps.XpsModel
{
  /// <summary>
  /// Represents a transformation matrix.
  /// </summary>
  static class MatrixHelper
  {
    public static XMatrix ToXMatrix(this Matrix matrix)
    {
      return new XMatrix(matrix.M11, matrix.M12, 
        matrix.M21, matrix.M22, 
        matrix.OffsetX, matrix.OffsetY);
    }
  }
}
