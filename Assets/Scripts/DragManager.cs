using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    public static DragManager instance;

    DragableItem currentDarggingItem;
    Camera camera;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            //Release
        }
        else if (Input.GetMouseButtonDown(0)) { 
            //Select
        }

        if (currentDarggingItem!=null) {
            Vector3 mousePos =Vector3.zero;
            try
            {
                mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            }
            catch (Exception e) {
                Debug.Log("ex -error- : " + e.Message);
                return;
            }
            mousePos.z = 0;
            currentDarggingItem.transform.position = mousePos;
        }
    }
}
