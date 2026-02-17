using UnityEngine;

public static class GameControl // Static class to hold game state variables
{
    public static int difficulty, newQuestion, score, easyHScore, mediumHScore, hardHScore;
    public static int isPaused = 0; // 0 = not paused, 1 = paused
    public static int isGameOver = 0; // 0 = game ongoing, 1 = game over
    public static int updateCertificates = 0; // 0 = don't update, 1 = can be updated
    public static void AddScore(int difficulty)
    {
        int points = 0;
        switch (difficulty)
        {
            case 0: points = 1; break;
            case 1: points = 2; break;
            case 2: points = 3; break;
        }
        score += points;
    }
}