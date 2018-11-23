using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPlayerWins : MonoBehaviour {

	void Update ()
    {
        transform.Rotate(0,15f * Time.deltaTime, 0);
	}
}
