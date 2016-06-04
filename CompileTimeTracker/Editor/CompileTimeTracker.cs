using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DT {
  [InitializeOnLoad]
  public static class CompileTimeTracker {
    public static event Action<CompileTimeKeyframe> KeyframeAdded = delegate {};

    public static IList<CompileTimeKeyframe> GetCompileTimeHistory() {
      return CompileTimeTracker._data.GetCompileTimeHistory();
    }

    static CompileTimeTracker() {
      EditorApplicationCompilationUtil.StartedCompiling += CompileTimeTracker.HandleEditorStartedCompiling;
      EditorApplicationCompilationUtil.FinishedCompiling += CompileTimeTracker.HandleEditorFinishedCompiling;
    }


    private const string kCompileTimeTrackerKey = "CompileTimeTracker::_data";
    private static CompileTimeTrackerData _data = new CompileTimeTrackerData(kCompileTimeTrackerKey);

    private static void HandleEditorStartedCompiling() {
      CompileTimeTracker._data.StartTime = CompileTimeTracker.GetMilliseconds();

      UnityEditorConsoleUtil.Clear();
    }

    private static void HandleEditorFinishedCompiling() {
      int elapsedTime = (int)(CompileTimeTracker.GetMilliseconds() - CompileTimeTracker._data.StartTime);

      // NOTE (darren): because we cleared the console when editor started compiling, all errors
      // at this point should be compile errors

      // NOTE (darren): we clear the console when starting compiling instead of now because we want
      // to preserve warnings and other information
      UnityConsoleCountsByType countsByType = UnityEditorConsoleUtil.GetCountsByType();
      bool hasErrors = countsByType.errorCount > 0;

      CompileTimeKeyframe keyframe = new CompileTimeKeyframe(elapsedTime, hasErrors);
      CompileTimeTracker._data.AddCompileTimeKeyframe(keyframe);
      CompileTimeTracker.KeyframeAdded.Invoke(keyframe);
    }

    private static long GetMilliseconds() {
      return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    }
  }
}