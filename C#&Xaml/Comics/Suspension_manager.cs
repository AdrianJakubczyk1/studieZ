using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
namespace Jan_Linq
{
    class Suspension_manager
    {
        public static string CurrentQuery { get; set; }

        private const string filename = "_sessionState.txt";//file that will be used to save state before app was closed

        static async public Task SaveAsync()//save current state
        {
            if (String.IsNullOrEmpty(CurrentQuery))
                CurrentQuery = String.Empty;
            IStorageFile storageFile =
                await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(storageFile, CurrentQuery);
        }
        static async public Task RestoreAsync()//restore state
        {
            IStorageFile storageFile =
                await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            CurrentQuery = await FileIO.ReadTextAsync(storageFile);
        }
    }
}
