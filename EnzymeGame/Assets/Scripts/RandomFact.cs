using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFact : MonoBehaviour
{

    public Sprite[] factSprites;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = factSprites[Random.Range(1, 10)];
    }
}
