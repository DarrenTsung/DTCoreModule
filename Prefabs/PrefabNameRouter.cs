using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DT {
	public static class PrefabNameRouter {
    // PRAGMA MARK - Static
    private static Dictionary<string, string> _prefabNameMapping = new Dictionary<string, string>();

    public static void RegisterRouting(string oldPrefabName, string newPrefabName) {
      if (PrefabNameRouter.HasRoutingForPrefabName(oldPrefabName)) {
        Debug.LogWarning(string.Format("PrefabNameRouter.RegisterRouting: Overriding previously routed old prefab name ({0})!", oldPrefabName));
      }

      PrefabNameRouter._prefabNameMapping[oldPrefabName] = newPrefabName;
    }

    public static bool HasRoutingForPrefabName(string prefabName) {
      return PrefabNameRouter._prefabNameMapping.ContainsKey(prefabName);
    }

    public static string RoutedPrefabName(string prefabName) {
      if (PrefabNameRouter.HasRoutingForPrefabName(prefabName)) {
        return PrefabNameRouter._prefabNameMapping[prefabName];
      }

      return prefabName;
    }
  }
}
