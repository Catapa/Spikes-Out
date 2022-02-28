using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    //public GameObject player;
   
    private float lineLength;
    List<Vector2> points;

    public void UpdateLine(Vector2 mousePos)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            lineLength = 0;
            return;
        }

        if (Vector2.Distance(points.Last(), mousePos) > .1f && lineLength <= 20f)
        {
            lineLength += Vector2.Distance(points.First(), mousePos);
            SetPoint(mousePos);
           
        }

        Destroy(gameObject, 0.5f);
        

    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);


        if (points.Count > 1)
            edgeCollider.points = points.ToArray();
        

    }



   
}
