using UnityEditor;
using UnityEngine;

namespace Revival
{
    public class RevivalEditorWindow : EditorWindow
    {
        [MenuItem("Window/Revival")]
        static void Init()
        {
            var window = (RevivalEditorWindow) GetWindow(typeof(RevivalEditorWindow), false, "Revival");
            window.Show();
        }

        void OnGUI()
        {
            if (GUILayout.Button("Replay"))
            {
                Input.Replay();
            }

            if (GUILayout.Button("Record"))
            {
                Input.Record();
            }
        }
    }
}