using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinksContainer : MonoBehaviour
{
    public Points Points;
    public SaveSerial SaveSerial;
    public Color OpenTextColor;
    public Color CloseTextColor;
    public ScaleAnimation scaleAnimation;
    
    public void NoOpenLevelAnimation()
    {
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        ActivateObjectSwitcher activateObjectSwitcher = GetComponent<ActivateObjectSwitcher>();

        activateObjectSwitcher.Deactive();
        scaleAnimation.Activate();
        yield return new WaitForSeconds(scaleAnimation.FullTimeAnimation());
        activateObjectSwitcher.Activate();
    }
}
