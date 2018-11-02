using PlutoRover.Logic;

namespace PlutosRover.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Testing methods
            //var pluto = new Pluto(null)
            //{
            //    SurfaceArea = new int[4, 4]
            //    { { 0, 1, 0, 0 },
            //      { 0, 0, 1, 0 },
            //      { 1, 1, 0, 0 },
            //      { 0, 0, 0, 0 } }
            //};

            //for(int i = 0; i <= pluto.SurfaceArea.GetLength(0) - 1; i++) {
            //    for(int j = 0; j <= pluto.SurfaceArea.GetLength(1) - 1; j++)
            //    {
            //        System.Console.Write("{0} ", pluto.SurfaceArea[i, j]);
            //    }
            //    System.Console.WriteLine();
            //}

            var pluto = new Pluto(null);
            var rover = new Rover(pluto, "");
            rover.ExecuteRoute();

            System.Console.ReadLine();
        }
    }
}
