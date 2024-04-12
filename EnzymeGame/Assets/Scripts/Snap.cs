using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Snap : MonoBehaviour
{
    public string id = "0";
    public bool isSnapped = false;

    public Sprite connectedSprite;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isSnapped)
        {
            return;
        }

        if (col.gameObject.tag == id)
        {
            GameManager.instance.addPiece();
            GetComponent<SpriteRenderer>().sprite = connectedSprite;
            Destroy(col.gameObject);
            isSnapped = true;

            Destroy(gameObject.GetComponent<BoxCollider2D>());
            gameObject.AddComponent<BoxCollider2D>();
        }
    }
}
