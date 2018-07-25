using UnityEngine;

namespace Revival
{
    public interface IInput
    {
        bool GetMouseButton(int button);

        bool GetMouseButtonDown(int button);

        bool GetMouseButtonUp(int button);

        Vector3 mousePosition { get; }

        Vector2 mouseScrollDelta { get; }

        bool mousePresent { get; }

        void Start();
    }
}