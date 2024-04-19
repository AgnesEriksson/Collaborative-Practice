using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.U2D;

public class Snap : MonoBehaviour
{
    public string id = "0";
    public bool isSnapped = false;

    public Sprite connectedSprite;

    public GameObject prefab;

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
            StartCoroutine(PrefabPlay());
            Destroy(col.gameObject);
            isSnapped = true;

            Destroy(gameObject.GetComponent<BoxCollider2D>());
            gameObject.AddComponent<BoxCollider2D>();
        }
    }

    IEnumerator PrefabPlay()
    {
        //GameObject go = Instantiate(prefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        //Destroy(go);
    }
}
