using Firebase.Auth;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BeerC0d3.Firebase
{
    public class FirebaseStorageManager
    {
        private static readonly string ApiKey = "AIzaSyDgRQVO5iAeyNbM588t2fknMLPow2lJGi8";
        private static readonly string Bucket = "leanproject-eeefc.appspot.com";
        private static readonly string AuthEmail = "playcold_s@gmail.com";
        private static readonly string AuthPassword = "Pruebas123*";

        public static StreamContent ConvertBase64ToStream(string fileFromRequest)
        {
            byte[] fileStringToBase64 = Convert.FromBase64String(fileFromRequest);
            StreamContent streamContent = new(new MemoryStream(fileStringToBase64));
            return streamContent;
        }

        public static async Task<string> UploadFile(Stream stream, FileDTO fileDTO)
        {
            string imageFromFirebaseStorage = "";
            FirebaseAuthProvider firebaseConfiguration = new(new FirebaseConfig(ApiKey));

            FirebaseAuthLink authConfiguration = await firebaseConfiguration.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            CancellationTokenSource cancellationToken = new();

            FirebaseStorageTask storageManager = new FirebaseStorage(Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(authConfiguration.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(fileDTO.FolderName)
                .Child(fileDTO.FileName)
                .PutAsync(stream, cancellationToken.Token);

            try
            {
                imageFromFirebaseStorage = await storageManager;
            }
            catch(Exception e)
            {
                var msg = e.Message;
            }
            return imageFromFirebaseStorage;
        }

        public static async void DeleteFile(FileDTO fileDTO)
        {
            var storage = await FirebaseStorageCustom();

            try
            {
                await storage.Child(fileDTO.FolderName).Child(fileDTO.FileName).DeleteAsync();
            }
            catch (Exception e)
            {
                var msg = e.Message;
            }
        }


        public static async Task<FirebaseStorage> FirebaseStorageCustom()
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var loginInfo = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
            var storage = new FirebaseStorage(Bucket, new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(loginInfo.FirebaseToken),
                ThrowOnCancel = true
            });
            return storage;
        }
    }
}
