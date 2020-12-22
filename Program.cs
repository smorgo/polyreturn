using System;

namespace polyreturn
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var handler = new VerbHandler();

            for(var ix = 0; ix < 10; ix++)
            {
                var response = handler.Take<string, int>(
                    onInt : (iValue) => { 
                        Console.WriteLine($"Take return an int, {iValue}");},
                    onDouble : (dValue) => {
                        Console.WriteLine($"Take return a double, {dValue}");},
                    onBool : (bValue) => {
                        Console.WriteLine($"Take return a bool, {bValue}");},
                    onString : (sValue) => {
                        Console.WriteLine($"Take return a string, {sValue}");},
                    onTuple : (tValue) => {
                        Console.WriteLine($"Take return a tuple, <\"{tValue.Item1}\",{tValue.Item2}>");}
                );

                if(response.ErrorCode != 0)
                {
                    Console.WriteLine($"There was an error: {response.ErrorCode}:{response.ErrorMessage}");
                }
            }
        }
    }
}
