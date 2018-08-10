using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData : MonoBehaviour{
    public static string ObjectToStringSerialize(Player obj) // Serialize
    {
        using (var memoryStream = new MemoryStream())
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memoryStream, obj);
            memoryStream.Flush();
            memoryStream.Position = 0;

            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }

    public static Player Deserialize<Player>(string xmlText) // Deserialize
    {
        if (xmlText != null && xmlText != String.Empty)
        {
            byte[] b = Convert.FromBase64String(xmlText);
            using (var stream = new MemoryStream(b))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (Player)formatter.Deserialize(stream);
            }
        }
        else
        {
            return default(Player);
        }
    }

    public static void SaveFile(Player player)
    {
        string objectAraData = ObjectToStringSerialize(player);
        PlayerPrefs.SetString("wer", objectAraData);
    }

    public void LoadFile()
    {
        string loadData = PlayerPrefs.GetString("wer", string.Empty);
        Player player;
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
            player = Deserialize<Player>(loadData);
        }
        else
        {
            player = Deserialize<Player>(loadData);
            Instantiate(player.gameObject);

        }
        DontDestroyOnLoad(player);
    }

}
