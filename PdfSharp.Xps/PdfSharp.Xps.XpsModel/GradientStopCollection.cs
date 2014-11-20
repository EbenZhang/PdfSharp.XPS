using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace PdfSharp.Xps.XpsModel
{
  internal static class GradientStopCollectionHelper
  {
    public static bool HasTransparency(this GradientStopCollection collection)
    {
      for (int idx = 0; idx < collection.Count; idx++)
      {
        if (collection[idx].Color.A != 255)
          return true;
      }
      return false;
    }
    /// <summary>
    /// HACK: Gets the average alpha value.
    /// </summary>
    public static double GetAverageAlpha(this GradientStopCollection collection)
    {
      double result = 0;
      for (int idx = 0; idx < collection.Count; idx++)
      {
        var clr = collection[idx].Color;
        result += clr.A / 255.0;
      }
      result /= collection.Count;
      return result;
    }
  }

}