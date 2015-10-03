using System.Collections;
using UnityEngine;

namespace DT {
  public class DTManager : Singleton<DTManager> {
    protected void Awake() {
      Locator.Initialize();
      Locator.ProvideLogger(new UnityLogger());
    }
  }
}