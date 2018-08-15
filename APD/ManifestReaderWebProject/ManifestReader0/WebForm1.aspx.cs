using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.Script.Services;
using HtmlAgilityPack;

namespace ManifestReader0
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private String masterPath;


        protected void Page_Load(object sender, EventArgs e)
        {
            //String path = @"C:\Users\GAMBOAJ\Documents\ExportedDemo";
            //masterPath = path;
        }

        private void readRootFolderTree(String path)
        {
            var directories = Directory.GetDirectories(path);
            //Display (Front-End)
            String htmlCode = "";
            for (int i = 0; i < directories.Length; i++)
            {
                string dirName = new DirectoryInfo((String)directories[i]).Name;
                string pathDirectory = new DirectoryInfo((String)directories[i]).FullName.Replace("\\", "\\\\\\\\"); // directories[i].Replace("\\","\\\\\\");
                String button = "<button onclick=\"getDocuments('"+pathDirectory+"','"+dirName+"')\" type=\"button\" class=\"btn\" data-toggle=\"modal\" data-target=\"#myModal\"><span class=\"glyphicon glyphicon-folder-open\" aria-hidden=\"true\"></span></button>";
                htmlCode += "<tr><td>"+button+"</td><td path=\""+pathDirectory+"\">" + dirName + "</td></tr>";
            }
            LiteralControl aspHtml = new LiteralControl();
            aspHtml.Text = htmlCode;
            this.foldersTbody.Controls.Add(aspHtml);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static int getNumberOfFiles(String folder)
        {
            int numberOfFilesInXML = new int();
            numberOfFilesInXML = 0;
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(folder + @"\Manifest.xml");
                foreach (XmlNode spObjects in xml.DocumentElement.ChildNodes)
                {
                    foreach (XmlNode file in spObjects)
                    {
                        if (file.Name == "File")
                        {
                            if (file.Attributes["FileValue"] == null || file.Attributes["Name"] == null)
                            {
                                foreach (XmlNode version in file)
                                {
                                    if (version.Name == "Versions")
                                    {
                                        foreach (XmlNode fileInVersions in version)
                                        {
                                            if (fileInVersions.Name == "File")
                                            {
                                                numberOfFilesInXML = numberOfFilesInXML + 1;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                numberOfFilesInXML = numberOfFilesInXML + 1;
                            }
                            
                        }
                    }
                }

                int manifestNumber = 1;
                String moreManifestsPath = folder + @"\Manifest" + manifestNumber + ".xml";
                if (File.Exists(moreManifestsPath))
                {
                    do
                    {
                        xml = new XmlDocument();
                        xml.Load(moreManifestsPath);
                        foreach (XmlNode spObjects in xml.DocumentElement.ChildNodes)
                        {
                            foreach (XmlNode file in spObjects)
                            {
                                if (file.Name == "File")
                                {
                                    if (file.Attributes["FileValue"] == null || file.Attributes["Name"] == null)
                                    {
                                        foreach (XmlNode version in file)
                                        {
                                            if (version.Name == "Versions")
                                            {
                                                foreach (XmlNode fileInVersions in version)
                                                {
                                                    if (fileInVersions.Name == "File")
                                                    {
                                                        numberOfFilesInXML = numberOfFilesInXML + 1;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        numberOfFilesInXML = numberOfFilesInXML + 1;
                                    }

                                }
                            }
                        }
                        manifestNumber++;
                        moreManifestsPath = folder + @"\Manifest" + manifestNumber + ".xml";
                    } while (File.Exists(moreManifestsPath));
                }
                
                return numberOfFilesInXML;
            }
            catch (Exception e)
            {
                numberOfFilesInXML = 0;
                return numberOfFilesInXML;
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true , ResponseFormat = ResponseFormat.Json)]
        public static Dictionary<String, String> getFileandOriginalName(String folder)
        {
            //Delete this 
            //getAndConvertFile(@"C:\Users\GAMBOAJ\Documents\ExportedDemo\001-test1", "00000000.dat", "AllItems.aspx");
            Dictionary<String, String> nameAndFileValue = new Dictionary<string, string>();
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(folder + @"\Manifest.xml");
                foreach (XmlNode spObjects in xml.DocumentElement.ChildNodes)
                {
                    foreach (XmlNode file in spObjects)
                    {
                        //In a future if you need more metadata (Like the URL) change a map for an object
                        if (file.Name == "File")
                        {
                            if (file.Attributes["FileValue"] == null || file.Attributes["Name"] == null)
                            {
                                foreach (XmlNode version in file)
                                {
                                    if (version.Name == "Versions")
                                    {
                                        foreach (XmlNode fileInVersions in version)
                                        {
                                            if (fileInVersions.Name == "File")
                                            {
                                                String fileValue = fileInVersions.Attributes["FileValue"].Value;
                                                String originalName = fileInVersions.Attributes["Name"].Value;
                                                nameAndFileValue.Add(fileValue, originalName);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                String fileValue = file.Attributes["FileValue"].Value;
                                String originalName = file.Attributes["Name"].Value;
                                nameAndFileValue.Add(fileValue, originalName);
                            }
                        }
                    }
                }

                int manifestNumber = 1;
                String moreManifestsPath = folder + @"\Manifest" + manifestNumber + ".xml";
                if (File.Exists(moreManifestsPath))
                {
                    do
                    {
                        xml = new XmlDocument();
                        xml.Load(moreManifestsPath);
                        foreach (XmlNode spObjects in xml.DocumentElement.ChildNodes)
                        {
                            foreach (XmlNode file in spObjects)
                            {
                                if (file.Name == "File")
                                {
                                    if (file.Attributes["FileValue"] == null || file.Attributes["Name"] == null)
                                    {
                                        foreach (XmlNode version in file)
                                        {
                                            if (version.Name == "Versions")
                                            {
                                                foreach (XmlNode fileInVersions in version)
                                                {
                                                    if (fileInVersions.Name == "File")
                                                    {
                                                        String fileValue = fileInVersions.Attributes["FileValue"].Value;
                                                        String originalName = fileInVersions.Attributes["Name"].Value;
                                                        nameAndFileValue.Add(fileValue, originalName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        String fileValue = file.Attributes["FileValue"].Value;
                                        String originalName = file.Attributes["Name"].Value;
                                        nameAndFileValue.Add(fileValue, originalName);
                                    }
                                }
                            }
                        }
                        manifestNumber++;
                        moreManifestsPath = folder + @"\Manifest" + manifestNumber + ".xml";
                    } while (File.Exists(moreManifestsPath));
                }

                return nameAndFileValue;
            }catch(Exception e)
            {
                String expetionType = e.Message;
                if(expetionType.Contains("Could not find file"))
                {
                    nameAndFileValue.Add("0", "This folder doesn't have manifest");
                }else
                {
                    nameAndFileValue.Add("0", "Error during the process: " + expetionType);
                }
                return nameAndFileValue;
            }
        }

        public void getAndConvertFile(String folder, String realName, String convertedName)
        {
            masterPath = txtMasterPath.Text;
            String fakeFileNameandPath = masterPath + "\\"+ folder + "\\" + convertedName;
            //String fakeFileNameandPath = "C:\\Users\\GAMBOAJ\\Documents\\ExportedDemo\\-001-test1\\00000000.dat";
            if (File.Exists(fakeFileNameandPath))
            {
                HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
                String Header = "Attachment; Filename=" + realName;
                HttpContext.Current.Response.AppendHeader("Content-Disposition", Header);
                System.IO.FileInfo Dfile = new System.IO.FileInfo(fakeFileNameandPath);
                HttpContext.Current.Response.WriteFile(Dfile.FullName);
                HttpContext.Current.Response.End();
            }
            else
            {
                //Change that and control the missing file
                throw new Exception();
            }
            
        }

        protected void btnDownloadFile_Click(object sender, EventArgs e)
        {
            String folder = pathFileASP.Value;
            String convertedName = convertedNameASP.Value;
            String realName = realNameASP.Value;
            getAndConvertFile(folder, convertedName, realName);
        }
        protected void btnMasterPath_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "hideFirstModal", "hideFirstModal();", true);
            masterPath = txtMasterPath.Text;
            lblMasterPath.Text = masterPath;
            try
            {
                readRootFolderTree(masterPath);
            }catch(Exception)
            {
                lblMasterPath.Text = "Invalid path";
            }
            
        }

    }
}