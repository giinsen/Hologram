using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour
{
    private float Speed;

    private void Start()
    {
        Speed = ParametersMgr.instance.GetParameterFloat("planetRotationSpeed");
        transform.localScale = Vector3.one * ParametersMgr.instance.GetParameterFloat("planetScale");
    }

    void Update()
    {
        this.transform.Rotate(0, Speed * Time.deltaTime, 0);
    }
}