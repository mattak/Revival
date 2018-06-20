using System.Collections.Generic;

namespace Revival
{
    public interface IInputLogger
    {
        IList<Log> Logs { get; }
        float StartTime { get; }
    }
}