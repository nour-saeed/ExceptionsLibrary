using System;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace ExceptionsLibrary
{
    
    [Serializable]
    public class BaseException : Exception
    {
        public static string Name => "ExceptionsLibrary.BaseException";

        private int _Line = 0;
        private string _MemberName = "";
        private string _FilePath = "";

        public virtual int Line => _Line;
        public virtual string MemberName => _MemberName;
        public virtual string FilePath => _FilePath;

        public BaseException(
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string name = "",
            [CallerFilePath] string path = "") : base()
        {
            this._Line = line;
            this._MemberName = name;
            this._FilePath = path;
        }

        public BaseException(string message,
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string name = "",
            [CallerFilePath] string path = "") : base(message: message)
        {
            this._Line = line;
            this._MemberName = name;
            this._FilePath = path;
        }

        public BaseException(string message, Exception innerException,
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string name = "",
            [CallerFilePath] string path = "") : base(message: message, innerException: innerException)
        {
            this._Line = line;
            this._MemberName = name;
            this._FilePath = path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info">System.Runtime.Serialization.SerializationInfo</param>
        /// <param name="context">System.Runtime.Serialization.StreamingContext</param>
        public BaseException(SerializationInfo info, StreamingContext context,
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string name = "",
            [CallerFilePath] string path = "") : base(info: info, context: context)
        {
            this._Line = line;
            this._MemberName = name;
            this._FilePath = path;
        }

        public override string ToString()
        {
            string output = $"{BaseException.Name}: {Environment.NewLine}" +
                $"Message: {Message} {Environment.NewLine}" +
                $"{this.GetInfos()}" +
                $"More Information: {this.GetOrginalToString()}";

            return output;
        }

        public string GetInfos()
        {
            return $"Time: {DateTime.Now} {Environment.NewLine}" +
                $"Method Name: {MemberName} {Environment.NewLine}" +
                $"Line Number: {Line} {Environment.NewLine}" +
                $"File path: {FilePath} {Environment.NewLine}";
        }

        public string GetStackTraceInfos() => base.StackTrace + Environment.NewLine;

        public string GetOrginalToString() => base.ToString() + Environment.NewLine;
    }
}
