using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;
    private float zCoord;
    private BoxCollider2D myCollider;
    private Vector3 basePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        basePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zCoord));
            transform.position = mousePos + offset;

        }

        
    }

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zCoord));
        isDragging = true;
        myCollider.enabled = false;

    }
    private void OnMouseUp()
    {
        isDragging = false;
        myCollider.enabled = true;
        StartCoroutine("Wait");
    }


    private void resetPosition()
    {
        transform.position = basePosition;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        resetPosition();
    }
    
}
