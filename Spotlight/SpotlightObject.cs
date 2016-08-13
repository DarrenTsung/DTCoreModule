using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT {
	public class SpotlightObject : MonoBehaviour, IRecycleCleanupSubscriber, IRecycleSetupSubscriber {
    // PRAGMA MARK - IRecycleCleanupSubscriber Implementation
    public void OnRecycleCleanup() {
      SpotlightManager.RemoveSpotlightGameObject(this.gameObject);
    }


    // PRAGMA MARK - IRecycleSetupSubscriber Implementation
    public void OnRecycleSetup() {
      SpotlightManager.AddSpotlightGameObject(this.gameObject);
    }
  }
}