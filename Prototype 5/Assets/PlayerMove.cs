using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float snapDist = 4f;
    public float maxX = 6f;
    public float minX = -6f;
    public float maxY = 6f;
    public float minY = -6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { // up
            float newY = Mathf.Clamp(transform.position.y + snapDist, minY, maxY);
            transform.position = new Vector2(transform.position.x, newY);
        }
        if (Input.GetKeyDown(KeyCode.A)) { // left
            float newX = Mathf.Clamp(transform.position.x - snapDist, minX, maxX);
            transform.position = new Vector2(newX, transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.S)) { // down
            float newY = Mathf.Clamp(transform.position.y - snapDist, minY, maxY);
            transform.position = new Vector2(transform.position.x, newY);
        }
        if (Input.GetKeyDown(KeyCode.D)) { // right
            float newX = Mathf.Clamp(transform.position.x + snapDist, minX, maxX);
            transform.position = new Vector2(newX, transform.position.y);
        }
    }
}
