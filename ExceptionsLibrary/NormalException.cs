using System;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace ExceptionsLibrary
{
    public class NormalException : BaseException
    {
        public new static string Name => "ExceptionsLibrary.NormalException";

        public NormalException(
               [CallerLineNumber] int line = 0,
               [CallerMemberName] string name = "",
               [CallerFilePath] string path = ""
               ) : base(line: line, name: name, path: path)
        {
            
        }

        /// <summary>
        /// (Line: (new System.Diagnostics.StackTrace(1).GetFrame(1) as System.Diagnostics.StackFrame).GetFileLineNumber())
        /// </summary>
        /// <param name="error"></param>
        /// <param name="message"></param>
        /// <param name="Path"></param>
        /// <param name="Name"></param>
        /// <param name="Line"></param>
        public NormalException(string message,
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string name = "",
            [CallerFilePath] string path = ""
            ) : base(message: message, line: line, name: name, path: path)
        {
            
        }

        public NormalException(string message, Exception innerException,
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string name = "",
            [CallerFilePath] string path = ""
            ) : base(message: message, innerException: innerException, line: line, name: name, path: path)
        {
            
        }

        public NormalException(SerializationInfo info, StreamingContext context,
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string name = "",
            [CallerFilePath] string path = ""
            ) : base(info: info, context: context, line: line, name: name, path: path)
        {
            
        }

        public override string ToString()
        {
            string output = $"{NormalException.Name}: {base.HResult} {Environment.NewLine}" +
                   $"Message: {Message} {Environment.NewLine}" +
                   $"{this.GetInfos()}" +
                   $"More Information: {this.GetOrginalToString()}";

            return output;
        }
    }
}
