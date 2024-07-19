namespace DemoGH__Tutor.Models
{
    public class SanPham
    {
        public Guid SanPhamId { get; set; }
        public string SanPhamName { get; set; }
        public string Price {  get; set; }
        public virtual List<GHHCT> GHHCT {  get; set; }
    }
}
