using System.Device.Gpio;
using GameBackend;
using Rasberry_Pi;

internal class Program
{
    private static void Main(string[] args)
    {
        StaircaseLedMatrix disp = new StaircaseLedMatrix(50, 100);
        StaircaseController cont = new StaircaseController();

        Game game = new SpaceInvaders(cont, disp);
        game.Run();
    }
}