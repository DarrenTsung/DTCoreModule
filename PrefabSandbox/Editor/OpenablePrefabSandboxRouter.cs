#if UNITY_EDITOR
#if DT_OPEN_OBJECT_WINDOW
using DTOpenObjectWindow;
using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
﻿using UnityEngine;
﻿using UnityEngine.SceneManagement;

namespace DT {
	[InitializeOnLoad]
	public class OpenablePrefabSandboxRouter {
		static OpenablePrefabSandboxRouter() {
      OpenablePrefabObject.OnPrefabGUIDOpened += OpenablePrefabSandboxRouter.OpenSandboxWithGUID;
		}


    // PRAGMA MARK - Static Internal
    private static void OpenSandboxWithGUID(string guid) {
      PrefabSandbox.OpenPrefab(guid);
    }
  }
}
#endif
#endif