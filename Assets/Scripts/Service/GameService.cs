using System;

public class GameService
{
    private static GameService _instance;

    private GameService() { }
    public static GameService GetInstanvce()
    {
        if (_instance == null) _instance = new GameService();
        return _instance;
    }

    public void GameOver()
    {
        // ʧ��
        // 1. ��������
        // 2. �߳��Թ�

        // ʤ��
        // 3. ���궹�ӣ��������Թ���
        if (ScoreModel.GetInstance().CurScore >= GameModel.GetInstance().Score)
        {
            Console.WriteLine("��Ϸʤ������");
        }
         
    }
}
