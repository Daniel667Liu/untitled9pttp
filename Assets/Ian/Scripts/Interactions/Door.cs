using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interaction
{
    public KeyCode key;
    
    public bool isOpened;
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
            if (!isOpened)
            {
                isOpened = true;
                anim.SetFloat("speed", 1f);
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.01f)
                {
                    anim.Play("open", 0, 0f);
                    if (!canvasControl.canvasInControl.Contains(canvas))
                    {
                        canvasControl.canvasInControl.Add(canvas);
                        canvas.SetActive(false);
                    }
                }
            }
        }
        else if (Input.GetKeyUp(key))
        {
            if (isOpened) 
            { 
                isOpened = false;
                anim.SetFloat("speed", -1f);
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
                {
                    anim.Play("open", 0, 1f);
                }
            }
        }
        
    }
}
