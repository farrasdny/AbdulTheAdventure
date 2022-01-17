using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable {

	public Sprite emptyChest;
	public int coinAmount = 5;
	protected override void OnCollect()
	{
		if(!collected)
		{
			collected = true;
			GetComponent<SpriteRenderer>().sprite = emptyChest;
			GameManager.instance.coin += coinAmount;
			GameManager.instance.showText("+" + coinAmount + " coin !", 30, Color.yellow, transform.position, Vector3.up * 25, 1.0f);
		}
	}
}
