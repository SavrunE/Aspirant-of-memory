using UnityEngine;

public class ButtonRotator : MonoBehaviour
{
	[HideInInspector] public Sequence sequence;
	[SerializeField] private Button _button;

	private void Start()
	{
		sequence = transform.parent.GetComponent<Sequence>();
	}

	public void SetRadiusScale(float yPos, float scale)
	{
		_button.transform.position = new Vector3(0f, yPos, 0f);
		_button.transform.localScale = new Vector3(scale, scale, scale);
	}
}
