using UnityEditor;
using UnityEngine;
using System;
 
namespace DT {
	public class EdgeCollider2DEditor : EditorWindow {
		[MenuItem("DarrenTsung/EdgeCollider2DEditor")]
		public static void ShowWindow() {
			EditorWindow.GetWindow (typeof(EdgeCollider2DEditor));
		}
	 
		protected EdgeCollider2D edge;
		protected Vector2[] vertices = new Vector2[0];
    protected Vector2 _offset;
    protected Vector2 _size;
	 
		protected void OnGUI()
		{
			GUILayout.Label ("EdgeCollider2D Editor", EditorStyles.boldLabel);
			edge = (EdgeCollider2D) EditorGUILayout.ObjectField("EdgeCollider2D to edit", edge, typeof(EdgeCollider2D), true);
			
			if (vertices.Length != 0) {
				for (int i = 0; i < vertices.Length; ++i) {
					vertices[i] = (Vector2) EditorGUILayout.Vector2Field("Element "+i, vertices[i]);
				}
			}
	 
			if (GUILayout.Button("Retrieve")) {
        this.Refresh();
			}
			
			if (GUILayout.Button("Set")) {
				edge.points = vertices;
			}
			
			if (GUILayout.Button("Add Point")) {
				Vector2[] newVertices = new Vector2[vertices.Length + 1];
				Array.Copy(vertices, newVertices, vertices.Length);
				newVertices[vertices.Length] = new Vector2(0.0f, 0.0f);
				edge.points = newVertices;
        this.Refresh();
			}
      
      GUILayout.Label("Set Rectangle (WARNING: THIS OVERRIDES ALL EDGES)", EditorStyles.boldLabel);
      _offset = EditorGUILayout.Vector2Field("Offset", _offset);
      _size = EditorGUILayout.Vector2Field("Size", _size);
			if (GUILayout.Button("Set Rectangle")) {
				if (EditorUtility.DisplayDialog("Set Rectangle?", 
				                                "Are you sure that you want to set this rectangle? (THIS OVERWRITE EVERYTHING)", 
				                                "I'm Sure", 
				                                "Cancel")) {
					edge.points = this.CreateRectanglePoints(_offset, _size);
          this.Refresh();
        }
      }
		}
    
    protected Vector2[] CreateRectanglePoints(Vector2 offset, Vector2 size) {
      Vector2 upperLeftPoint = offset + new Vector2(-size.x, size.y);
      Vector2 lowerLeftPoint = offset + new Vector2(-size.x, -size.y);
      Vector2 upperRightPoint = offset + new Vector2(size.x, size.y);
      Vector2 lowerRightPoint = offset + new Vector2(size.x, -size.y);
      
      Vector2[] points = new Vector2[5];
      points[0] = upperLeftPoint;
      points[1] = lowerLeftPoint;
      points[2] = lowerRightPoint;
      points[3] = upperRightPoint;
      points[4] = upperLeftPoint;
      
      return points;
    }
    
    protected void Refresh() {
				vertices = edge.points;
        OnGUI();
    }
	 
		void OnSelectionChange() {
			if (Selection.gameObjects.Length == 1) {
				EdgeCollider2D aux = Selection.gameObjects[0].GetComponent<EdgeCollider2D>();
				
				if (aux) {
					edge = aux;
					vertices = edge.points;
				}
			}
		}
	}
}