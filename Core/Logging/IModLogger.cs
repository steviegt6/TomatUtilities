using System;
using log4net;

namespace TomatUtilities.Core.Logging
{
    public interface IModLogger
    {
        ILog Logger { get; }

        void Debug(object message);

        void Debug(object message, Exception exception);

        void Info(object message);

        void Info(object message, Exception exception);

        void Warn(object message);

        void Warn(object message, Exception exception);

        void Error(object message);

        void Error(object message, Exception exception);

        void Fatal(object message);

        void Fatal(object message, Exception exception);

        void PatchFailure(string type, string method, string opCode, string value = null);
    }
}