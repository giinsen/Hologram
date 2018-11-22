using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour {

    public float Speed;

	void Update () {

        this.transform.Rotate(0, Speed, 0);
	}
}
