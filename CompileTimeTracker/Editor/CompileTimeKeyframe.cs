using System;

namespace DT {
    [Serializable]
    public class CompileTimeKeyframe {
        public DateTime Date {
          get {
            if (string.IsNullOrEmpty(this.serializedDate)) {
              return DateTime.MinValue;
            }

            return DateTime.Parse(this.serializedDate);
          }
        }

        public int elapsedCompileTimeInMS;
        public string serializedDate;
        public bool hadErrors;

        public CompileTimeKeyframe(int elapsedCompileTimeInMS, bool hadErrors) {
            this.elapsedCompileTimeInMS = elapsedCompileTimeInMS;
            this.serializedDate = DateTime.Now.ToString();
            this.hadErrors = hadErrors;
        }
    }
}