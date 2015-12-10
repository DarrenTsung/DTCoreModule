using DT.Prefab;
using System;

namespace DT {
  public class OpenablePrefabObject : OpenableAsset {
    // PRAGMA MARK - IOpenableObject
    public override void Open() {
			PrefabSandbox.OpenPrefab(_guid, null);
    }
    
    
    // PRAGMA MARK - Constructors
    public OpenablePrefabObject(string guid) : base(guid) {
      if (!PathUtil.IsPrefab(_path)) {
        throw new ArgumentException("OpenablePrefabObject loaded with guid that's not a prefab!");
      }
    }
  }
}