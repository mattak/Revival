using UnityEngine;
using UnityEngine.EventSystems;

namespace Revival.Examples.MouseDemo
{
    public class MousePositionPlacer : UIBehaviour
    {
        protected override void Start()
        {
            Input.Instance = new MemoryInputLogger(new DefaultInput());
            Input.Instance.Start();
        }

        private void Update()
        {
            if (Input.Instance.GetMouseButton(0))
            {
                var position = Input.Instance.mousePosition;

                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    this.transform.parent.GetComponent<RectTransform>(),
                    position,
                    Camera.main,
                    out localPoint
                );

                UnityEngine.Debug.LogFormat("{0} {1}", position, localPoint);
                this.GetComponent<RectTransform>().localPosition = localPoint;
            }
        }
    }
}