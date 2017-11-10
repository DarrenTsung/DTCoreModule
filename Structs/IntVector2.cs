using System;
using UnityEngine;

namespace DT {
	[Serializable]
	public struct IntVector2 {
		public static readonly IntVector2 zero = new IntVector2(0, 0);
		public static readonly IntVector2 up = new IntVector2(0, 1);
		public static readonly IntVector2 right = new IntVector2(1, 0);

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

		public static bool operator !=(IntVector2 a, IntVector2 b) {
			return !(a == b);
		}

		public static IntVector2 operator +(IntVector2 a, IntVector2 b) {
			return new IntVector2(a.x + b.x, a.y + b.y);
		}

		public static IntVector2 operator -(IntVector2 a, IntVector2 b) {
			return new IntVector2(a.x - b.x, a.y - b.y);
		}

		public static IntVector2 operator *(IntVector2 a, int c) {
			return new IntVector2(a.x * c, a.y * c);
		}

		public static IntVector2 operator -(IntVector2 a) {
			return a * -1;
		}
	}
}