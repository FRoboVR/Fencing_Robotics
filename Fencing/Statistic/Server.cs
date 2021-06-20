using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
namespace zzeerr.game
{

    public class Server : MonoBehaviour
    {
        #region Singlton:Top

        public static Server Instance;

        void Awake()
        {

            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        #endregion

        

        public enum DataType
        {
            Post,
            Get
        }

        public string GetUrl(DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Post:
                    return "http://diamine.net/Fencing/Post.php";
                    break;
                case DataType.Get:
                    return "http://diamine.net/Fencing/Get.php";
                    break;
                default:
                    return null;
                    break;
            }
        }

        public void GetTop(string discipline, string type, int count)
        {
            StartCoroutine(_GetTop(discipline, type, count));
        }

        private IEnumerator _GetTop(string discipline, string type, int count)
        {

            WWWForm formD = new WWWForm();
            formD.AddField("discipline", discipline);
            formD.AddField("type", type);
            formD.AddField("count", count.ToString());

            using (UnityWebRequest www = UnityWebRequest.Post(Server.Instance.GetUrl(Server.DataType.Post) + "?&discipline=" + discipline + "&type=" + type + "&count=" + count, formD))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError)
                {
                    Debug.Log("Error:" + www.error);
                }
                else
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    TopItem[] items = JsonHelper.getJsonArray<TopItem>(jsonResult);
                    InfoPanel.Instance.ClearTxt();
                    foreach (TopItem item in items)
                    {
                       // Debug.Log(item.name + item.score + item.discipline);
                        InfoPanel.Instance.AppendText(item);
                    }
                }
            }
        }

        public void SendTop(TopItem topItem)
        {
            StartCoroutine(_SendTop(topItem));
        }

        private IEnumerator _SendTop(TopItem topItem)
        {

            WWWForm formD = new WWWForm();
         /*   formD.AddField("name", topItem.name);
            formD.AddField("discipline", topItem.discipline);
            formD.AddField("score", topItem.score);*/
           
            var Query = new WWW(Server.Instance.GetUrl(Server.DataType.Get), formD);
            yield return Query;
            
            using (UnityWebRequest www = UnityWebRequest.Post(Server.Instance.GetUrl(Server.DataType.Get)+ "?&name="+topItem.name+"&discipline=" + topItem.discipline+ "&score="+topItem.score, formD))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError)
                {
                    Debug.Log("Error:" + www.error);
                }
                else
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log("Success"+ jsonResult);
                }
            }

        }
    }
}
