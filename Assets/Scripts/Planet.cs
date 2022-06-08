using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed; //speed awannya
    public bool isMoving; //flag untuk membuat  awan scroll down screen
    Vector2 min; //bottom-left point of screen
    Vector2 max; //top-right point of screen

    void Awake()
    {
        isMoving = false;
        min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        //add the cloud sprite  half eight to max y
        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        //substract the cloud sprite half height to min y
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
            return;
        
        //mendapatkan posisi awal dari awan
        Vector2 position = transform.position;
        //menghitung posisi baru dari  awan
        position = new Vector2 (position.x, position.y + speed * Time.deltaTime);
        //update posisi awan
        transform.position = position;
        //jika awan berada pda posisi minimum  y, maka hentikan  gerakan planet
        if(transform.position.y < min.y)
        {
            isMoving = false;
        }
    }

    //Fungsi untuk mereset posisi planet
    public void ResetPosition()
    {
        transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);
    }
}
