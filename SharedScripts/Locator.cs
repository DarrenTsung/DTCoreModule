using System.Collections;
using System.Collections.Generic;

namespace DT {
  /// <summary>
  /// Service-locator design pattern
  ///
  /// http://gameprogrammingpatterns.com/
  /// </summary>
  public class Locator {
    public static void Initialize() {
      _nullLoggerService = new NullLogger();
    }
    
    public static Logger Logger {
      get { return _loggerService; }
    }
    
    public static void ProvideLogger(Logger service) {
      if (service == null) {
        _loggerService = _nullLoggerService;
      } else {
        _loggerService = service;
      }
    }
    
    protected static Logger _loggerService;
    protected static NullLogger _nullLoggerService;
  }
}