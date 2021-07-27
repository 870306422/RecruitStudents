using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonnelInformation
    {
        DAL.PersonnelInformation dal = new DAL.PersonnelInformation();
        public DataTable selectPersonnelInformationToList(string where, int PageIndex , int PageSize, string sort, out int common)
        {
            return dal.selectPersonnelInformationToList(where, PageSize, PageIndex, sort, out common);
        }
        #region
        public int Userinsert(Model.PersonnelInformation where)
        {
            return dal.Userinsert(where);
        }
        public int UserEdit(Model.PersonnelInformation where)
        {
            return dal.UserEdit(where);
        }
        public DataTable SelectHead(string where)
        {
            return dal.SelectHead(where);
        }
        #endregion
        #region 人员登录
        public DataTable DL(string where)
        {
            return dal.DL(where);
        }
        #endregion
        #region 删除人员
        public int DeletePI(Model.PersonnelInformation personnelInformation)
        {
            return dal.DeletePI(personnelInformation);
        }
        #endregion
        #region 添加PI(
        public int InsertPI(Model.PersonnelInformation personnelInformation)
        {
            return dal.InsertPI(personnelInformation);
        }
        #endregion
        #region 修改PIPwd(
        public int EditPIPwd(Model.PersonnelInformation personnelInformation)
        {
            return dal.EditPIPwd(personnelInformation);
        }
        #endregion
    }
}
