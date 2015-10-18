using DT;
using System.Collections;
﻿using UnityEngine;
﻿using UnityEngine.Events;

namespace DT {
	public static class DTNotifications {
		// NOTE (darren): notification snippet is useful here [notif, notifArgs]
		
		// PRAGMA MARK - Player
		public static UnityEvents.IG PlayerChanged = new UnityEvents.IG();
		public static UnityEvents.I PlayerDied = new UnityEvents.I();
		
		// PRAGMA MARK - Input
		public static UnityEvents.V2 HandleMouseScreenPosition = new UnityEvents.V2();
		public static UnityEvents.IV2 HandlePrimaryDirection = new UnityEvents.IV2();
		public static UnityEvents.IV2 HandleSecondaryDirection = new UnityEvents.IV2();
	}
}