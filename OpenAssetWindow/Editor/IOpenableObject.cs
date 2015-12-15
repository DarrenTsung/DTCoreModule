using DT;
using UnityEngine;

namespace DT {
	public interface IOpenableObject {
    string DisplayTitle {
      get; 
    }
		
		string DisplayDetailText {
			get;
		}
		
		Texture2D DisplayIcon {
			get;
		}
		
		bool IsValid();
    
    void Open();
  }
}
