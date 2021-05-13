using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float x, y = 1;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] public Text playerhealth;

    public int health = 100;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        playerhealth.text = "Player Health: " + health;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerhealth.text = "Player Health: " + health;

        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(x * speed, y * speed);

        if (x < 0 && isFacingRight || x > 0 && !isFacingRight)
		{
			Flip();
		}

        if(health <= 0){
            health = 0;
            Die();
        }
    }

    void Flip()
	{
		
		isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
	}



    private void OnTriggerEnter2D(Collider2D collider)
    {   
        if (collider.tag == "Enemy"){
            health -= 50;
        }
    }


    void Die(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
   
    public void TakeDamage(int damage){
        health -= damage;
    }

}
