using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManifestReaderForms0
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdChooseFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            try {
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                if (result == DialogResult.OK)
                {
                    lblPath.Text = folderBrowserDialog1.SelectedPath;
                    lblFilesFound.Text = getNumberOfFiles().ToString();
                    this.dataGridView1.Rows.Clear();
                    fillTable(getFileandOriginalName());
                }
                enableElementsSearch();
            }
            catch (Exception exept)
            {

            }
        }
        private int getNumberOfFiles()
        {
            string folder = lblPath.Text;
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
        private Dictionary<string,string> getFileandOriginalName()
        {
            String folder = lblPath.Text;
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
            }
            catch (Exception e)
            {
                String expetionType = e.Message;
                if (expetionType.Contains("Could not find file"))
                {
                    nameAndFileValue.Add("0", "This folder doesn't have manifest");
                }
                else
                {
                    nameAndFileValue.Add("0", "Error during the process: " + expetionType);
                }
                return nameAndFileValue;
            }
        }

        private Dictionary<string,string> searchFiles(string word)
        {
            Dictionary<string, string> search = new Dictionary<string, string>();
            foreach(KeyValuePair<string, string> currentSearch in getFileandOriginalName())
            {
                if (currentSearch.Value.Contains(word))
                {
                    search.Add(currentSearch.Key, currentSearch.Value);
                }
            }
            return search;
        }

        private void fillTable(Dictionary<string, string>  data)
        {
            DataGridViewColumn column = dataGridView1.Columns[1];
            column.Width = 499;
            foreach (KeyValuePair<string, string> namesAndFiles in data)
            {
                dataGridView1.Rows.Add(namesAndFiles.Key, namesAndFiles.Value);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblFile.Text = dataGridView1.CurrentRow.Cells["tblname"].Value.ToString();
                lblFakeFile.Text = dataGridView1.CurrentRow.Cells["tblFile"].Value.ToString();
                enableElemntsToGet();
            }
            catch(Exception exep)
            {

            }
            
        }

        private void cmdGetFile_Click(object sender, EventArgs e)
        {
            string path = lblPath.Text;
            //path = @"C:\Users\GAMBOAJ\Documents\Versum Decommission\ExportedDemo\001_APJ_Adm_Mtg";
            string tempFolder = path + "\\temp";
            string fakeName = lblFile.Text;
            //string fakeName = "000002AF.dat";
            string originalName = lblFakeFile.Text;
            //string originalName = "75th_Message_from_Seifi_Ghasemi_Re_Gifts_2Sept2015.pdf";
            Directory.CreateDirectory(tempFolder);
            File.Copy(Path.Combine(path, fakeName), Path.Combine(tempFolder, originalName), true); //Save the file and change the name in a temp folder
            System.Diagnostics.Process.Start(tempFolder+"\\"+originalName); //Launch the file
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string path = lblPath.Text;
            string fakeName = lblFile.Text;
            string originalName = lblFakeFile.Text;
            try
            {
                string extension = originalName.Substring(originalName.LastIndexOf('.'));
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FileName = originalName;
                saveFileDialog1.DefaultExt = extension;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("File Saved");
                }
                File.Copy(Path.Combine(path, fakeName), Path.Combine(Path.GetDirectoryName(saveFileDialog1.FileName), Path.GetFileName(saveFileDialog1.FileName)), true);
            }
            catch(Exception ex)
            {
                MessageBox.Show("File not selected");
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            string searchWord = txtSearch.Text;
            Dictionary<string, string> search = new Dictionary<string, string>();
            search = searchFiles(searchWord);
            if (search.Count > 0)
            {
                fillTable(search);
            }else
            {
                MessageBox.Show(searchWord + " not found");
            }
            
        }

        private void cmdClean_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            txtSearch.Text = "";
            fillTable(getFileandOriginalName());
        }

        private void enableElementsSearch()
        {
            txtSearch.Enabled = true;
            cmdSearch.Enabled = true;
            cmdClean.Enabled = true;
        }

        private void enableElemntsToGet()
        {
            cmdGetFile.Enabled = true;
            cmdSave.Enabled = true;
        }
    }
}
