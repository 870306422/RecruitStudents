using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MangementBLL
    {
        Model.STURecordsModel modelT = new Model.STURecordsModel();
        DAL.MangeMentDAL dal = new DAL.MangeMentDAL();
        #region 主页面
        public DataTable SelectManage(string where, int PageIndex, int PageSize, string sort, out int countNum)
        {
            return dal.SelectManage(where, PageIndex,PageSize,sort,out countNum);
        }
        public DataTable SelectManageMG(string where)
        {
            return dal.SelectManageMG(where);
        }
        public DataTable SelectManageT(string where, int PageIndex, int PageSize, string sort, out int countNum)
        {
            return dal.SelectManageT(where, PageIndex, PageSize, sort, out countNum);
        }
        public DataTable SelectManagea(string where, int PageIndex, int PageSize, string sort, out int countNum)
        {
            return dal.SelectManagea(where, PageIndex, PageSize, sort, out countNum);
        }
        
        public DataTable SelectManageA(string where,int PageSize, int PageIndex, string sort, out int countNum)
        {
            return dal.SelectManageA(where, PageIndex, PageSize, sort, out countNum);
        }
        #endregion
        public DataTable Comboxly(string where)
        {
            return dal.Comboxly(where);
        }
        public DataTable ComboxKm(string where)
        {
            return dal.ComboxKm(where);
        }
        public DataTable Comboxls(string where)
        {
            return dal.Comboxls(where);
        }
        public DataTable Comboxzy(string where)
        {
            return dal.Comboxzy(where);
        }
        public int DeleteRecords(Model.STURecordsModel model)
        {
            return dal.DeleteRecords(model);
        }
        public int AddData(Model.StudentinfoModel model)
        {
            return dal.AddData(model);
        }
        public int EditOpen(Model.STURecordsModel model)
        {
            return dal.EditOpen(model);
        }
        public int AddRecords(Model.STURecordsModel modelT)
        {
            return dal.AddRecords(modelT);
        }
        public int EditData(Model.StudentinfoModel model)
        {
            return dal.EditData(model);
        }
        public int edit(string where)
        {
            return dal.edit(where);
        }
        public DataTable SelectManage(string where)
        {
            return dal.SelectManage(where);
        }
        public int Delete(string where)
        {
            return dal.Delete(where);
        }
    }
}
