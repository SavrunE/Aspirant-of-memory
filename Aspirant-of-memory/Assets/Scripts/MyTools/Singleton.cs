using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	[SerializeField]
	private bool _dontDestroyOnLoad = false;

	public static T instance { get; private set; }

	protected virtual void Awake()
	{
		if (instance != null)
		{
			Debug.LogError($"Error! Only single instance of {instance.GetType().Name} is allowed");
			Destroy(instance);
		}
		else
		{
			instance = this as T;
			if (_dontDestroyOnLoad) DontDestroyOnLoad(instance.gameObject);
		}
	}

	protected virtual void OnDestroy()
	{
		instance = null;
	}
}