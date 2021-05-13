using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyShip2 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isFacingRight = false;
    [SerializeField] public Text enemyhealth;
	[SerializeField] Player target;
    [SerializeField] Vector2 moveDirection;


    public int health = 100;
    public Animator animator;
    public GameObject portalPrefab;


    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        enemyhealth.text = "Enemy Health: " + health;
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindObjectOfType<Player>();
		moveDirection = (target.transform.position - transform.position).normalized * speed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    // Update is called once per frame
    void Update()
    {
        enemyhealth.text = "Enemy Health: " + health;

        if(health <= 0){
            health = 0;
            moveDirection = new Vector2(0, 0);
            Die();
        } else {
            moveDirection = (target.transform.position - transform.position).normalized * speed;
        }
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);    


        if (moveDirection.x < 0 && isFacingRight || moveDirection.y > 0 && !isFacingRight)
		{
			Flip();
		}
    }

    void Flip()
	{
		
		isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
	}

    public void TakeDamage(int damage){
        health -= damage;


    }
    void Die(){
        animator.SetInteger("health", 0);
        gameObject.GetComponent<Fire>().Stopfire();

        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
        Instantiate(portalPrefab, new Vector3(10f, 0f, 0f), portalPrefab.gameObject.transform.rotation);
    }

}
