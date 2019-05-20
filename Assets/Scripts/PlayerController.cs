using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public int health;
	public int immunityFrames;
	public int knockbackForceMultiplier;
	private int currentImmunityFrames;

    // Start is called before the first frame update
    void Start()
    {
        currentImmunityFrames = immunityFrames;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void FixedUpdate() {
		if(currentImmunityFrames > 0) 
		{
			currentImmunityFrames -= 1;
		}
		if(health > 0) 
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			Vector3 movement = new Vector3(moveHorizontal*speed*Time.deltaTime,0.0f,moveVertical*speed*Time.deltaTime);
			//GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);
			transform.position = transform.position + movement;
		}
	}
	
	public void Damage(int amount, Vector3 takenFrom)
	{
		if (currentImmunityFrames == 0 && health > 0) 
		{
			Vector3 knockback = transform.position - takenFrom;
			knockback.y = 1;
			knockback = Vector3.Normalize(knockback) * amount * knockbackForceMultiplier;
			health -= amount;
			currentImmunityFrames = immunityFrames;
			if(health <= 0) {
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			}
			GetComponent<Rigidbody>().AddForce(knockback);
		}
	}		
}
