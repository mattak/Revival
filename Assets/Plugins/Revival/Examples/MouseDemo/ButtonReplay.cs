using UnityEngine;
using UnityEngine.UI;

namespace Revival
{
    [RequireComponent(typeof(Button))]
    public class ButtonReplay : MonoBehaviour
    {
        void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(this.Click);
        }

        void Click()
        {
            Input.Replay();
        }
    }
}