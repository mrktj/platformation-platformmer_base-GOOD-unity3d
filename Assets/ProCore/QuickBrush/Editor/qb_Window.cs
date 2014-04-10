using UnityEngine;
using UnityEditor;
using System.Collections;

//	QuickBrush: Prefab Placement Tool
//	by PlayTangent
//	all rights reserved
//	www.ProCore3d.com

public class qb_Window : EditorWindow
{
	public static qb_Window window;

	#region Textures
	static Texture2D bulletPointTexture;

	protected static void LoadTextures()
	{
		string guiPath 		= "Assets/ProCore/QuickBrush/Resources/Skin/";
		bulletPointTexture 	= Resources.LoadAssetAtPath(guiPath + "qb_bullet.tga", typeof(Texture2D)) as Texture2D;
	}
	
	#endregion
	
	void OnEnable()
	{
		window = this;

		LoadTextures();
	//	BuildStyles();
	}
	
	protected static void MenuListItem(bool bulleted, bool centered, string text)
	{
		EditorGUILayout.BeginHorizontal();
		
			if(bulleted)
				GUILayout.Label(bulletPointTexture,window.bulletPointStyle);
			
			if(centered)
				EditorGUILayout.LabelField(text,window.labelStyle_centered);
		
			else
				EditorGUILayout.LabelField(text,window.labelStyle);
		
		EditorGUILayout.EndHorizontal();
				EditorGUILayout.Space();

	}
	
	protected static void MenuListItem(bool bulleted, string text)
	{
		MenuListItem(bulleted,false,text);
	}
	
	protected static void MenuListItem(string text)
	{
		MenuListItem(false, false, text);
	}
	
	[SerializeField] protected GUIStyle labelStyle;
	[SerializeField] protected GUIStyle labelStyle_bold;
	[SerializeField] protected GUIStyle labelStyle_centered;
	[SerializeField] protected GUIStyle menuBlockStyle;
	[SerializeField] protected GUIStyle bulletPointStyle;
	
    protected void BuildStyles()
    {
		labelStyle = new GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).label);
		labelStyle.alignment = TextAnchor.UpperLeft;
		labelStyle.wordWrap = true;
		labelStyle.padding.left = 0;
		labelStyle.margin.left = 0;
		
		labelStyle_bold = new GUIStyle(EditorStyles.boldLabel);
		
		labelStyle_centered = new GUIStyle(EditorStyles.label);
		labelStyle_centered.alignment = TextAnchor.UpperCenter;
		
		bulletPointStyle = new GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).label);
		bulletPointStyle.margin.right = 0;
		bulletPointStyle.margin.left = 0;
		bulletPointStyle.margin.top = 0;
		bulletPointStyle.margin.bottom = 0;
		bulletPointStyle.padding.right = 0;
		bulletPointStyle.padding.left = 0;
		bulletPointStyle.padding.top = 0;
		bulletPointStyle.padding.bottom = 0;
		
		menuBlockStyle = new GUIStyle(EditorStyles.textField);//GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).box);//new GUIStyle(EditorStyles.textField); //new GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene).textField);
		menuBlockStyle.alignment = TextAnchor.UpperLeft;
		
	}
}
