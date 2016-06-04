using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace DT {
  [InitializeOnLoad]
  public class CompileTimeTrackerWindow : EditorWindow {
    // PRAGMA MARK - Static
    static CompileTimeTrackerWindow() {
      CompileTimeTracker.KeyframeAdded += CompileTimeTrackerWindow.LogCompileTimeKeyframe;
    }

    [MenuItem("Window/Compile Time Tracker Window")]
    public static void Open() {
      EditorWindow.GetWindow<CompileTimeTrackerWindow>(false, "Compile Timer Tracker", true);
    }

    private static string FormatMSTime(int ms) {
      return string.Format("{0}s", (ms / 1000.0f).ToString("F3", CultureInfo.InvariantCulture));
    }

    private static void LogCompileTimeKeyframe(CompileTimeKeyframe keyframe) {
      string compilationFinishedLog = "Compilation Finished: " + CompileTimeTrackerWindow.FormatMSTime(keyframe.elapsedCompileTimeInMS);
      if (keyframe.hadErrors) {
        compilationFinishedLog += " (error)";
      }
      UnityEngine.Debug.Log(compilationFinishedLog);
    }


    // PRAGMA MARK - Internal
    private Vector2 _scrollPosition;

    void OnGUI() {
      Rect screenRect = this.position;
      int totalCompileTimeInMS = 0;

      this._scrollPosition = EditorGUILayout.BeginScrollView(this._scrollPosition, GUILayout.Height(screenRect.height - 20.0f));
        foreach (CompileTimeKeyframe keyframe in CompileTimeTracker.GetCompileTimeHistory()) {
          string compileText = CompileTimeTrackerWindow.FormatMSTime(keyframe.elapsedCompileTimeInMS);
          if (keyframe.hadErrors) {
            compileText += " (error)";
          }
          GUILayout.Label(compileText);

          totalCompileTimeInMS += keyframe.elapsedCompileTimeInMS;
        }

        EditorGUILayout.Space();

        if (EditorApplication.isCompiling) {
          GUILayout.Label("Compiling..");
        }
      EditorGUILayout.EndScrollView();

      GUILayout.Label("Total compile time: " + CompileTimeTrackerWindow.FormatMSTime(totalCompileTimeInMS));
    }

    void OnEnable() {
      EditorApplicationCompilationUtil.StartedCompiling += this.HandleEditorStartedCompiling;
      CompileTimeTracker.KeyframeAdded += this.HandleCompileTimeKeyframeAdded;
    }

    void OnDisable() {
      EditorApplicationCompilationUtil.StartedCompiling -= this.HandleEditorStartedCompiling;
      CompileTimeTracker.KeyframeAdded -= this.HandleCompileTimeKeyframeAdded;
    }

    private void HandleEditorStartedCompiling() {
      this.Repaint();
    }

    private void HandleCompileTimeKeyframeAdded(CompileTimeKeyframe keyframe) {
      this.Repaint();
    }
  }
}