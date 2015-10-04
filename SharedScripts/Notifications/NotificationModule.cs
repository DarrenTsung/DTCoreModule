#define ENABLE_NOTIFICATION_MODULE_MANAGER

﻿using DT;
using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;

// All credit goes to prime31's MessageKit - I'm just rewriting it so I have a
// better understanding of all the code in my project
namespace DT {
	public static class NotificationModule {
		// PRAGMA MARK - INTERFACE
#if ENABLE_NOTIFICATION_MODULE_MANAGER
		static NotificationModule() {
			NotificationModuleManager.RegisterNotificationModuleMap(_messageMap);
		}
#endif

		public static void AddObserver(int messageType, Action handler) {
			List<Action> handlerList = null;
			if (!_messageMap.TryGetValue(messageType, out handlerList)) {
				handlerList = new List<Action>();
				_messageMap.Add(messageType, handlerList);
			}
			
			if (!handlerList.Contains(handler)) {
				_messageMap[messageType].Add(handler);
			}
		}
		
		public static void RemoveObserver(int messageType, Action handler) {
			List<Action> handlerList = null;
			if (_messageMap.TryGetValue(messageType, out handlerList)) {
				if (handlerList.Contains(handler)) {
					handlerList.Remove(handler);
				}
			}
		}
		
		public static void Post(int messageType) {
			List<Action> handlerList = null;
			if (_messageMap.TryGetValue(messageType, out handlerList)) {
				foreach (Action act in handlerList) {
					act();
				}
			}
		}
		
		public static void ClearObserversForType(int messageType) {
			if (_messageMap.ContainsKey(messageType)) {
				_messageMap.Remove(messageType);
			}
		}
		
		public static void ClearAllObservers() {
			_messageMap.Clear();
		}
		
		// PRAGMA MARK - INTERNAL
		private static Dictionary<int, List<Action>> _messageMap = new Dictionary<int, List<Action>>();
	}
	
	public static class NotificationModule<U> {
		// PRAGMA MARK - INTERFACE
#if ENABLE_NOTIFICATION_MODULE_MANAGER
		static NotificationModule() {
			NotificationModuleManager.RegisterNotificationModuleMap(_messageMap);
		}
#endif

		public static void AddObserver(int messageType, Action<U> handler) {
			List<Action<U>> handlerList = null;
			if (!_messageMap.TryGetValue(messageType, out handlerList)) {
				handlerList = new List<Action<U>>();
				_messageMap.Add(messageType, handlerList);
			}
			
			if (!handlerList.Contains(handler)) {
				_messageMap[messageType].Add(handler);
			}
		}
		
		public static void RemoveObserver(int messageType, Action<U> handler) {
			List<Action<U>> handlerList = null;
			if (_messageMap.TryGetValue(messageType, out handlerList)) {
				if (handlerList.Contains(handler)) {
					handlerList.Remove(handler);
				}
			}
		}
		
		public static void Post(int messageType, U param) {
			List<Action<U>> handlerList = null;
			if (_messageMap.TryGetValue(messageType, out handlerList)) {
				foreach (Action<U> act in handlerList) {
					act(param);
				}
			}
		}
		
		public static void ClearObserversForType(int messageType) {
			if (_messageMap.ContainsKey(messageType)) {
				_messageMap.Remove(messageType);
			}
		}
		
		public static void ClearAllObservers() {
			_messageMap.Clear();
		}
		
		// PRAGMA MARK - INTERNAL
		private static Dictionary<int, List<Action<U>>> _messageMap = new Dictionary<int, List<Action<U>>>();
	}
	
	public static class NotificationModule<U, V> {
		// PRAGMA MARK - INTERFACE
#if ENABLE_NOTIFICATION_MODULE_MANAGER
		static NotificationModule() {
			NotificationModuleManager.RegisterNotificationModuleMap(_messageMap);
		}
#endif

		public static void AddObserver(int messageType, Action<U, V> handler) {
			List<Action<U, V>> handlerList = null;
			if (!_messageMap.TryGetValue(messageType, out handlerList)) {
				handlerList = new List<Action<U, V>>();
				_messageMap.Add(messageType, handlerList);
			}
			
			if (!handlerList.Contains(handler)) {
				_messageMap[messageType].Add(handler);
			}
		}
		
		public static void RemoveObserver(int messageType, Action<U, V> handler) {
			List<Action<U, V>> handlerList = null;
			if (_messageMap.TryGetValue(messageType, out handlerList)) {
				if (handlerList.Contains(handler)) {
					handlerList.Remove(handler);
				}
			}
		}
		
		public static void Post(int messageType, U param1, V param2) {
			List<Action<U, V>> handlerList = null;
			if (_messageMap.TryGetValue(messageType, out handlerList)) {
				foreach (Action<U, V> act in handlerList) {
					act(param1, param2);
				}
			}
		}
		
		public static void ClearObserversForType(int messageType) {
			if (_messageMap.ContainsKey(messageType)) {
				_messageMap.Remove(messageType);
			}
		}
		
		public static void ClearAllObservers() {
			_messageMap.Clear();
		}
		
		// PRAGMA MARK - INTERNAL
		private static Dictionary<int, List<Action<U, V>>> _messageMap = new Dictionary<int, List<Action<U, V>>>();
	}
	
#if ENABLE_NOTIFICATION_MODULE_MANAGER
	public static class NotificationModuleManager {
		// PRAGMA MARK - INTERFACE
		public static void RegisterNotificationModuleMap(IDictionary messageMap) {
			_messageMaps.Add(messageMap);
		}
		
		public static void ClearAllObserversForAllTypes() {
			foreach (IDictionary messageMap in _messageMaps) {
				messageMap.Clear();
			}
		}
		
		// PRAGMA MARK - INTERNAL
		private static List<IDictionary> _messageMaps = new List<IDictionary>();
	}
#endif
}