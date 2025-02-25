using System.Collections;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public LevelData levelData;
    public GameObject notePrefab;

    private void Start()
    {
        StartCoroutine(SpawnNotes());
    }

    private IEnumerator SpawnNotes() // spawn notes at specified times
    {
        foreach (var noteData in levelData.notes)
        {
            yield return new WaitForSeconds(noteData.time);
            Instantiate(notePrefab, noteData.position, Quaternion.identity);
        }
    }
}