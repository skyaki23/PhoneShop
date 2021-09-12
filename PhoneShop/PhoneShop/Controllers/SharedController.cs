using System;
using System.IO;
using System.Web.Mvc;

namespace PhoneShop.Controllers
{
    public class SharedController : Controller
    {
        /// <summary>
        /// 回傳Json資料(Success: Boolean)使判斷圖片上傳成功與否
        /// </summary>
        /// <returns></returns>
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                var file = Request.Files[0]; // 得到上傳圖片檔案
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName); // 隨機產生圖片檔案名稱 + 圖片副檔名
                var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName); // 設定圖片存放路徑
                file.SaveAs(path); // 儲存圖片檔案至路徑

                result.Data = new { Success = true, ImageURL = string.Format("/Content/images/{0}", fileName) };
            }
            catch (Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }

            return result;
        }
    }
}