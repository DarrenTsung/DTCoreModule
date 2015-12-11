using DT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public class OpenableObjectManager {
    // PRAGMA MARK - Static
    public static void AddLoader(IOpenableObjectLoader loader) {
      _objectLoaders.Add(loader);
    }
    
    public static List<IOpenableObject> LoadAll() {
      List<IOpenableObject> loadedObjects = new List<IOpenableObject>();
      
      foreach (IOpenableObjectLoader loader in _objectLoaders) {
        IOpenableObject[] objects = loader.Load();
        loadedObjects.AddRange(objects);
      }
      
      return loadedObjects;
    }
    
    private static List<IOpenableObjectLoader> _objectLoaders = new List<IOpenableObjectLoader>();
    
    
    // PRAGMA MARK - Constructors
    public OpenableObjectManager() {
      _loadedObjects = OpenableObjectManager.LoadAll();
    }
    
    
    // PRAGMA MARK - Public Interface
    public IOpenableObject[] ObjectsSortedByMatch(string input) {
			string inputLowercase = input.ToLower();
			
      List<IOpenableObject> objectsCopy = new List<IOpenableObject>(_loadedObjects);
      
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
    private List<IOpenableObject> _loadedObjects;
  }
}
