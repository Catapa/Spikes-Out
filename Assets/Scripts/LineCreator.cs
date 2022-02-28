using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

    public GameObject LinePrefab;

    Line activeLine;

    void Update()
    {  

        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineGO = Instantiate(LinePrefab);
            activeLine = lineGO.GetComponent<Line>();

        }

        if(Input.GetMouseButtonUp(0))
        {
            activeLine = null;
           
        }

        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
            

        }
        
    }
}
