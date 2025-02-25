#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System;

//This is the class that will be used to edit the LevelData object in the Unity Editor
[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor 
{
    private LevelData levelData;

    private void OnEnable()
    {
        levelData = (LevelData)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Add Note"))
        {
            // Add a new note to the level data
            Array.Resize(ref levelData.notes, levelData.notes.Length + 1);
            levelData.notes[levelData.notes.Length - 1] = new NoteData();
        }

        if (GUILayout.Button("Clear All Notes"))
        {
            
            levelData.notes = new NoteData[0];
        }

        
        if (GUI.changed)
        {
            EditorUtility.SetDirty(levelData); // Mark the object as "dirty" and save the changes
        }
    }

    private void OnSceneGUI()
    {
        if (levelData == null || levelData.notes == null)
            return;

        // Draw the notes in the scene view
        Handles.color = Color.green;
        foreach (var note in levelData.notes)
        {
            Vector3 position = new Vector3(note.position.x, note.position.y, 0);
            Handles.DrawSolidDisc(position, Vector3.forward, 0.2f);
            Handles.Label(position, $"Time: {note.time}");
        }
    }
}
#endif