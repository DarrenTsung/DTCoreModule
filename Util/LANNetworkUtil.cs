using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine;

namespace DT {
  public static class LANNetworkUtil {
    public static bool IsConnectedToNetwork() {
      return NetworkInterface.GetIsNetworkAvailable();
    }

    public static IPAddress GetIpAddress() {
      using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0)) {
          socket.Connect("10.0.2.4", 65530);
          return (socket.LocalEndPoint as IPEndPoint).Address;
      }
    }
  }
}