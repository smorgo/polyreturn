using System;

namespace polyreturn
{
    public class VerbResponse
    {
        public int ErrorCode {get; private set;}
        public string ErrorMessage {get; private set;}

        public VerbResponse(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public static VerbResponse OK()
        {
            return new VerbResponse(0,string.Empty);
        }
    }

    public class VerbHandler
    {
        private static Random _rnd = new Random();

        public VerbResponse Take<T,TU>(
            Action<int> onInt = null,
            Action<double> onDouble = null, 
            Action<bool> onBool = null, 
            Action<string> onString = null,
            Action<Tuple<T,TU>> onTuple = null)
        {
            // Some silly logic to return different types
            
            switch(_rnd.Next(1,6))
            {
                case 1:
                    onInt?.Invoke(_rnd.Next());
                    break;
                case 2:
                    onDouble?.Invoke(_rnd.NextDouble());
                    break;
                case 3:
                    onBool?.Invoke(_rnd.Next() % 2 == 0); 
                    break;
                case 4:
                    onString?.Invoke($"I generated {_rnd.Next()}");
                    break;
                case 5:
                    onTuple?.Invoke(new Tuple<T, TU>(default(T), default(TU)));
                    break;
                case 6:
                    return new VerbResponse(_rnd.Next(), "There was an error");
            }

            return VerbResponse.OK();
        }
    }
}