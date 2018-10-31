using Trade.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QSDMS.Util.Extension;
using QSDMS.Util;
using QSDMS.Util.Attributes;

namespace QSDMS.Application.Web.Controllers
{
    public class DataItemEnumsController : Controller
    {
        /// <summary>
        /// 获取文章状态
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetArticleStatus()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.ArticleStatus));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.ArticleStatus));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 用户操作类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetOperationType()
        {
            //枚举值转列表
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.OperationType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.OperationType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 赠送类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGiveType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.GiveType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.GiveType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 用户类型 会员类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUserType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.UserType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.UserType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 系统角色机构类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetOrganizeType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.OrganizeType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.OrganizeType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 学车预约订单状态
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetStudySubscribeStatus()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.StudySubscribeStatus));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.StudySubscribeStatus));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 支付订单状态
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPayStatus()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.PaySatus));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.PaySatus));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 实训订单状态
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTrainingStatus()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.TrainingStatus));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.TrainingStatus));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }


        /// <summary>
        /// 看车 保险 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSubscribeStatus()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.SubscribeStatus));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.SubscribeStatus));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 报名 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetApplyStatus()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.ApplyStatus));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.ApplyStatus));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 考试状态 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetExamStatus()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.ExamStatus));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.ExamStatus));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 学车类型 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetStudyType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.StudyType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.StudyType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 学车时段类型 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetStudyTimeType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.WorkTimeType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.WorkTimeType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 使用性质
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUseType()
        {
            //string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.DistanceRange));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.UseType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < values.Length; i++)
            {
                var discript = EnumAttribute.GetDescription((Trade.Model.Enums.UseType)values[i]);
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = discript });
            }



            return Content(list.ToJson());
        }

        /// <summary>
        /// 车辆类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCarType()
        {
            //string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.DistanceRange));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.CarType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < values.Length; i++)
            {
                var discript = EnumAttribute.GetDescription((Trade.Model.Enums.CarType)values[i]);
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = discript });
            }

            return Content(list.ToJson());
        }

        /// <summary>
        /// 实训预约类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTrainingUserType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.TrainingUserType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.TrainingUserType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 实训类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTrainingType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.TrainingType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.TrainingType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        [HttpGet]
        public ActionResult GetYesOrNo()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.YesOrNo));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.YesOrNo));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCashType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.CashType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.CashType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTimeSpaceType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.TimeSpaceType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.TimeSpaceType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        [HttpGet]
        public ActionResult GetTimeType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.TimeType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.TimeType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }

        /// <summary>
        /// 年检类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAuditType()
        {
            string[] names = System.Enum.GetNames(typeof(Trade.Model.Enums.AuditType));
            int[] values = (int[])System.Enum.GetValues(typeof(Trade.Model.Enums.AuditType));
            List<KeyValueEntity> list = new List<KeyValueEntity>();
            for (int i = 0; i < names.Length; i++)
            {
                list.Add(new KeyValueEntity() { ItemId = values[i].ToString(), ItemName = names[i] });
            }
            return Content(list.ToJson());
        }
    }
}
