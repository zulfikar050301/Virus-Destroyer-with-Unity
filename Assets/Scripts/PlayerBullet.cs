using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;  //bullet speed
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the bullet's current position
        Vector2 position = transform.position;

        //compute the bullet's new position 
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //update the bullet's position
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1, 1));

        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //mendetekksi collision  dengan musuh atau  peluru musuh
        if((col.tag == "EnemyShipTag"))
        {
            //menghancurkan  peluru   ini
            Destroy(gameObject);
        }
    }
}
