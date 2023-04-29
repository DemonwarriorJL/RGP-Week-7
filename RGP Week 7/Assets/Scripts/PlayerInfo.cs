using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerInfo", order = 1)]
public class PlayerInfo : ScriptableObject
{
    public static float playerMaxHealth = 100;

    public static int playerGold = 0;
    public static bool timerUpgrade = false;
}