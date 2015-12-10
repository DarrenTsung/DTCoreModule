using DT;
using System.Collections;
using System.Collections.Generic;

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
      List<IOpenableObject> objectsCopy = new List<IOpenableObject>(_loadedObjects);
      
      Dictionary<string, int> cachedEditDistances = new Dictionary<string, int>();
      foreach (IOpenableObject obj in objectsCopy) {
        cachedEditDistances[obj.DisplayName] = ComparisonUtil.EditDistance(obj.DisplayName, input);
      }
      
      objectsCopy.Sort(delegate(IOpenableObject objA, IOpenableObject objB) {
        int editDistanceA = cachedEditDistances[objA.DisplayName];
        int editDistanceB = cachedEditDistances[objB.DisplayName];
        return editDistanceA.CompareTo(editDistanceB);
      });
      
      return objectsCopy.ToArray();
    }
    
    
    // PRAGMA MARK - Internal
    private List<IOpenableObject> _loadedObjects;
  }
}
