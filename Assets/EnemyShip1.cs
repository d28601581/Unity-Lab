using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyShip1 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float x = -1;
    [SerializeField] bool isFacingRight = false;
    [SerializeField] private Vector2 screenBounds;
    [SerializeField] public Text enemyhealth;

    public Camera MainCamera;
    public int health = 100;
    public Animator animator;
    public GameObject portalPrefab;


    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        enemyhealth.text = "Enemy Health: " + health;
        rb = GetComponent<Rigidbody2D>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        enemyhealth.text = "Enemy Health: " + health;
        rb.velocity = new Vector2(x * speed, 0);
        if (x < 0 && isFacingRight || x > 0 && !isFacingRight)
		{
			Flip();
		}

        if ((isFacingRight && transform.position.x >= screenBounds.x - 0.5) || (!isFacingRight && transform.position.x <= screenBounds.x * - 1 + 0.5))
        {
            x *= -1;
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

    public void TakeDamage(int damage){
        health -= damage;


    }
    void Die(){
        x = 0;
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
