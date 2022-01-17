﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable {

	//Damage Structure
	public int damagePoint = 1;
	public float pushForce = 2.0f;

	//Upgrade
	public int weaponLevel = 0;
	private SpriteRenderer spriteRenderer;


	//Swing
	private Animator anim;
	private float cooldown = 0.5f;
	private float lastSwing;



    protected override void Start()
    {
        base.Start();
		spriteRenderer = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();

    }

    protected override void Update()
    {
        base.Update();

		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			if(Time.time - lastSwing > cooldown)
			{
				lastSwing = Time.time;
				Swing();
			}	
		}
    }

	protected override void OnCollide(Collider2D coll)
	{
		if (coll.tag == "Fighter")
		{
			if (coll.name == "Player")
				return;

		
			//Create Damage Object
			Damage dmg = new Damage()
			{
				damageAmount = damagePoint,
				origin = transform.position,
				pushForce = pushForce

			};

			coll.SendMessage("RecieveDamage", dmg);
		}
		
		
	}

	private void Swing()
	{
		anim.SetTrigger("Swing");
	}
}
