using System.Collections;
using UnityEngine;

namespace DT {
  public static class EditorGUIStyleUtil {
    // PRAGMA MARK - Public Interface
    public static GUIStyle StyleWithOddColor() {
      return GUIStyleUtil.StyleWithBackgroundColor(EditorColorUtil.OddColor());
    }

    public static GUIStyle StyleWithEvenColor() {
      return GUIStyleUtil.StyleWithBackgroundColor(EditorColorUtil.EvenColor());
    }

    public static GUIStyle CachedStyleWithOddColor() {
      return _oddGUIStyle ?? (_oddGUIStyle = EditorGUIStyleUtil.StyleWithOddColor());
    }

    public static GUIStyle CachedStyleWithEvenColor() {
      return _evenGUIStyle ?? (_evenGUIStyle = EditorGUIStyleUtil.StyleWithEvenColor());
    }

    public static GUIStyle CachedStyleWithColorFor(int index) {
      return index % 2 == 0 ? EditorGUIStyleUtil.CachedStyleWithEvenColor() : EditorGUIStyleUtil.CachedStyleWithOddColor();
    }


    // PRAGMA MARK - Internal
    private static GUIStyle _oddGUIStyle = null;
    private static GUIStyle _evenGUIStyle = null;
  }
}
