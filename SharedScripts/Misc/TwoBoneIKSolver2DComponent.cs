using DT;
﻿using System.Collections;
﻿using System.Collections.Generic;
﻿using UnityEngine;

namespace DT {
  [ExecuteInEditMode]
	public class TwoBoneIKSolver2DComponent : MonoBehaviour, ICustomEditor {
    // PRAGMA MARK - Internal
    [SerializeField]
    protected Transform _bone1;
    [SerializeField]
    protected Transform _bone2;
    
    [SerializeField]
    protected bool _solveForPositiveAngle2;
    
    [SerializeField]
    protected double _bone1Length = 1.0;
    [SerializeField]
    protected double _bone2Length = 1.0;
    
    [SerializeField, LocalVectorInspectable]
    protected Vector2 _targetLocalPosition;
    
    [Header("Read-Only Properties")]
    [SerializeField, ReadOnly]
    protected bool _validPositionFound;
    
    [SerializeField, ReadOnly]
    protected double _angle1;
    [SerializeField, ReadOnly]
    protected float _angle1Degrees;
    [SerializeField, ReadOnly]
    protected double _angle2;
    [SerializeField, ReadOnly]
    protected float _angle2Degrees;
    
    protected void Update() {
      this.SolveForIKSolution();
    }
    
    [MakeButtonAttribute]
    protected void SolveForIKSolution() {
      _validPositionFound = IKUtil.Calc2DTwoBoneAnalytic(out _angle1, out _angle2, _solveForPositiveAngle2, _bone1Length, _bone2Length, _targetLocalPosition);
      
      _angle1Degrees = (float)(Mathf.Rad2Deg * _angle1);
      _angle2Degrees = (float)(Mathf.Rad2Deg * _angle2);
      
      _bone1.eulerAngles = new Vector3(0, 0, _angle1Degrees);
      _bone2.position = _bone1.position + (Vector3)(new Vector2((float)_bone1Length, 0.0f)).Rotate(_angle1Degrees);
      _bone2.eulerAngles = new Vector3(0, 0, _angle1Degrees + _angle2Degrees);
    }
    
    protected void OnDrawGizmos() {
      Gizmos.color = (_validPositionFound) ? Color.green : Color.red;
      
      Vector3 bone2Position = _bone1.position + (Vector3)(new Vector2((float)_bone1Length, 0.0f)).Rotate(_angle1Degrees);
      Vector3 bone2EndPosition = bone2Position + (Vector3)(new Vector2((float)_bone2Length, 0.0f)).Rotate(_angle1Degrees + _angle2Degrees);
      
      Gizmos.DrawLine(_bone1.position, bone2Position);
      Gizmos.DrawLine(bone2Position, bone2EndPosition);
      
      Gizmos.DrawSphere((Vector3)((Vector2)transform.position + _targetLocalPosition), 0.05f);
    }
	}
}