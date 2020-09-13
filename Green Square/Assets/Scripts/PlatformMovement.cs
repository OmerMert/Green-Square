﻿using UnityEngine;

public class PlatformMovement : MonoBehaviour 
{
	private Vector3 posA;

		private Vector3 posB;

		private Vector3 nexPos;

		public float speed;

		public Transform childTransform;

		public Transform transformB;


	void Start () {
		posA = childTransform.localPosition;
		posB = transformB.localPosition;
		nexPos = posB;
	}
	

	void Update () {
	
		Move ();
	}
	private void Move ()
	{
		childTransform.localPosition = Vector3.MoveTowards (childTransform.localPosition, nexPos, speed * Time.deltaTime);

		if (Vector3.Distance (childTransform.localPosition, nexPos) <= 0.1) 
		{
			ChangeDestination ();
		}
	}

	private void ChangeDestination()
	{
		nexPos = nexPos != posA ? posA : posB;
	}

	

}
