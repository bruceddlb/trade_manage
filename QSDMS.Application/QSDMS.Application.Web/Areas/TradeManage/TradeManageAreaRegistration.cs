using System.Web.Mvc;

namespace QSDMS.Application.Web.Areas.TradeManage
{
    public class TradeManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TradeManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TradeManage_default",
                "TradeManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
