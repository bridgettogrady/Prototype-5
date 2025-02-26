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
    public float destroyDelay = 0.2f;
    public Vector2 originalScale;
    private GameObject player; 
    private PlayerMove playerMove;

    public GameObject Player
    {
        get { return player; }
        set { player = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
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

    private IEnumerator Wait() {
        circleFull = true;
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay() // destroy note after delay
    {
        yield return new WaitForSeconds(destroyDelay); 
        if (circleFull) 
        {
            Debug.Log("Note destroyed due to no player hit");
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Note hit by Player");
            Destroy(gameObject); 
        }

        if (circleFull && other.CompareTag("Player"))
        {
            Debug.Log("Note hit by Player");
            playerMove.CallCoroutine();
            GameManager.Instance.AddScore(10); 
            Destroy(gameObject); 
        }

    }

} 