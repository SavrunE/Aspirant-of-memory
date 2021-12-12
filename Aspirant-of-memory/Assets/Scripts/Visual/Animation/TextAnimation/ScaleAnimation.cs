using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private float scaleRangeChangeMultiplier;
    [SerializeField] private float scaleSpeedCnange;
    [SerializeField] private Points points;

    public float FullTimeAnimation() => scaleSpeedCnange * 2f;

    public void Activate()
    {
        ZeroValueChanger();

        StartCoroutine(Changer());
    }

    private IEnumerator Changer()
    {
        Vector3 startTextScale = transform.localScale;
        Vector3 startPointsScale = points.transform.localScale;

        ActivateObjectSwitcher activateObjectSwitcher = transform.parent.GetComponent<ActivateObjectSwitcher>();

        activateObjectSwitcher.Activate();

        ChangeScale(startTextScale * scaleRangeChangeMultiplier, this.gameObject);
        ChangeScale(startPointsScale * scaleRangeChangeMultiplier, points.gameObject);

        yield return new WaitForSeconds(scaleSpeedCnange);
        ChangeScale(startTextScale, this.gameObject);
        ChangeScale(startPointsScale, points.gameObject);

        yield return new WaitForSeconds(scaleSpeedCnange);
        activateObjectSwitcher.Deactive();
    }

    private void ChangeScale(Vector3 endScale, GameObject transformObject)
    {
        transformObject.transform.DOScale(endScale, scaleSpeedCnange);
    }

    private void ZeroValueChanger()
    {
        if (scaleRangeChangeMultiplier == 0)
        {
            scaleRangeChangeMultiplier = 2f;
        }
        if (scaleSpeedCnange == 0)
        {
            scaleSpeedCnange = 1f;
        }
    }
}
