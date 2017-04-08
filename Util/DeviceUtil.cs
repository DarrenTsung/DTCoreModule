using DT;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public static class DeviceUtil {
		private static int? seed_;
		public static int Seed {
			get { return (int)(seed_ ?? (seed_ = SystemInfo.deviceUniqueIdentifier.GetHashCode())); }
		}
	}
}
