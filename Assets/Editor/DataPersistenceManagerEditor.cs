using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(DataPersistenceManager))]
public class DataPersistenceManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DataPersistenceManager manager = (DataPersistenceManager)target;

        if(GUILayout.Button("Save Data"))
        {
            manager.SaveInspectorDataToFile();
            Debug.Log("Data Saved to file!");
        }

        if(GUILayout.Button("Load Data"))
        {
            manager.LoadDataToInspector();
            Debug.Log("Data Loaded to DataPersistenceManager");
        }
    }
}
