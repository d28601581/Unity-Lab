using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    [SerializeField] float moveSpeed;
    [SerializeField] int damage;
    public AudioSource audio;

    public Rigidbody2D rb;

	[SerializeField] Player target;
	[SerializeField] Vector2 moveDirection;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();

		target = GameObject.FindObjectOfType<Player>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy (gameObject, 3f);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
            target.GetComponent<Player>().TakeDamage(damage);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);

			Destroy (gameObject);
		}
	}

}
