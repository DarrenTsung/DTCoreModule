using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;

namespace DT {
	public static class ViewManagerLocator {
		// PRAGMA MARK - Static Public Interface
		public static ViewManager Main {
      get {
        if (ViewManagerLocator._main == null) {
          GameObject main = GameObjectUtil.FindRequired("MainViewManager");
          ViewManagerLocator._main = main.GetRequiredComponent<ViewManager>();
        }
        return ViewManagerLocator._main;
      }
    }

    private static ViewManager _main;
  }
}