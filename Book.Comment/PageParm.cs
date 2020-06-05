﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Comment
{
    /// <summary>
    /// 自定义排序
    /// </summary>
    public class PageSort
    {
        public int p { get; set; }
        public int i { get; set; }
        public int o { get; set; }
    }

    /// <summary>
    /// 自定义排序
    /// </summary>
    public class ParmStringSort
    {
        public string p { get; set; }
        public string i { get; set; }
        public int o { get; set; }
    }

    /// <summary>
    /// 提供字符串FromBody的解析
    /// </summary>
    public class ParmString
    {
        public string parm { get; set; }
    }

    /// <summary>
    /// 提供字符串FromBody的解析
    /// </summary>
    public class ParmInt
    {
        public int id { get; set; }
    }

    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParm
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; } = 1;

        /// <summary>
        /// 每页总条数
        /// </summary>
        public int limit { get; set; } = 15;

        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; } = 0;

        /// <summary>
        /// 编号
        /// </summary>
        public string guid { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 类型条件
        /// </summary>
        public int types { get; set; } = 0;

        /// <summary>
        /// 审核状态
        /// </summary>
        public int audit { get; set; } = -1;

        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; } = -1;

        /// <summary>
        /// 属性
        /// </summary>
        public int attr { get; set; } = 0;

        /// <summary>
        /// 搜索日期，可能是2个日期，通过-分隔
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 排序方式，可根据数字来判断，
        /// </summary>
        public int orderType { get; set; } = 0;

        /// <summary>
        /// 排序的字段
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// 排序的类型 asc  desc
        /// </summary>
        public string order { get; set; } = "desc";

        /// <summary>
        /// 动态条件
        /// </summary>
        public string where { get; set; }

    }
}
