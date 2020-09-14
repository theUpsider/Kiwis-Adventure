using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/player.data";
    static string pathGameData = Application.persistentDataPath + "/game.data";
        static BinaryFormatter formatter = new BinaryFormatter();
    public static void SavePlayer(Player player)
    {        
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, player);
        stream.Close();
        Debug.Log("Saved under: " + path);
    }

    public static void SaveGameData(GameData gamedata)
    {
        FileStream stream = new FileStream(pathGameData, FileMode.Create);

        formatter.Serialize(stream, gamedata);
        stream.Close();
        Debug.Log("Saved under: " + path);
        SoundManager.PlaySound(Sounds.saved);
    }

    public static GameData LoadGameState()
    {
        if (File.Exists(pathGameData))
        {
            FileStream stream = new FileStream(pathGameData, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("Save File not found in " + path);
            return null;
        }
    }
    public static Player LoadPlayer()
    {
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);

            Player data = formatter.Deserialize(stream) as Player;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("Save File not found in " + path);
            return null;
        }
    }
}
