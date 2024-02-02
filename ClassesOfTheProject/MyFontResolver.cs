using PdfSharp.Fonts;
using System;
using System.Resources;

namespace MathMaster;

public class MyFontResolver : IFontResolver //this is inheriting from IFontResolver
{
    public static string pathNow = Directory.GetCurrentDirectory(); //just getting the path the user is on

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic) //here we are just looking at which font we use.
    {
        if (familyName.Equals("OpenSans", StringComparison.CurrentCultureIgnoreCase)) //this doesn't care about the letters if they are capital or not. It compares them then
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
        var faceNamePath = Path.Join(pathNow + "\\Font\\open-sans", faceName); //here we just get the path where the font was saved
        using (var ms = new MemoryStream()) //kind of like a streamreader / writer ish; backing store is memory
        {
            try
            {
                using (var fs = File.OpenRead(faceNamePath)) //Opens the file and reads it
                {
                    fs.CopyTo(ms); //font which gets copied to my MemoryStream
                    ms.Position = 0; //font position in the stream
                    return ms.ToArray(); //just returns an Array of the MemoryStream
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("No Font File Found - " + faceNamePath); //just an Exception message
            }
        }
    }
}