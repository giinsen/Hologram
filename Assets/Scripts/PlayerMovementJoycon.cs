using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementJoycon : MonoBehaviour
{
    public GameObject planet;
    private List<Joycon> joycons;
    public int jc_ind = 0;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

    #if UNITY_STANDALONE
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1)
        {
            Destroy(gameObject);
        }
    #endif
    }

    void Update()
    {
        #if UNITY_STANDALONE
        Joycon j = joycons[jc_ind];

        if (joycons.Count > 0)
        {
            Debug.Log("ok");
            if (jc_ind == 0) //joy gauche
            {
                Vector3 v = new Vector3(j.GetStick()[0], 0, j.GetStick()[1]);
                Debug.Log(Vector3.Angle(v,transform.localPosition));
                transform.rotation = Quaternion.LookRotation(v.normalized);
                float horizontal = v.x * 10f * Time.deltaTime;
                float vertical = v.z * 10f * Time.deltaTime;

                Vector3 origin = Vector3.zero;

                Quaternion hg = Quaternion.AngleAxis(-horizontal, Vector3.up);
                Quaternion vg = Quaternion.AngleAxis(vertical, Vector3.up);
                Quaternion q = hg * vg;

                //transform.Translate(transform.forward * 10f * Time.deltaTime);
                //GetComponent<Rigidbody>().MovePosition(transform.forward * 10f * Time.deltaTime);
                //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(v) * 10f * Time.deltaTime);
                //planet.GetComponent<PlanetScript>().Attract(transform);
                //transform.RotateAround(planet.transform.position, v, 40f * Time.deltaTime);
            }
        }
        #endif

        #if UNITY_EDITOR
        

        #endif
    }
}
