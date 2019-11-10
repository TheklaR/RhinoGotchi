using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace Suriyun
{
	public class AnimationScript : MonoBehaviour
	{

		public Animator animator;

		public void SetInt(int value)
		{
			Debug.Log(value);
			animator.SetInteger("animation", value);
		}
	}
}