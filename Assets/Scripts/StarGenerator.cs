using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject StarGO; //prefabs untuk StarGO
    public int MaxStars; //maximum jumlah daun
    //array of colors
    Color[] starColors = {
        new Color (0.5f, 0.5f, 1f),
        new Color (0, 1f, 1f),
        new Color (1f, 1f, 0),
        new Color (1f, 0, 0),
    };
    // Start is called before the first frame update
    void Start()
    {
        //bottom-left point of  the screen
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        //this is the top-right of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        //looping untuk  daun jatuh
        for(int i = 0; i < MaxStars; ++i)
        {
            GameObject star = (GameObject)Instantiate(StarGO);
            //set leaf color
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            //st posisi dari daun pada random x dan y
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //set a random speed for leaf
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

            //make the leaf a  child of StarGeneratorGO
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
