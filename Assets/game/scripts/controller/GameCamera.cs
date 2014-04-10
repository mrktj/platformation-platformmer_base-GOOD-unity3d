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
			float y = IncrementTowards(transform.position.y, target.position.y + 4, trackSpeed);
			transform.position = new  Vector3(x, y, transform.position.z);
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
