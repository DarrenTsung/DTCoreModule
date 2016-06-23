using DT;
﻿using System.Collections;
using System.Linq;
﻿using UnityEngine;

namespace DT {
	public class CanvasUtil {
    // PRAGMA MARK - Static Interface
    public static GameObject ScreenSpaceMainCanvas {
      get {
        if (CanvasUtil._screenSpaceMainCanvas == null) {
          CanvasUtil.FindCanvases();
        }
        return CanvasUtil._screenSpaceMainCanvas;
      }
    }

    public static void ParentUIElementToCanvas(GameObject uiElement, GameObject canvas) {
      // HACK: make this better Darren
      uiElement.transform.SetParent(canvas.transform, worldPositionStays: false);
      uiElement.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }


    // PRAGMA MARK - Static Internal
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
	}
}