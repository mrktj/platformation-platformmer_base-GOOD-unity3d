using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour 
{
	private BoxCollider collider;
	private Vector3 s;
	private Vector3 c;
	private Vector3 originalSize;
	private Vector3 originalCenter;
	private float colliderScale;

	private int collDivX = 3;
	private int collDivY = 10;

	private float skin = 0.005f;

	[HideInInspector]
	public bool playerStopped;
	[HideInInspector]
	public bool grounded;
	public LayerMask collisionMask;

	Ray ray;
	RaycastHit hit;

//	void Start()
//	{
//		collider = GetComponent<BoxCollider>();
//		colliderScale = transform.localScale.x;
//
//		originalSize = collider.size;
//		originalCenter = collider.center;
//		setCollider(originalSize, originalCenter);
//	}
//
//	public void Move(Vector2 moveAmount)
//	{
//		float deltaX = moveAmount.x;
//		float deltaY = moveAmount.y;
//		Vector2 p = transform.position;
//
//		grounded = false;
//
//		for (int i = 0; i < collDivX; i++) 
//		{
//			float dir = Mathf.Sign(deltaY);
//			float x = (p.x + c.x - s.x/2) + s.x/(collDivX - 1) * i;
//			float y = p.y + c.y + s.y/2 * dir;
//
//			ray = new Ray(new Vector2(x, y), new Vector2(0, dir));
//
//			Debug.DrawRay(ray.origin, ray.direction);
//
//			if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaY) + skin, collisionMask))
//			{
//				float dist = Vector3.Distance(ray.origin, hit.point);
//
//				if (dist > skin)
//				{
//					deltaY = dist * dir - skin * dir;
//				}
//				else
//				{
//					deltaY = 0;
//				}
//
//				grounded = true;
//				break;
//			}
//		}
//
//		playerStopped = false;
//
//		for (int i = 0; i < collDivY; i++) 
//		{
//			float dir = Mathf.Sign(deltaX);
//			float x = p.x + c.x + s.x/2 * dir;
//			float y = p.y + c.y - s.y/2 + s.y/(collDivY - 1) * i;
//			
//			ray = new Ray(new Vector2(x, y), new Vector2(dir, 0));
//			
//			Debug.DrawRay(ray.origin, ray.direction);
//			
//			if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaX) + skin, collisionMask))
//			{
//				float dist = Vector3.Distance(ray.origin, hit.point);
//				
//				if (dist > skin)
//				{
//					deltaX = dist * dir - skin * dir;
//				}
//				else
//				{
//					deltaX = 0;
//				}
//
//				playerStopped = true;
//
//				break;
//			}
//		}
//
//		Vector3 playerDir = new Vector3(deltaX, deltaY);
//		Vector3 o = new Vector3(p.x + c.x + s.x/2 * Mathf.Sign(deltaX), p.y + c.y + s.y/2 * Mathf.Sign(deltaY));
//
//		ray = new Ray(o, playerDir.normalized);
//
//		Debug.DrawRay(o, playerDir.normalized);
//
//		if (!grounded && !playerStopped) 
//		{
//			if (Physics.Raycast (ray, Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY), collisionMask)) {
//				grounded = true;
//				deltaY = 0;
//			}
//		}
//
//		Vector2 finalTransform = new Vector2(deltaX, deltaY);
//
//		transform.Translate(finalTransform, Space.World);
//	}
//
//	public void setCollider(Vector3 size, Vector3 center)
//	{
//		collider.size = size;
//		collider.center = center;
//
//		s = size * colliderScale;
//		c = center * colliderScale;
//	}
}
