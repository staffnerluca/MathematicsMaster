using PdfSharp.Fonts;
using System;
using System.Resources;

namespace MathMaster;

public class MyFontResolver : IFontResolver
{
    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        if (familyName.Equals("OpenSans", StringComparison.CurrentCultureIgnoreCase))
        {
            if (isBold && isItalic)
            {
                return new FontResolverInfo("OpenSans-BoldItalic.ttf");
            }
            else if (isBold)
            {
                return new FontResolverInfo("OpenSans-Bold.ttf");
            }
            else if (isItalic)
            {
                return new FontResolverInfo("OpenSans-Italic.ttf");
            }
            else
            {
                return new FontResolverInfo("OpenSans-Regular.ttf");
            }
        }
        return null;
    }

    public byte[] GetFont(string faceName)
    {
        var faceNamePath = Path.Join("C:\\Users\\luker\\source\\repos\\HAK-KB\\2024-swp-4it-staffnerlresch\\Fonts\\open-sans", faceName);
        using (var ms = new MemoryStream()) //kind of like a streamreader / writer ish
        {
            try
            {
                using (var fs = File.OpenRead(faceNamePath))
                {
                    fs.CopyTo(ms); //font which gets copied to my MemoryStream
                    ms.Position = 0; //font position in the stream
                    return ms.ToArray();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception($"No Font File Found - " + faceNamePath);
            }
        }
    }
}