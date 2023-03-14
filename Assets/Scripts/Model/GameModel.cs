using System;

public class GameModel 
{
    private static GameModel _instance;
    private int _score = 35; // 获得胜利的分数
    //private int _dotCount;
    private int _gameTime = 60; // 游戏时间

    private GameModel() { }

    public int Score { get => _score; }

    public static GameModel GetInstance()
    {
        if (_instance == null) _instance = new GameModel();
        return _instance;
    }
}
