using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	private Transform target;
	private float trackSpeed = 10;

	public void SetTarget(Transform t)
	{
		target = t;
	}

	void LateUpdate()
	{
		if (target) 
		{
			float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
			float y = IncrementTowards(transform.position.y, target.position.y + 5, trackSpeed);
            float z = IncrementTowards(transform.position.z, target.position.z - 39, trackSpeed);
			transform.position = new  Vector3(x, y, z);
		}
	}

	private float IncrementTowards(float m, float target, float a)
	{
		if (m == target) 
		{
			return m;
		} 
		else 
		{
			float dir = Mathf.Sign(target - m);
			m += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target - m)) ? m : target;
		}
	}
}



//var camera1 : Camera;
//var camera2 : Camera;
//var camera3 : Camera;
//
//function Start () { camera1.enabled = true; camera2.enabled = false; camera3.enabled = false;
//}
//
//function Update () { if (Input.GetKeyDown ("2")){ camera1.enabled = false; camera2.enabled = true; camera3.enabled = false;
//    } if (Input.GetKeyDown ("3")){ camera1.enabled = false; camera2.enabled = false; camera3.enabled = true;
//    }
//    if (Input.GetKeyDown ("1")){ camera1.enabled = true; camera2.enabled = false; camera3.enabled = false;
//    }
//    
//    
//    
//    
//}
