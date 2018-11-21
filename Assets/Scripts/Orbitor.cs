using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitor : MonoBehaviour
{
    public float radius = 1.5f;
    public float poleMargin = 3.1416f / 2.0f + 0.2f;

    private float circleY = 0;
    private float circleX = 0;

    virtual protected void Update()
    {
        float x = radius * Mathf.Cos(circleY) * Mathf.Cos(circleX);
        float y = radius * Mathf.Sin(circleY);
        float z = radius * Mathf.Cos(circleY) * Mathf.Sin(circleX);
        transform.position = new Vector3(x, y, z);

        transform.up = transform.position.normalized;
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