using DT;
﻿using System.Collections;
using System.Linq;
﻿using UnityEngine;

namespace DT {
	public class CanvasUtil {
    private static GameObject _screenSpaceMainCanvas;

    static CanvasUtil() {
      CanvasUtil.FindCanvases();
    }

    private static void FindCanvases() {
      Canvas[] canvasComponents = Object.FindObjectsOfType(typeof(Canvas)) as Canvas[];
      if (canvasComponents == null || canvasComponents.Length <= 0) {
        Debug.LogError("CanvasUtil: No canvases components found!");
        return;
      }

      CanvasUtil._screenSpaceMainCanvas = (from canvasComponent in canvasComponents
        where canvasComponent.gameObject.tag == "ScreenSpaceCanvas" select canvasComponent.gameObject).FirstOrDefault();
    }

    public static GameObject ScreenSpaceMainCanvas {
      get {
        if (CanvasUtil._screenSpaceMainCanvas == null) {
          CanvasUtil.FindCanvases();
        }
        return CanvasUtil._screenSpaceMainCanvas;
      }
    }
	}
}