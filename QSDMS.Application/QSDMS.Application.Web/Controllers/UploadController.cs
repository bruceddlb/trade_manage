﻿using iFramework.Framework;
using iFramework.Framework.Log;
using QSDMS.Util;
using QSDMS.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QSDMS.Application.Web.Controllers
{
    public class UploadController : Controller
    {
        private Log _logger;
        /// <summary>
        /// 日志操作
        /// </summary>
        public Log Logger
        {
            get { return _logger ?? (_logger = LogFactory.GetLogger(this.GetType().ToString())); }
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public JsonResult UploadPic()
        {
            ReturnMessage result = new ReturnMessage(false) { Message = "上传图片失败!" };
            try
            {
                HttpPostedFileBase file = Request.Files["fileDataFileName"];
                string extansion = System.IO.Path.GetExtension(file.FileName);
                if (extansion != ".jpg" && extansion != ".png" && extansion != ".gif" && extansion != ".jpeg" && extansion != ".bmp") //Do not create thumb if file is not an image
                {
                    result.Message = "无效文件";
                    return Json(result);
                }
                var imageHost = System.Configuration.ConfigurationManager.AppSettings["ImageHost"] == "" ? string.Format("http://{0}{1}", Request.Url.Host, Request.Url.Port == 80 ? "" : ":" + Request.Url.Port) : System.Configuration.ConfigurationManager.AppSettings["ImageHost"];
                var url = string.Format("{0}/Upload/UploadFile", imageHost);
                FileClient fileClient = new FileClient();
                result = fileClient.Post(url, string.Empty, file);
                if (result.IsSuccess)
                {
                    result.IsSuccess = true;
                    result.ResultData["path"] = result.ResultData["files"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.Data["Method"] = "UploadController>>SavePic";
                new ExceptionHelper().LogException(ex);
            }
            return Json(result);

        }


        [HttpPost]
        public JsonResult UploadFile()
        {
            ReturnMessage result = new ReturnMessage(false) { Message = "上传图片失败!" };
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                //没有文件上传，直接返回
                if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
                {
                    result.Message = "无效文件";
                    return Json(result);
                    // return HttpNotFound();
                }
                string extansion = System.IO.Path.GetExtension(files[0].FileName);
                if (extansion != ".jpg" && extansion != ".png" && extansion != ".gif" && extansion != ".jpeg" && extansion != ".bmp") //Do not create thumb if file is not an image
                {
                    result.Message = "无效文件";
                    return Json(result);
                }
                //string FileEextension = Path.GetExtension(files[0].FileName);
                string virtualPath = string.Format("/File/AttachmentPic/{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), extansion);
                string fullFileName = Server.MapPath("~" + virtualPath);
                //创建文件夹，保存文件
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                files[0].SaveAs(fullFileName);

                result.ResultData["files"] = virtualPath;
                result.IsSuccess = true;
                result.Message = "上传成功";
            }
            catch (Exception ex)
            {
                new ExceptionHelper().LogException(ex);
                result.Message = ex.Message;
                return Json(result);

            }
            return Json(result);

        }
        [HttpPost]
        public JsonResult UploadVideoFile(HttpFileCollectionBase file)
        {
            ReturnMessage result = new ReturnMessage(false) { Message = "上传视频失败!" };
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                //没有文件上传，直接返回
                if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
                {
                    result.Message = "无效文件";
                    return Json(result);
                    // return HttpNotFound();
                }
                string extansion = System.IO.Path.GetExtension(files[0].FileName);
                if (extansion != ".mp4" && extansion != ".MP4") //Do not create thumb if file is not an image
                {
                    result.Message = "无效文件";
                    return Json(result);
                }
                //string FileEextension = Path.GetExtension(files[0].FileName);
                string virtualPath = string.Format("/File/Video/{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), extansion);
                string fullFileName = Server.MapPath("~" + virtualPath);
                //创建文件夹，保存文件
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                files[0].SaveAs(fullFileName);

                result.ResultData["files"] = virtualPath;
                result.IsSuccess = true;
                result.Message = "上传成功";
            }
            catch (Exception ex)
            {
                new ExceptionHelper().LogException(ex);
                result.Message = ex.Message;
                return Json(result);

            }
            return Json(result);

        }
        [HttpPost]
        public JsonResult UploadDocFile(HttpFileCollectionBase file)
        {
            ReturnMessage result = new ReturnMessage(false) { Message = "上传视频失败!" };
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                //没有文件上传，直接返回
                if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
                {
                    result.Message = "无效文件";
                    return Json(result);
                    // return HttpNotFound();
                }
                string extansion = System.IO.Path.GetExtension(files[0].FileName);
                if (extansion != ".doc" && extansion != ".docx") //Do not create thumb if file is not an image
                {
                    result.Message = "无效文件";
                    return Json(result);
                }
                //string FileEextension = Path.GetExtension(files[0].FileName);
                string virtualPath = string.Format("/File/Doc/{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), extansion);
                string fullFileName = Server.MapPath("~" + virtualPath);
                //创建文件夹，保存文件
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                files[0].SaveAs(fullFileName);

                result.ResultData["files"] = virtualPath;
                result.IsSuccess = true;
                result.Message = "上传成功";
            }
            catch (Exception ex)
            {
                new ExceptionHelper().LogException(ex);
                result.Message = ex.Message;
                return Json(result);

            }
            return Json(result);

        }

        /// <summary>
        /// 产品
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Product(HttpPostedFileBase file)
        {
            var result = new ReturnMessage(false) { Message = "上传图片失败!" };
            result = Upload(ImageType.Product, new ImageWidthHeight[] {
                new ImageWidthHeight(){ Height=640,Width=640}            
            }, false);
            return Json(result);
        }

        /// <summary>
        /// 裁剪图片 220*180
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadCutFile()
        {
            ReturnMessage result = new ReturnMessage(false) { Message = "上传图片失败!" };
            try
            {
                result = Upload(ImageType.Certificate, new ImageWidthHeight[] {
                new ImageWidthHeight(){ Height=220,Width=180}            
            }, false);
            }
            catch (Exception ex)
            {
                new ExceptionHelper().LogException(ex);
                result.Message = ex.Message;
            }
            return Json(result);

        }

        /// <summary>
        /// 带裁剪保存
        /// </summary>
        /// <param name="model"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void SaveFile(FileModel model, int width, int height)
        {
            var newName = string.Format("_{1}_{2}_{0}", model.FileNewNoExtensionName, width, height);
            Thumbnail.MakeThumbnail(model.PhysicFullPath + model.FileNewName, model.PhysicFullPath + newName + model.FileExtension, width, height, ThumbnailMode.HW, 200);
            model.FileNewName = newName + model.FileExtension;
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="type"></param>
        /// <param name="imageSizes"></param>
        /// <param name="isAddHost"></param>
        /// <returns></returns>
        private ReturnMessage Upload(ImageType type, IEnumerable<ImageWidthHeight> imageSizes, bool isAddHost = false)
        {
            var result = new ReturnMessage(false) { Message = "上传文件失败!" };
            var fileList = new List<string>();
            try
            {
                var flag = true;
                var uploadHelper = new FileUpload(type.ToString());
                string errorstring = "上传文件失败,请重新上传!";
                for (var i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    var filePath = string.Format("/File/{0}/{1}/", type.ToString(), DateTime.Now.ToString("yyyyMMdd"));
                    var fileModel = uploadHelper.Save(file, Server.MapPath(filePath));
                    if (!fileModel.Status)
                    {
                        flag = false;
                        errorstring = fileModel.ErrorString;
                        break;
                    }

                    var imagePath = string.Format(filePath + "_{0}_{1}_" + fileModel.FileNewName, imageSizes.First().Width, imageSizes.First().Height);
                    if (isAddHost)
                    {
                        imagePath = string.Format("http://{0}{1}{2}", Request.Url.Host, Request.Url.Port == 80 ? "" : ":" + Request.Url.Port, imagePath);
                    }

                    fileList.Add(imagePath);

                    //生成图片则生成缩略图
                    if (imageSizes != null)
                    {
                        foreach (var size in imageSizes)
                        {
                            SaveFile(fileModel, size.Width, size.Height);
                        }
                    }
                }

                if (flag)
                {
                    result.IsSuccess = true;
                    result.Message = "上传文件成功!";
                    result.ResultData["files"] = fileList;
                }
                else
                {
                    result.Message = errorstring;
                }
            }
            catch (Exception ex)
            {
                ex.Data["Method"] = "UploadController => Upload";
                new ExceptionHelper().LogException(ex);
            }
            return result;
        }


    }
    /// <summary>
    /// 高宽属性
    /// </summary>
    public class ImageWidthHeight
    {
        public int Width { get; set; }

        public int Height { get; set; }
    }
}