using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    public NoteData[] notes; // array of notes
}

[Serializable]
public class NoteData
{
    public float time; // time to spawn the note
    public Vector2 position; // position to spawn the note
}