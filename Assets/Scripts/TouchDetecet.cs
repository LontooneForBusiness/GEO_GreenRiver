using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TouchDetecet : MonoBehaviour
{
    public LayerMask touchableMask;
    public static event Action<GameObject> OnTouched;
    public static event Action<GameObject> OnTouchEnded;
    Camera camera;
    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            //RaycastHit2D hit = Physics2D.Raycast(mousePos, camera.transform.forward, 999, touchableMask);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity, touchableMask);
            
            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    OnTouched?.Invoke(hits[i].collider.gameObject);
                    Debug.Log(hits[i].collider.gameObject.name);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity, touchableMask);
            
            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    OnTouchEnded?.Invoke(hits[i].collider.gameObject);
                }
            }
        }
    }

}
