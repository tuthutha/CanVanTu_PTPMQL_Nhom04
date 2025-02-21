namespace DemoMVC.Models
{
    public class GradeModel
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public double Index()
        {
            return C * 0.1 + B * 0.3 + A * 0.6;
        }

        public string GetClassification()
        {
            double finalGrade = Index();
            if (finalGrade >= 8) return "Giỏi";
            else if (finalGrade >= 6.5) return "Khá";
            else if (finalGrade >= 5) return "Trung bình";
            else return "Yếu";
        }
    }
}