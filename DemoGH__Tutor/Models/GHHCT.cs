using System.ComponentModel.DataAnnotations;

namespace DemoGH__Tutor.Models
{
    public class GHHCT
    {
        
        public Guid Id { get; set; }
        public Guid ProductID { get; set; }  ///khóa ng
        public Guid CartId { get; set; }
        public string UserName {  get; set; }
        public  GioHang GioHang { get; set; }
        public  SanPham SanPham { get; set; }    

    }
}
