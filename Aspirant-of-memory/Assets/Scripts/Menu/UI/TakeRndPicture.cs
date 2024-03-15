using UnityEngine;
using UnityEngine.UI;

public class TakeRndPicture : MonoBehaviour
{
	[SerializeField] private Image _image;
	[SerializeField] private Sprite[] _sprites;

    void Awake()
    {
        var rnd = Random.Range(0, _sprites.Length);
		_image.sprite = _sprites[rnd];
	}
}
