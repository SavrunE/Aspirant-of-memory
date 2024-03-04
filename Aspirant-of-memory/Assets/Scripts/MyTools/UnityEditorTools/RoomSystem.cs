using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEditor;
using UnityEngine;

public sealed class RoomSystem : Singleton<RoomSystem>
{
	[SerializeField]
	private List<RoomInfo> _persistentRooms;


	public List<RoomInfo> GetAllRoomsInfo()
	{
		return _persistentRooms;
	}

	public bool GetRoomInfo(string room, out RoomInfo inf)
	{
		int idx = _persistentRooms.FindIndex(x => x.name == room);

		if (idx != -1)
		{
			inf = _persistentRooms[idx];
			return true;
		}
		else
		{
			inf = RoomInfo.Null;
			return false;
		}
	}

#if UNITY_EDITOR

	public void CreateAllScenesOffline()
	{
		_persistentRooms = new List<RoomInfo>();

		for (int i = 2; i < EditorBuildSettings.scenes.Length; i++)
		{
			string sceneName = System.IO.Path.GetFileNameWithoutExtension(EditorBuildSettings.scenes[i].path);
			_persistentRooms.Add(new RoomInfo(sceneName, Guid.NewGuid().ToString(), EditorBuildSettings.scenes[i].path));
		}

		EditorUtility.SetDirty(gameObject);
	}

	[ContextMenu("Update all scenes (offline)")]
	public void UpdateAllScenesOffline()
	{
		for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
		{
			string sceneName = System.IO.Path.GetFileNameWithoutExtension(EditorBuildSettings.scenes[i].path);

			int idx = _persistentRooms.FindIndex(x => x.name == sceneName);

			if (idx == -1)
			{
				_persistentRooms.Add(new RoomInfo(sceneName, Guid.NewGuid().ToString(), EditorBuildSettings.scenes[i].path));
			}
			else
			{
				bool needUpdate = false;
				RoomInfo inf = _persistentRooms[idx];

				if (string.IsNullOrEmpty(inf.uuid))
				{
					inf.uuid = Guid.NewGuid().ToString();
					needUpdate = true;
				}

				if (string.IsNullOrEmpty(inf.path))
				{
					inf.path = EditorBuildSettings.scenes[i].path;
					needUpdate = true;
				}

				if (needUpdate)
				{
					_persistentRooms[idx] = inf;
					Debug.Log($"Found room info, updating: {inf.name} {inf.uuid} {inf.path}");
				}
			}
		}

		EditorUtility.SetDirty(gameObject);
	}

	[ContextMenu("Create editor scene switch menu")]
	public void UpdateEditorSceneList()
	{
		const string fileName = "VoUnityEditorExtensionsSceneList.cs";

		string absPath = Application.dataPath + "/Scripts/Editor";
		string absFilePath = absPath + "/" + fileName;

		// Make sure path exists
		if (!Directory.Exists(absPath))
		{
			Directory.CreateDirectory(absPath);
		}

		// Create file if not exists
		if (!File.Exists(absFilePath))
		{
			FileStream fs = File.Open(absFilePath, FileMode.OpenOrCreate);
			fs.Close();
		}

		StreamWriter stream = new StreamWriter(absFilePath, false, Encoding.ASCII);

		try
		{
			using (stream)
			{
				stream.WriteLine("#if UNITY_EDITOR");
				stream.WriteLine("using UnityEditor;");
				stream.WriteLine("using UnityEditor.SceneManagement;");
				stream.WriteLine("");
				stream.WriteLine("");
				stream.WriteLine("class VoUnityEditorExtensionsSceneList");
				stream.WriteLine("{");

				for (int i = 0; i < _persistentRooms.Count; i++)
				{
					RoomInfo inf = _persistentRooms[i];

					stream.WriteLine($"\t[MenuItem(\"VoEditor/LoadScene/{inf.name}\")]");
					stream.WriteLine($"\tpublic static void LoadScene_{inf.name}()");
					stream.WriteLine("\t{");
					stream.WriteLine($"\t\tEditorSceneManager.OpenScene(\"{inf.path}\");");
					stream.WriteLine("\t}");
					stream.WriteLine("");
				}

				stream.WriteLine("}");
				stream.WriteLine("#endif");
			}
		}
		catch (Exception e)
		{
			Debug.LogError(e.Message);
		}

		stream.Close();

		AssetDatabase.Refresh();
		GC.Collect();
	}

	//[ContextMenu("Update room path")]
	public void UpdateRoomPath()
	{
		for (int f = 0; f < _persistentRooms.Count; f++)
		{
			RoomInfo info = _persistentRooms[f];

			for (int i = 2; i < EditorBuildSettings.scenes.Length; i++)
			{
				string sceneName = System.IO.Path.GetFileNameWithoutExtension(EditorBuildSettings.scenes[i].path);

				if (sceneName == info.name)
				{
					_persistentRooms[f] = new RoomInfo(info.name, info.uuid, EditorBuildSettings.scenes[i].path);
					break;
				}
			}
		}

		EditorUtility.SetDirty(gameObject);
	}

#endif
}

[Serializable]
public struct RoomInfo
{
	public string name;
	public string uuid;
	public string path;

	public RoomInfo(string n, string u)
	{
		name = n;
		uuid = u;
		path = n;
	}

	public RoomInfo(string n, string u, string p)
	{
		name = n;
		uuid = u;
		path = p;
	}

	public static readonly RoomInfo Null = new RoomInfo() { name = "", uuid = Guid.Empty.ToString(), path = "" };
}