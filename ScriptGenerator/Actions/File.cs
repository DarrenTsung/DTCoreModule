using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
    public class File {
        public string Path { get; private set; }
        public string[] Lines { get; private set; }

        public File(string path, IList<string> lines) {
            this.Path = path;
            this.Lines = lines.ToArray();
        }
    }
}
