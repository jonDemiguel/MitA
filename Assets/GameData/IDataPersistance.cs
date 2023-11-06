using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public interface IDataPersistance 
{
    void loadData(GameData gameData);
    void saveData(ref GameData gameData);
}
