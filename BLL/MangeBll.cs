using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MangeBll
    {
        DAL.MangeDal dal = new DAL.MangeDal();
        public DataTable MangeSelect(string where)
        {
            return dal.MangeSelect(where);
        }
         public DataTable DropSelect(string where)
        {
            return dal.DropSelect(where);
        }
        public DataTable DropSelectT(string where)
        {
            return dal.DropSelectT(where);
        }
        public DataTable AddHead(string where)
        {
            return dal.AddHead(where);
        }
        public DataTable AddHeadT(string where)
        {
            return dal.AddHeadT(where);
        }
        public int Add(string where)
        {
            return dal.Add(where);
        }
        public int AddT(string where)
        {
            return dal.AddT(where);
        }
        public int EditHeaderT(Model.Academy academy)
        {
            return dal.EditHeaderT(academy);
        }
        public int EditHeader(Model.Academy academy)
        {
            return dal.EditHeader(academy);
        }

        /// <summary>
        /// 根据id查负责人姓名
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable SelName(string where)
        {
            return dal.SelName(where);
        }

        /// <summary>
        /// 有父级是添加二级专业负责人
        /// </summary>
        /// <param name="academy"></param>
        /// <returns></returns>
        public int AddTwoAca(Model.Academy academy)
        {
            return dal.AddTwoAca(academy);
        }

        /// <summary>
        /// 没有父级是添加学院二级专业负责人
        /// </summary>
        /// <param name="academy"></param>
        /// <returns></returns>
        public int AddAcademy(Model.Academy academy)
        {
            return dal.AddAcademy(academy);
        }


        /// <summary>
        /// 根据姓名查id
        /// </summary>
        /// <param name="academy"></param>
        /// <returns></returns>
        public DataTable SelId(Model.Academy academy)
        {
            return dal.SelId(academy);
        }


        /// <summary>
        /// 没有父级是二级专业负责人
        /// </summary>
        /// <param name="academy"></param>
        /// <returns></returns>
        public int AddAca(Model.Academy academy)
        {
            return dal.AddAca(academy);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Del(string where)
        {
            return dal.Del(where);
        }
    }
}
