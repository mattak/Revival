using System.Collections.Generic;
using UnityEngine;

namespace Revival
{
    public interface IInputReplayer : IInput
    {
        IInputLogger Logger { get; }
        int StartFrame { get; }
    }

    public static class IInputReplayerExtension
    {
        public static int GetPassedFrame(this IInputReplayer replayer)
        {
            return Time.frameCount - replayer.StartFrame;
        }

        public static IEnumerable<Log> GetLogs(this IInputReplayer replayer, InputTag tag)
        {
            return replayer.Logger.LogMap.GetOrDefault(tag)?.GetOrDefault(replayer.GetPassedFrame());
        }
    }
}