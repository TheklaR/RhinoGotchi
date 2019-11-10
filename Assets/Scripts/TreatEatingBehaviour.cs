using GoogleARCore.Examples.HelloAR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatEatingBehaviour : MonoBehaviour
{
	private HelloRhinoController _helloRhinoController;

	public float eatTimeSeconds;
	public float jumpTimeSeconds;
	private Coroutine _eatingCoroutine;
	// Start is called before the first frame update
	public void Start()
	{
		_helloRhinoController = GameObject.FindObjectOfType<HelloRhinoController>();
	}

	void OnCollisionEnter(Collision collision)
	{
		//Check for a match with the specified name on any GameObject that collides with your GameObject
		if (collision.gameObject.tag == "Rhino")
		{
			//If the GameObject's tag matches the one you suggest, output this message in the console
			Debug.Log("Collision");
			_helloRhinoController.StopMovingIfNeeded();
			StartEatingApple();
		}
	}

	private void StartEatingApple()
	{
		if (_eatingCoroutine != null)
		{
			StopCoroutine(_eatingCoroutine);
		}
		_eatingCoroutine = StartCoroutine(AppleEatingCoroutine());
	}

	private IEnumerator AppleEatingCoroutine()
	{
		_helloRhinoController.SetRhinoAnimationState(RhinoAnimationState.Eating);
		yield return new WaitForSeconds(eatTimeSeconds);
		_helloRhinoController.SetRhinoAnimationState(RhinoAnimationState.Jumping);
		_helloRhinoController.HappyDance(jumpTimeSeconds);
		gameObject.SetActive(false);
	}
}
