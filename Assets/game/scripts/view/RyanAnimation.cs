using UnityEngine;
using System.Collections;

public class RyanAnimation : MonoBehaviour {

	public Sprite[] sprites;
	public float framesPerSecond;

	private SpriteRenderer spriteRenderer;

	void Start () 
	{
		spriteRenderer = renderer as SpriteRenderer;
		renderer.castShadows = true;  
		renderer.receiveShadows = true;
	}
	
	void Update () 
	{
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % sprites.Length;
		spriteRenderer.sprite = sprites[index];
	}
}
