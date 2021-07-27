using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PowerInfo
    {
        DAL.PowerInfo dal = new DAL.PowerInfo();
        # region 分页查询UserInfo
        public DataTable SelectUserInfoToList(string where, int pageIndex, int PageSize, string sort, out int countNum)
        {
            return dal.SelectUserInfoToList(where, pageIndex, PageSize, sort, out countNum);
        }
        #endregion
        #region 分页查询PowerInfo
        public DataTable SelectPowerInfoToList(string where, int pageIndex, int PageSize, string sort, out int countNum)
        {
            return dal.SelectPowerInfoToList(where, pageIndex, PageSize, sort, out countNum);
        }
        #endregion
        #region 删除
        public int DeletePower(Model.PowerInfo model)
        {
            return dal.DeletePower(model);
        }
        #endregion
        #region 增加
        public int InsertPower(Model.PowerInfo model)
        {
            return dal.InsertPower(model);
        }
        #endregion
        #region 修改
        public int UpdatePower(Model.PowerInfo model)
        {
            return dal.UpdatePower(model);
        }
        #endregion
    }
}
