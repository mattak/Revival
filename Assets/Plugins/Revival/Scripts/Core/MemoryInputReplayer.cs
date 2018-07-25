using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Revival
{
    public class MemoryInputReplayer : IInput
    {
        private IInputLogger Logger;
        private int StartFrame;
        private int PassedFrame => Time.frameCount - this.StartFrame;

        public MemoryInputReplayer(IInputLogger logger)
        {
            this.Logger = logger;
            this.StartFrame = Time.frameCount;
        }

        public void Start()
        {
            this.StartFrame = Time.frameCount;
        }

        public bool GetMouseButton(int button)
        {
            return this.GetButtonByTag(InputTag.GetMouseButton, button);
        }

        public bool GetMouseButtonDown(int button)
        {
            return this.GetButtonByTag(InputTag.GetMouseButtonDown, button);
        }

        public bool GetMouseButtonUp(int button)
        {
            return this.GetButtonByTag(InputTag.GetMouseButtonUp, button);
        }

        private bool GetButtonByTag(InputTag tag, int button)
        {
            return (bool?) this.GetLogs(tag)
                       ?.FirstOrDefault(it => (int) it.InputValue == button)
                       ?.ReturnValue
                   ?? false;
        }

        private IEnumerable<Log> GetLogs(InputTag tag)
        {
            return this.Logger.LogMap.GetOrDefault(tag)?.GetOrDefault(this.PassedFrame);
        }

        public Vector3 mousePosition =>
            (Vector3?) this.GetLogs(InputTag.mousePosition)?.FirstOrDefault()?.ReturnValue
            ?? Vector3.zero;

        public Vector2 mouseScrollDelta =>
            (Vector2?) this.GetLogs(InputTag.mouseScrollDelta)?.FirstOrDefault()?.ReturnValue
            ?? Vector2.zero;

        public bool mousePresent =>
            (bool?) this.GetLogs(InputTag.mousePresent)?.FirstOrDefault()?.ReturnValue
            ?? false;
    }
}