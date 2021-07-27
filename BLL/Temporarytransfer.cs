using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Temporarytransfer
    {
        DAL.Temporarytransfer dal = new DAL.Temporarytransfer();
        #region 查询转院记录
        
        //public DataTable SelectTemporarytransfer(string where)
        //{
        //    return dal.SelectTemporarytransfer(where);
        //}
        public DataTable SelectTemporarytransfer(Model.PersonnelInformation model)
        {
            return dal.SelectTemporarytransfer(model);
        }

        public DataTable SelectName(string str)
        {
            return dal.SelectName(str);
        }
        #endregion
        #region 确认接收数据
        public int saveconfirm(Model.Temporarytransfer temporarytransfer)
        {
            return dal.saveconfirm(temporarytransfer);
        }
        #endregion
        #region 转院显示咨询数据
        public DataTable TurnZXSJToList(string where, int PageIndex, int PageSize, string sort, out int commun)
        {
            return dal.TurnZXSJToList(where, PageIndex, PageSize, sort, out commun);
        }
        #endregion
        #region 删除缓存数据
        public int savedelete(Model.Temporarytransfer temporarytransfer)
        {
            return dal.savedelete(temporarytransfer);
        }
        #endregion
        //查询条数
        public DataTable Transfer(Model.PersonnelInformation　model)
        {
            return dal.Transfer(model);
        }
    }
}
