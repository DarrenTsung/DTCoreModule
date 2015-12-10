using DT;

namespace DT {
	public interface IOpenableObject {
    string DisplayName {
      get; 
    }
    
    void Open();
  }
}
