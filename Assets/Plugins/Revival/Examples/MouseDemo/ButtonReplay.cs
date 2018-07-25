using UnityEngine;
using UnityEngine.UI;

namespace Revival
{
    [RequireComponent(typeof(Button))]
    public class ButtonReplay : MonoBehaviour
    {
        private IInputLogger Logger;

        void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(this.Click);
        }

        void Click()
        {
            if (Input.Instance is IInputLogger)
            {
                this.Logger = (IInputLogger) Input.Instance;
                Input.Instance = new MemoryInputReplayer(this.Logger);
            }

            Input.Instance.Start();
        }
    }
}