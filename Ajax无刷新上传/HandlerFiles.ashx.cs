using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax无刷新上传
{
    /// <summary>
    /// HandlerFiles 的摘要说明
    /// </summary>
    public class HandlerFiles : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int rec = context.Request.Files.Count;
            if (context.Request.Files.Count > 0)
            {
                HttpPostedFile  files = context.Request.Files[0];
                if (files.ContentLength > 0)
                {
                    int n=files.ContentLength;
                    string fileName = files.FileName;
                    files.SaveAs(context.Request.MapPath("files/"+Guid.NewGuid().ToString()+"_"+fileName));
                    context.Response.Write("上传完毕!");
                    context.Response.End();
                }
                else { context.Response.Write("选择的文件不能小于0字节"); context.Response.End(); }

                
            }
            else {
                context.Response.Write("请先选择上传文件");
                context.Response.End();
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}