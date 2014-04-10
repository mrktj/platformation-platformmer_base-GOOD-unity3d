using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[InitializeOnLoad]
public class QuickDecals : EditorWindow 
{	
	const int RIGHT_MOUSE_BUTTON = 1;
	const string BILLBOARD_PATH = "Assets/ProCore/QuickDecals/DecalMesh/DecalMeshObject.fbx";

#region INIT

	[MenuItem("Tools/QuickDecals (v1.0.2)")]
    public static void MenuInitQuickDecals()
	{
		EditorWindow.GetWindow<QuickDecals>(false, "QuickDecals v1.0.2", false);
    }
	
    void OnEnable()
    {
		// use delegate to pass sceneview info to our own sceneview
		if(SceneView.onSceneGUIDelegate != this.OnSceneGUI)
		   SceneView.onSceneGUIDelegate += this.OnSceneGUI;
    }

	void OnDisable()
	{
		SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
	}
	
	void OnGUI()
	{
		useRandom = EditorGUILayout.Toggle("Random?", useRandom);
		//randomRtn = EditorGUILayout.Toggle("Random Rotation?", randomRtn);
		if(!useRandom)
		{
			decalMat = (Material)EditorGUILayout.ObjectField("",  decalMat, typeof(Material), false);
		}
		else
		{
			matNum = EditorGUILayout.IntField("# of Decals: ", matNum);
			scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
			if(matNum != 0)
			{
				for(int i = 0; i < matNum; i++)
				{
					if(i+1 > matArray.Count)
					{
						matArray.Add(null);
					}
					matArray[i] = (Material)EditorGUILayout.ObjectField("",  matArray[i], typeof(Material), false);
				}
			}
			EditorGUILayout.EndScrollView();
		}
		
	}

#endregion


	Vector2 scrollPos = Vector2.zero;
	
	Material decalMat;
	
	bool useRandom = false;
	bool randomRtn = false;
	int matNum = 0;
	List<Material> matArray = new List<Material>();
	
	// Vector2 initialPos = Vector2.zero;

	void OnSceneGUI(SceneView scnView)
	{	
		Event e = Event.current;
		
		#if UNITY_STANDALONE_OSX
		if(e.modifiers != (EventModifiers.Shift | EventModifiers.Control))
			return;

		int controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
		HandleUtility.AddDefaultControl(controlID);
		#endif

		#if UNITY_STANDALONE_OSX
		if(e.type == EventType.MouseUp)
		#else
		if(e.type == EventType.MouseUp && e.button == RIGHT_MOUSE_BUTTON && e.modifiers == EventModifiers.Shift)
		#endif
		{
			Event.current.Use();
			AttemptDecalPlacement();
		}
	}
	
	void AttemptDecalPlacement()
	{
		Ray worldRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
		RaycastHit hitInfo;
		if(Physics.Raycast(worldRay, out hitInfo, 1000))
		{
			if(hitInfo.collider.gameObject.GetComponent(typeof(MeshRenderer)))
			{
				PlaceNewDecal(hitInfo);
			}
		}
	}
	
	void PlaceNewDecal(RaycastHit hitInfo)
	{
		Material chosenMaterial;

		if(useRandom)
		{
			if(matNum == 0)
			{
				Debug.LogWarning("You need to add some decal materials first!");
				return;
			}

			int matIndex = Random.Range(0, matNum);
			chosenMaterial = matArray[matIndex];
			
			if(chosenMaterial == null)
			{
				Debug.LogWarning("Decal #"+(matIndex+1)+" has no material chosen, please add a material there.");
				return;
			}
		}
		else
		{
			chosenMaterial = decalMat;
			if(chosenMaterial == null)
			{
				Debug.LogWarning("No material chosen for the Decal- please choose one first!");
				return;
			}
		}
		
		Vector3 decalPos = hitInfo.point;
		Quaternion decalRtn = Quaternion.LookRotation(hitInfo.normal);
		
		GameObject newDecal = (GameObject)Instantiate((Resources.LoadAssetAtPath(BILLBOARD_PATH, typeof(Object))), Vector3.zero, Quaternion.identity);

		newDecal.GetComponent<MeshRenderer>().sharedMaterial = chosenMaterial;
		newDecal.transform.position = decalPos;
		newDecal.transform.rotation = decalRtn;
		
		newDecal.transform.Rotate( Vector3.right * 90f );

		if(randomRtn)
			newDecal.transform.Rotate( Vector3.up * Random.Range(0f, 360f) );

		newDecal.transform.Translate( Vector3.up * 0.005f );
		
		newDecal.GetComponent<MeshRenderer>().castShadows = false;
		
		newDecal.isStatic = false;
		var staticFlags = StaticEditorFlags.BatchingStatic | StaticEditorFlags.LightmapStatic | StaticEditorFlags.OccludeeStatic;
		GameObjectUtility.SetStaticEditorFlags(newDecal, staticFlags);
		
		Selection.activeObject = newDecal;
	}
}