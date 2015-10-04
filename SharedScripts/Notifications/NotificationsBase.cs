using DT;
using System.Collections;
﻿using UnityEngine;

public static class NotificationsBase {
	// NOTE (darren): notification snippet is useful here
	
	// PRAGMA MARK - Player
	public static UnityEvents.G PlayerChanged = new UnityEvents.G();
	
	// PRAGMA MARK - Input
	public static UnityEvents.V2 HandlePrimaryDirection = new UnityEvents.V2();
	public static UnityEvents.V2 HandleSecondaryDirection = new UnityEvents.V2();
	public static UnityEvents.V2 HandleMouseScreenPosition = new UnityEvents.V2();
}
