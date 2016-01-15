using DT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public class OpenableObjectManager {
    // PRAGMA MARK - Constructors
    public void AddLoader(IOpenableObjectLoader loader) {
      this._objectLoaders.Add(loader);

      // Add all objects from loaded into _loadedObjects
      IOpenableObject[] objects = loader.Load();
      this._loadedObjects.AddRange(objects);
    }

    // PRAGMA MARK - Public Interface
    public IOpenableObject[] ObjectsSortedByMatch(string input) {
			string inputLowercase = input.ToLower();

      List<IOpenableObject> objectsCopy = new List<IOpenableObject>(this._loadedObjects);

      Dictionary<string, double> cachedDistances = new Dictionary<string, double>();
      foreach (IOpenableObject obj in objectsCopy) {
				string displayTitle = obj.DisplayTitle;
				string displayTitleLowercase = displayTitle.ToLower();

				float editDistance = ComparisonUtil.EditDistance(displayTitleLowercase, inputLowercase);

				string longestCommonSubstring = ComparisonUtil.LongestCommonSubstring(displayTitleLowercase, inputLowercase);
				float substringLength = longestCommonSubstring.Length;
				float substringIndex = displayTitleLowercase.IndexOf(longestCommonSubstring);

				double distance = 0;
				distance += 0.05f * editDistance;
				distance += 2.0f * -substringLength;
				distance += substringIndex;

        cachedDistances[displayTitle] = distance;
      }

      objectsCopy.Sort(delegate(IOpenableObject objA, IOpenableObject objB) {
        double distanceA = cachedDistances[objA.DisplayTitle];
        double distanceB = cachedDistances[objB.DisplayTitle];
        return distanceA.CompareTo(distanceB);
      });

      return objectsCopy.ToArray();
    }


    // PRAGMA MARK - Internal
    private List<IOpenableObject> _loadedObjects = new List<IOpenableObject>();
    private List<IOpenableObjectLoader> _objectLoaders = new List<IOpenableObjectLoader>();
  }
}
