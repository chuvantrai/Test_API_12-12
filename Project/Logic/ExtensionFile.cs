using Microsoft.AspNetCore.Http;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project.Logic
{
    public class ExtensionFile
    {
        public static string AddandUploadImgae(IFormFile myfile, User user)
        {
            if (myfile == null)
            {
                return null;
            }
            //add img
            var newfilename = Guid.NewGuid();
            var _extension = Path.GetExtension(myfile.FileName);
            string _FileName = newfilename + _extension;
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "myfiles", _FileName);
            using (var file = new FileStream(fullPath, FileMode.Create))
            {
                myfile.CopyTo(file);
            }

            // delete img 
            if (user.ImgAvar != null)
            {
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "myfiles", user.ImgAvar);
                FileInfo fi = new FileInfo(imgPath);
                if (fi != null)
                {
                    System.IO.File.Delete(imgPath);
                    fi.Delete();
                }
            }

            return _FileName;
        }
        public static string AddnewImgae(IFormFile myfile)
        {
            if (myfile == null)
            {
                return null;
            }
            //add img
            var newfilename = Guid.NewGuid();
            var _extension = Path.GetExtension(myfile.FileName);
            string _FileName = newfilename + _extension;
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "myfiles", _FileName);
            using (var file = new FileStream(fullPath, FileMode.Create))
            {
                myfile.CopyTo(file);
            }
            return _FileName;
        }
        public static string AddandUploadImgaeNews(IFormFile myfile, News news)
        {
            if (myfile == null)
            {
                return null;
            }
            //add img
            var newfilename = Guid.NewGuid();
            var _extension = Path.GetExtension(myfile.FileName);
            string _FileName = newfilename + _extension;
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "myfiles", _FileName);
            using (var file = new FileStream(fullPath, FileMode.Create))
            {
                myfile.CopyTo(file);
            }

            // delete img 
            if (news.ImgAvar != null)
            {
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "myfiles", news.ImgAvar);
                FileInfo fi = new FileInfo(imgPath);
                if (fi != null)
                {
                    System.IO.File.Delete(imgPath);
                    fi.Delete();
                }
            }

            return _FileName;
        }
        public static bool DeleteListImgae(List<string> listimg)
        {
            bool ch = true;
            foreach (string i in listimg)
            {
                try
                {
                        string imgPath = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot", "myfiles", i);
                        FileInfo fi = new FileInfo(imgPath);
                        if (fi != null)
                        {
                            System.IO.File.Delete(imgPath);
                            fi.Delete();
                        }
                }
                catch {
                    ch = false;
                }
            }
            return ch;
        }
        public static bool DeleteImgae(string img)
        {
            if (!string.IsNullOrEmpty(img))
            {
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(),
                      "wwwroot", "myfiles", img);
                FileInfo fi = new FileInfo(imgPath);
                if (fi != null)
                {
                    System.IO.File.Delete(imgPath);
                    fi.Delete();
                }
            }
            return true;
        }
        public static string AddandUploadImgaeP(IFormFile myfile, string img)
        {
            if (myfile == null)
            {
                return null;
            }
            //add img
            var newfilename = Guid.NewGuid();
            var _extension = Path.GetExtension(myfile.FileName);
            string _FileName = newfilename + _extension;
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "myfiles", _FileName);
            using (var file = new FileStream(fullPath, FileMode.Create))
            {
                myfile.CopyTo(file);
            }

            // delete img 
            if (img != null)
            {
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "myfiles", img);
                FileInfo fi = new FileInfo(imgPath);
                if (fi != null)
                {
                    System.IO.File.Delete(imgPath);
                    fi.Delete();
                }
            }

            return _FileName;
        }
    }
}
