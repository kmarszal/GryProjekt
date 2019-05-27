using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public int damage { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject.name == "Enemy") {
			collision.gameObject.GetComponent<EnemyController>().Damage(damage, transform.position);
        }
		if(collision.gameObject.name != "Player") {
			Destroy(gameObject);
		}
    }
}
