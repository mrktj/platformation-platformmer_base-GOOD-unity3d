using UnityEngine;
using System.Collections;

public class Propeller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //iTween.RotateBy(gameObject, iTween.Hash("y", 1, "easeType", iTween.EaseType.linear, "looptype", iTween.LoopType.loop));
        gameObject.RotateBy(new Vector3(0, 1, 0), 0.6f, 0, EaseType.linear, LoopType.loop);
	}
	
	// Update is called once per frame
	void Update () {


	}
}
