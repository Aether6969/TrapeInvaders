using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Give path to an image");
        string path = Console.ReadLine()!;

        Image image = Image.FromFile(path); //he he funny warning

        Bitmap bitmap = new Bitmap(image);

        Graphics graphics = Graphics.FromImage(bitmap);

        for (int x = 0; x < bitmap.Width; x++)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                Color col = bitmap.GetPixel(x, y);
                bitmap.SetPixel(x, y, col);
            }
        }

        Console.WriteLine("save image to a path");

        string destPath = Console.ReadLine()!;

        bitmap.Save(destPath);
    }
}