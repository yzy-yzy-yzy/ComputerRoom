﻿using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Entity.DataManage;
using Coldairarrow.Entity.Device;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Coldairarrow.Business.DataManage
{
    public class AANodeOnOffBusiness : BaseBusiness<AANodeOnOff>, IAANodeOnOffBusiness, IDependency
    {
        #region 外部接口

        //public List<AANodeOnOff> GetDataList(Pagination pagination, string condition, string keyword)
        //{
        //    var q = GetIQueryable();
        //    var where = LinqHelper.True<AANodeOnOff>();

        //    //筛选
        //    if (!condition.IsNullOrEmpty() && !keyword.IsNullOrEmpty())
        //    {
        //        var newWhere = DynamicExpressionParser.ParseLambda<AANodeOnOff, bool>(
        //            ParsingConfig.Default, false, $@"{condition}.Contains(@0)", keyword);
        //        where = where.And(newWhere);
        //    }

        //    return q.Where(where).GetPagination(pagination).ToList();
        //}

        //public AANodeOnOff GetTheData(string id)
        //{
        //    return GetEntity(id);
        //}
        public List<AANodeOnOffDTO> GetDataList(Pagination pagination, bool all, string userId = null, string ParentId = null, string keyword = null)
        {
            Expression<Func<AANodeOnOff, DeviceInfo, Base_Department, AANodeOnOffDTO>> select = (a, b, c) => new AANodeOnOffDTO
            {
                DepartmentName = c.Name,
                DeviceName = b.DeviceName,
                NodeNumber = b.DeviceNode
            };
            select = select.BuildExtendSelectExpre();
            var q_AANodeOnOff = all ? Service.GetIQueryable<AANodeOnOff>() : GetIQueryable();
            var q = from a in q_AANodeOnOff.AsExpandable()
                    join b in Service.GetIQueryable<DeviceInfo>() on new { nodeNumber = a.nodeNumber, devicetype = "AANodeOnOff" } equals new { nodeNumber = b.DeviceNode, devicetype = b.deviceType } into ab
                    from b in ab.DefaultIfEmpty()
                    join c in Service.GetIQueryable<Base_Department>() on ParentId equals c.Id into ac
                    from c in ac.DefaultIfEmpty()
                    select @select.Invoke(a, b, c);

            var where = LinqHelper.True<AANodeOnOffDTO>();
            //if (!userId.IsNullOrEmpty())
            //    where = where.And(x => x.Id == userId);
            var list = q.Where(where).GetPagination(pagination).ToList();

            return list;
        }

        public AANodeOnOffDTO GetTheData(string id)
        {
            if (id.IsNullOrEmpty())
                return null;
            else
                return GetDataList(new Pagination(), true, id).FirstOrDefault();
        }
        public AjaxResult AddData(AANodeOnOff data)
        {
            Insert(data);

            return Success();
        }

        public AjaxResult UpdateData(AANodeOnOff data)
        {
            Update(data);

            return Success();
        }

        public AjaxResult DeleteData(List<string> ids)
        {
            Delete(ids);

            return Success();
        }

        #endregion

        #region 私有成员

        #endregion

        #region 数据模型

        #endregion
    }
    public class AANodeOnOffDTO : AANodeOnOff
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// 节点号
        /// </summary>
        public string NodeNumber { get; set; }

    }
}