


//SaveLoadSystem.cs
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSystem : MonoBehaviour
{
    //Required Headers(System.IO/System.Runtime.Serialization/System.Runtime.Serialization.Formatters.Binary)
    //Takes a generic type of object in order to make it work for almost any scenario.
    public static void Save<T>(T objectToSave,string key)
    {
        //creates new folder called save under the presistentDataPath.
        string path = Application.persistentDataPath + "/saves/";

        //presistantDataPath is usually found under Appdata/LocalRoaming/Companyname/ProjectName
        Directory.CreateDirectory(path);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream filestream = new FileStream(path + key + ".txt", FileMode.Create);

        //To evade all possible errors from causing a system malfunction.
        try { formatter.Serialize(filestream,objectToSave); }
        catch { Debug.Log("Save Failed"); }
        finally { filestream.Close(); }  
    }


    //Generic load type makes it more versetile.
    public static T  Load<T>(string key)
    {
        string path = Application.persistentDataPath + "/saves/";
        FileStream filestream = new FileStream(path + key + ".txt", FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();

        T returnValue = default(T);

        try { returnValue = (T)formatter.Deserialize(filestream); }
        catch { Debug.Log("Loading Failed"); }
        finally { filestream.Close(); }
        return returnValue;
    }

    //Before retrieving data its safer to make sure it exists as to not throw nullReferenceExceptions.
    public static bool SaveExists(string key)
    {
        string path = Application.persistentDataPath + "/saves/"+key+".txt";
        return File.Exists(path);

    }

    //Mostly used in the progress of creating a New Game
    public static void DeleteAllSavedFiles()
    {
        string path = Application.persistentDataPath + "/saves/";
        DirectoryInfo director = new DirectoryInfo(path);
        director.Delete(true);
        Directory.CreateDirectory(path);
    }

}
