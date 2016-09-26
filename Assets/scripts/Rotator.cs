using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	private float speed = 200;

	private void Update () {
		transform.localEulerAngles = new Vector3 (
			transform.localEulerAngles.x,
			transform.localEulerAngles.y,
			transform.localEulerAngles.z + speed * Time.deltaTime
		);
	}
}