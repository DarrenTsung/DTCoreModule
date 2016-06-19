using UnityEditor;
using UnityEngine;

namespace DT {
	public class ToggleActiveSelectedGameObjectMenu {
		[MenuItem("DarrenTsung/Toggle Active/Smart Toggle Active for Selected GameObject #a")]
		public static void ToggleActiveSelectedGameObject() {
      GameObject obj = Selection.activeGameObject;
      if (obj == null) {
        return;
      }

      obj = PrefabUtility.FindPrefabRoot(obj);

      obj.SetActive(!obj.activeSelf);
		}
	}
}