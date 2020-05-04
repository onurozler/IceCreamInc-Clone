using System;
using BezierSolution;
using UnityEngine;

public class IceCreamTest : MonoBehaviour
{
    public BezierSpline _bezierSpline;
    public GameObject iceCream;

    private void Start()
    {
       // iceCream.transform.position =_bezierSpline.GetPoint(0.7f);
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(iceCream,transform);
            // https://www.reddit.com/r/Unity3D/comments/g0e1lv/how_can_i_create_cream_like_in_ice_cream_inc/
            // Bezier Curves
            
        }
    }
}
