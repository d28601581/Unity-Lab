using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 10;
    [SerializeField] int damage = 10;
    public AudioSource audio;

    public Rigidbody2D rb;
    // Update is called once per frame
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "EnemyShip1"){
            other.GetComponent<EnemyShip1>().TakeDamage(damage);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(gameObject);
        } else if(other.name == "EnemyShip2"){
            other.GetComponent<EnemyShip2>().TakeDamage(damage);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(gameObject);
        }
    }
}
