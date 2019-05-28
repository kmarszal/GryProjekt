using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	public int ammo;
	public int clipSize;
	protected int ammoInClip;
	public int reloadTime;
	protected int reloadTimeNow;
	public Transform Owner { get; set; }
	public float bulletVelocity;
	public int damage;
	
    // Start is called before the first frame update
    void Start()
    {
		ammoInClip = clipSize;
    }

    // Update is called once per frame
    public virtual void Update()
    {
		if(Owner != null)
		{
			transform.position = Owner.GetComponent<GunPlaceholder>().position;
			Quaternion rotation = Owner.GetComponent<GunPlaceholder>().rotation;
			if(rotation != null) 
			{
				transform.rotation = rotation;
			}
			
			if (Input.GetMouseButtonDown(0) && reloadTimeNow == 0) 
			{
				if(ammoInClip > 0) {
					GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Cube);
					bullet.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
					bullet.transform.position = transform.position;
					BulletController bc = bullet.AddComponent<BulletController>() as BulletController;
					bc.damage = damage;
					bullet.AddComponent<Rigidbody>();
					Vector3 bulletDirection = rotation * new Vector3(0, 0, 1);
					bullet.GetComponent<Rigidbody>().AddForce(bulletDirection * bulletVelocity);
					--ammoInClip;
				}
				else if(ammo > 0)
				{
					reloadTimeNow = reloadTime;
					ammo -= clipSize;
					ammoInClip = ammo > 0 ? clipSize : clipSize + ammo;
				}
			}
			if(reloadTimeNow > 0) 
			{
				--reloadTimeNow;
			}
		}
    }
	
	public void TransferAmmo(Transform a_Gun)
	{
		ammo += a_Gun.GetComponent<GunController>().ammo;
		a_Gun.GetComponent<GunController>().ammo = 0;
	}
}
