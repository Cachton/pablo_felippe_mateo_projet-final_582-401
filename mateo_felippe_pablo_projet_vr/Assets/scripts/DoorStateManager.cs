using System.Collections.Generic;

public static class DoorStateManager
{
    public static HashSet<string> unlockedDoors = new HashSet<string>();

    public static void UnlockDoor(string doorID)
    {
        unlockedDoors.Add(doorID);
    }

    public static bool IsDoorUnlocked(string doorID)
    {
        return unlockedDoors.Contains(doorID);
    }
}