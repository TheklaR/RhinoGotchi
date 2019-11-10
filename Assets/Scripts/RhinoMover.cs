using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoMover : MonoBehaviour
{
	public GameObject rhino;
	public Vector3 targetPosition;
	public Quaternion targetRotation;
	private bool isMoving = false;
	private float progress = Time.deltaTime;
    // Start is called before the first frame update
    void Start()
    {
		rhino.gameObject.GetComponent<Transform>().position = new Vector3(-10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
		{
			var current = rhino.GetComponent<Transform>().position;
			var newPos = Vector3.Lerp(current, targetPosition, progress*Time.deltaTime);
		}
    }
}
