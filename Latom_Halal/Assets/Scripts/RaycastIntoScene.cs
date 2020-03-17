using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastIntoScene : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;

    [SerializeField]
    private LayerMask layerMask;

    private const float MAX_DISTANCE = 10f;
    private void OnValidate()
    {
        if (camera == null)
            camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mouseScreenPosition);
        if (Physics.Raycast(ray,out RaycastHit raycastHit,MAX_DISTANCE,layerMask))
        {
            raycastHit.collider.GetComponent<Renderer>().material.color = Color.green;
        }
        
    }
}
