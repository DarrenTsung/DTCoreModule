using DT;
﻿using System.Collections;
﻿using UnityEngine;

namespace DT {
	public static class AnimationCurveUtil {
    // PRAGMA MARK - Static Interface
    public static AnimationCurve NormalizedEaseFrom0To1() {
      return AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);
    }

    public static AnimationCurve Default1To1() {
      return AnimationCurve.Linear(0.0f, 1.0f, 1.0f, 1.0f);
    }
	}
}