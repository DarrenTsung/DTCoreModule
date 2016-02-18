using DT;
﻿using System.Collections;
using System.Linq;
﻿using UnityEngine;

namespace DT {
	public class CanvasUtil {
    private static GameObject[] _canvases;

    static CanvasUtil() {
      CanvasUtil.FindCanvases();
    }

    private static void FindCanvases() {
      Canvas[] canvasComponents = Object.FindObjectsOfType(typeof(Canvas)) as Canvas[];
      if (canvasComponents == null || canvasComponents.Length <= 0) {
        Debug.LogError("CanvasUtil: No canvases components found!");
        CanvasUtil._canvases = new GameObject[0];
        return;
      }

      CanvasUtil._canvases = (from canvasComponent in canvasComponents select canvasComponent.gameObject).ToArray();
    }

    public static GameObject MainCanvas {
      get {
        if (CanvasUtil._canvases.Length <= 0 || CanvasUtil._canvases[0] == null) {
          CanvasUtil.FindCanvases();
        }
        return CanvasUtil._canvases[0];
      }
    }
	}
}