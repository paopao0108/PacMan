using System;

public class GameModel 
{
    private static GameModel _instance;
    private int _score = 35; // 获得胜利的分数
    //private int _dotCount;
    private int _gameTime = 60; // 游戏时间

    public static bool IsSwitchCamera = false; // 相机拉近
    public static bool IsReadying = false; // 倒计时准备
    public static bool IsGameStart = false; // 游戏开始
    public static bool IsGameOver = false; // 游戏结束

    private GameModel() { }

    public int Score { get => _score; }

    public static void Reset()
    {
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
