using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTableController : MonoBehaviour
{
	public Transform initialGun;
	public Transform Gun { get; set; }
	public Transform Player;
	public int collisionIgnoreFrames;
	private int currentCollisionIgnoreFrames;
	
    // Start is called before the first frame update
    void Start()
    {
		Gun = initialGun;
		currentCollisionIgnoreFrames = 0;
		Vector3 gunPosition = transform.position;
		gunPosition.y += 1.75f;
        GetComponent<GunPlaceholder>().position = gunPosition;
    }

    // Update is called once per frame
    void Update()
    {
		if(currentCollisionIgnoreFrames != 0)
		{
			--currentCollisionIgnoreFrames;
		}
    }
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Player") 
		{
			if(Gun != null) 
			{
				Player.GetComponent<PlayerController>().GrabGunOrTakeAmmo(Gun, transform);
			}
			currentCollisionIgnoreFrames = collisionIgnoreFrames;
		}
	}
}
