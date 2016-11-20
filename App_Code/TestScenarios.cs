using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using Gherkin;
using System.Collections;


/// <summary>
/// Summary description for Class1
/// </summary>
namespace Testhoekje.App_Code.TestScenarios
{

    public partial class TestScenarios : System.Web.UI.Page
    {


        public static void ImportFeatures(XmlWriter writer)
        {
         
            writer.WriteStartDocument();
            writer.WriteStartElement("SpoorPlaza_Apps");
        
            ImportFeaturesForOneApp(writer, "Mijn_Dienst", @"C:\03 workspace\tfs\NS Railpocket\Product\20-Frontends\MijnDienst\MijnDienst.Droid.UITest\Features\");
            ImportFeaturesForOneApp(writer, "Service_Coach", @"C:\03 workspace\tfs\NS Railpocket\Product\20-Frontends\ServiceCoach\ServiceCoach.Droid.UITest\Features\");
            ImportFeaturesForOneApp(writer, "Mijn_Profiel", @"C:\03 workspace\tfs\NS Railpocket\Product\20-Frontends\MijnProfiel\Tests\features\");
            ImportFeaturesForOneApp(writer, "NScontacten", @"C:\03 workspace\tfs\NS Railpocket\Product\20-Frontends\NsContacten\Tests\features\");
            ImportFeaturesForOneApp(writer, "Mijn_Materieel", @"C:\03 workspace\tfs\NS Railpocket\Product\20-Frontends\MijnMaterieel\MijnMaterieel.Droid.UITest\Features\");
            ImportFeaturesForOneApp(writer, "Mijn_Meldingen", @"C:\03 workspace\tfs\NS Railpocket\Product\20-Frontends\MijnMeldingen\MijnMeldingen.Droid.UITest\Features\");
            ImportFeaturesForOneApp(writer, "Mijn_Berichten", @"C:\03 workspace\tfs\NS Railpocket\Product\20-Frontends\MijnBerichten\MijnBerichten.Droid.UITest\Features\");
            ImportFeaturesForOneApp(writer, "Mijn_Biljetten", @"C:\03 workspace\tfs\NS Railpocket\Product\20-Frontends\MijnBiljetten\MijnBiljetten.Droid.UITest\Features\");
            ImportFeaturesForOneApp(writer, "Shared", @"C:\03 workspace\tfs\NS Railpocket\Product\20-Frontends\Shared\Tests\features\");
 

            writer.WriteEndElement();
            writer.WriteEndDocument();

            //doc.Save(writer);
            writer.Close();
         }


        public static void ImportFeaturesForOneApp(XmlWriter writer, string AppNaam, string Folder)
        {

            writer.WriteStartElement(AppNaam);
            int TotaalAantalScenarios = 0;

            //loop door alle files in een folder
            string pathFeatureFile = Folder;
            foreach (string file in Directory.EnumerateFiles(pathFeatureFile, "*.feature"))
            {
                var parser = new Parser();
                var feature = parser.Parse(file);
                var AantalScenarios = 0;

                //tel aantal scenarios
                foreach (var scenariodef in feature.ScenarioDefinitions)
                {
                    AantalScenarios = AantalScenarios + 1;
                }
                TotaalAantalScenarios = TotaalAantalScenarios + AantalScenarios;

                if (AantalScenarios != 0)
                {
                    //loop door alle Scenarios
                    string featureName = feature.Name;
                    string featureDescription = feature.Description;

                    writer.WriteStartElement("feature");
                    writer.WriteAttributeString("text", AantalScenarios.ToString() + " - " + feature.Name);


                    // toevoegen Background
                    if (feature.Background != null)
                    {

                        string backgrondSteps = "backgrond";

                        foreach (var B in feature.Background.Name)
                        {
                            backgrondSteps = backgrondSteps + B + "<br>";
                        }


                        writer.WriteElementString("backgrond", backgrondSteps);
                    }


                    //stoevoegen scenarioa
                    foreach (var scenariodef in feature.ScenarioDefinitions)
                    {

                        string tags = "";
                        string Id = "";



                        //toevoegen tags
                        foreach (var T in scenariodef.Tags)
                        {
                            tags = tags + T.Name + "  ";
                            if (T.Name.Contains("@UC") | T.Name.Contains("@EPIC") | T.Name.Contains("@SD"))
                            {
                                Id = T.Name + " - ";
                            }
                        }

                        string scenarioSteps = "";
                        string tekst = "";
                        foreach (var S in scenariodef.Steps)
                        {
                            tekst = S.Text.Replace("<", "<font color=\"orange\">");
                            tekst = tekst.Replace(">", "</font>");
                            scenarioSteps = scenarioSteps + "<b>" + S.Keyword + "</b> " + tekst + "<br>";
                        }

                        //examples
                        if (scenariodef.Keyword == "Scenario Outline")
                        {
                            foreach (var X in scenariodef.Steps)
                            {
                                scenarioSteps = scenarioSteps + X;
                            }
                        }
                        //foreach (var X in scenariodef)
                        //{
                        //    tekst = S.Text.Replace("<", "<font color=\"orange\">");
                        //    tekst = tekst.Replace(">", "</font>");
                        //    scenarioSteps = scenarioSteps + "<b>" + S.Keyword + "</b> " + tekst + "<br>";
                        //}

                        writer.WriteStartElement("scenario");
                        writer.WriteAttributeString("text", Id + scenariodef.Name);
                        writer.WriteStartElement("tags");
                        writer.WriteStartElement("text");
                        writer.WriteString(tags);
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteStartElement("steps");
                        writer.WriteString(scenarioSteps);
                        writer.WriteEndElement();
                        writer.WriteEndElement();





                    }
                    //writer.WriteAttributeString("aantal", TotaalAantalScenarios.ToString() );
                    writer.WriteEndElement();
                }
            }


            writer.WriteEndElement();

       }
    }
}
