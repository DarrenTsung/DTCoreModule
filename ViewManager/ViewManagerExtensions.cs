using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT {
	public static class ViewManagerExtensions {
		// PRAGMA MARK - Public Interface
		public static void AttachView(this ViewManager viewManager, MonoBehaviour view) {
      viewManager.AttachView(view.gameObject);
    }
  }
}