using DT;
using System;
﻿using System.Collections.Generic;
﻿using UnityEngine;

namespace DT {
	public static class DeviceUtil {
    private static int? _seed;
    public static int Seed {
      get { return (int)(DeviceUtil._seed ?? (DeviceUtil._seed = SystemInfo.deviceUniqueIdentifier.GetHashCode())); }
    }
  }
}
