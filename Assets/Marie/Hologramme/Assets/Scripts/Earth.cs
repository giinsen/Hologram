using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour
{
    private float Speed;
    private float planetScale;
    public AnimationCurve animationCurveEnter;

    private void Start()
    {
        Speed = ParametersMgr.instance.GetParameterFloat("planetRotationSpeed");
        planetScale = ParametersMgr.instance.GetParameterFloat("planetScale");
        transform.localScale = Vector3.one * 0f;
    }

    void Update()
    {
        this.transform.Rotate(0, Speed * Time.deltaTime, 0);
        transform.localScale = Vector3.one * planetScale * animationCurveEnter.Evaluate(Time.time);
    }
}