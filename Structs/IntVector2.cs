using System;
using UnityEngine;

namespace DT {
	[Serializable]
	public struct IntVector2 {
		public int x;
		public int y;

		public IntVector2(int x, int y) {
			this.x = x;
			this.y = y;
		}

		public override bool Equals(object obj) {
			return obj is IntVector2 && this == (IntVector2)obj;
		}

		public override int GetHashCode() {
			return x ^ y;
		}

		public static bool operator ==(IntVector2 a, IntVector2 b) {
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(IntVector2 x, IntVector2 y) {
			return !(x == y);
		}
	}
}