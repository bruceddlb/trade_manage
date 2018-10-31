﻿
using QSDMS.Model;
using System.Collections.Generic;

namespace QSDMS.Data.IService
{
    /// <summary>  
    /// 描 述：过滤时段
    /// </summary>
    public interface IFilterTimeService
    {
        #region 获取数据
        /// <summary>
        /// 过滤时段列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <param name="visitType">访问:0-拒绝，1-允许</param>
        /// <returns></returns>
        IEnumerable<FilterTimeEntity> GetList(string objectId, string visitType);
        /// <summary>
        /// 过滤时段列表
        /// </summary>
        /// <param name="objectId">对象Id,用逗号隔开</param>
        /// <returns></returns>
        IEnumerable<FilterTimeEntity> GetList(string objectId);
        /// <summary>
        /// 过滤时段实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        FilterTimeEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除过滤时段
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存过滤时段表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="filterTimeEntity">过滤时段实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, FilterTimeEntity filterTimeEntity);
        #endregion
    }
}
