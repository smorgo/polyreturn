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
                        Console.WriteLine($"Take returned an int, {iValue}");},
                    onDouble : (dValue) => {
                        Console.WriteLine($"Take returned a double, {dValue}");},
                    onBool : (bValue) => {
                        Console.WriteLine($"Take returned a bool, {bValue}");},
                    onString : (sValue) => {
                        Console.WriteLine($"Take returned a string, \"{sValue}\"");},
                    onTuple : (tValue) => {
                        Console.WriteLine($"Take returned a tuple, <\"{tValue.Item1}\",{tValue.Item2}>");}
                );

                if(response.ErrorCode != 0)
                {
                    Console.WriteLine($"There was an error: {response.ErrorCode}:{response.ErrorMessage}");
                }
            }
        }
    }
}
