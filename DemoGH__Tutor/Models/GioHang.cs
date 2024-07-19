namespace DemoGH__Tutor.Models
{
    public class GioHang
    {
        public Guid Id { get; set; }   
        public string UserName {  get; set; }
        public int Status {  get; set; }
        public virtual User User { get; set; }
        public Guid UserID { get; set; }
        public virtual List<GHHCT> GHHCT { get; set; }

    }
}
