using System;

namespace DT {
    [Serializable]
    public class CompileTimeKeyframe {
        public int elapsedCompileTimeInMS;
        public DateTime date;
        public bool hadErrors;

        public CompileTimeKeyframe(int elapsedCompileTimeInMS, bool hadErrors) {
            this.elapsedCompileTimeInMS = elapsedCompileTimeInMS;
            this.date = DateTime.Now;
            this.hadErrors = hadErrors;
        }
    }
}