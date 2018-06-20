using UnityEngine;

namespace Revival
{
    public class DefaultInput : IInput
    {
        public bool GetMouseButton(int button)
        {
            return UnityEngine.Input.GetMouseButton(button);
        }

        public bool GetMouseButtonDown(int button)
        {
            return UnityEngine.Input.GetMouseButtonDown(button);
        }

        public bool GetMouseButtonUp(int button)
        {
            return UnityEngine.Input.GetMouseButtonUp(button);
        }

        public Vector3 mousePosition
        {
            get { return UnityEngine.Input.mousePosition; }
        }

        public Vector2 mouseScrollDelta
        {
            get { return UnityEngine.Input.mouseScrollDelta; }
        }

        public bool mousePresent
        {
            get { return UnityEngine.Input.mousePresent; }
        }
    }
}