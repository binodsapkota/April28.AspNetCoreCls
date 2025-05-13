using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreChapter.Model
{
    [Table("Students")]
    //by default class name is used as table name
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150),Column("StudentName",TypeName ="varchar")]
        public string Name { get; set; }
        [Range(1,100)]
        public int Age { get; set; }
    }
}
