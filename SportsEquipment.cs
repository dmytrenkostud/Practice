namespace Practice;


public class SportsEquipment
{
    public SportType SportType { get; set; }
    public float Weight { get; set; }
    public bool ProGrade { get; set; }

    
    public SportsEquipment(){}
    public SportsEquipment(SportType sport, float Weight, bool ProGrade)
    {
        this.SportType = sport;
        this.Weight = Weight;
        this.ProGrade = ProGrade;
    }

    public string String()
    {
        return $"Sport type: {SportType.ToString()}, " +
               $"Weight: {Weight.ToString()}, " +
               $"Professional Grade: {ProGrade.ToString()}.";
    }
}