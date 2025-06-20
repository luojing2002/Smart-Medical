using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore
{
    /// <summary>
    /// 字典表实体类
    /// </summary>
    public class Dictionary : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 类型编码（如 Gender、Department、DrugType）
        /// </summary>
        [Required]
        [StringLength(50)]
        public string TypeCode { get; set; } = string.Empty;

        /// <summary>
        /// 类型名称（如 性别、科室、药品类型）
        /// </summary>
        [Required]
        [StringLength(100)]
        public string TypeName { get; set; } = string.Empty;

        /// <summary>
        /// 键（Key，如 M、F、001）
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// 值（Value，如 男、女、内科）
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        public string? Remark { get; set; } = string.Empty;
    }
}
