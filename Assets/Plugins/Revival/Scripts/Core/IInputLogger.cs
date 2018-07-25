using System.Collections.Generic;
using UnityEngine;

namespace Revival
{
    public interface IInputLogger : IInput
    {
        IDictionary<InputTag, IDictionary<int, IList<Log>>> LogMap { get; }
        int StartFrame { get; }
    }

    public static class IInputLoggerExtension
    {
        public static int GetPassedFrame(this IInputLogger logger)
        {
            return Time.frameCount - logger.StartFrame;
        }

        public static void AddLog(this IInputLogger logger, InputTag tag, object inputValue, object returnValue)
        {
            logger.LogMap
                .GetOrSet(tag, () => new Dictionary<int, IList<Log>>())
                .GetOrSet(logger.GetPassedFrame(), () => new List<Log>())
                .Add(new Log
                {
                    Frame = logger.GetPassedFrame(),
                    InputValue = inputValue,
                    ReturnValue = returnValue
                });
        }
    }
}