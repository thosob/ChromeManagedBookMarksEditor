using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChromeManagedBookmarksEditor.Model;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;

namespace ChromeManagedBookmarksEditor.Helpers
{
    public static class ChromeJSONConverter
    {
        // Async methods to convert ManagedBookmarks object into JSON code
        public static async Task<string> ConvertToJSON(Folder RootFolder)
        {
            string ReturnableJSON = string.Empty;

            await Task.Run(() => 
            {
                ReturnableJSON = _ConvertToJSON(RootFolder);
            });

            return ReturnableJSON;
        }

        private static string _ConvertToJSON(Folder RootFolder)
        {
            //string convertedJSON = string.Empty;
            //string topLevelName = $"[{{\"toplevel_name\":\"{RootFolder.Name}\"}},";
            //convertedJSON = topLevelName;
            string convertedJSON = "[";

            ObservableCollection<string> JSONCollection = new ObservableCollection<string>();

            string GetFolderJSONContent(Folder folder)
            {
                ObservableCollection<string> folderContents = new ObservableCollection<string>();
                if (folder.folders.Count > 0)
                {
                    foreach (Folder subfolder in folder.folders)
                    {
                        folderContents.Add($"{{\"name\":\"{subfolder.Name}\",\"children\":[]}}");
                    }
                }

                if (folder.URLs.Count > 0)
                {
                    foreach (URL url in folder.URLs)
                    {
                        folderContents.Add($"{{\"name\":\"{url.Name}\",\"url\":\"{url.Url}\"}}");
                    }
                }

                string joinedContents = String.Join(",", folderContents);
                if(joinedContents == "" && folder.FolderIndex != 0) { joinedContents = "EMPTY"; }
                return joinedContents;
            }

            void IterateSubFolders(Folder folder)
            {
                JSONCollection.Add(GetFolderJSONContent(folder));
                if (folder.folders.Count > 0)
                {
                    foreach (Folder subFolder in folder.folders)
                    {
                        IterateSubFolders(subFolder);
                    }
                }
            }

            //Get RootFolder content
            JSONCollection.Add(GetFolderJSONContent(RootFolder));

            //iterate RootFolders.folders
            if (RootFolder.folders.Count > 0)
            {
                foreach (Folder subfolder in RootFolder.folders)
                {
                    IterateSubFolders(subfolder);
                }
            }

            convertedJSON += JSONCollection[0];

            //replace folder children [] with actual contents
            for(int i = 1; i < JSONCollection.Count(); i++)
            {
                var regex = new Regex(Regex.Escape("[]"));
                convertedJSON = regex.Replace(convertedJSON, $"[{JSONCollection[i]}]", 1);
            }

            convertedJSON = convertedJSON.Replace("[EMPTY]", "[]");
            convertedJSON += "]";

            return convertedJSON;
        }

        // Async Methods to parse JSON code into a ManagedBookmarks object
        public static async Task<ManagedBookmarks> ParseJSON(string JSONCode)
        {
            ManagedBookmarks ReturnableManagedBookmarks = new ManagedBookmarks();

            await Task.Run(() =>
            {
                ReturnableManagedBookmarks = _ParseJSON(JSONCode);
            });

            return ReturnableManagedBookmarks;
        }

        private static Folder CreateFoldersRecursively(IEnumerable<ManagedBookmarkJsonModel> managedBookmarkJsonModels, Folder workingFolder) 
        {
            foreach (var item in managedBookmarkJsonModels) {
                //To ensures compatibility of former created json files
                //toplevel is ignored, since it seems not to be necessary for chrome
                if (item.ToplevelName == null)
                {
                    if (item.URL != null && item.URL != "")
                    {
                        URL newUrl = new URL { Name = item.Name, Url = item.URL };
                        workingFolder.URLs.Add(newUrl);
                    }
                    else
                    {
                        if (item.Children != null && item.Children.Count() > 0)
                        {
                            Folder newFolder = CreateFoldersRecursively(item.Children, new Folder());
                            newFolder.Name = item.Name;
                            newFolder.Parent = workingFolder;
                            newFolder.FolderIndex = workingFolder.FolderIndex + 1;
                            workingFolder.folders.Add(newFolder);
                        }
                        else
                        {
                            //If the folder is empty
                            Folder newFolder = new Folder();
                            newFolder.Name = item.Name;
                            newFolder.Parent = workingFolder;
                            newFolder.FolderIndex = workingFolder.FolderIndex + 1;
                            workingFolder.folders.Add(newFolder);
                        }
                    }
                }
            }
            return workingFolder;
        }

        private static ManagedBookmarks _ParseJSON(string JSONCode)
        {
            ManagedBookmarks parsedBookmarks = new ManagedBookmarks();
            try
            {
                
                var managedBookmark = JsonConvert.DeserializeObject<List<ManagedBookmarkJsonModel>>(JSONCode);                
                parsedBookmarks.RootFolder = CreateFoldersRecursively(managedBookmark, new Folder() { FolderIndex = 0, Name = "root" });              
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
            }

            return parsedBookmarks;
        }
    }
}