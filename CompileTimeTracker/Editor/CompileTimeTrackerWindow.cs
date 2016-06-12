using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
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
      return string.Format("{0}s", (ms / 1000.0f).ToString("F2", CultureInfo.InvariantCulture));
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

    private bool ShowErrors {
      get { return EditorPrefs.GetBool("CompileTimeTrackerWindow.ShowErrors"); }
      set { EditorPrefs.SetBool("CompileTimeTrackerWindow.ShowErrors", value); }
    }

    private bool OnlyToday {
      get { return EditorPrefs.GetBool("CompileTimeTrackerWindow.OnlyToday"); }
      set { EditorPrefs.SetBool("CompileTimeTrackerWindow.OnlyToday", value); }
    }

    private bool OnlyYesterday {
      get { return EditorPrefs.GetBool("CompileTimeTrackerWindow.OnlyYesterday"); }
      set { EditorPrefs.SetBool("CompileTimeTrackerWindow.OnlyYesterday", value); }
    }

    void OnGUI() {
      Rect screenRect = this.position;
      int totalCompileTimeInMS = 0;

      // show filters
      EditorGUILayout.BeginHorizontal(GUILayout.Height(20.0f));
        EditorGUILayout.Space();
        float toggleRectWidth = screenRect.width / 4.0f;
        Rect toggleRect = new Rect(Vector2.zero, new Vector2(toggleRectWidth, 20.0f));

        // Psuedo enum logic here
        if (this.OnlyToday && this.OnlyYesterday) {
          this.OnlyYesterday = false;
        }

        if (!this.OnlyToday && !this.OnlyYesterday) {
          this.OnlyToday = true;
        }

        bool newOnlyToday = GUI.Toggle(toggleRect, this.OnlyToday, "Today", (GUIStyle)"Button");
        if (newOnlyToday != this.OnlyToday) {
          this.OnlyToday = newOnlyToday;
          this.OnlyYesterday = !newOnlyToday;
        }

        toggleRect.position = toggleRect.position.AddX(toggleRectWidth);
        bool newOnlyYesterday = GUI.Toggle(toggleRect, this.OnlyYesterday, "Yesterday", (GUIStyle)"Button");
        if (newOnlyYesterday != this.OnlyYesterday) {
          this.OnlyYesterday = newOnlyYesterday;
          this.OnlyToday = !newOnlyYesterday;
        }
        // End psuedo enum logic

        toggleRect.position = toggleRect.position.AddX(toggleRectWidth + 20.0f);
        this.ShowErrors = GUI.Toggle(toggleRect, this.ShowErrors, "Errors", (GUIStyle)"Button");
      EditorGUILayout.EndHorizontal();

      this._scrollPosition = EditorGUILayout.BeginScrollView(this._scrollPosition, GUILayout.Height(screenRect.height - 40.0f));
        foreach (CompileTimeKeyframe keyframe in this.GetFilteredKeyframes()) {
          string compileText = string.Format("({0:hh:mm tt}): ", keyframe.Date);
          compileText += CompileTimeTrackerWindow.FormatMSTime(keyframe.elapsedCompileTimeInMS);
          if (keyframe.hadErrors) {
            compileText += " (error)";
          }
          GUILayout.Label(compileText);

          totalCompileTimeInMS += keyframe.elapsedCompileTimeInMS;
        }
      EditorGUILayout.EndScrollView();

      string statusBarText = "Total compile time: " + CompileTimeTrackerWindow.FormatMSTime(totalCompileTimeInMS);
      if (EditorApplication.isCompiling) {
        statusBarText = "Compiling.. || " + statusBarText;
      }
      GUILayout.Label(statusBarText);
    }

    void OnEnable() {
      EditorApplicationCompilationUtil.StartedCompiling += this.HandleEditorStartedCompiling;
      CompileTimeTracker.KeyframeAdded += this.HandleCompileTimeKeyframeAdded;
    }

    void OnDisable() {
      EditorApplicationCompilationUtil.StartedCompiling -= this.HandleEditorStartedCompiling;
      CompileTimeTracker.KeyframeAdded -= this.HandleCompileTimeKeyframeAdded;
    }

    private IEnumerable<CompileTimeKeyframe> GetFilteredKeyframes() {
      IEnumerable<CompileTimeKeyframe> filteredKeyframes = CompileTimeTracker.GetCompileTimeHistory();
      if (!this.ShowErrors) {
        filteredKeyframes = filteredKeyframes.Where(keyframe => !keyframe.hadErrors);
      }

      if (this.OnlyToday) {
        filteredKeyframes = filteredKeyframes.Where(keyframe => DateTimeUtil.SameDay(keyframe.Date, DateTime.Now));
      } else if (this.OnlyYesterday) {
        filteredKeyframes = filteredKeyframes.Where(keyframe => DateTimeUtil.SameDay(keyframe.Date, DateTime.Now.AddDays(-1)));
      }

      return filteredKeyframes;
    }

    private void HandleEditorStartedCompiling() {
      this.Repaint();
    }

    private void HandleCompileTimeKeyframeAdded(CompileTimeKeyframe keyframe) {
      this.Repaint();
    }
  }
}