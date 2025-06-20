

using System.ComponentModel.DataAnnotations;

namespace BookStore.Prescriptions
{
    public class PrescriptionDto
    {
        /// <summary>
        /// 处方名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string PrescriptionName { get; set; }
        /// <summary>
        /// 父级Id
        /// </summary>
        [Required]
        public int ParentId { get; set; }
    }
}
