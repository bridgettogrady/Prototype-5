using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelData levelData;
    public GameObject notePrefab;
    public static GameManager Instance;
    public GameObject player;
    public Vector3 playerStartPosition;
    public AudioSource backgroundMusic; 
    public int score = 0;

    private bool gameStarted = false;

    void Update()
    {
        if (!gameStarted && Input.anyKeyDown)
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        backgroundMusic.Play(); 
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes() 
    {
        float startTime = Time.time; 
        foreach (var noteData in levelData.notes)
        {
            // wait for the note to be played
            float waitTime = noteData.time - (Time.time - startTime);
            if (waitTime > 0)
            {
                yield return new WaitForSeconds(waitTime);
            }

            // spawn the note
            if (notePrefab != null)
            {
                GameObject note = Instantiate(notePrefab, noteData.position, Quaternion.identity);
                note.GetComponent<MusicNote>().Player = player;
            }
        }
    }

    void RestartGame()
    {
        // reset player position
        player.transform.position = playerStartPosition;
        
        score = 0;

        // destroy all notes
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
        foreach (var note in notes)
        {
            Destroy(note);
        }

        // stop and restart background music
        backgroundMusic.Stop();
        backgroundMusic.Play();

        // restart game
        gameStarted = false;
    }

    public void AddScore(int points)
    {
        score += points;
    }

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}