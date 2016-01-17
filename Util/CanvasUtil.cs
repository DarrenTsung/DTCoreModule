using DT;
﻿using System.Collections;
﻿using UnityEngine;

namespace DT {
	public class CanvasUtil {
    private static GameObject[] _canvases;

    static CanvasUtil() {
      CanvasUtil._canvases = GameObject.FindGameObjectsWithTag("Canvas");
      if (CanvasUtil._canvases.Length <= 0) {
        Debug.LogError("CanvasUtil: No canvases found! Are they tagged with Canvas?");
      }
    }

    public static GameObject MainCanvas {
      get {
        return CanvasUtil._canvases[0];
      }
    }
	}
}