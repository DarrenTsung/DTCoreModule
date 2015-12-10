using DT;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  public static class ComparisonUtil {
    /// <summary>
    /// Computes the Levenshtein Edit Distance between two enumerables.
    /// </summary>
    public static int EditDistance<T>(IEnumerable<T> x, IEnumerable<T> y) where T : IEquatable<T> {
      // Validate parameters
      if (x == null) throw new ArgumentNullException("x");
      if (y == null) throw new ArgumentNullException("y");
      
      // Convert the parameters into IList instances
      // in order to obtain indexing capabilities
      IList<T> first = x as IList<T> ?? new List<T>(x);
      IList<T> second = y as IList<T> ?? new List<T>(y);
      
      // Get the length of both.  If either is 0, return
      // the length of the other, since that number of insertions
      // would be required.
      int n = first.Count, m = second.Count;
      if (n == 0) return m;
      if (m == 0) return n;
      
      // Rather than maintain an entire matrix (which would require O(n*m) space),
      // just store the current row and the next row, each of which has a length m+1,
      // so just O(m) space. Initialize the current row.
      int curRow = 0, nextRow = 1;
      int[][] rows = new int[][] { new int[m + 1], new int[m + 1] };
      for (int j = 0; j <= m; ++j) rows[curRow][j] = j;
      
      // For each virtual row (since we only have physical storage for two)
      for (int i = 1; i <= n; ++i) {
        // Fill in the values in the row
        rows[nextRow][0] = i;
        for (int j = 1; j <= m; ++j) {
          int dist1 = rows[curRow][j] + 1;
          int dist2 = rows[nextRow][j - 1] + 1;
          int dist3 = rows[curRow][j - 1] +
          (first[i - 1].Equals(second[j - 1]) ? 0 : 1);
          
          rows[nextRow][j] = Math.Min(dist1, Math.Min(dist2, dist3));
        }
        
        // Swap the current and next rows
        if (curRow == 0) {
          curRow = 1;
          nextRow = 0;
        } else {
          curRow = 0;
          nextRow = 1;
        }
      }
      
      // Return the computed edit distance
      return rows[curRow][m];
    }
  }
}
