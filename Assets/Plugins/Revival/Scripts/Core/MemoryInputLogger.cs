using System.Collections.Generic;
using UnityEngine;

namespace Revival
{
    public class MemoryInputLogger : IInput, IInputLogger
    {
        public IDictionary<InputTag, IDictionary<int, IList<Log>>> LogMap { get; private set; }
        public int StartFrame { get; private set; }
        private IInput input;

        public MemoryInputLogger(IInput input)
        {
            this.input = input;
            this.LogMap = new Dictionary<InputTag, IDictionary<int, IList<Log>>>();
            this.StartFrame = Time.frameCount;
        }

        public void Start()
        {
            this.StartFrame = Time.frameCount;
        }

        public bool GetMouseButton(int button)
        {
            var value = this.input.GetMouseButton(button);
            if (value)
            {
                this.AddLog(InputTag.GetMouseButton, button, value);
            }
            return value;
        }

        public bool GetMouseButtonDown(int button)
        {
            var value = this.input.GetMouseButtonDown(button);
            if (value)
            {
                this.AddLog(InputTag.GetMouseButtonDown, button, value);
            }
            return value;
        }

        public bool GetMouseButtonUp(int button)
        {
            var value = this.input.GetMouseButtonUp(button);
            if (value)
            {
                this.AddLog(InputTag.GetMouseButtonUp, button, value);
            }
            return value;
        }

        public Vector3 mousePosition
        {
            get
            {
                var value = this.input.mousePosition;
                if (value != default(Vector3))
                {
                    this.AddLog(InputTag.mousePosition, null, value);
                }
                return value;
            }
        }

        public Vector2 mouseScrollDelta
        {
            get
            {
                var value = this.input.mouseScrollDelta;
                if (value != default(Vector2))
                {
                    this.AddLog(InputTag.mouseScrollDelta, null, value);
                }
                return value;
            }
        }

        public bool mousePresent
        {
            get
            {
                var value = this.input.mousePresent;
                if (value)
                {
                    this.AddLog(InputTag.mousePresent, null, value);
                }
                return value;
            }
        }
    }
}