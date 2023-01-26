using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    //public List<GameObject> canvas;
    public List<GameObject> canvasInControl;
    // Start is called before the first frame update
    void Start()
    {
        canvasInControl = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        VisibleControl();
    }

    void VisibleControl() 
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            if (canvasInControl.Count >= 1) 
            {
                foreach (GameObject c in canvasInControl)
                {
                    c.SetActive(true);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (canvasInControl.Count >= 1)
            {
                foreach (GameObject c in canvasInControl)
                {
                    c.SetActive(false);
                }
            }
        }

    }
}
