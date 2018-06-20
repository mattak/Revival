using UnityEngine;

namespace Revival
{
    public class MemoryInputReplayer : IInput
    {
        private IInputLogger Logger;
        private float StartTime;
        
        public MemoryInputReplayer(IInputLogger logger)
        {
            this.Logger = logger;
            this.StartTime = Time.time;
        }

        public void Replay()
        {
        }
        
        public bool GetMouseButton(int button)
        {
            this.Logger
        }

        public bool GetMouseButtonDown(int button)
        {
            throw new System.NotImplementedException();
        }

        public bool GetMouseButtonUp(int button)
        {
            throw new System.NotImplementedException();
        }

        public Vector3 mousePosition { get; private set; }
        public Vector2 mouseScrollDelta { get; private set; }
        public bool mousePresent { get; private set; }
    }
}