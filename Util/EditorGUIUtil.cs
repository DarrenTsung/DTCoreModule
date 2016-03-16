using DT;
using System;
﻿using System.Reflection;
﻿using System.Collections.Generic;
﻿using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace DT {
	public static class EditorGUIUtil {
    private static MethodInfo _boldFontMethodInfo = null;

    public static void SetBoldDefaultFont(bool value) {
      if (_boldFontMethodInfo == null) {
        _boldFontMethodInfo = typeof(EditorGUIUtility).GetMethod("SetBoldDefaultFont", BindingFlags.Static | BindingFlags.NonPublic);
      }
      _boldFontMethodInfo.Invoke(null, new[] { value as object });
    }
  }
}
#endif