using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Book.Comment
{
   public class GroupEmptyAttribute: ValidationAttribute
    {
        private readonly string _groupFields;
        private readonly bool _notNullableAll;
        /// <summary>
        ///  构造函数
        /// </summary>
        /// <param name="groupFields">属性名，多个属性名逗号隔开</param>
        /// <param name="notNullableAll"> true全部不允许为空。 false只要存在不为空的属性即可</param>
        public GroupEmptyAttribute(string groupFields, bool notNullableAll)
        {
            _groupFields = groupFields;
            _notNullableAll = notNullableAll;
        }
        /// <summary>
        /// 构造函数,默认至少1个非空
        /// </summary>
        /// <param name="groupFields">属性名，多个属性名逗号隔开</param>
        public GroupEmptyAttribute(string groupFields)
        {
            _groupFields = groupFields;
            _notNullableAll = false;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validateResult = false;
            var obj = validationContext.ObjectInstance;
            Type Ts = obj.GetType();
            var fields = _groupFields.Split(',');
            if (fields.Count() > 0)
            {
                for (var i = 0; i < fields.Count(); i++)
                {
                    var filedName = Convert.ToString(fields[i]);
                    if (string.IsNullOrEmpty(filedName)) continue;
                    //value
                    string filedValue = Convert.ToString(Ts.GetProperty(filedName).GetValue(obj, null));
                    //_notNullableAll=true，任意一个为空直接验证挂掉跳出循环
                    if (_notNullableAll && string.IsNullOrWhiteSpace(filedValue))
                    {
                        validateResult = false;
                        break;
                    }
                    //_notNullableAll=false,只要有一个不为空就可以过验证
                    if (!_notNullableAll && !string.IsNullOrWhiteSpace(filedValue))
                    {
                        validateResult = true;
                        break;
                    }
                }
            }
            //success
            if (validateResult)
                return ValidationResult.Success;
            else
            {
                //fail
                if (string.IsNullOrEmpty(ErrorMessage) && _notNullableAll)
                    return new ValidationResult($"{_groupFields}字段全部不允许为空值");
                else if (string.IsNullOrEmpty(ErrorMessage) && !_notNullableAll)
                    return new ValidationResult($"{_groupFields}字段中至少要有一个不为空的值");
                else
                    return new ValidationResult(ErrorMessage);
            }

        }
    }

    /// <summary>
    /// 组内数据同步判断，同时为空或同时不为空通过验证
    /// </summary>
    public class GroupEmptySyncAttribute : ValidationAttribute
    {
        private readonly string _groupFields;

        public GroupEmptySyncAttribute(string groupFields)
        {
            _groupFields = groupFields;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validateResult = true;
            var obj = validationContext.ObjectInstance;
            Type Ts = obj.GetType();
            var fields = _groupFields.Split(',');
            if (fields.Count() > 0)
            {
                bool firstValueIsEmpty = true;//第一个值是否为空
                for (var i = 0; i < fields.Count(); i++)
                {
                    var filedName = Convert.ToString(fields[i]);
                    if (string.IsNullOrEmpty(filedName)) continue;
                    //value
                    string filedValue = Convert.ToString(Ts.GetProperty(filedName).GetValue(obj, null));
                    //第一个值记录是否为空
                    if (i == 0 && string.IsNullOrWhiteSpace(filedValue))
                        firstValueIsEmpty = true;
                    if (i == 0 && !string.IsNullOrWhiteSpace(filedValue))
                        firstValueIsEmpty = false;

                    //后续值判断是否和第一个值符合，不符合直接结束验证
                    if (i > 0)
                    {
                        if (string.IsNullOrWhiteSpace(filedValue) != firstValueIsEmpty)
                        {
                            validateResult = false;
                            break;
                        }
                    }
                }
            }
            //success
            if (validateResult)
                return ValidationResult.Success;
            else
            {
                //fail
                if (string.IsNullOrEmpty(ErrorMessage))
                    return new ValidationResult($"{_groupFields}字段是否为空不一致（必须同时为空或同时不为空）");
                else
                    return new ValidationResult(ErrorMessage);
            }

        }
    }

    /// <summary>
    /// 判断时间格式是否对应，时间格式一致通过验证
    /// </summary>
    public class DateFormatValidAttribute : ValidationAttribute
    {
        private readonly string _formatStr;
        public DateFormatValidAttribute(string formatStr)
        {
            _formatStr = formatStr;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validateResult = false;
            try
            {
                //转成要求的格式后 再和传入的值对比
                var formatValue = Convert.ToDateTime((string)value).ToString(_formatStr);
                if ((string)value == formatValue)
                    validateResult = true;
                else
                    validateResult = false;

                //success
                if (validateResult)
                    return ValidationResult.Success;
                else
                {
                    //fail
                    if (string.IsNullOrEmpty(ErrorMessage))
                        return new ValidationResult($"时间格式不符合{_formatStr}格式");
                    else
                        return new ValidationResult(ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(ErrorMessage))
                    return new ValidationResult($"时间格式不符合{_formatStr}格式");
                else
                    return new ValidationResult(ErrorMessage);
            }

    }
}
}
