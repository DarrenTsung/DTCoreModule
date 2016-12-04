#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DT {
  public static class GUIStyleUtil {
    public static GUIStyle StyleWithBackgroundColor(Color color) {
      return GUIStyleUtil.StyleWithTexture(Texture2DUtil.GetCached1x1TextureWithColor(color));
    }

    public static GUIStyle StyleWithTexture(Texture2D texture) {
      return GUIStyleUtil.StyleWithTexture(GUIStyle.none, texture);
    }

    public static GUIStyle StyleWithTexture(GUIStyle baseStyle, Texture2D texture) {
      GUIStyle style = GUIStyleUtil._cachedTextureStyles.SafeGet(texture);
      if (style == null) {
        style = new GUIStyle(baseStyle);
        style.normal.background = texture;
      }

      return style;
    }


    // PRAGMA MARK - Internal
    private static Dictionary<Texture2D, GUIStyle> _cachedTextureStyles = new Dictionary<Texture2D, GUIStyle>();
  }
}
#endif