using System.Diagnostics;
using System.IO;

namespace PdfSharp.Xps.Test
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var dir = Path.GetDirectoryName(Process.GetCurrentProcess().ProcessName);
      var sampleDir = Path.Combine(dir, "SampleXpsDocs");
      var targetDir = Path.Combine(dir, "ConvertedDocs");

      Directory.CreateDirectory(targetDir);

      var xpsFiles = Directory.GetFiles(sampleDir, "*.xps", SearchOption.TopDirectoryOnly);
      foreach (var xps in xpsFiles)
      {
        var targetFile = Path.Combine(targetDir, Path.GetFileNameWithoutExtension(xps) + ".pdf");
        PdfSharp.Xps.XpsConverter.Convert(xps, targetFile, 0);
      }

      Process.Start(targetDir);
    }
  }
}