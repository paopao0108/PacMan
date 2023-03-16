using System;

public class GameModel 
{
    private static GameModel _instance;
    public static int startCountDown = 3; // 游戏开始倒计时
    public static int gameTime = 60; // 游戏时间
    public static int leftTime = gameTime; // 剩余时间

    public static bool IsSwitchCamera = false; // 相机拉近
    public static bool IsReadying = false; // 倒计时准备
    public static bool IsGameStart = false; // 游戏开始
    public static bool IsGameOver = false; // 游戏结束
    //public static bool isTrackerStop = true; // 追踪者是否停止移动

    private GameModel() { }

    public static void Reset()
    {
        startCountDown = 3;
        leftTime = 60;
        ScoreModel.GetInstance().CurScore = 0;
        AudioController.isPaused = false;
        IsSwitchCamera = true;
        IsReadying = false;
        IsGameStart = false;
        IsGameOver = false;
    }

    public static GameModel GetInstance()
    {
        if (_instance == null) _instance = new GameModel();
        return _instance;
    }
}
