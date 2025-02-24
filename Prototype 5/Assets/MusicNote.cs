using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour
{
    private Transform child;
    private float currScale;
    private bool isScaling = true;
    private bool circleFull = false;

    // public variables
    public float expansionRate = 1.01f;
    public float maxScale = 1.2f;
    public float waitTime = 1f;
    public Vector2 originalScale;
    public GameObject player;
    private PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        child = transform.Find("Circle");
        currScale = 1f;
        playerMove = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isScaling) {
            float newScale = currScale * expansionRate;
            if (newScale > maxScale) { // exceeded scale
                isScaling = false;
                StartCoroutine(Wait());
            }
            else { // adjust scale
                child.transform.localScale = new Vector2(newScale, newScale);
                currScale = newScale;
            }            
        }

    }

    // for you in case you need to reset the music note for the next note
    private void Reset() {
        child.transform.localScale = originalScale;
        currScale = 1f;
        circleFull = false;
    }

    private IEnumerator Wait() {
        circleFull = true;
        yield return new WaitForSeconds(waitTime);
        Reset();
        isScaling = true;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("entered");
        if (circleFull) {
            Debug.Log("circle is full");
            StartCoroutine(playerMove.SetColors());
        }
    }

} 