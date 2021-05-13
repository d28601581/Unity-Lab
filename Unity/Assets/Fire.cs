using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	[SerializeField] GameObject enemyBullet;

	[SerializeField] float fireRate;
	[SerializeField] float nextFire;

	// Use this for initialization
	void Start () {
		nextFire = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		CheckIfTimeToFire ();
	}
    public void Stopfire(){
        fireRate = 10000;
    }

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire) {
			Instantiate (enemyBullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}
		
	}

}
