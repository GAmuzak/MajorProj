using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tester))]
public class TesterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Tester tester = target as Tester;
        
        if(GUILayout.Button("Activate"))
        {
            tester.Activate(out string message);
            Debug.Log(message);
        }
        
        if(GUILayout.Button("Deactivate")) tester.Deactivate();
        
        DrawDefaultInspector();
    }
}
