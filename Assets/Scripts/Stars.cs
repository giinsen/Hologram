using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour {


	void Update ()
    {
        transform.Rotate(0, 0, 15f * Time.deltaTime);
	}
}
