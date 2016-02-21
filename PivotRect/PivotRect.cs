using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  // Less performant than Rect, but pivots can make things easier to understand
  [Serializable]
  public class PivotRect {
    // PRAGMA MARK - Public Interface
    public Vector2 Pivot {
      get { return this._pivot; }
      set {
        if (this._pivot == value) {
          return;
        }

        this._pivot = value;
        this.UpdateComputedRect();
      }
    }

    public Rect ComputedRect {
      get {
        if (!this._initialized) {
          this.UpdateComputedRect();
          this._initialized = true;
        }

        return this._computedRect;
      }
    }

    public Rect Rect {
      set {
        if (this._rect == value) {
          return;
        }

        this._rect = value;
        this.UpdateComputedRect();
      }
    }

#if UNITY_EDITOR
    public void EditorUpdateComputedRect() {
      this.UpdateComputedRect();
    }
#endif


    // PRAGMA MARK - Internal
    [SerializeField]
    private Rect _rect;
    [SerializeField]
    public Vector2 _pivot = Vector2.zero;

    private Rect _computedRect;
    private bool _initialized = false;

    private void UpdateComputedRect() {
      this._computedRect = new Rect(
        this._rect.x - (this._pivot.x * this._rect.width),
        this._rect.y - (this._pivot.y * this._rect.height),
        this._rect.width,
        this._rect.height
      );
    }
  }
}
