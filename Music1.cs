using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music1 : MonoBehaviour
{
	private void Awake()
	{
		GameObject[] musicobj = GameObject.FindGameObjectsWithTag("GameMusic");
		if (musicobj.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}