using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = new RaycastHit2D();
            rayHit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (rayHit.collider != null)
            {
                TryGetButton(rayHit.collider);
            }
        }
    }

    private void TryGetButton(Collider2D hittedObject)
    {
        if (hittedObject.TryGetComponent(out IButtonEffect effect))
        {
            effect.Activate();
        }
    }
}
