using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float snapDist = 4f;
    public float maxX = 6f;
    public float minX = -6f;
    public float maxY = 6f;
    public float minY = -6f;
    public Color originalColor;
    public Color successColor;
    public float colorWait = 1.5f;

    private SpriteRenderer sr;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) { // up
            float newY = Mathf.Clamp(transform.position.y + snapDist, minY, maxY);
            transform.position = new Vector2(transform.position.x, newY);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { // left
            float newX = Mathf.Clamp(transform.position.x - snapDist, minX, maxX);
            transform.position = new Vector2(newX, transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { // down
            float newY = Mathf.Clamp(transform.position.y - snapDist, minY, maxY);
            transform.position = new Vector2(transform.position.x, newY);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { // right
            float newX = Mathf.Clamp(transform.position.x + snapDist, minX, maxX);
            transform.position = new Vector2(newX, transform.position.y);
        }
    }

    public IEnumerator SetColors()
    {
        sr.color = successColor;
        yield return new WaitForSeconds(colorWait);
        sr.color = originalColor;
    }
}
