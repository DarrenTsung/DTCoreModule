using DT;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace DT {
	public class IKUtil {
		/// <summary>
		/// 2D Two Bone Analytic Solver - (http://www.ryanjuckett.com/programming/analytic-two-bone-ik-in-2d/)
		/// </summary>
		/// <param name="angle1">Angle of bone 1</param>
		/// <param name="angle2">Angle of bone 2</param>
		/// <param name="solveForPositiveAngle2">Solve for positive angle 2 instead of negative angle 2</param>
		/// <param name="length1">Length of bone 1, must be >= 0</param>
		/// <param name="length2">Length of bone 2, must be >= 0</param>
		/// <param name="targetPosition">Position to solve for</param>
		public static bool Calc2DTwoBoneAnalytic(out double angle1, out double angle2, bool solveForPositiveAngle2, double length1, double length2, Vector2 targetPosition) {
			Assert.IsTrue(length1 > 0.0 && length2 > 0.0);

			bool foundValidSolution = true;

			double targetDistanceSquared = (targetPosition.x * targetPosition.x) + (targetPosition.y * targetPosition.y);

			// compute the value for angle2
			double sinAngle2;
			double cosAngle2;

			double cosAngle2Denominator = 2.0 * length1 * length2;
			if (cosAngle2Denominator > MathUtil.epsilon) {
				cosAngle2 = (targetDistanceSquared - (length1 * length1) - (length2 * length2)) / cosAngle2Denominator;

				// if value is not inside legal range, it's not a valid solution 
				if (cosAngle2 < -1.0 || cosAngle2 > 1.0) {
					foundValidSolution = false;
				}

				// clamp inside legal range
				cosAngle2 = Math.Max(-1.0, Math.Min(1.0, cosAngle2));

				angle2 = Math.Acos(cosAngle2);

				if (!solveForPositiveAngle2) {
					angle2 = -angle2;
				}

				sinAngle2 = Math.Sin(angle2);
			} else {
				// at least one of the bones had a zero length, so our solvable domain
				// is a circle around the origin with a radius equal to the sum of bone lengths
				double totalLengthSquared = (length1 + length2) * (length1 + length2);

				// if the target distance is not approx equal to the total length of the bones
				if (targetDistanceSquared < (totalLengthSquared - MathUtil.epsilon)
					|| targetDistanceSquared > (totalLengthSquared + MathUtil.epsilon)) {
					foundValidSolution = false;
				}

				// only the value of angle1 matters (since angle2 is a child of angle1).
				// we can set angle2 to zero
				angle2 = 0.0;
				cosAngle2 = 1.0;
				sinAngle2 = 0.0;
			}

			// compute the value for angle1
			double triangleAdjacent = length1 + (length2 * cosAngle2);
			double triangleOpposite = length2 * sinAngle2;

			double tanY = (targetPosition.y * triangleAdjacent) - (targetPosition.x * triangleOpposite);
			double tanX = (targetPosition.x * triangleAdjacent) + (targetPosition.y * triangleOpposite);

			// it's safe to call Atan2(0.0, 0.0) - possible edge case if targetX and targetY are zero
			angle1 = Math.Atan2(tanY, tanX);

			return foundValidSolution;
		}
	}
}