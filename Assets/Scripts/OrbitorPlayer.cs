using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitorPlayer : Orbitor
{
	public float speed = 3.0f;
	public int jc_ind = 0;
	public Vector2 startingPosition;
	public GameObject missilePrefab;


	private List<Joycon> joycons = new List<Joycon>();
	private Joycon joycon;
	private Rigidbody rb;
	private Vector2 tempInput = Vector2.zero;

	private void Start()
	{
        joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind + 1)
        {
            Destroy(gameObject);
        }
		joycon = joycons[jc_ind];	

		circleX = startingPosition.x;
		circleY = startingPosition.y;	

		rb = GetComponent<Rigidbody>();
	}

	protected override void Update()
	{
		base.Update();
		Vector2 input = new Vector2(joycon.GetStick()[0], joycon.GetStick()[1]);
		if (input != Vector2.zero) tempInput = input;
		Move(-input.y, input.x, speed);
		if (joycon.GetButtonDown(Joycon.Button.SHOULDER_1))
		{
			Shoot(tempInput);
		}
	}

	private void Shoot(Vector2 input)
	{
		GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
		missile.GetComponent<OrbitorMissile>().SetInput(input);
	}

}