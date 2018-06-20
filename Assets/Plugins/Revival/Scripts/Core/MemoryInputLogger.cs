using System.Collections.Generic;
using UnityEngine;

namespace Revival
{
    public class MemoryInputLogger : IInput, IInputLogger
    {
        private IInput input;
        
        public IList<Log> Logs { get; private set; }
        public float StartTime { get; private set; }

        public MemoryInputLogger(IInput input)
        {
            this.input = input;
            this.Logs = new List<Log>();
            this.StartTime = Time.time;
        }

        public void Record()
        {
            this.StartTime = Time.time;
        }

        public bool GetMouseButton(int button)
        {
            var value = this.input.GetMouseButton(button);

            this.Logs.Add(new Log
            {
                Time = Time.time,
                InputValue = button,
                ReturnValue = value
            });

            return value;
        }

        public bool GetMouseButtonDown(int button)
        {
            var value = this.input.GetMouseButtonDown(button);

            this.Logs.Add(new Log
            {
                Time = Time.time,
                InputValue = button,
                ReturnValue = value,
            });

            return value;
        }

        public bool GetMouseButtonUp(int button)
        {
            var value = this.input.GetMouseButtonUp(button);
            this.Logs.Add(new Log
            {
                Time = Time.time,
                InputValue = button,
                ReturnValue = value,
            });
            return value;
        }

        public Vector3 mousePosition
        {
            get
            {
                var value = this.input.mousePosition;
                this.Logs.Add(new Log
                {
                    Time = Time.time,
                    ReturnValue = value,
                });
                return value;
            }
        }

        public Vector2 mouseScrollDelta
        {
            get
            {
                var value = this.input.mouseScrollDelta;
                this.Logs.Add(new Log
                {
                    Time = Time.time,
                    ReturnValue = value,
                });
                return value;
            }
        }

        public bool mousePresent
        {
            get
            {
                var value = this.input.mousePresent;
                this.Logs.Add(new Log
                {
                    Time = Time.time,
                    ReturnValue = value,
                });
                return value;
            }
        }
    }
}