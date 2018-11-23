using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitor : MonoBehaviour
{
    public float radius;
    public float poleMargin;
    public Transform globe;
    private Vector3 position;

    protected float circleY = 0;
    protected float circleX = 0;

    virtual protected void Start()
    {
        float planetScale = ParametersMgr.instance.GetParameterFloat("planetScale");
        Debug.Log(ParametersMgr.instance.GetParameterFloat("orbitHeight"));
        radius = planetScale/2.0f + ParametersMgr.instance.GetParameterFloat("orbitHeight");
    }

    virtual protected void Update()
    {
        float x = radius * Mathf.Cos(circleY) * Mathf.Cos(circleX);
        float y = radius * Mathf.Sin(circleY);
        float z = radius * Mathf.Cos(circleY) * Mathf.Sin(circleX);
        position = new Vector3(x, y, z);
        transform.position = position;

        transform.position += globe.position;   
    }


    /// <summary>
    /// Moving an object around a central sphere
    /// </summary>
    /// <param name="vertical">between -1 and 1</param>
    /// <param name="horizontal">between -1 and 1</param>
    /// <param name="speed">meter per second</param>
    /// <param name="polecap">does the movement is restricted by the pole</param>
    protected void Move(float vertical, float horizontal, float speed, bool polecap = true)
    {
        if (!polecap || Mathf.Abs(circleY + vertical * speed * Time.deltaTime) <= poleMargin)
        {
            circleY += vertical * speed * Time.deltaTime;
        }
        circleX += horizontal * speed * Time.deltaTime; 
    }

    private float CircleSum(float min, float max, float input)
    {
        float result = input;
        if (input < min)
        {
            result = max;
        }
        else if (input > max)
        {
            result = min;
        }
        return result;
    }
}