using System.Collections;
using UnityEditor;
using UnityEngine;

namespace DT {
  public class CustomHeaderAttribute : PropertyAttribute {
    public string Text = "";
    public bool BoldText = false;

    public CustomHeaderAttribute(string text) {
      this.Text = text;
    }
  }
}