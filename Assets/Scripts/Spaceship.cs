using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {
	
	void Update ()
    {
        Vector3 v = new Vector3(GetComponentInParent<OrbitorPlayer>().tempInput.x, GetComponentInParent<OrbitorPlayer>().tempInput.y, 0);

        var pos = ProjectPointOnPlane(transform.position, transform.position, transform.position + v.normalized);
        transform.LookAt(pos, transform.position + v.normalized);

        if (v.normalized.x != 0 && transform.position.z < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x - 90f, transform.rotation.eulerAngles.y , transform.rotation.eulerAngles.z));

            if (v.normalized.x == 1)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x + 90f, transform.rotation.eulerAngles.y , transform.rotation.eulerAngles.z));
                if (transform.position.x > 0)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180f, transform.rotation.eulerAngles.z));
                }
            }
            if (v.normalized.x == -1)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x - 90f, transform.rotation.eulerAngles.y , transform.rotation.eulerAngles.z));
                //if (transform.position.x > 0)
                //{
                //    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180f, transform.rotation.eulerAngles.z));
                //}
            }

            if (v.normalized.y < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x - 180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
            }
        }
    }

    private Vector3 ProjectPointOnPlane( Vector3 planeNormal, Vector3 planePoint , Vector3 point)
    {
        planeNormal.Normalize();
        var distance = -Vector3.Dot(planeNormal.normalized, (point - planePoint));
        return point + planeNormal * distance;
    }
}
