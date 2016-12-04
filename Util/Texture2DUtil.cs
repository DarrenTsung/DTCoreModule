using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public static class Texture2DUtil {
    // PRAGMA MARK - Public
    public static Texture2D CreateTextureWithColor(Color color, int width = 1, int height = 1) {
      Color[] pixels = new Color[width * height];

      for (int i = 0; i < pixels.Length; i++) {
        pixels[i] = color;
      }

      Texture2D tex = new Texture2D(width, height);
      tex.SetPixels(pixels);
      tex.Apply();

      return tex;
    }

    public static Texture2D GetCached1x1TextureWithColor(Color color) {
      return Texture2DUtil._cached1x1Textures.GetOrCreateCached(color, c => Texture2DUtil.CreateTextureWithColor(c));
    }


    // PRAGMA MARK - Internal
    private static Dictionary<Color, Texture2D> _cached1x1Textures = new Dictionary<Color, Texture2D>();
	}
}