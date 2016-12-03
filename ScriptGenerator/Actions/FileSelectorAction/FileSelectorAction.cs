using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
    public abstract class FileSelectorAction : ScriptableObject {
        // PRAGMA MARK - Public Interface
        public void Apply() {
            foreach (File f in this.SelectFiles()) {
                FileContext fContext = new FileContext(f);
                foreach (var replacementPopulator in this._replacementPopulators) {
                    replacementPopulator.Populate(fContext);
                }

                foreach (var fileContextAction in this._fileContextActions) {
                    fileContextAction.Apply(fContext);
                }
            }
        }


        // PRAGMA MARK - Internal
        [SerializeField] private List<ReplacementPopulator> _replacementPopulators = new List<ReplacementPopulator>();
        [SerializeField] private List<FileContextAction> _fileContextActions = new List<FileContextAction>();

        protected abstract IEnumerable<File> SelectFiles();
    }
}
