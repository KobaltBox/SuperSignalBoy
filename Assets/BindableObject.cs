using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BindableObject : MonoBehaviour
{
    public PointerEventData cursorPos;

    public Button boundButton;
    public LineRenderer lineRenderer;
    public Camera cam;
    public bool dragging;
    public Vector3 dragAnchor;

    // Start is called before the first frame update
    public virtual void Start()
    {

        //Set the point on the model the line will originate from
        dragAnchor = transform.position;

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, dragAnchor);
        lineRenderer.enabled = false;

        cam = Camera.main;

        cursorPos = new PointerEventData(EventSystem.current);
    }

    public void OnMouseDrag()
    {
        lineRenderer.SetPosition(1, cam.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.enabled = true;
        dragging = true;
    }

    public void OnMouseUp()
    {
        lineRenderer.enabled = false;
        //If we were dragging check whats below the mouse
        if (dragging)
        {
            cursorPos.position = Input.mousePosition;
            List<RaycastResult> objectsHit = new List<RaycastResult>();
            EventSystem.current.RaycastAll(cursorPos, objectsHit);
            int count = objectsHit.Count;
            if(count > 0)
            {
                foreach(RaycastResult result in objectsHit)
                {
                    if (result.gameObject.tag == "BindButton")
                    {
                        //Bind the button to the object.
                        Debug.Log("Dropped on button");
                        boundButton = result.gameObject.GetComponent<Button>();
                        boundButton.onClick.AddListener(() =>
                        {
                            Debug.Log(string.Format("You pressed the button: {0}", boundButton.name));
                            toggleAction();
                        });
                    }
                    else
                    {
                        continue;
                    }
                }
                dragging = false;
            }
        }

    }

    public virtual void toggleAction()
    {
        Debug.Log("Performing Toggle Action");
    }

}
