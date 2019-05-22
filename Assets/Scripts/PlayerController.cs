using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public int health;
	public int immunityFrames;
	public int knockbackForceMultiplier;
	public Transform Gun;
	private int currentImmunityFrames;

    // Start is called before the first frame update
    void Start()
    {
        currentImmunityFrames = immunityFrames;
    }

    // Update is called once per frame
    void Update()
    {
		if(health > 0) 
		{
			Vector3 mouse = Input.mousePosition;
			Ray castPoint = Camera.main.ScreenPointToRay(mouse);
			Vector3 lookDirection = castPoint.direction;
			lookDirection.y = 0;
			Quaternion rotation = Quaternion.LookRotation(lookDirection);
			transform.rotation = rotation;
			
			Vector3 gunPosition = transform.position;
			Vector3 right = -Vector3.Cross(lookDirection, Vector3.up).normalized * (transform.localScale.x / 2 + 0.25f);
			gunPosition += right;
			gunPosition.y += 0.5f;
			GetComponent<GunPlaceholder>().position = gunPosition;
			GetComponent<GunPlaceholder>().rotation = rotation;
		}
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
	
	public void GrabGunOrTakeAmmo(Transform a_Gun, Transform a_GunTable)
	{
		if(Gun != null && Gun.name == a_Gun.name) 
		{
			Gun.GetComponent<GunController>().TransferAmmo(a_Gun);
		}
		else
		{
			a_GunTable.GetComponent<GunTableController>().Gun = Gun;
			if(Gun != null) 
			{
				Gun.GetComponent<GunController>().Owner = a_GunTable;
			}
			Gun = a_Gun;
			Gun.GetComponent<GunController>().Owner = this.transform;
		}
	}
}
