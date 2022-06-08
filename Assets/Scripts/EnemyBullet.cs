using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed; //bullet speed
    Vector2 _direction; //the direction  of bullet
    bool isReady; //to   know when bullet direction  is set

    void Awake()
    {
        speed = 5f;
        isReady = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //fungsi  untuk mengatur arah peluru
    public void SetDirection(Vector2 direction)
    {
        //mengatur  arah agar sesuai vektor
        _direction = direction.normalized;

        isReady = true; //mengatur flag kke true
    }

    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            //posisi normal peluru
            Vector2 position = transform.position;

            //mengubah posisi   peluru
            position += _direction * speed * Time.deltaTime;

            //update posisi peluru
            transform.position = position;

            //menghancurkan  peluru jika  peluru  keluar  layar

            //untuk bottom-left point layar
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            //top right  point layar
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            //hancurkan peluru jika kluar  layar
            if((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //deteksi collision dengan player
        if(col.tag == "PlayerShipTag")
        {
            Destroy(gameObject); //hancurin peluru ini
        }
    }
}
