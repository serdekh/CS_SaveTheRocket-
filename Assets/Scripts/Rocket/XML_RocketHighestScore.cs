using System.Xml;
using UnityEngine;

public class XML_RocketHighestScore : MonoBehaviour
{
    private const string HIGHEST_SCORE_ATTRIBUTE = "highest-score";
    private const string CONFIG = "/config.xml";

    [SerializeField] private int _highestScore;

    private Rocket _rocket;

    private void Awake()
    {
        _rocket = FindObjectOfType<Rocket>();
        LoadConfig();
    }

    private void OnEnable()
    {
        Rocket.OnDeath += SaveConfig;
    }

    private void OnDisable()
    {
        Rocket.OnDeath -= SaveConfig;
    }

    private void SaveConfig()
    {
        LoadConfig();

        if (_rocket.Score < GetHighestScore())
        {
            return;
        }

        XmlElement element;
        XmlDocument xmlDocument = new XmlDocument();
        XmlNode root = xmlDocument.CreateElement("Config");

        xmlDocument.AppendChild(root);

        element = xmlDocument.CreateElement(HIGHEST_SCORE_ATTRIBUTE);
        element.SetAttribute(HIGHEST_SCORE_ATTRIBUTE, _rocket.Score.ToString());
        root.AppendChild(element);

        xmlDocument.Save(Application.dataPath + CONFIG);
    }

    private void LoadConfig()
    {
        XmlTextReader reader = new XmlTextReader(Application.dataPath + CONFIG);

        while (reader.Read())
        {
            if (reader.IsStartElement(HIGHEST_SCORE_ATTRIBUTE))
            {
                int highestScore = 0;

                if (int.TryParse(reader.GetAttribute("value"), out highestScore))
                {
                    _highestScore = highestScore;                   
                }
            }
        }

        reader.Close();
    }

    public int GetHighestScore()
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(Application.dataPath + CONFIG);
 
        XmlElement xRoot = xDoc.DocumentElement;

        if (xRoot != null)
        {
            foreach (XmlElement xnode in xRoot)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem(HIGHEST_SCORE_ATTRIBUTE);
                return int.Parse(attr.InnerText);
            }
        }

        return -1;
    }
}
