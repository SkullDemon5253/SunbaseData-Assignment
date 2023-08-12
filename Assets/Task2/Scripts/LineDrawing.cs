using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LineDrawing : MonoBehaviour 
{
    public UITweening2 uitweening;
    public LineRenderer lineRenderer;
    public LayerMask circleLayer;
    public float intersectionCheckRadius = 0.1f;

    private bool isDrawing = false;
    private Vector2 lastMousePosition , firstMousePosition;
    private List<CircleController> intersectedCircles = new List<CircleController>();

    private RaycastHit2D currentCircle;

    public GameObject restartPanel;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            firstMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //lineRenderer.SetPosition(0, firstMousePosition);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
            RemoveIntersectedCircles();
        }


        if (isDrawing)
        {
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentCircle = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, circleLayer);

            //lineRenderer.SetPosition(1, lastMousePosition);

            if(currentCircle == true)
            {
                AddCircleToList(currentCircle.transform.GetComponent<CircleController>());
            }
           
            lineRenderer.SetPosition(intersectedCircles.Count, lastMousePosition);

            Debug.Log(intersectedCircles.Count);
        }
            /*
            Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //lineRenderer.positionCount = 2;
            //lineRenderer.SetPositions(new Vector3[] { lastMousePosition, currentMousePosition });

            Collider2D[] colliders = Physics2D.OverlapCircleAll(currentMousePosition, intersectionCheckRadius, circleLayer);
            intersectedCircles.Clear();

            foreach (Collider2D collider in colliders)
            {
                CircleController circle = collider.GetComponent<CircleController>();
                if (circle != null && circle.IsIntersecting(currentMousePosition))
                {
                    intersectedCircles.Add(circle);
                }
            }

            lastMousePosition = currentMousePosition;
        }
        else
        {
            lineRenderer.positionCount = 0;
        }*/
    }

    public void AddCircleToList(CircleController circle)
    {
        intersectedCircles.Add(circle);
        lineRenderer.positionCount = intersectedCircles.Count + 1;
        lineRenderer.SetPosition(intersectedCircles.Count - 1, circle.transform.position);


        circle.transform.GetComponent<CircleCollider2D>().enabled = false;
    }


    private void RemoveIntersectedCircles()
    {
        foreach (CircleController circle in intersectedCircles)
        {
            Destroy(circle.gameObject);
        }

        intersectedCircles.Clear();
        lineRenderer.enabled = false;

        restartPanel.SetActive(true);
        uitweening.startTween();

        this.enabled = false;
    }
}
