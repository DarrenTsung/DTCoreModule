using DT;
using System.Collections;
﻿using UnityEngine;

public static class NotificationTypesBase {
	// PRAGMA MARK - Player
	// HandlePlayerChanged(GameObject player);
	public const int PLAYER_CHANGED = 100; 
	
	// PRAGMA MARK - Input
	// HandlePrimaryDirection(Vector2 primaryDirection);
	public const int HANDLE_PRIMARY_DIRECTION = 200;
	// HandleSecondaryDirection(Vector2 secondaryDirection);
	public const int HANDLE_SECONDARY_DIRECTION = 201;
}
