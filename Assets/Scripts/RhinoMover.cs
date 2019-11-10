using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoMover : MonoBehaviour
{
	public GameObject rhino;
	public Vector3 stopPosition;
	public Quaternion stopRotation;
	private Coroutine _coroutine;

	public float moveDuration = 4.0f;
	public float rotDuration = 1.0f;
	void Start()
	{
		_coroutine = StartCoroutine(MoveCoroutine(rhino));
	}

	public void StartMovement(Transform t)
	{
		if (_coroutine != null)
		{
			StopCoroutine(_coroutine);
		}
		_coroutine = StartCoroutine(MoveCoroutine(t));
	}

	IEnumerator MoveCoroutine(Transform transform)
	{
		Debug.Log("Starting Motion");
		float t = 0.0f;
		Vector3 startPos = transform.position;
		Quaternion startRot = transform.rotation;
		SetAnimationState(RhinoAnimationState.Jogging);
		while (t < moveDuration)
		{
			t += Time.deltaTime;
			transform.position = Vector3.Lerp(startPos, stopPosition, t / moveDuration);
			if (t < rotDuration)
			{
				transform.rotation = Quaternion.Slerp(startRot, stopRotation, t / rotDuration);
			}

			Debug.Log($"Moved to {transform.position}");
			yield return null;
		}
		transform.position = stopPosition;
		transform.rotation = stopRotation;
		SetAnimationState(RhinoAnimationState.Idle);
	}

	IEnumerator MoveCoroutine(GameObject gObject)
	{
		var transform = gObject.GetComponent<Transform>();
		return MoveCoroutine(transform);
	}

	public void SetAnimationState(RhinoAnimationState state)
	{
		var animator = rhino.GetComponent<Animator>();
		animator.SetInteger("animation", (int) state);
	}

	public enum RhinoAnimationState
	{
		Idle = 0,
		Walking = 1,
		Jogging = 2,
		Jumping = 3,
		Unknown = 4,
		Dead = 5
	}
}