using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    private List<IDataPersistance> datapersistancesObject;
    private FileDataHandler dataHandler;
    public static DataManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("More Data Manager");
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if(this.gameData == null)
        {
            Debug.Log("No saved game. Creating New Game");
            NewGame();
        }
        foreach (IDataPersistance dataPersistenceObj in datapersistancesObject)
        {
            dataPersistenceObj.loadData(gameData);
        }
        
    }

    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistenceObj in datapersistancesObject)
        {
            dataPersistenceObj.saveData(ref gameData);
        }
        
        dataHandler.Save(gameData);
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.datapersistancesObject = FindAllDataPersistenecObject();
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistenecObject()
    {
        IEnumerable<IDataPersistance> dataPersistenceObject = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistenceObject);
    }
}
