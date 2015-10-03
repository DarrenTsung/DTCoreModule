using UnityEngine;
using System.Collections;
using UnityEditor;

public class TagSearcher : EditorWindow {
  static string tagValue = "";
  static string oldTagValue;
  static Vector2 scrollValue = Vector2.zero;
  static GameObject[] searchResult;
  
  [MenuItem("DarrenTsung/TagSearcher")]
  public static void OpenTagSearcher() {
    searchResult = GameObject.FindGameObjectsWithTag(tagValue);
  }
  
  protected void OnGUI() {
    oldTagValue = tagValue;
    tagValue = EditorGUILayout.TagField(tagValue); 
    
    if (tagValue != oldTagValue) {
      searchResult = GameObject.FindGameObjectsWithTag(tagValue);
      Selection.objects = searchResult;
    }
    
    // BEGIN SCROLL VIEW
    scrollValue = EditorGUILayout.BeginScrollView(scrollValue);
    if (searchResult != null) {
      foreach (GameObject obj in searchResult) { 
        if (obj != null) {
          if (GUILayout.Button(obj.name)) {
            Selection.activeObject =  obj; 
            EditorGUIUtility.PingObject(obj);
          }
        }
        else {
          searchResult = GameObject.FindGameObjectsWithTag(tagValue);
          Selection.objects = searchResult;
          break;
        }
      }
    }
    EditorGUILayout.EndScrollView();
    // END SCROLL VIEW
  } 
  
}