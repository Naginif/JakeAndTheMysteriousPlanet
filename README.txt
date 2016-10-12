READ ME:
bugs found: 
-Ground pieces overlaped instead of seemlessly connecting to each other.  FIX: reduce prefab scale of each ground block from 1 to .8
-player rolls instead of moves forward. FIX: expanded "Contraints" option and check "Freeze Rotation Z" in player inspector
-when animated, player will jump endlessly despite isGrounded method.  FIX: checked "isAlive" and unchecked "isGrounded" in Unity Animator
-List levelPieces in LevelGenerator script giving null reference error.  FIX: set Level Prefabs size to 2 and drag and droped the appropriate prefabs in LevelGenerator Inspector.
-GameOver sreen appeared during menu screen. FIX: unchecked "Canvas" in GameOverCanvas Inspector.
-Coins would spawn on top of each other rather than following each level piece.  FIX: take x position of level starting point as position of first coin and increment from there.
-Unity could not find level 2.  FIX: added level 2 in unity build settings.
