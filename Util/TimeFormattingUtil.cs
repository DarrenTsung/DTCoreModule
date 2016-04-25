using UnityEngine;
using System.Text;

namespace DT {
	public static class TimeFormattingUtil {
    public static string FormatTimeLeft(int timeLeftInSeconds) {
      StringBuilder builder = new StringBuilder();

      int dayInSeconds = 60 * 60 * 24;
      int hourInSeconds = 60 * 60;
      int minuteInSeconds = 60;

      if (timeLeftInSeconds > dayInSeconds) {
        int numberOfDays = Mathf.FloorToInt(timeLeftInSeconds / dayInSeconds);
        builder.Append(string.Format(" {0}d", numberOfDays));
        timeLeftInSeconds %= dayInSeconds;
      }

      if (timeLeftInSeconds > hourInSeconds) {
        int numberOfHours = Mathf.FloorToInt(timeLeftInSeconds / hourInSeconds);
        builder.Append(string.Format(" {0}h", numberOfHours));
        timeLeftInSeconds %= hourInSeconds;
      }

      // Minute
      if (timeLeftInSeconds > minuteInSeconds) {
        int numberOfMinutes = Mathf.FloorToInt(timeLeftInSeconds / minuteInSeconds);
        builder.Append(string.Format(" {0}m", numberOfMinutes));
        timeLeftInSeconds %= minuteInSeconds;
      }

      builder.Append(string.Format(" {0}s", timeLeftInSeconds));
      return builder.ToString().Trim();
    }
	}
}