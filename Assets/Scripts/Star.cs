using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed; //speed of the leaf

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //posisi normal daun
        Vector2 position = transform.position;

        //Menghitung perubahan posisi daun
        position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

        //mengupdate posisi daun
        transform.position = position;

        //bottom-left point of screen
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

        //top-right point dari screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        //jika daun keluar dari layar bagian bawah
        //kemudian posisi daun ada di pojok layar
        //dan secara random berada di  kanan dan kiri dari  layar
        if(transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
    }
}
