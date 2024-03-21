using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Snap : MonoBehaviour
{
    public string id = "0";
    public bool isSnapped = false;

    public Sprite connectedSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isSnapped)
        {
            return;
        }

        if (col.gameObject.tag == id)
        {
            GetComponent<SpriteRenderer>().sprite = connectedSprite;
            Destroy(col.gameObject);
            isSnapped = true;

            Destroy(gameObject.GetComponent<BoxCollider2D>());
            gameObject.AddComponent<BoxCollider2D>();
        }
    }
}
