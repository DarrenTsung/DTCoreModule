using DT;
using System.Collections;
﻿using UnityEngine;
﻿using UnityEngine.Events;

namespace DT {
	public static class DTNotifications {
		// NOTE (darren): notification snippet is useful here [notif, notifArgs]
		
		// PRAGMA MARK - Player
		public static UnityEvents.G PlayerChanged = new UnityEvents.G();
		public static UnityEvent PlayerDied = new UnityEvent();
		
		// PRAGMA MARK - Input
		public static UnityEvents.V2 HandlePrimaryDirection = new UnityEvents.V2();
		public static UnityEvents.V2 HandleSecondaryDirection = new UnityEvents.V2();
		public static UnityEvents.V2 HandleMouseScreenPosition = new UnityEvents.V2();
	}
}