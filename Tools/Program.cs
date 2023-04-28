using System.Drawing;

internal class Program
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "I canot be fucked to mange analyser setings between projects")]
    private static void Main(string[] args)
    {
        Console.WriteLine("Give path to an image");
        string path = Console.ReadLine()!;

        Image image = Image.FromFile(path);

        Bitmap bitmap = new Bitmap(image);

        Graphics graphics = Graphics.FromImage(bitmap); //some build in functions for make more complex shapes

        for (int x = 0; x < bitmap.Width; x++)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                Color col = bitmap.GetPixel(x, y);
                bitmap.SetPixel(x, y, col);
            }
        }

        Console.WriteLine("save image as a c# class to a path");

        string destPath = Console.ReadLine()!;

        destPath = Path.ChangeExtension(Path.Combine(destPath, Path.GetFileNameWithoutExtension(path)), ".cs");

        string namespaceName = "funnynamespace";

        using (var writer = new StreamWriter(destPath))
        {
            writer.WriteLine("using System.Drawing;");
            writer.WriteLine();

            writer.WriteLine("namespace " + namespaceName);
            writer.WriteLine('{');

            {
                string tab = "\t";

                writer.WriteLine(tab + "internal partial static class Textures");
                writer.WriteLine(tab + "{");

                {
                    string tab2 = tab + tab;

                    writer.WriteLine(tab2 + "public static readonly byte[] " + Path.GetFileNameWithoutExtension(path) + " =");
                    writer.WriteLine(tab2 + "new Color[" + bitmap.Width + ", " + bitmap.Height + "]");
                    writer.WriteLine(tab2 + "{");

                    {
                        string tab3 = tab + tab + tab;

                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            writer.Write(tab3);
                            for (int x = 0; x < bitmap.Width; x++)
                            {
                                Color color = bitmap.GetPixel(x, (bitmap.Height - 1 - y));
                                writer.Write($"new Color({color.R}, {color.G}, {color.B}), ");
                            }
                        }
                    }

                    writer.WriteLine(tab2 + "};");
                }

                writer.WriteLine(tab + "}");
            }
            
            writer.WriteLine('}');
        }
    }
}