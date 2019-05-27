using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{	
	public List<Node> FinalPath;
	public float speed;
	public int damage;
	public Transform Player;
	public float damageRadius;
	public int knockbackForceMultiplier;
	public int health;

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if(health > 0) 
		{
			if(FinalPath != null && FinalPath.Count > 1) 
			{
				float moveHorizontal = 1;
				float moveVertical = 1;
				
				Node target = FinalPath[1];
				if(target.vPosition.x - transform.position.x > 1) 
				{
					moveHorizontal = 1;
				}
				else if(target.vPosition.x - transform.position.x < -1) 
				{
					moveHorizontal = -1;
				}
				if(target.vPosition.z - transform.position.z > 1) {
					moveVertical = 1;
				}
				else if(target.vPosition.z - transform.position.z < -1) {
					moveVertical = -1;
				}
				
				Vector3 movement = new Vector3(moveHorizontal*speed*Time.deltaTime,0.0f,moveVertical*speed*Time.deltaTime);
				transform.position = transform.position + movement;
			}
			if(Vector3.Distance(transform.position, Player.transform.position) <= damageRadius)
			{
				Player.GetComponent<PlayerController>().Damage(damage, transform.position);
			}
		}
    }
	
	public void Damage(int amount, Vector3 takenFrom)
	{
		if (health > 0) 
		{
			Vector3 knockback = transform.position - takenFrom;
			knockback.y = 0.25f;
			knockback = Vector3.Normalize(knockback) * amount * knockbackForceMultiplier;
			health -= amount;
			if(health <= 0) {
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			}
			GetComponent<Rigidbody>().AddForce(knockback);
		}
	}
}
