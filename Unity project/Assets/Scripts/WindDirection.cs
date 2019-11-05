using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Boomlagoon.JSON; 

public class WindDirection : MonoBehaviour
{
    private string city_name;
    private double wind_spd;  //Wind speed (Default m/s).
    private double wind_dir;  //Wind direction (degrees).
    private string wind_cdir; //Abbreviated wind direction.

    void Start()
    {
        StartCoroutine(GetRequest("https://api.weatherbit.io/v2.0/current?city_id=2735943&key=19bab0f9f75d4c8594ccc9ba5a27d2ae"));
    }

    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            var json = JSONObject.Parse(uwr.downloadHandler.text);
            var dataArray = json.GetArray("data");
            var data = JSONObject.Parse(dataArray[0].ToString());
            city_name = data.GetString("city_name");
            wind_spd = data.GetNumber("wind_spd");
            wind_dir = data.GetNumber("wind_dir");
            wind_cdir = data.GetString("wind_cdir");
        }
    }

    Vector3 getWind(){
        float radians = (float)wind_dir * (Mathf.PI / 180);
        Vector3 degreeVector = new Vector3(Mathf.Cos(radians)*(float)wind_dir, 0, Mathf.Sin(radians)*(float)wind_dir);
        return degreeVector;
    }
}
