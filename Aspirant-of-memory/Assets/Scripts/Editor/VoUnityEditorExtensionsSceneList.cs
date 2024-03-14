#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;


class VoUnityEditorExtensionsSceneList
{
	[MenuItem("VoEditor/LoadScene/Basic")]
	public static void LoadScene_Basic()
	{
		EditorSceneManager.OpenScene("Assets/Art By Kandles/Basic Icons/Basic.unity");
	}

	[MenuItem("VoEditor/LoadScene/Demo")]
	public static void LoadScene_Demo()
	{
		EditorSceneManager.OpenScene("Assets/40+ Simple Icons - Free/Scenes/Demo.unity");
	}

	[MenuItem("VoEditor/LoadScene/Test")]
	public static void LoadScene_Test()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Test.unity");
	}

	[MenuItem("VoEditor/LoadScene/StartWindow")]
	public static void LoadScene_StartWindow()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/StartWindow.unity");
	}

	[MenuItem("VoEditor/LoadScene/DefaultLevel")]
	public static void LoadScene_DefaultLevel()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/DefaultLevel.unity");
	}

	[MenuItem("VoEditor/LoadScene/preLoadScene")]
	public static void LoadScene_preLoadScene()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/preLoadScene.unity");
	}

	[MenuItem("VoEditor/LoadScene/ExampleYG")]
	public static void LoadScene_ExampleYG()
	{
		EditorSceneManager.OpenScene("Assets/YandexGame/Example/Scenes/ExampleYG.unity");
	}

}
#endif
