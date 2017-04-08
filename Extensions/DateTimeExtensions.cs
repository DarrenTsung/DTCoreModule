using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DT {
	public static class DateTimeExtensions {
		public static int IntSecondsPassedFromNow(this DateTime time) {
			return time.IntSecondsPassedFrom(DateTime.UtcNow);
		}

		public static int IntSecondsPassedFrom(this DateTime time, DateTime fromTime) {
			return (int)time.SecondsPassedFrom(fromTime);
		}

		public static float SecondsPassedFromNow(this DateTime time) {
			return time.SecondsPassedFrom(DateTime.UtcNow);
		}

		public static float SecondsPassedFrom(this DateTime time, DateTime fromTime) {
			return (float)(fromTime - time).TotalSeconds;
		}
	}
}