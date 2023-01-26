using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStop : Interaction
{
    public KeyCode key;

    public GameObject lightObj;
    public Material dimMat;
    public Material brightMat;

    private bool isBright;
    private Animator anim;

    public GameObject canvas;
    private CanvasControl canvasControl;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        canvasControl = FindObjectOfType<CanvasControl>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        if (Input.GetKeyDown(key))
        {
            if (!canvasControl.canvasInControl.Contains(canvas))
            {
                canvasControl.canvasInControl.Add(canvas);
                canvas.SetActive(false);
            }
            
            if (isBright)
            {
                lightObj.GetComponent<MeshRenderer>().material = dimMat;
                anim.SetFloat("speed", 0f);
                isBright = false;
            }
            else
            {
                lightObj.GetComponent<MeshRenderer>().material = brightMat;
                anim.SetFloat("speed", 1f);
                isBright = true;
            }
        }
    }
}
