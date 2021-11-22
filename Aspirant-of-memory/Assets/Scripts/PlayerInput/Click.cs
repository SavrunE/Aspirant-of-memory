using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    private Camera mainCamera;
    private bool activateClicker = false;
    [SerializeField] private SpinnerMover spinnerMover;

    private void OnEnable()
    {
        spinnerMover.SequenceActivated += ClickerActivate;
    }

    private void OnDisable()
    {
        spinnerMover.SequenceActivated -= ClickerActivate;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && activateClicker)
        {
            RaycastHit2D rayHit = new RaycastHit2D();
            rayHit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

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
            effect.OnClick();
        }
    }

    public void ClickerActivate(bool value)
    {
        if (value)
        {
            activateClicker = true;
        }
        else
        {
            activateClicker = false;
        }
    }
}
