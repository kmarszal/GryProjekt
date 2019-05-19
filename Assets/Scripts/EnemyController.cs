using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{	
	public List<Node> FinalPath;
	public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }
}
