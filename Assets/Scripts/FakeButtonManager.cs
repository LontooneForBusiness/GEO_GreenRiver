using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FakeButtonManager : MonoBehaviour
{
    public UnityEvent onClicked;
    public Collider2D collider;

    private void OnEnable()
    {
        if (collider != null)
            collider.enabled = false;
        Invoke("CanUse", 1);
    }
    private void CanUse()
    {
        if (collider != null)
            collider.enabled = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.transform.gameObject == gameObject)
            {
                onClicked?.Invoke();
            }
        }
    }
}
