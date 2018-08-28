﻿using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content;
using Android.Widget;
using System.Security.Cryptography;
using System.IO;
using static Android.App.ActionBar;
using Java.IO;

namespace texteditor
{
    public interface IChangeViewvalues
    {
        void Changevalues();
    }

    public static class CommonMethods
    {
        public static Context _context;
        static List<String> _dirs=new List<string>();
        static Dialog _dialog;
        //public static List<System.String> dataFromFile;
        static String _filepath=null;
        static AlertDialog.Builder _builder;
        private static IChangeViewvalues _activityobj;

        public static Context Context { get => _context; set => _context = value; }
        public static string Filepath { get => _filepath; set => _filepath = value; }
        public static List<string> Dirs { get => _dirs; set => _dirs = value; }
        public static Dialog Dialog { get => _dialog; set => _dialog = value; }
        public static AlertDialog.Builder Builder { get => _builder; set => _builder = value; }
        public static IChangeViewvalues Activityobj { get => _activityobj; set => _activityobj = value; }

        private static readonly byte[] salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76, 0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb };
        

        public static string EncryptPassword(string passcode, string EncryptionKey)
        {
            string clearText = "";
            try
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, salt)
                    {
                        IterationCount = 10000
                    };
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    MemoryStream ms = new MemoryStream();                   
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(Encoding.Unicode.GetBytes(passcode), 0, Encoding.Unicode.GetBytes(passcode).Length);
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                   
                }
            }
            catch
            {
                throw;
            }

            return clearText;
        }

        public static string DecryptPassword(string enpasscode, string EncryptionKey)
        {
            string cipherText = "";
            try
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, salt)
                    {
                        IterationCount = 10000
                    };
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    MemoryStream ms = new MemoryStream();
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(Convert.FromBase64String(enpasscode), 0, Convert.FromBase64String(enpasscode).Length);
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            catch
            {
                throw;
            }
            return cipherText;
        }

       public static void MessageDialog(System.String title, System.String data, Context context)
        {
            try
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(context);
                AlertDialog alert = dialog.Create();
                alert.SetTitle(title);
                alert.SetMessage(data);
                alert.SetButton("OK", (c, ev) =>
                {
                // Ok button click task  
            });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
            catch(Exception ex)
            {
                MessageDialog("Error", "message dialog" + ex.Message, context);               
            }
        }

       public static String GetDataFromFile(String filename)
       {
            try
            {
                return System.IO.File.ReadAllText(filename);

            }
           catch (Exception ex)
           {
               MessageDialog("Error....", "getdatafromfile :" + ex.Message, Application.Context);

                return null;
           }
          
        }

        public static void DisplayFilesAndFolders(object sender, EventArgs e)
        {
            try
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(_context);
                Dirs.Clear();
                Java.IO.File dirFile;

                dirFile = new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath);
                Dirs.Add("..");

                foreach (Java.IO.File file in dirFile.ListFiles())
                {
                    if (file.IsDirectory)
                    {
                        Dirs.Add(file.Name + "/");
                    }
                    else
                    {
                        Dirs.Add(file.Name);
                    }
                }

                using (var adapter = new ArrayAdapter<System.String>(_context, Android.Resource.Layout.SimpleListItemSingleChoice, Dirs))
                {
                    ListView dirtext = new ListView(_context)
                    {
                        Adapter = adapter
                    };
                    dirtext.ItemClick += OnContextItemSelected;
                    builder.SetView(dirtext);
                    builder.SetTitle("folders");
                    Dialog = builder.Create();
                    Dialog.Show();
                };
            }

            catch (Exception ex)
            {
                MessageDialog("Error msg :-", "displayfilesandfolders method :-" + ex.Message, _context);
            }
        }

        public static void OnContextItemSelected(object sender, AdapterView.ItemClickEventArgs e)
        {
            try
            {
                Dirs.Clear();
                String str = e.Parent.GetItemAtPosition(e.Position).ToString();

                if (str.StartsWith(".."))
                {
                    DisplayFilesAndFolders(sender, e);
                    return;
                }
                else
                {
                    Java.IO.File dirFile = new Java.IO.File(Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, str));
                    Dirs.Add("..");
                    Dirs.Add(str);

                    if (dirFile.IsDirectory)
                    {
                        foreach (Java.IO.File file in dirFile.ListFiles())
                        {

                            if (file.IsDirectory)
                            {
                                Dirs.Add(str + file.Name + "/");
                            }
                            else
                            {
                                Dirs.Add(str + file.Name);
                            }

                        }
                    }
                    else if (dirFile.IsFile)
                    {
                       // fileData =GetDataFromJson(dirFile.AbsolutePath);
                        Filepath = dirFile.AbsolutePath;
                        //MFileData = GetDataFromJson(Filepath);
                        Dialog.Dismiss();
                       _activityobj.Changevalues();
                        return;
                    }
                }
                Dialog.Dismiss();
                //Builder.Dispose();
                Builder = new AlertDialog.Builder(_context);
                Builder.SetTitle("Selected Content");

                var adapter = new ArrayAdapter<System.String>(_context, Android.Resource.Layout.SimpleSelectableListItem, Dirs);
                ListView dirtext = new ListView(_context)
                {
                    Adapter = adapter,

                };

                dirtext.LayoutParameters = new LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.MatchParent);
                dirtext.ItemClick += OnContextItemSelected;
                Builder.SetView(dirtext);
                Dialog = Builder.Create();
                Dialog.Show();
            }

            catch (Exception ex)
            {
                MessageDialog("Error:", "OnContextItemSelected" + ex.Message, _context);
            }

        }

        public static void ListViewLongClickListener(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            string selectedFromList = ((ListView)e.Parent).GetItemAtPosition(e.Position).ToString();
            ClipboardManager clipboard = (ClipboardManager)_context.GetSystemService("clipboard");
            ClipData clip = ClipData.NewPlainText(selectedFromList, selectedFromList);
            clipboard.PrimaryClip = clip;
            Toast.MakeText(_context, text: "Copied To Clipboard", duration: ToastLength.Long).Show();
        }
    }

   
}