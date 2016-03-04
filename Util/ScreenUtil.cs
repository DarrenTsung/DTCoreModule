using DT;
﻿using System.Collections;
﻿using UnityEngine;

namespace DT {
	public class ScreenUtil {
    public static Vector2 ScaledScreenSize {
      get {
        RectTransform canvasTransform = (RectTransform)CanvasUtil.ScreenSpaceMainCanvas.transform;
        return new Vector2(Screen.width / canvasTransform.localScale.x,
                           Screen.height / canvasTransform.localScale.y);
      }
    }
    public static Vector2 ConvertRelativeCoord(Vector2 relativeCoordinates) {
      Vector2 scaledScreenSize = ScreenUtil.ScaledScreenSize;
      return new Vector2(relativeCoordinates.x * scaledScreenSize.x,
                         relativeCoordinates.y * scaledScreenSize.y);
    }
	}
}