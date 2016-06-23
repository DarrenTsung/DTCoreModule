using DT;
using System;
﻿using UnityEngine;

namespace DT {
	public static class PlayerPrefsUtil {
    public static void IncrementInt(string key, int defaultValue = 0) {
      int oldValue = PlayerPrefs.GetInt(key, defaultValue);
      PlayerPrefs.SetInt(key, oldValue + 1);
    }
	}
}