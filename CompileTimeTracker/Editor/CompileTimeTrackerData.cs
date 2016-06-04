using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DT {
    public class CompileTimeTrackerData {
        public long StartTime {
            get { return this._startTime; }
            set {
                this._startTime = value;
                this.Save();
            }
        }

        public void AddCompileTimeKeyframe(CompileTimeKeyframe keyframe) {
            this._compileTimeHistory.Add(keyframe);
            this.Save();
        }

        public IList<CompileTimeKeyframe> GetCompileTimeHistory() {
            return this._compileTimeHistory;
        }

        public CompileTimeTrackerData(string editorPrefKey) {
            this._editorPrefKey = editorPrefKey;
            this.Load();
        }


        [SerializeField] private long _startTime;
        [SerializeField] private List<CompileTimeKeyframe> _compileTimeHistory;

        private string _editorPrefKey;

        private void Save() {
            EditorPrefs.SetString(this._editorPrefKey, JsonUtility.ToJson(this));
        }

        private void Load() {
            string serialized = EditorPrefs.GetString(this._editorPrefKey);
            JsonUtility.FromJsonOverwrite(serialized, this);
        }
    }
}