using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoMover : MonoBehaviour
{
	public Vector3 stopPosition;
	private Coroutine _coroutine;

	public float moveDuration = 4.0f;
	void Start()
	{
		_coroutine = StartCoroutine(MoveCoroutine(rhino));
	}

	IEnumerator MoveCoroutine(GameObject gObject)
	{
		float t = 0.0f;
		Vector3 start = gObject.GetComponent<Transform>().position;

		while (t < moveDuration)
		{
			t += Time.deltaTime;
			transform.position = Vector3.Lerp(start, stopPosition, t / moveDuration);
			yield return null;
		}
	}
}