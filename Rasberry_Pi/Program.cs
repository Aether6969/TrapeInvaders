using System.Device.Gpio;
using TrapeInvaders;
using Rasberry_Pi;

internal class Program
{
    private static void Main(string[] args)
    {
        //GpioController gpioController = new GpioController();
        //gpioController.OpenPin(14, PinMode.Output);
        //gpioController.OpenPin(15, PinMode.Input);

        //bool last = false;
        //while (true)
        //{
        //    if (!last)
        //    {
        //        gpioController.Write(14, PinValue.High);
        //    }
        //    else
        //    {
        //        gpioController.Write(14, PinValue.Low);
        //    }

        //    if ((bool)gpioController.Read(15))
        //    {
        //        Console.WriteLine("y");
        //        last = true;
        //    }
        //    else
        //    {
        //        Console.WriteLine("n");
        //        last = false;
        //    }
        //}


        StaircaseLedMatrix disp = new StaircaseLedMatrix(50, 100);
        StaircaseController cont = new StaircaseController();

        Game game = new SpaceInvaders(cont, disp);
        game.Run();
    }
}