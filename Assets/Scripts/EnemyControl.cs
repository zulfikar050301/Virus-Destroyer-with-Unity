using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject scoreUITextGO; //text ui score
    public GameObject ExplosionGO; //ledakan kapal musuh
    float speed; //kecepatan musuh

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f; //ngatur speed
        scoreUITextGO = GameObject.FindGameObjectWithTag ("ScoreTextTag"); //get the sscore text ui
    }

    // Update is called once per frame
    void Update()
    {
        //posisi normal musuh
        Vector2 position = transform.position;

        //posisi baru  musuh
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //update posisi  musuh
        transform.position = position;

        //bottom-left point on  sscreen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //jika musuh  diluar layar bagian bawah maka hancurkan
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //mendeteksi  collision antara kapal musuh dengan player, atau pluru player
        if((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            //add 100 point ke score
            scoreUITextGO.GetComponent<GameScore>().Score += 100;
            //matiiin kapal musuh
            Destroy(gameObject);
        }    
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        //mengatur posisi ledakan
        explosion.transform.position = transform.position;
    }
}
