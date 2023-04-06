using System.ComponentModel.DataAnnotations;

namespace TestInternSiliconStack.Data
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public bool Female { get; set; }
        public int Born { get; set; }
        public int? Died { get; set; }
        public static int getAge(int Born, int? Died)
        {
            return Died == null ? DateTime.Now.Year - Born : Died.Value - Born;
        }

    }
}
