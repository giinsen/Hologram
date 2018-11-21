using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitorPlayer : Orbitor
{
	public float speed = 3.0f;
	public int jc_ind = 0;

	private List<Joycon> joycons = new List<Joycon>();
	private Joycon joycon;


	private void Start()
	{
        joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind + 1)
        {
            Destroy(gameObject);
        }
		joycon = joycons[jc_ind];		
	}

	protected override void Update()
	{
		base.Update();
		Vector2 input = new Vector2(joycon.GetStick()[0], joycon.GetStick()[1]);
		Move(-input.y, input.x, speed);
	}
}
