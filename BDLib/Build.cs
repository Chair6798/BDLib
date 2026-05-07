using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using System.Xml.Linq;
using System.Xml;
namespace BDLib
{
    public static class Build
    {
        internal static Building BuildComponent = null;
        public static bool IsAvaiable()
        {
            return BuildComponent != null;
        }

        internal static void Init()
        {
            Logging.LogBuilder("Initializing BDLib Build class...");
            Events.SceneEvents.OnGameSceneLoaded.AddListener(OnGameLoaded);
        }
        internal static void OnGameLoaded()
        {
            Logging.LogBuilder("Game load handled, mapping build component...");
            try
            {
                BuildComponent = GameObject.Find("Camera").GetComponent<Building>();
                Logging.LogBuilder("Build component has been mapped successfully.");
            }
            catch
            {
                Logging.LogBuilder("Failed to map build component, building will not work.");
            }
            
        }

        public static void LoadXMLBuilding(string XmlFilePath = "myxmlfile.xml")
        {
            Logging.LogBuilder("Loading building from file: " + XmlFilePath);
            try
            {
                XDocument xmlbuilding = XDocument.Load(XmlFilePath);
                var walls = xmlbuilding.Descendants("wall");
                foreach (XElement wall in walls)
                {
                    Logging.LogBuilder("Loading wall");
                    try
                    {

                        var pos = new Vector3((float)wall.Attribute("posX"), (float)wall.Attribute("posY"), (float)wall.Attribute("posZ"));
                        var rot = new Vector3((float)wall.Attribute("rotX"), (float)wall.Attribute("rotY"), (float)wall.Attribute("rotZ"));
                        PlaceWall(pos, rot);
                        Logging.LogBuilder("Wall loaded at "+pos.ToString()+" with rotation "+rot.ToString());
                    }
                    catch
                    {
                        Logging.LogBuilder("Failed to load XML building!");
                    }
                }
            }
            catch(Exception ex)
            {
                Logging.LogBuilder(ex.Message);
            }
        }

        public static void PlaceWall(Vector3 pos, Vector3 rot)
        {
            if (ServerLobbyUi.GameStarted & (Networking.isHost() | Networking.RunningSingleplayer) & BuildComponent!=null)
            {
                BuildComponent.Build(pos, rot);
            }
        }
    }
}
