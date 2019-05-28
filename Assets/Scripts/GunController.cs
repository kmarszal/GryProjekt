using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	public int ammo { get; set; }
	public int clipSize;
	public int reloadTime;
	public Transform Owner { get; set; }
	public float bulletVelocity;
	public int damage;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if(Owner != null)
		{
			transform.position = Owner.GetComponent<GunPlaceholder>().position;
			Quaternion rotation = Owner.GetComponent<GunPlaceholder>().rotation;
			if(rotation != null) 
			{
				transform.rotation = rotation;
			}
			
			if (Input.GetMouseButtonDown(0)) 
			{
				GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Cube);
				bullet.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
				bullet.transform.position = transform.position;
				BulletController bc = bullet.AddComponent<BulletController>() as BulletController;
				bc.damage = damage;
				bullet.AddComponent<Rigidbody>();
				Vector3 bulletDirection = rotation * new Vector3(0, 0, 1);
				bullet.GetComponent<Rigidbody>().AddForce(bulletDirection * bulletVelocity);
			}
		}
    }
	
	public void TransferAmmo(Transform a_Gun)
	{
		ammo += a_Gun.GetComponent<GunController>().ammo;
		a_Gun.GetComponent<GunController>().ammo = 0;
	}
}
