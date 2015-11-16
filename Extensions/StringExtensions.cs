using System;
using System.Collections;
using System.Collections.Generic;

namespace DT {
  public static class StringExtensions {
    public static char[] InvalidFileChars = new char[] {
      '/',
      '?',
      '<',
      '>',
      '\\',
      ':',
      '*',
      '|',
      '\"'
    };
    
    public static string RemoveSubstring(this string input, string removeString) {
      int index = input.IndexOf(removeString);
      if (index < 0) {
        return input;
      } else {
        return input.Remove(index, removeString.Length);
      }
    }
  }
}