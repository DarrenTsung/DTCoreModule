using DT;
using System;
﻿using System.Collections.Generic;
﻿using System.Reflection;
using UnityEditor;
﻿using UnityEngine;

namespace DT {
	public static class EditorGUIUtilityUtil {
    public const float kIndentWidth = 15.0f;

    public static float IndentedLabelWidth {
      get {
        return EditorGUIUtility.labelWidth - (EditorGUI.indentLevel * EditorGUIUtilityUtil.kIndentWidth);
      }
    }
	}
}