using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	public int ammo { get; set; }
	public int clipSize;
	public int reloadTime;
	public Transform Owner { get; set; }
	private Vector3 orientation;
	
    // Start is called before the first frame update
    void Start()
    {
        orientation = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
		if(Owner != null)
		{
			transform.position = Owner.GetComponent<GunPlaceholder>().position;
		}
    }
	
	public void TransferAmmo(Transform a_Gun)
	{
		ammo += a_Gun.GetComponent<GunController>().ammo;
		a_Gun.GetComponent<GunController>().ammo = 0;
	}
}
