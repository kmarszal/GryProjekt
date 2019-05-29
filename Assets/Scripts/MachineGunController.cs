using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunController : GunController
{
    public override void Update()
    {
		if(Owner != null)
		{
			transform.position = Owner.GetComponent<GunPlaceholder>().position;
			Quaternion rotation = Owner.GetComponent<GunPlaceholder>().rotation;
			if(rotation != null) 
			{
				transform.rotation = rotation;
			}
			
			if (Input.GetMouseButton(0) && reloadTimeNow == 0) 
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
}
