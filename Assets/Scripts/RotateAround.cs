using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	[SerializeField] Transform target; 
	public int speed; 
	
	void Start() {
		if (target == null) 
		{
			target = gameObject.transform;
		}
	}

	void Update () {

		transform.RotateAround(target.transform.position,target.transform.up,speed * Time.deltaTime);
	}
}
