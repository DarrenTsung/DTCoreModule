using System.Collections;
using UnityEngine;

namespace DT {
  public static class ColorExtensions {
    /// <summary>
    /// Creates a washed out color (random color mixed with white) that isn't too bad looking
    /// Not sure it's the best way to generate nice colors, but it's alright.
    /// </summary>
    public static Color RandomPleasingColor() {
      float red = (Random.value + 1.0f) / 2.0f;
      float green = (Random.value + 1.0f) / 2.0f;
      float blue = (Random.value + 1.0f) / 2.0f;
      
      return new Color(red, green, blue);
    }
  }
}
