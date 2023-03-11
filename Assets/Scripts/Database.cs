using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Database
{
    public static void LocalSave(User _user)
    {

        BinaryFormatter formatter = new();
        string path = Application.persistentDataPath + "/player.nutrivitals";
        FileStream stream = new(path, FileMode.Create);

        UserModel userModel = new(_user);
        formatter.Serialize(stream, userModel);
        stream.Close();

    }

    public static UserModel LocalLoadUser()
    {

        string path = Application.persistentDataPath + "/player.nutrivitals";

        if (File.Exists(path))
        {

            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            UserModel userModel = formatter.Deserialize(stream) as UserModel;
            stream.Close();
            return userModel;

        }
        else
        {

            Debug.Log("Savefile Not Found in " + path);
            return null;

        }

    }
}
