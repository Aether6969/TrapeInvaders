using System.Device.Gpio;
using GameEngine;
using Rasberry_Pi;
using TrapeInvaders;
using Trappeworks;

internal class Program
{
    private static void Main(string[] args)
    {
        StaircaseLedMatrix disp = new StaircaseLedMatrix(50, 100);
        StaircaseController cont = new StaircaseController();

        Game game = new Trapeworks(cont, disp);
        game.Run();
    }
}