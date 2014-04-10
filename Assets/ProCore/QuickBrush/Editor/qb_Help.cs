using UnityEngine;
using UnityEditor;
using System.Collections;

//	QuickBrush: Prefab Placement Tool
//	by PlayTangent
//	all rights reserved
//	www.ProCore3d.com

public class qb_Help : qb_Window
{
	[MenuItem ("Tools/QuickBrush/Help")]
	public static void ShowWindow()
	{
		window = EditorWindow.GetWindow<qb_Help>(false,"QB Help");
		
		//window.position = new Rect(100,100,290,600);
		window.maxSize = new Vector2(400,500);
		window.minSize = new Vector2(400,300);
    }
	
	static Vector2 sliderVal;
	
	void OnGUI()
	{
		BuildStyles();
		
		EditorGUILayout.Space();
		
		sliderVal = EditorGUILayout.BeginScrollView(sliderVal,false,false);
			
			MenuListItem(false,true,"Complete documentation & info at:");
			MenuListItem(false,true,"http://www.proCore3d.com/quickBrush/");
		EditorGUILayout.LabelField("Basic Usage",labelStyle_bold);
		
		EditorGUILayout.BeginVertical(menuBlockStyle);
			MenuListItem(true,"To begin, drag and drop a prefab (or prefabs) onto the outlined region near the top of the QuickBrush window");
			MenuListItem(true,"This adds it to the prefab list pane");
			MenuListItem(true,"Each item in the list pane has a slider, a preview window, and two overlaid controls");
			MenuListItem(true,"The Slider dictates how likely each prefab in the list is to be spawned vs the others when using the brush to place objects");
			MenuListItem(true,"Clicking the 'Red X' overlay removes the item from the list");
			MenuListItem(true,"Clicking the 'Green Checkmark' toggles whether an object will be placed exclussively.");
		EditorGUILayout.EndVertical();
		
		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Painting Controls",labelStyle_bold);
		
		EditorGUILayout.BeginVertical(menuBlockStyle);
			MenuListItem(true,"The brush is toggled ON by holding down Ctrl/Cmd");
			MenuListItem(true,"To switch between painting and erasing, press the X key while holding down Ctrl/Cmd");
			MenuListItem(true,"To paint (or erase), click and drag with the mouse while holding Ctrl/Cmd");
			MenuListItem(true,"An additional percision placement mode is available by simultaneously holding down Shift and Ctr/Cmd");
			MenuListItem(true,"While precision placing, clicking the mouse spawns a single prefab. Dragging the cursor while still holding down the mouse allows you to scale and rotate the object being placed");
			MenuListItem(true,"To chose the object which will be percision placed using this control, toggle the green checkmark overlaying the preview pane for the prefab in the prefab list pane.");
			MenuListItem(true,"If no object is selected, QuickBrush will use the first item in the list (the one on the left)");
		EditorGUILayout.EndVertical();

		EditorGUILayout.Space();
		
		EditorGUILayout.LabelField("FAQ (will expand with feedback)",labelStyle_bold);
		
		EditorGUILayout.BeginVertical(menuBlockStyle);
			
			EditorGUILayout.LabelField("Q: When I paint, my objects stack on top of one another instead of painting onto my chosen surface. What gives?",labelStyle);
			EditorGUILayout.Space();

			EditorGUILayout.LabelField("A: It is likely that your prefabs have colliders and are layered such that QuickBrush is painting them onto one another. Use the layer settings in order to paint to a different layer than the one your prefabs are on.",labelStyle);
			EditorGUILayout.Space();
		
		EditorGUILayout.EndVertical();
		
		EditorGUILayout.EndScrollView();
	}


	
}